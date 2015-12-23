using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reactive;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using ProviderFactory.Speech;
using ProviderFactory.Speech.RxToProjectOxford;
using SpotifySearch.Models;

namespace SpotifySearch.Controllers
{
    using ProviderFactory;

    public class HomeController : AsyncController
    {
        public ActionResult Index()
        {
            var model = TempData["model"] as RecoModel;
            TempData["model"] = model;

            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> StartReco()
        {
            var speechRecognition =
                ProviderFactory.Create(new SpeechRecognitionConfig(
                    WebConfigurationManager.AppSettings["luisAppId"],
                    WebConfigurationManager.AppSettings["luisSubscriptionId"],
                    WebConfigurationManager.AppSettings["oxfordSpeechSubscriptionId"]));

            IRecognizedPhrase result = null;
            var tcs = new TaskCompletionSource<IRecognizedPhrase>();

            var ct = new CancellationTokenSource(20000);
            ct.Token.Register(() => tcs.TrySetCanceled());

            var obsvr = Observer.Create<IEnumerable<IRecognizedPhrase>>(
                phrases =>
                {
                    var firstPhrase = phrases.First();

                    if (firstPhrase.Kind == RecognizedPhraseKind.Success)
                    {
                        result = firstPhrase;
                    }
                },
                ex =>
                {
                    Console.Error.WriteLine(ex);
                    speechRecognition.Stop();
                    tcs.SetException(ex);
                },
                () =>
                {
                    tcs.SetResult(result);
                    speechRecognition.Stop();
                });

            speechRecognition.Start(obsvr);

            var response = await tcs.Task;

            var model = new RecoModel
            {
                Intent =
                {
                    Query = response.Intent.Query,
                    Entities = response.Intent.Entities,
                    Intents = response.Intent.Intents,
                }
            };

            var song = model.Intent.Entities.FirstOrDefault(x => x.Type == "song");
            var artist =
                model.Intent.Entities.FirstOrDefault(x => x.Type == "builtin.encyclopedia.people.person" || x.Type == "artist");

            if (song != null)
            {
                model.Song = song.Entity;
            }

            if (artist != null)
            {
                model.Artist = artist.Entity;
            }

            TempData["model"] = model;

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> PlaySpotify()
        {
            var model = TempData["model"] as RecoModel;

            var client = new HttpClient();
            Task<string> spotifySearch =
                client.GetStringAsync(string.Format("https://api.spotify.com/v1/search?q=track:{0}%20artist:{1}&type=track", Uri.EscapeDataString(model.Song), Uri.EscapeDataString(model.Artist)));

            var result = await spotifySearch;
            dynamic json = JsonConvert.DeserializeObject(result);

            model.SpotifyLink = json.tracks.items[0].preview_url;
            TempData["model"] = model;
            return RedirectToAction("Index");
        }

    }
}

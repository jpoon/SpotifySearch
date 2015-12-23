using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ProviderFactory.Speech.RxToProjectOxford;

namespace SpotifySearch.Models
{
    public class RecoModel 
    {
        public RecognizedPhraseIntent Intent { get; set; }

        public string Song { get; set; }

        public string Artist { get; set; }

        public string SpotifyLink { get; set; }

        public RecoModel()
        {
            Intent = new RecognizedPhraseIntent();
        }
    }
}

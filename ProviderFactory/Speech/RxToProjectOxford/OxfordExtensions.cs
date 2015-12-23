//
// Copyright Microsoft Corporation.  All rights reserved.
// ericroz - Sept 2015
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using Microsoft.ProjectOxford.SpeechRecognition;
using Newtonsoft.Json;
using ProviderFactory.Speech.RxToProjectOxford.Exceptions;
using ProviderFactory.Speech.RxToProjectOxford.Internal;

namespace ProviderFactory.Speech.RxToProjectOxford
{
    /// <summary>
    /// Reactive extensions for Project Oxford.
    /// </summary>
    public static class OxfordReactiveExtensions
    {
        /// <summary>
        /// Gets the response observable for the speech recognition client.
        /// </summary>
        /// <param name="client">The speech recognition client.</param>
        /// <returns>
        /// A response observable, which is a sequence of observables
        /// containing partial results, terminated by a final success and a
        /// completion event or an error event.
        /// </returns>
        public static IObservable<IObservable<IEnumerable<IRecognizedPhrase>>> GetResponseObservable(this MicrophoneRecognitionClient client)
        {
            var errorObservable = Observable.FromEventPattern<SpeechErrorEventArgs>(
                    h => client.OnConversationError += h,
                    h => client.OnConversationError -= h)
                .Select<EventPattern<SpeechErrorEventArgs>, IEnumerable<IRecognizedPhrase>>(
                    x => { throw new SpeechRecognitionException(x.EventArgs.SpeechErrorCode, x.EventArgs.SpeechErrorText); });

            var partialObservable = Observable.FromEventPattern<PartialSpeechResponseEventArgs>(
                    h => client.OnPartialResponseReceived += h,
                    h => client.OnPartialResponseReceived -= h)
                .Select(x => Enumerable.Repeat(RecognizedPhraseImpl.CreatePartial(x.EventArgs.PartialResult), 1));

            var intentObservable = Observable.FromEventPattern<SpeechIntentEventArgs>(
                h => client.OnIntent += h,
                h => client.OnIntent -= h)
                .Select(x => x.EventArgs);

            var responseObservable = Observable.FromEventPattern<SpeechResponseEventArgs>(
                h => client.OnResponseReceived += h,
                h => client.OnResponseReceived -= h)
                .Select(x =>
                {
                    var response = x.EventArgs.PhraseResponse;
                    switch (response.RecognitionStatus)
                    {
                        case RecognitionStatus.Intermediate:
                            return response.Results.Select(RecognizedPhraseImpl.CreateIntermediate);
                        case RecognitionStatus.RecognitionSuccess:
                        case RecognitionStatus.EndOfDictation:
                            return response.Results.Select(RecognizedPhraseImpl.CreateSuccess);
                        case RecognitionStatus.InitialSilenceTimeout:
                            throw new InitialSilenceTimeoutException();
                        case RecognitionStatus.BabbleTimeout:
                            throw new BabbleTimeoutException();
                        case RecognitionStatus.DictationEndSilenceTimeout:
                            throw new DictationEndTimeoutException();
                        case RecognitionStatus.Cancelled:
                        case RecognitionStatus.HotWordMaximumTime:
                        case RecognitionStatus.NoMatch:
                        case RecognitionStatus.None:
                        case RecognitionStatus.RecognitionError:
                        default:
                            throw new SpeechRecognitionException();
                    }
                })
                .CombineLatest(intentObservable, (response, intent) =>
                {
                    var lastResponse = response.Last();
                    var recognizedPhraseIntent = JsonConvert.DeserializeObject<RecognizedPhraseIntent>(intent.Payload);
                    lastResponse.Intent = recognizedPhraseIntent;
                    return Enumerable.Repeat(lastResponse, 1);
                });

            return responseObservable.Publish(observable =>
                    Observable.Merge(errorObservable, partialObservable, observable)
                        .Window(() => observable));
        }

    }
}

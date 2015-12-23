//
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license.
//
// MIT License:
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
//
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED ""AS IS"", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

using System;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Microsoft.ProjectOxford.SpeechRecognition;
using ProviderFactory.Speech.RxToProjectOxford;

namespace ProviderFactory.Speech
{
    public class SpeechRecognition : IDisposable, ISpeechRecognition
    {
        private const string RecoLanguage = "en-us";
        private readonly MicrophoneRecognitionClient _client;

        internal SpeechRecognition(SpeechRecognitionConfig recognitionConfig)
        {
            if (recognitionConfig == null)
            {
                throw new ArgumentNullException(nameof(recognitionConfig));
            }

            _client = SpeechRecognitionServiceFactory.CreateMicrophoneClientWithIntent(
                RecoLanguage,
                recognitionConfig.OxfordSpeechSubscriptionId,
                recognitionConfig.LuisAppId,
                recognitionConfig.LuisSubscriptionId);
        }

        public IDisposable Start(IObserver<IEnumerable<IRecognizedPhrase>> observer)
        {
            _client.StartMicAndRecognition();

            var disposable = new CompositeDisposable();
            var sentenceSubscription = _client.GetResponseObservable()
                .Select((observable, count) => new {observable, count})
                .Subscribe(
                    x => disposable.Add(x.observable.Subscribe(observer)));

            disposable.Add(sentenceSubscription);

            return disposable;
        }

        public void Stop()
        {
            _client.EndMicAndRecognition();
        }

        public void Dispose()
        {
            _client.EndMicAndRecognition();
            _client.Dispose();
        }
    }
}

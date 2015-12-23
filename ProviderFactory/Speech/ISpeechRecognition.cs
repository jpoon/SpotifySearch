using System;
using System.Collections.Generic;
using ProviderFactory.Speech.RxToProjectOxford;

namespace ProviderFactory.Speech
{
    public interface ISpeechRecognition
    {
        void Dispose();
        IDisposable Start(IObserver<IEnumerable<IRecognizedPhrase>> observer);
        void Stop();
    }
}
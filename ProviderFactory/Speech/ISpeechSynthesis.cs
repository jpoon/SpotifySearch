namespace ProviderFactory.Speech
{
    using System.Collections.Generic;
    public interface ISpeechSynthesis
    {
        IEnumerable<string> InstalledVoices { get; }

        void Say(string text, string voice = null);

        void Dispose();
    }
}
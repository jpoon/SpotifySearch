namespace ProviderFactory.Speech
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Speech.Synthesis;

    public class SpeechSynthesis : IDisposable, ISpeechSynthesis
    {
        private readonly SpeechSynthesizer _speechSynthesizer;
        private readonly SpeechSynthesisConfig _config;

        public IEnumerable<string> InstalledVoices => _speechSynthesizer.GetInstalledVoices(CultureInfo.CurrentCulture).Where(v => v.Enabled).Select(v => v.VoiceInfo.Name);

        internal SpeechSynthesis(SpeechSynthesisConfig config)
        {
            this._config = config;

            _speechSynthesizer = new SpeechSynthesizer();
            _speechSynthesizer.SetOutputToDefaultAudioDevice();
        }

        public void Say(string text, string voice = null)
        {
            if (!String.IsNullOrEmpty(voice))
            {
                if (InstalledVoices.Any(v => v == voice))
                {
                    _speechSynthesizer.SelectVoice(voice);
                }
            }

            _speechSynthesizer.Speak(text);
        }

        public void Dispose()
        {
            _speechSynthesizer.Dispose();
        }
    }
}

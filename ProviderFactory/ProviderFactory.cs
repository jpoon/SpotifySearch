using ProviderFactory.Speech;

namespace ProviderFactory
{
    public static class ProviderFactory
    {
        public static SpeechRecognition Create(SpeechRecognitionConfig config)
        {
            return new SpeechRecognition(config);
        }

        public static ISpeechSynthesis Create(SpeechSynthesisConfig config)
        {
            return new SpeechSynthesis(config);
        }
    }
}

namespace ProviderFactory.Speech
{
    using System;

    public class SpeechRecognitionConfig
    {
        public string LuisAppId { get; internal set; }

        public string LuisSubscriptionId { get; internal set; }

        public string OxfordSpeechSubscriptionId { get; internal set; }


        public SpeechRecognitionConfig(string luisAppId, string luisSubscriptionId, string oxfordSpeechSubscriptionId)
        {
            if (String.IsNullOrEmpty(luisAppId))
            {
                throw new ArgumentNullException(nameof(luisAppId));
            }

            if (String.IsNullOrEmpty(luisSubscriptionId))
            {
                throw new ArgumentNullException(nameof(luisSubscriptionId));
            }

            if (String.IsNullOrEmpty(oxfordSpeechSubscriptionId))
            {
                throw new ArgumentNullException(nameof(oxfordSpeechSubscriptionId));
            }

            LuisAppId = luisAppId;
            LuisSubscriptionId = luisSubscriptionId;
            OxfordSpeechSubscriptionId = oxfordSpeechSubscriptionId;
        }
    }
}

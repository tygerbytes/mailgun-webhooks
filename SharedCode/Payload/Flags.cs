using Newtonsoft.Json;

namespace MailgunWebhooks.Payload
{
    public class Flags
    {
        [JsonProperty(PropertyName = "is-routed")]
        public bool IsRouted { get; set; }

        [JsonProperty(PropertyName = "is-authenticated")]
        public bool IsAuthenticated { get; set; }

        [JsonProperty(PropertyName = "is-system-test")]
        public bool IsSystemTest { get; set; }

        [JsonProperty(PropertyName = "is-test-mode")]
        public bool IsTestMode { get; set; }
    }
}
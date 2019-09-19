using Newtonsoft.Json;

namespace MailGunWebhooks
{
    public class PayloadFlags
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
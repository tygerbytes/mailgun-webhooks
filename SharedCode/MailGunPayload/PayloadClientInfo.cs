using Newtonsoft.Json;

namespace MailGunWebhooks
{
    public class PayloadClientInfo
    {
        [JsonProperty(PropertyName = "client-name")]
        public string ClientName { get; set; }

        [JsonProperty(PropertyName = "client-os")]
        public string ClientOS { get; set; }
        
        [JsonProperty(PropertyName = "user-agent")]
        public string UserAgent { get; set; }

        [JsonProperty(PropertyName = "device-type")]
        public string DeviceType { get; set; }
    }
}
using Newtonsoft.Json;

namespace MailgunWebhooks.Payload
{
    public class ClientInfo
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
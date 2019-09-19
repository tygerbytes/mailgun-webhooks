using Newtonsoft.Json;

namespace MailGunWebhooks
{
    public class PayloadMessageHeaders
    {
        [JsonProperty(PropertyName = "message-id")]
        public string MessageId { get; set; }

        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
    }
}
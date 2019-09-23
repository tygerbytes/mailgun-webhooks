using Newtonsoft.Json;

namespace MailgunWebhooks.Payload
{
    public class MessageHeaders
    {
        [JsonProperty(PropertyName = "message-id")]
        public string MessageId { get; set; }

        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
    }
}
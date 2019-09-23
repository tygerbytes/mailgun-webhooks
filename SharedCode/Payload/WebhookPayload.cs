using Newtonsoft.Json;

namespace MailgunWebhooks.Payload
{
    public class WebhookPayload
    {
        public HmacSignature Signature { get; set; }

        [JsonProperty(PropertyName = "event-data")]
        public EventData EventData { get; set; }
    }
}
using Newtonsoft.Json;

namespace MailGunWebhooks
{
    public class MailGunWebookPayload
    {
        public PayloadSignature Signature { get; set; }

        [JsonProperty(PropertyName = "event-data")]
        public PayloadEventData EventData { get; set; }
    }
}
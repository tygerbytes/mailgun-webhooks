using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MailGunWebhooks
{
    public class PayloadEventData
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public MailGunEvent Event { get; set; }
        public string TimeStamp { get; set; }
        public string Id { get; set; }
        public string Severity { get; set; }
        public string Reason { get; set; }
        public PayloadFlags Flags { get; set; }
        public PayloadGeolocation GeoLocation { get; set; }

        [JsonProperty(PropertyName = "ip")]
        public string IpAddress { get; set; }

        public string Recipient { get; set; }

        [JsonProperty(PropertyName = "recipient-domain")]
        public string RecipientDomain { get; set; }
        public PayloadEnvelope Envelope { get; set; }

        [JsonProperty(PropertyName = "log-level")]
        public string LogLevel { get; set; }

        [JsonProperty(PropertyName = "client-info")]
        public PayloadClientInfo ClientInfo { get; set; }

        public PayloadMessage Message { get; set; }

        [JsonProperty(PropertyName = "delivery-status")]
        public PayloadDeliveryStatus DeliveryStatus { get; set; }
    }
}
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MailgunWebhooks.Payload
{
    public class EventData
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public MailGunEvent Event { get; set; }
        public string TimeStamp { get; set; }
        public string Id { get; set; }
        public string Severity { get; set; }
        public string Reason { get; set; }
        public Flags Flags { get; set; }
        public Geolocation GeoLocation { get; set; }

        [JsonProperty(PropertyName = "ip")]
        public string IpAddress { get; set; }

        public string Recipient { get; set; }

        [JsonProperty(PropertyName = "recipient-domain")]
        public string RecipientDomain { get; set; }
        public Envelope Envelope { get; set; }

        [JsonProperty(PropertyName = "log-level")]
        public string LogLevel { get; set; }

        [JsonProperty(PropertyName = "client-info")]
        public ClientInfo ClientInfo { get; set; }

        public Message Message { get; set; }

        [JsonProperty(PropertyName = "delivery-status")]
        public DeliveryStatus DeliveryStatus { get; set; }
    }
}
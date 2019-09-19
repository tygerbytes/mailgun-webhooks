using Newtonsoft.Json;

namespace MailGunWebhooks
{
    public class PayloadEnvelope
    {
        [JsonProperty(PropertyName = "sending-ip")]
        public string SendingIp { get; set; }
        public string Sender { get; set; }
        public string Transport { get; set; }
        public string Targets { get; set; }
    }
}
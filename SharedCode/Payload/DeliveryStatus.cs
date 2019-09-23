using Newtonsoft.Json;

namespace MailgunWebhooks.Payload
{
    public class DeliveryStatus
    {
        public bool Tls { get; set; }
        
        [JsonProperty(PropertyName = "mx-host")]
        public string MxHost { get; set; }

        [JsonProperty(PropertyName = "attempt-no")]
        public int AttemptNumber { get; set; }

        public string SignatureDescription { get; set; }

        [JsonProperty(PropertyName = "session-seconds")]
        public decimal SessionSeconds { get; set; }

        public bool Utf8 { get; set; }

        public int Code { get; set; }

        public string Message { get; set; }

        public bool CertificateVerified { get; set; }
    }
}
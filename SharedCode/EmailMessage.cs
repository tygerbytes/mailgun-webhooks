using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MailGunWebhooks
{
    public class EmailMessage
    {
        public string From { get; set; }

        public string To { get; set; }

        public string Subject { get; set; }

        public string Message { get; set; }

        public string ContentType { get; set; }
    }
}
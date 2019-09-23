using SendGrid.Helpers.Mail;

namespace MailgunWebhooks
{
    public class EmailMessage
    {
        public EmailAddress From { get; set; }

        public EmailAddress To { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }
    }
}
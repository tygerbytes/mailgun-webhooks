using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MailgunWebhooks
{
    public class FuncConfig
    {
        private readonly static Lazy<FuncConfig> _config
            = new Lazy<FuncConfig>(() => new FuncConfig
            {
                MailgunWebhookSigningKey = Environment.GetEnvironmentVariable("mailgun-webhook-signing-key"),
                AlertEmailAddresses = SplitEmailAddresses(Environment.GetEnvironmentVariable("alert-email-addresses")),
                FromEmailAddress = SplitEmailAddresses(Environment.GetEnvironmentVariable("from-email-address")).Single()
            });

        public static FuncConfig Instance => _config.Value;

        internal string MailgunWebhookSigningKey { get; private set; }

        public IEnumerable<EmailAddress> AlertEmailAddresses { get; private set; }

        public EmailAddress FromEmailAddress { get; private set; }

        private static IEnumerable<EmailAddress> SplitEmailAddresses(string emailAddresses)
        {
            return emailAddresses
                .Trim(';')
                .Split(';')
                .Select(x => new EmailAddress(x));
        }
    }
}

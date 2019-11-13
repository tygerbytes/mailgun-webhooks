using System;
using System.Text.RegularExpressions;
using MailgunWebhooks.Payload;

namespace MailgunWebhooks
{
    public class SpamFilter
    {
        private static SpamFilter _filter;

        internal static SpamFilter GetInstance()
        {
            if (_filter == null)
            {
                _filter = new SpamFilter();
            }

            return _filter;
        }

        internal bool IsSpam(WebhookPayload payload)
        {
            // Example
            var subject = payload.EventData.Message.Headers.Subject;
            if (payload.EventData.Flags.IsAuthenticated == false
                && Regex.IsMatch(subject, @"suspended"))
            {
                return true;
            }

            return false;
        }
    }
}
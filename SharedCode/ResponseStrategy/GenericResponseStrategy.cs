using System.Threading.Tasks;
using MailgunWebhooks.Payload;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MailgunWebhooks.ResponseStrategy
{
    public class GenericResponseStrategy : IResponseStrategy
    {
        public async Task<ObjectResult> Execute(FuncContext context, WebhookPayload payload)
        {
            await EnqueueAlertEmails(context, payload);

            return new OkObjectResult($"Whew, thanks for the FYI 😊!");
        }

        private static async Task EnqueueAlertEmails(FuncContext context, WebhookPayload payload)
        {
            var e = payload.EventData.Event;
            var subject = $"{e.ToEmoji()} Mailgun Alert ({e})";
            var bodyJson = Utils.ToJson(payload.EventData);

            if (context.SpamFilter.IsSpam(payload))
            {
                context.Logger.LogInformation("Spam filter tripped.");
                return;
            }

            foreach (var email in context.Config.AlertEmailAddresses)
            {
                var msg = new EmailMessage
                {
                    From = context.Config.FromEmailAddress,
                    To = email,
                    Subject = subject,
                    Body = bodyJson
                };

                await context.EmailQueue.AddAsync(msg);
            }
        }
    }
}
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MailgunWebhooks.Payload;
using SendGrid.Helpers.Mail;

namespace MailgunWebhooks
{
    public static class HandlePermanentFailure
    {
        [FunctionName("HandlePermanentFailure")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "tygerbytes/mailgun/epicpermfail")] HttpRequest req,
            [Queue("email-outbox")]IAsyncCollector<EmailMessage> emailQueue,
            ILogger log)
        {
            var config = FuncConfig.Instance;

            // Deserialize request
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var payload = JsonConvert.DeserializeObject<WebhookPayload>(requestBody);
            log.LogInformation(Utils.ToJson(payload));

            // Verify signature
            if (!payload.Signature.IsValid(config.MailgunWebhookSigningKey))
            {
                return new ObjectResult("Invalid signature")
                {
                    // Mailgun will keep retrying unless we send a 406
                    StatusCode = 406
                };
            }

            // Add emails to the outbox
            foreach (var email in config.AlertEmailAddresses)
            {
                var emailTemplate = BuildFailureAlertEmail(config, email, payload.EventData);
                await emailQueue.AddAsync(emailTemplate);
            }

            return new OkObjectResult($"Whew, thanks for the FYI 😊!");
        }

        private static EmailMessage BuildFailureAlertEmail(FuncConfig config, EmailAddress toEmailAddress, EventData eventData)
        {
            return new EmailMessage
            {
                From = config.FromEmailAddress,
                To = toEmailAddress,
                Subject = "❌Mailgun failure alert",
                Body = Utils.ToJson(eventData)
            };
        }
    }
}

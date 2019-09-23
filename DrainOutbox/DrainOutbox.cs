using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using SendGrid.Helpers.Mail;

namespace MailgunWebhooks.DrainOutbox
{
    public static class DrainOutbox
    {
        [FunctionName("DrainOutbox")]
        public static async Task Run(
            [QueueTrigger("email-outbox", Connection = "AzureWebJobsStorage")]EmailMessage queuedEmail,
            [SendGrid( ApiKey = "sendgrid-api-key")] IAsyncCollector<SendGridMessage> message,
            ILogger log)
        {
            var config = FuncConfig.GetInstance();

            log.LogInformation($"Processing email message from work queue: {Utils.ToJson(queuedEmail)}");

            var msg = BuildMessage(config, queuedEmail);

            await message.AddAsync(msg);
        }

        public static SendGridMessage BuildMessage(FuncConfig config, EmailMessage email)
        {
            return MailHelper.CreateSingleEmail(
                    from: config.FromEmailAddress,
                    to: email.To,
                    subject: email.Subject,
                    plainTextContent: email.Body,
                    htmlContent: null);
        }
    }
}

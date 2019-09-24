using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MailgunWebhooks.Payload;
using MailgunWebhooks.ResponseStrategy;

namespace MailgunWebhooks
{
    public static class HandleWebhook
    {
        [FunctionName("HandleWebhook")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "tygerbytes/mailgun/webhook")] HttpRequest req,
            [Queue("email-outbox")]IAsyncCollector<EmailMessage> emailQueue,
            ILogger log)
        {
            var config = FuncConfig.Instance;
            var context = new FuncContext
            {
                Config = config,
                EmailQueue = emailQueue,
                Logger = log
            };

            var payload = await DeserializeRequestPayload(req);
            log.LogInformation(Utils.ToJson(payload));

            if (!payload.Signature.IsValid(config.MailgunWebhookSigningKey))
            {
                return new ObjectResult("Invalid signature")
                {
                    // Mailgun will keep retrying unless we send a 406
                    StatusCode = 406
                };
            }

            var responseStrategy = ResponseStrategyFactory.GetStrategy(payload.EventData.Event);
            var result = await responseStrategy.Execute(context, payload);
            return result;
        }

        private static async Task<WebhookPayload> DeserializeRequestPayload(HttpRequest req)
        {
            using (var bodyStream = new StreamReader(req.Body))
            {
                var requestBody = await bodyStream.ReadToEndAsync();
                var payload = JsonConvert.DeserializeObject<WebhookPayload>(requestBody);
                return payload;
            }
        }
    }
}

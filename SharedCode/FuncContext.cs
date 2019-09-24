using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace MailgunWebhooks
{
    public class FuncContext
    {
        public FuncConfig Config { get; set; }
        public IAsyncCollector<EmailMessage> EmailQueue { get; set; }
        public ILogger Logger { get; set; }
    }
}
using System.Threading.Tasks;
using MailgunWebhooks.Payload;
using Microsoft.AspNetCore.Mvc;

namespace MailgunWebhooks.ResponseStrategy
{
    public interface IResponseStrategy
    {
        Task<ObjectResult> Execute(FuncContext context, WebhookPayload payload);
    }
}
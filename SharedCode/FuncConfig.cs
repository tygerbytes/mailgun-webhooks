using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MailGunWebhooks
{
    class FuncConfig
    {
        private IConfigurationRoot config;

        internal string MailgunWebhookSigningKey { get; private set; }
        public string FromEmailAddress { get; private set; }

        public IEnumerable<string> AlertEmailAddresses;

        public async Task<FuncConfig> InitAsync(ExecutionContext context)
        {
            this.config = new ConfigurationBuilder()
                .SetBasePath(context.FunctionAppDirectory)
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            this.FromEmailAddress = this.config["FROM_EMAIL_ADDRESS"].Trim(';');
            this.AlertEmailAddresses = (this.config["ALERT_EMAIL_ADDRESSES"]).Trim(';').Split(';');

            this.MailgunWebhookSigningKey =
                this.config["MAILGUN_WEBHOOK_SIGNING_KEY"]
                ?? await GetVaultSecretAsync("mailgun-webhook-signing-key");

            return this;
        }

        private async Task<string> GetVaultSecretAsync(string secret)
        {
            var serviceTokenProvider = new AzureServiceTokenProvider();
            var keyVaultClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(serviceTokenProvider.KeyVaultTokenCallback));

            var secretUri = SecretUri(secret);
            var secretBundle = await keyVaultClient.GetSecretAsync(secretUri);

            return secretBundle?.Value;
        }

        private string SecretUri(string secret)
        {
            return $"{this.config["KEY_VAULT_URI"]}/secrets/{secret}";
        }
    }
}

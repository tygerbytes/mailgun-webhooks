# MailGun Webhook email alerts with Azure Functions

Use an Azure function to intercept your MailGun webhooks.

## Overview

* `HandleWebhook` receives any webhook from MailGun, then invokes the appropriate response strategy based on the `MailGunEvent` type. For example, it might adds an outgoing alert email message to the 'email-outbox' storage queue.
* `DrainOutbox` processes the 'email-outbox' queue, sending queued emails via the SendGrid API.

## MailGun POCOs!

The request body payload is deserialized to C# classes to make working with the data easier and more type-safe.

## Why SendGrid for the email alerts?

1. If MailGun is having issues, it might make sense to send the alerts via another channel
2. SendGrid is easier to work with in Azure. There's a nuget package and everything. :)

## Getting Started

1. Clone the repo. :)
2. Create `local.settings.json` in the root of the repo and set it up like this:

```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet",
    "alert-email-addresses": "{ This email addresses to alert, separated by semicolons ';' }",
    "from-email-address": "{ Your email address }",    
    "mailgun-webhook-signing-key": "{ Get this from https://app.mailgun.com/app/account/security/api_keys }",
    "sendgrid-api-key": "{ Your API key for SendGrid }"
  }
}
```

3. Run the project in Visual Studio (*not Visual Studio Code if you want the full development experience*)
4. Run ngrok and point it against your visual studio dev server
5. Head over to the mailgun webhooks page for your site, for example https://app.mailgun.com/app/sending/domains/example.com/webhooks. From there you can paste in your URL and see what happens. As coded, the URL might look something like https://deadbeef.ngrok.io/api/tygerbytes/mailgun/webhook.
6. Create new implementations of `IResponseStrategy` to customize all the response things.

Have fun. 😊

# MailGun Webhooks with Azure Functions

Use an azure function to intercept your MailGun webhooks.

As an example, the `HandlePermanentFailure` function creates email messages and adds them to an Azure Job Storage queue. You could create another AzureFunction to process this queue to actually send out the alert emails.

The request body payload is deserialized to POCOs to make working with the data easier and more type-safe.

## Getting Started

1. Clone the repo. :)
2. Create `local.settings.json` in the root of the repo and set it up like this:

```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "ALERT_EMAIL_ADDRESSES": "{ This email addresses to alert, separated by semicolons ';' }",
    "FROM_EMAIL_ADDRESS": "{ Your email address }",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet",
    "MAILGUN_WEBHOOK_SIGNING_KEY": "{ Get this from https://app.mailgun.com/app/account/security/api_keys }"
  }
}
```

3. Run the project in Visual Studio (*not Visual Studio Code if you want the full development experience*)
4. Run ngrok and point it against your visual studio dev server
5. Head over to the mailgun webhooks page for your site, for example https://app.mailgun.com/app/sending/domains/example.com/webhooks. From there you can paste in your URL and see what happens. As coded, the URL might look something like https://deadbeef.ngrok.io/api/tygerbytes/mailgun/epicpermfail.

Have fun. 😊

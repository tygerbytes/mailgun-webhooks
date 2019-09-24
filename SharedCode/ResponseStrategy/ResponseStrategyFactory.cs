namespace MailgunWebhooks.ResponseStrategy
{
    public static class ResponseStrategyFactory
    {
        public static IResponseStrategy GetStrategy(MailGunEvent mailGunEvent)
        {
            switch (mailGunEvent)
            {
                case MailGunEvent.Failed:
                case MailGunEvent.Clicked:
                case MailGunEvent.Complained:
                case MailGunEvent.Delivered:
                case MailGunEvent.Opened:
                case MailGunEvent.Unsubscribed:
                default:
                    return new GenericResponseStrategy();
            }
        }
    }
}
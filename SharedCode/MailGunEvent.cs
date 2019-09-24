namespace MailgunWebhooks
{
    public enum MailGunEvent
    {
        Clicked,
        Complained,
        Delivered,
        Failed,
        Opened,
        Unsubscribed
    }

    public static class MailGunEventExtensions
    {
        public static string ToEmoji(this MailGunEvent mailGunEvent)
        {
            switch (mailGunEvent)
            {
                case MailGunEvent.Clicked:
                    return "🖱";
                case MailGunEvent.Complained:
                    return "😠";
                case MailGunEvent.Delivered:
                    return "🚚";
                case MailGunEvent.Failed:
                    return "❌";
                case MailGunEvent.Opened:
                    return "📤";
                case MailGunEvent.Unsubscribed:
                    return "👋";
                default:
                    return "❓";
            }
        }
    }
}
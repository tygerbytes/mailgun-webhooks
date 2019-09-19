namespace MailGunWebhooks.Payload
{
    public class Message
    {
        public MessageHeaders Headers { get; set; }
        public int Size { get; set; }
    }
}
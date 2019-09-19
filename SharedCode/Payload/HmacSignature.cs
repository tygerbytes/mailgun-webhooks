using System;
using System.Security.Cryptography;

namespace MailGunWebhooks.Payload
{
    public class HmacSignature
    {
        public int Timestamp { get; set; }
        public string Token { get; set; }
        public string Signature { get; set; }

        public bool IsValid(string mailgunApiKey)
        {
            var msg = $"{this.Timestamp}{this.Token}";
            using (var hmac = new HMACSHA256(mailgunApiKey.ToByteArray()))
            {
                var hash = hmac.ComputeHash(msg.ToByteArray());
                var signature = BitConverter.ToString(hash).Replace("-", "").ToLower();
                return signature == this.Signature;
            }
        }
    }
}
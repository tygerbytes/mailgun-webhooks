using System;
using System.Security.Cryptography;

namespace MailgunWebhooks.Payload
{
    public class HmacSignature
    {
        public int Timestamp { get; set; }
        public string Token { get; set; }
        public string Signature { get; set; }

        public bool IsValid(string mailgunSigningKey)
        {
            var msg = $"{Timestamp}{Token}";
            using (var hmac = new HMACSHA256(mailgunSigningKey.ToByteArray()))
            {
                var hash = hmac.ComputeHash(msg.ToByteArray());
                var signature = BitConverter.ToString(hash).Replace("-", "").ToLower();
                return signature == Signature;
            }
        }
    }
}
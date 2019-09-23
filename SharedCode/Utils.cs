using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

namespace MailgunWebhooks
{
    static class Utils
    {
        public static byte[] HashHMAC(byte[] key, byte[] message)
        {
            using (var hash = new HMACSHA256(key))
            {
                return hash.ComputeHash(message);
            }
        }

        public static byte[] ToByteArray(this string str)
        {
            var utf8 = new UTF8Encoding();
            return utf8.GetBytes(str);
        }

        public static string ToJson(object obj, Formatting formatting = Formatting.Indented)
        {
            var settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };
            var json = JsonConvert.SerializeObject(obj, formatting, settings);
            return json;
        }
    }
}


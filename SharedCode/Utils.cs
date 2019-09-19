using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace MailGunWebhooks
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


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlGame.Domain.Extensions
{
    public static class StringExtension
    {
        public static string ConvertToMD5(this string password)
        {
            if (string.IsNullOrEmpty(password))
                return "";

            var senha = (password += "|2d331cca-f6c0-40c0-bb43-6e32989c2881");
            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(Encoding.Default.GetBytes(password));
            var sbString = new StringBuilder();

            foreach (var item in data)
                sbString.Append(item.ToString("x2"));

            return sbString.ToString();
        }
    }
}

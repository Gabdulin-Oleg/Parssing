using System;
using System.Text.RegularExpressions;

namespace Parssing
{
    public static class Sanitizer
    {
        static Regex sanitizer = new Regex("[ ]{2,}", RegexOptions.None);
        public static string Sanitize(string data)
        {
            var str = sanitizer.Replace(data?.Trim(), " ");
            if (string.IsNullOrEmpty(str))
                return null;
            return str;
        }

        public static DateTime? SanitizeDate(string data)
        {
            if (string.IsNullOrEmpty(data))
                return default;

            var str = sanitizer.Replace(data?.Trim(), " ");
            if (DateTime.TryParse(str, out DateTime res))
                return res;

            return default;
        }

        public static int? SanitizeInt(string data)
        {
            if (string.IsNullOrEmpty(data))
                return default;

            var str = sanitizer.Replace(data?.Trim(), " ");
            if (int.TryParse(str, out int res))
                return res;

            return default;
        }
    }
}


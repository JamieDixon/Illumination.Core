using System.Text;
using System.Web;

namespace Illumination.Core.Extensions
{
    public static class StringExtensions
    {
        public static string MakeDotsafeString(this string input)
        {
            return HttpUtility.HtmlEncode(input);
        }

        public static string FormatWith(this string format, params object[] args)
        {
            return string.Format(format, args);
        }

        /// <summary>
        /// Produces optional, URL-friendly version of a title, "like-this-one". 
        /// hand-tuned for speed, reflects performance refactoring contributed
        /// by John Gietzen (user otac0n) 
        /// Method obtains from: http://stackoverflow.com/questions/25259/how-does-stackoverflow-generate-its-seo-friendly-urls/25486#25486
        /// </summary>
        public static string ToUrlSlug(this string title)
        {
            if (title == null) return "";

            const int maxlen = 80;
            int len = title.Length;
            bool prevdash = false;
            var sb = new StringBuilder(len);

            for (int i = 0; i < len; i++)
            {
                char c = title[i];
                if ((c >= 'a' && c <= 'z') || (c >= '0' && c <= '9'))
                {
                    sb.Append(c);
                    prevdash = false;
                }
                else if (c >= 'A' && c <= 'Z')
                {
                    // tricky way to convert to lowercase
                    sb.Append((char)(c | 32));
                    prevdash = false;
                }
                else if (c == ' ' || c == ',' || c == '.' || c == '/' ||
                    c == '\\' || c == '-' || c == '_' || c == '=')
                {
                    if (!prevdash && sb.Length > 0)
                    {
                        sb.Append('-');
                        prevdash = true;
                    }
                }
                else if (c >= 128)
                {
                    int prevlen = sb.Length;
                    sb.Append(RemapInternationalCharToAscii(c));
                    if (prevlen != sb.Length) prevdash = false;
                }
                if (i == maxlen) break;
            }

            return prevdash ? sb.ToString().Substring(0, sb.Length - 1) : sb.ToString();
        }

        private static char RemapInternationalCharToAscii(char input)
        {
            return input;
        }

    }
}
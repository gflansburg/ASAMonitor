using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ASAMonitor
{
    public static class StringExtension
    {
        public static string ToMinimalReadableString(this TimeSpan span)
        {
            string formatted = string.Format("{0}:{1}",
                string.Format("{0:0}", span.Minutes),
                string.Format("{0:00}", span.Seconds));
            return formatted;
        }

        public static bool IsNumber(this string val)
        {
            int result;
            return int.TryParse(val, out result);
        }

        public static bool IsDecimal(this string val)
        {
            decimal result;
            return decimal.TryParse(val, out result);
        }

        public static bool IsBool(this string val)
        {
            return val.Equals("True", StringComparison.OrdinalIgnoreCase) || val.Equals("False", StringComparison.OrdinalIgnoreCase);
        }

        public static string ToVBString(this bool value)
        {
            return (value ? "True" : "False");
        }

        public static string ToStringOrEmpty(this object value)
        {
            return string.Concat(value, "");
        }

        /// <summary>
        /// Converts a string from CamelCase to a human readable format. 
        /// Inserts spaces between upper and lower case letters. 
        /// Also strips the leading "_" character, if it exists.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns>A human readable string.</returns>
        public static string FromCamelCase(this string propertyName)
        {
            string returnValue = null;
            returnValue = propertyName.ToStringOrEmpty();

            //Strip leading "_" character
            returnValue = Regex.Replace(returnValue, "^_", "").Trim();
            //Add a space between each lower case character and upper case character
            returnValue = Regex.Replace(returnValue, "([a-z])([A-Z])", "$1 $2").Trim();
            returnValue = Regex.Replace(returnValue, "([A-Z]|[a-z])([0-9])", "$1 $2").Trim();
            returnValue = Regex.Replace(returnValue, "([0-9])([A-Z]|[a-z])", "$1 $2").Trim();
            //Add a space between 2 upper case characters when the second one is followed by a lower space character
            returnValue = Regex.Replace(returnValue, "([A-Z])([A-Z])([A-Z])([A-Z])", "$1$2$3 $4").Trim();
            returnValue = returnValue.Replace("Pv P", "PvP ");
            return returnValue;
        }
    }
}

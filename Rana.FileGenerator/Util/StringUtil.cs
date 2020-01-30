using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rana.FileGenerator.Util
{
   public static class StringUtil
    {
        public static string SubstringValue(int initialPosition, int finalPosition,string value)
        {
            int maxSize = finalPosition - initialPosition;
            int size = value.Length;

            return (maxSize > 0) ? (value as string).Substring(0, Math.Min(size, maxSize)) : value;
        }

        public static string SubstringNumericValue(int initialPosition, int finalPosition, string value)
        {
            int maxSize = finalPosition - initialPosition;
            int size = value.Length;

            return (size > 0 ? value.Substring(Math.Max(0, size - maxSize), Math.Min(size, maxSize)) : value);
        }

        public static string SubstringBooleanValue(int initialPosition, int finalPosition, string value)
        {
            return value == "True" ? "1" : "0";
        }
    }
}

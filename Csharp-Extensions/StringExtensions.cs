using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsExtensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Multiplies the string.<para />
        /// e.g. str = "/\", multiplier = 4<para/>
        /// result: "/\/\/\/\";
        /// </summary>
        /// <param name="str">String to be multiplied</param>
        /// <param name="multiplier">Count of multiplications/concatenations.</param>
        /// <returns>The new string.</returns>
        public static string Multiply(this string str, int multiplier)
        {
            StringBuilder sb = new StringBuilder(multiplier * str.Length);
            for (; multiplier > 0; multiplier--)
                sb.Append(str);
            return sb.ToString();
        }

        /// <summary>
        /// Short access to .Split, splitting only at
        /// splitSeq and removing empty entries.
        /// </summary>
        /// <param name="str">String to split.</param>
        /// <param name="splitSeq">The delimeter-string.</param>
        /// <returns>Array of strings.</returns>
        public static string[] Split(this string str, string splitSeq)
        {
            return str.Split(new string[] { splitSeq }, StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Short form of String.Format(...).
        /// </summary>
        /// <param name="str">Format-string</param>
        /// <param name="objs">Values to appear in string.</param>
        /// <returns>Formatted string.</returns>
        public static string Format(this string str, params object[] objs)
        {
            return String.Format(str, objs);
        }

        /// <summary>
        /// Parses the given string to the
        /// required enum, if possible.
        /// </summary>
        /// <typeparam name="T">Type of the desired enum</typeparam>
        /// <param name="str">string to parse</param>
        /// <returns>The resulting enum.</returns>
        public static T ParseToEnum<T>(this string str) where T : struct, IConvertible // pseudo-enum
        {   // TODO could also be in an EnumExtensions.
            return (T)Enum.Parse(typeof(T), str, true);
        }
    }
}

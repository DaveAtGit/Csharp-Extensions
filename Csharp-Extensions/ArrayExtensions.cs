using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsExtensions
{
    public static class ArrayExtensions
    {
        /// <summary>
        /// Extends the first array by
        /// adding the second one to it.<para />
        /// **Out of place**<para />
        /// This does not remove <code>null</code>s.
        /// </summary>
        /// <typeparam name="T">any type</typeparam>
        /// <param name="firstArray">The array to be first in the new one.</param>
        /// <param name="secondArray">The array to be set behind the first one.</param>
        /// <returns>The new array being the concatination of both given arrays.</returns>
        public static T[] Extend<T>(this T[] firstArray, T[] secondArray)
        {
            var firstLen = firstArray.LongLength;
            var secondLen = secondArray.LongLength;
            T[] result = new T[firstLen + secondLen];

            int i;
            for (i = 0; i < firstLen; ++i)
                result[i] = firstArray[i];
            for (int j = 0; j < secondLen; ++j, ++i)
                result[i] = secondArray[j];

            return result;
            // TODO : test this.
        }
    }
}

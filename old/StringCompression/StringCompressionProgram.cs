// <copyright file="StringCompressionProgram.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace StringCompression
{
    using System;
    using System.Text;

    /// <summary>
    /// Реализуйте метод сжатия строки на основе счетчика повторяющихся символов. Например, строка aabcccccaaa должна превратиться в а2b1с5аЗ.
    ///  Если «сжатая» строка оказывается длиннее исходной, метод должен вернуть исходную строку.
    /// </summary>
    internal class StringCompressionProgram
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Введите строку: ");
            var str = Console.ReadLine();
            var finalStr = StrCompress(str);
            finalStr = GetSmallerStr(str, finalStr);
            Console.WriteLine(finalStr);
        }

        /// <summary>
        /// Takes 2 strings and return string whith smaller lenght.
        /// If they have equal lenght, returns first string.
        /// </summary>
        /// <param name="str1"> First string. </param>
        /// <param name="str2"> Second string. </param>
        /// <returns> String whith smaller lenght. </returns>
        private static string GetSmallerStr(string str1, string str2)
        {
            if (str1.Length < str2.Length)
                return str1;
            else if (str1.Length > str2.Length)
                return str2;
            else
                return str1;
        }

        /// <summary>
        /// Compress string.
        /// </summary>
        /// <param name="str"> Str. </param>
        /// <returns> Compressed str. </returns>
        /// <example>
        /// aaabbbbsst => a3b4s2t1.
        /// </example>
        private static string StrCompress(string str)
        {
            var finalStr = new StringBuilder();
            char element = str[0];
            var count = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == element)
                {
                    count++;
                }
                else
                {
                    finalStr.Append(element);
                    finalStr.Append(count);
                    count = 1;
                    element = str[i];
                }
            }

            // В случае если последний элемент отличается.
            if (str[str.Length - 1] != str[str.Length - 2])
            {
                finalStr.Append(element);
                finalStr.Append(count);
            }

            return finalStr.ToString();
        }
    }
}

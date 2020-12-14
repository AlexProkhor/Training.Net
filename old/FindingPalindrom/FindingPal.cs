// <copyright file="FindingPal.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace FindingPalindrom
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Найти наибольшую длину подстроки-палиндрома в строке.
    /// Слева и справа от палиндромов должны стоять символы.
    /// </summary>
    /// <example>
    /// tPDDDPy tRPPPRhuuuhP.
    /// </example>
    internal class FindingPal
    {
        private static void Main()
        {
            Console.WriteLine("Введите палиндром: ");

            var str = Console.ReadLine();
            var cenrePalArray = FindCentreOfPal(str);
            var palindroms = FindPalBody(cenrePalArray, str);
            var biggerPal = GetBiggerPal(palindroms);

            Console.WriteLine($"Самый большой палиндром: {biggerPal}");
        }

        /// <summary>
        /// Finding bigger palindrome.
        /// </summary>
        /// <param name="strList"> List whith pall's.</param>
        /// <returns> String bigger palindrome.</returns>
        private static string GetBiggerPal(List<string> strList)
        {
            int lenght = 0;
            int maxPosition = 0;

            for (int i = 0; i < strList.Count; i++)
            {
                if (strList[i].Length > lenght)
                {
                    lenght = strList[i].Length;
                    maxPosition = i;
                }
            }

            return strList[maxPosition].ToString();
        }

        /// <summary>
        /// Finding bodyes of palindromes.
        /// </summary>
        /// <param name="array"> Int array whith positions of centers of palindromes.</param>
        /// <returns>List whith full palidromes.</returns>
        private static List<string> FindPalBody(int[] array, string str)
        {
            var strList = new List<string>();

            // Поиск и добавление в список палиндромов.
            foreach (int i in array)
            {
                var isEnd = false;
                var positionFirst = i;
                var positionSecond = i;
                var strBuilder = new StringBuilder();
                while (isEnd != true)
                {
                    // Если от центра палиндрома по бокам одинаковые символы, раздвигаем позиции на шаг влево и вправо, расширяя центр палиндрома.
                    if ((positionFirst - 1) >= 0 && (positionSecond + 1) <= str.Length && str[positionFirst - 1] == str[positionSecond + 1])
                    {
                        positionFirst--;
                        positionSecond++;
                    }

                    // При нахождении краёв палиндрома добавляем, вынимаем его из строки.
                    else
                    {
                        for (int g = positionFirst; g <= positionSecond; g++)
                        {
                            strBuilder.Append(str[g]);
                        }

                        isEnd = true;
                        strList.Add(strBuilder.ToString());
                        strBuilder.Clear();
                    }
                }
            }

            return strList;
        }

        /// <summary>
        /// Find centre index of palindrome.
        /// </summary>
        /// <param name="str">Console entered str.</param>
        /// <returns> Int array whith indexs whith centers of palindromes.</returns>
        private static int[] FindCentreOfPal(string str)
        {
            int[] array = new int[str.Length];
            int k = 0;

            // Поиск и добавление в массив центров(индексов) палиндромов.
            for (int i = 0; i < str.Length; i++)
            {
                if ((i - 1) > 0 && (i + 1) < str.Length && str[i - 1] == str[i + 1])
                {
                    array[k] = i;
                    k++;
                }
            }

            // Удаляем нулевые элементы массива.
            var resultArray = array.Where(x => x != 0).ToArray();
            return resultArray;
        }
    }
}

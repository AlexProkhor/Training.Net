using System;
using System.Collections.Generic;
using System.Linq;

namespace CutList
{
    /// <summary>
    /// 1. Дано K упорядоченных списков чисел. Нужно вернуть первые N элементов из их объединения. Предложите алгоритм эффективнее тривиального, то есть быстрее, чем за O(NK).
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var unionList = CombiningLists();

            Console.WriteLine("Сколько элементов вывести?");
            var n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n");
            if (n <= unionList.Count)
            {
                var cutedList = unionList.GetRange(0, n).ToArray();

                //var cutedList = CutList(n, unionList).ToArray();

                for (int i = 0; i < cutedList.Length; i++)
                {
                    Console.Write($"{cutedList[i]}");
                }
            }
            else
                Console.WriteLine(" Столько чисел нет(");
        }

        /// <summary>
        /// Обрезка листа.
        /// </summary>
        /// <param name="n"> Размер обрезки.</param>
        /// <param name="unionList"> Лист. </param>
        /// <returns> Лист длиннок n.</returns>
        //static List<char> CutList(int n, List<char> unionList)
        //{
        //    var cutedList = new List<char>();

        //    for (int i = 0; i < n; i++)
        //    {
        //        cutedList.Add(unionList[i]);
        //    }

        //    return cutedList;
        //}

        /// <summary>
        /// Gets char union list from console.
        /// </summary>
        /// <returns> Char union list.</returns>
        static List<char> CombiningLists()
        {
            var unionList = new List<char>();

            Console.WriteLine("Введите строки чисел через пробел: ");
            var str = Console.ReadLine().ToCharArray();

            // Осуществляем union, исключая пробелы.
            for (int g = 0; g < str.Length; g++)
            {
                if (str[g] != ' ' && unionList.Contains(str[g]) == false)
                    unionList.Add(str[g]);
            }

            return unionList;
        }
    }
}

// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ConsoleApp2
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Есть два множества строк без повторов. Нужно их объединить, исключив повторения.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Filling sets.
        /// </summary>
        /// <param name="set1"> First set. </param>
        /// <param name="set2"> Second set. </param>
        private static void FillingSets(List<string> set1, List<string> set2)
        {
            set1.Add("Первый");
            set1.Add("Второй");
            set1.Add("Третий");
            set1.Add("Четвертый");
            set1.Add("Пятый");

            Console.WriteLine("First set: ");
            for (int i = 0; i < set1.Count; i++)
                Console.Write($"{set1[i]} ");

            set2.Add("Четвертый");
            set2.Add("Пятый");
            set2.Add("Шестой");
            set2.Add("Седьмой");
            set2.Add("Третий");

            Console.WriteLine("Second set: ");
            for (int i = 0; i < set2.Count; i++)
                Console.Write($"{set2[i]} ");
        }

       /// <summary>
       /// Add second set to first set and removes same elements.
       /// </summary>
       /// <param name="set1"> First set. </param>
       /// <param name="set2"> Second set. </param>
        private static List<string> AddSets(List<string> set1, List<string> set2)
        {
            FillingSets(set1, set2);
            set1.AddRange(set2);
            var result = set1.Distinct().ToList();
            return result;
        }

        /// <summary>
        /// Gets result of program.
        /// </summary>
        /// <param name="resultSet"> Result set. </param>
        private static void GetResult(List<string> resultSet)
        {
            Console.WriteLine("\n");

            for (int i = 0; i < resultSet.Count; i++)
                Console.Write($"{resultSet[i]} ");
        }

        /// <summary>
        /// Main.
        /// </summary>
        private static void Main()
        {
            var set1 = new List<string>();
            var set2 = new List<string>();
            var result = AddSets(set1, set2);
            GetResult(result);
        }
    }
}

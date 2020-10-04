// <copyright file="CrossUnionAndExeptProgram.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CrossUnionAndDifferenceOfArrays
{
    using System;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Даны два отсортированных массива чисел.
    /// Сформировать отсортированные массивы,
    /// являющиеся объединением, пересечением и разностью этих двух массивов
    /// (разность в смысле мультимножеств).
    /// </summary>
    internal class CrossUnionAndExeptProgram
    {
        private static void Main()
        {
            var firstArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            Console.WriteLine("First array:");
            foreach (int s in firstArray)
            {
                Console.Write($" {s}");
            }

            Console.WriteLine();

            var secondArray = new int[] { 6, 7, 8, 9, 10, 11, 12, 13 };
            Console.WriteLine("SecondArray:");
            foreach (int s in secondArray)
            {
                Console.Write($" {s}");
            }

            Console.WriteLine();

            CrossUnionAndExept(firstArray, secondArray);
        }

        /// <summary>
        /// Cross, Union and Exept realization.
        /// </summary>
        /// <param name="firstArray"> First array. </param>
        /// <param name="secondArray"> Second array. </param>
        private static void CrossUnionAndExept(int[] firstArray, int[] secondArray)
        {
            var crossing = firstArray.Intersect(secondArray).ToArray();
            var union = firstArray.Union(secondArray).ToArray();
            var difference = union.Except(crossing).ToArray();

            Output(crossing, union, difference);
        }

        private static void Output(int[] array, int[] array2, int[] array3)
        {
            Console.WriteLine("Crossing:");
            foreach (int s in array)
            {
                Console.Write($" {s}");
            }

            Console.WriteLine();

            Console.WriteLine("Union:");
            foreach (int s in array2)
            {
                Console.Write($" {s}");
            }

            Console.WriteLine();

            Console.WriteLine("Difference:");
            foreach (int s in array3)
            {
                Console.Write($" {s}");
            }
        }
    }
}

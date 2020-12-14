// <copyright file="ArrayShiftProgram.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ArrayShiftProgram
{
    using System;

    /// <summary>
    /// Дан массив чисел. Нужно его сдвинуть циклически на K позиций вправо, не используя других массивов.
    /// </summary>
    internal class ArrayShiftProgram
    {
        private static void Main()
        {
            var array = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
            Console.WriteLine("Enter the number of shifts");
            var shifts = int.Parse(Console.ReadLine());
            for (int i = 0; i < shifts; i++)
            {
               ArrayShiftMethod(array);
            }

            ResultList(array);
        }

        /// <summary>
        /// Array shift.
        /// </summary>
        /// <param name="array"> array. </param>
        private static void ArrayShiftMethod(int[] array)
        {
            var lastElement = array[array.Length - 1];

            for (int i = array.Length - 1; i > 0; i--)
            {
                array[i] = array[i - 1];
            }

            array[0] = lastElement;
        }

        /// <summary>
        /// Output result.
        /// </summary>
        /// <param name="array"> array. </param>
        private static void ResultList(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
        }
    }
}

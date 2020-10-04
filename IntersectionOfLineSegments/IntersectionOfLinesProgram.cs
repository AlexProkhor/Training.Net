// <copyright file="IntersectionOfLinesProgram.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace IntersectionOfLineSegments
{
    using System;

    /// <summary>
    /// Пересечение двух отрезков [A,B] и [C,D] на числовой прямой.
    /// </summary>
    internal class IntersectionOfLinesProgram
    {
        /// <summary>
        /// Programm gets intersection of two lines.
        /// Created by 4 points.
        /// </summary>
        private static void Main()
        {
            Console.WriteLine("Enter 1rst point of 1rst segment");
            int aOfAB = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter 2nd point of 1rst segment");
            int bOfAB = Convert.ToInt32(Console.ReadLine());

            // Get min and max value of AB.
            var result = AssingMinMax(aOfAB, bOfAB);
            int abMin = result.min;
            int abMax = result.max;
            Console.WriteLine("Enter 1rst point of 2nd segment");
            int cOfCD = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter 2nd point of 2nd segment");
            int dOfCD = Convert.ToInt32(Console.ReadLine());

            // Get min and max value of CD.
            result = AssingMinMax(cOfCD, dOfCD);
            int cdMin = result.min;
            int cdMax = result.max;
            Console.WriteLine($" AB segment : A: {aOfAB}, B: {bOfAB}; \n CD segment : C: {cOfCD}, D: {dOfCD}");

            GetIntersection(abMin, abMax, cdMin, cdMax);
        }

        /// <summary>
        /// Defines the extreme points of the line.
        /// </summary>
        /// <param name="first">first introduced point.</param>
        /// <param name="second">second introduced point.</param>
        /// <returns>defines the extreme points of the line.</returns>
        private static int FindMinMax(int first, int second)
        {
            if (first < second)
            {
                return 0;
            }
            else if (first > second)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }

        /// <summary>
        /// Get min and max point of line.
        /// </summary>
        /// <param name="first">first introduced point.</param>
        /// <param name="second">second introduced point.</param>
        /// <returns>returns min and max point of number line.</returns>
        private static (int min, int max) AssingMinMax(int first, int second)
        {
            int min, max;
            byte minMaxResult = Convert.ToByte(FindMinMax(first, second));
            if (minMaxResult == 0)
            {
                min = first;
                max = second;
            }
            else if (minMaxResult == 1)
            {
                min = second;
                max = first;
            }
            else
            {
                min = first;
                max = second;
            }

            return (min, max);
        }

        /// <summary>
        /// Finnaly count of number line.
        /// </summary>
        /// <param name="abMin">abmin.</param>
        /// <param name="abMax">abMax.</param>
        /// <param name="cdMin">cdMin.</param>
        /// <param name="cdMax">cdMax.</param>
        public static void GetIntersection(int abMin, int abMax, int cdMin, int cdMax)
        {
            if (cdMax < abMin || abMax < cdMin)
            {
                // If they are not intersect returns message.
                Console.WriteLine("They are not interect");
            }
            else
            {
                int minValue, generalMaxRange;

                // Get general min value.
                if (abMin < cdMin)
                {
                    minValue = cdMin;
                }
                else if (abMin > cdMin)
                {
                    minValue = abMin;
                }
                else
                {
                    minValue = abMin;
                }

                // Get general max value.
                if (abMax < cdMax)
                {
                    generalMaxRange = abMax;
                }
                else if (abMax > cdMax)
                {
                    generalMaxRange = cdMax;
                }
                else
                {
                    generalMaxRange = abMax;
                }

                // Return intersection of lines.
                while (minValue - 1 != generalMaxRange)
                {
                    Console.Write($"{minValue} ");
                    minValue++;
                }
            }
        }
    }
}

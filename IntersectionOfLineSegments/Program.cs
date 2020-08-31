using System;

namespace IntersectionOfLineSegments
{
    class Program
    {
        /// <summary>
        /// Programm gets intersection of two lines 
        /// Created by 4 points 
        /// </summary>

        static void Main()
        {
            int aOfAB, bOfAB, cOfCD, dOfCD;
            Console.WriteLine("Enter 1rst point of 1rst segment");
            aOfAB = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter 2nd point of 1rst segment");
            bOfAB = Convert.ToInt32(Console.ReadLine());
            ///<summary>
            ///Get min and max value of AB
            ///</summary>
            var result = AssingMinMax(aOfAB, bOfAB);
            int abMin = result.min;
            int abMax = result.max;
            Console.WriteLine("Enter 1rst point of 2nd segment");
            cOfCD = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter 2nd point of 2nd segment");
            dOfCD = Convert.ToInt32(Console.ReadLine());
            ///<summary>
            ///Get min and max value of CD
            ///</summary>
            result = AssingMinMax(cOfCD, dOfCD);
            int cdMin = result.min;
            int cdMax = result.max;
            Console.WriteLine($" AB segment : A: {aOfAB}, B: {bOfAB}; \n CD segment : C: {cOfCD}, D: {dOfCD}");
            GetIntersection(abMin, abMax, cdMin, cdMax);

        }
        /// <summary>
        /// Defines the extreme points of the line
        /// </summary>
        /// <param name="first">first introduced point</param>
        /// <param name="second">second introduced point</param>
        /// <returns>defines the extreme points of the line</returns>
        static int FindMinMax(int first, int second)
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
        /// Get min and max point of line
        /// </summary>
        /// <param name="first">first introduced point</param>
        /// <param name="second">second introduced point</param>
        /// <returns>returns min and max point of number line</returns>
        static (int min, int max) AssingMinMax(int first, int second)
        {
            int min, max;
            byte minMaxResult;
            minMaxResult = Convert.ToByte(FindMinMax(first, second));
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
        /// Finnaly count of number line
        /// </summary>
        /// <param name="abMin"></param>
        /// <param name="abMax"></param>
        /// <param name="cdMin"></param>
        /// <param name="cdMax"></param>
        static void GetIntersection(int abMin, int abMax, int cdMin, int cdMax)
        {
            //if they are not intersect returns message
            int minValue, generalMaxRange;
            if (cdMax < abMin || abMax < cdMin)
            {
                Console.WriteLine("They are not interect");
            }
            else
            {
                ///<summary>
                ///Get general min value
                /// </summary>
                if (abMin < cdMin)
                {
                    minValue = cdMin;
                }
                else if (abMin > cdMin)
                {
                    minValue = abMin;
                }
                else minValue = abMin;
                ///<summary>
                ///Get general max value
                /// </summary>
                if (abMax < cdMax)
                {
                    generalMaxRange = abMax;
                }
                else if (abMax > cdMax)
                {
                    generalMaxRange = cdMax;
                }
                else generalMaxRange = abMax;
                ///<summary>
                ///Return intersection of lines
                /// </summary>
                while (minValue - 1 != generalMaxRange)
                {
                    Console.Write($"{minValue} ");
                    minValue++;
                }

            }
        }
    }
}

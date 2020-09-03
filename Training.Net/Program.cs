// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Training.Net
{
    using System;
    using System.Diagnostics;
    using System.Text;

    /// <summary>
    /// Проверка скорости работы string и stringBuilder.
    /// Вводится кол-во n тысяч экспериментов (n*1000).
    /// Идет выбор метода.
    /// НА выходе получаем время выполнения и длинну строки для каждого метода.
    /// </summary>
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Enter the number of thousands of experiments");
            /// <example>
            /// 1 = 1000, 10 = 10000, 100 = 100000 и т.д.
            /// </example>
            int operations = Convert.ToInt32(Console.ReadLine()) * 1000;

            Console.WriteLine("Which method will be used? \n 1 - Common string method \n 2 - StringBuilder menthd \n 3 - Both");
            byte methodChange = Convert.ToByte(Console.ReadLine());

            Console.WriteLine("Adding operations");
            switch (methodChange)
            {
                case 1:
                    StrCommonMethod();
                    break;

                case 2:
                    StrStringBuilderMethod();
                    break;

                case 3:
                    StrCommonMethod();
                    StrStringBuilderMethod();
                    break;

                default:
                    Console.WriteLine(" Edit error!");
                    break;
            }

            Console.WriteLine("Experiment done!");
        }

        /// <summary>
        /// Метод без использования stringBuilder.
        /// </summary>
        private static void StrCommonMethod()
        {
            int operationCount = 0;
            var commonString = "StarCommon ";
            var stopWatch = new Stopwatch();

            stopWatch.Start();
            while (operationCount != 400000)
            {
                commonString += "1";
                operationCount++;
            }

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            string elapsedTime =
                string.Format(
                    "{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours,
                    ts.Minutes,
                    ts.Seconds,
                    ts.Milliseconds / 10);
            Console.WriteLine($" strCommonMethod whith 100000 operations: {elapsedTime} lenght: {commonString.Length}");
        }

        /// <summary>
        /// Метод с использованием stringBuilder.
        /// </summary>
        private static void StrStringBuilderMethod()
        {
            int operationCount = 0;
            var commonString = "StarStringBuilder: ";
            var sBuilder = new StringBuilder(commonString);
            var stopWatch = new Stopwatch();

            stopWatch.Start();
            while (operationCount != 400000000)
            {
                sBuilder.Append("1");
                operationCount++;
            }

            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;

            string elapsedTime =
                string.Format(
                    "{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours,
                    ts.Minutes,
                    ts.Seconds,
                    ts.Milliseconds / 10);
            Console.WriteLine($" strCommonMethod whith 400000000 operations: {elapsedTime} lenght: {sBuilder.Length}");
        }
    }
}

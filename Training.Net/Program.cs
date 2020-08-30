using System;
using System.Diagnostics;
using System.Text;

namespace Training.Net
{

    /// <summary>
    /// Проверка скорости работы string и stringBuilder
    /// Вводится кол-во n тысяч экспериментов (n*1000)
    /// Идет выбор метода
    /// НА выходе получаем время выполнения и длинну строки для каждого метода
    /// </summary>
    class Program
    {
        static void Main()
        {

            Console.WriteLine("Enter the number of thousands of experiments");
            ///<example>
            ///1 = 1000, 10 = 10000, 100 = 100000 и т.д.
            ///</example>
            int operations = Convert.ToInt32(Console.ReadLine()) * 1000;

            Console.WriteLine("Which method will be used? \n 1 - Common string method \n 2 - StringBuilder menthd \n 3 - Both");
            byte methodChange = Convert.ToByte(Console.ReadLine());

            Console.WriteLine("Adding operations");
            switch (methodChange)
            {
                case 1:
                    strCommonMethod();
                    break;
                case 2:
                    strStringBuilderMethod();
                    break;
                case 3:
                    strCommonMethod();
                    strStringBuilderMethod();
                    break;
            }

            Console.WriteLine("Experiment done!");
        }
        /// <summary>
        /// Метод без использования stringBuilder
        /// </summary>
        static void strCommonMethod()
        {
            int operationCount = 0;
            string commonString = "StarCommon ";
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            while (operationCount != 400000)
            {
                commonString += "1";
                operationCount++;
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            Console.WriteLine($" strCommonMethod whith 100000 operations: {elapsedTime} lenght: {commonString.Length}");
        }
        /// <summary>
        /// Метод с использованием stringBuilder
        /// </summary>
        static void strStringBuilderMethod()
        {
            int operationCount = 0;
            string commonString = "StarStringBuilder: ";
            StringBuilder sBuilder = new StringBuilder(commonString);
            Stopwatch stopWatch = new Stopwatch();

            stopWatch.Start();
            while (operationCount != 400000000)
            {
                sBuilder.Append("1");
                operationCount++;
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            Console.WriteLine($" strCommonMethod whith 400000000 operations: {elapsedTime} lenght: {sBuilder.Length}");
        }
    }
}

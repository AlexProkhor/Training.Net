using System;

namespace FuncAction
{
    class FuncActionProgram
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Введите кол-во операций");
            int count = Convert.ToInt32(Console.ReadLine());
            Start(count);
        }

        static void Start(int count)
        {
            int value = 0;
            Action<int, int> op;
            Func<int, int> retFunc;
            op = Add;
            retFunc = Decrease;

            while (value != count)
            {
                value++;
                op(value, count);
                retFunc(count);
            }
        }

        static void Operation(int x1, int x2, Action<int, int> op)
        {
            op(x1, x2);
        }

        static void Add(int value, int count)
        {
            try
            {
                int res = value / count;
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка!");
            }
            finally
            {
                Console.WriteLine($"Операция № {value}");
            }
        }

        static int Decrease(int count)
        {
            count--;
            return count;
        }
    }
}

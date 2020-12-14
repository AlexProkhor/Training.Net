

namespace FindKElementFromTaleList
{
    using System;
    class FindElement
    {
        /// <summary>
        /// 1. Предложите алгоритм поиска в односвязном списке k-го элемента с конца.
        /// Список реализован вручную, есть только операция получения следующего элемента и указатель на первый элемент. 
        /// Алгоритм, по возможности, должен быть оптимален по времени и памяти.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Введите список через пробел: ");
            var str = Console.ReadLine();
            var strWithoutSpaces = str.Replace(" ", "").ToCharArray();

            Console.WriteLine("Введите индекс элемента для поиска(с конца)");
            int position = Int32.Parse(Console.ReadLine());
            Find(strWithoutSpaces, position);
        }

        /// <summary>
        /// Find k element from tail.
        /// </summary>
        /// <param name="array"> Entered char array. </param>
        /// <param name="position"> Entered index of element. </param>
        static void Find(char[] array, int position)
        {
            int index1 = 0;
            int index2 = position;

            int n = array[index1];
            int t = array[index2];
            try
            {
                while (true)
                {
                    n = array[index1++];
                    t = array[index2++];
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Find!!!");
            }

            finally
            {
                Console.WriteLine(array[index1 - 1]);
            }
        }

    }
}

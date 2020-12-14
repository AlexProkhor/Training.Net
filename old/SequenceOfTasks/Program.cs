using System;
using System.Linq;
using System.Text;

namespace SequenceOfTasks
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Введите зависимости:");
            var str = Console.ReadLine();
            var array = GetTasks(str);
        }

        // {1, 2}, {2, 5}, {2, 4}, {3, 1} -> 3, 1, 2, 5, 4
        static private int[] GetTasks(string str)
        {
            var strBuilder = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] != '{' && str[i] != '}' && str[i] != ' ' && str[i] != ',')
                {
                    strBuilder.Append(str[i]);
                }
            }
            var charArray = strBuilder.ToString().ToCharArray();
            int[] array = new int[charArray.Length];

            //Запись последовательности.
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = Convert.ToInt32(charArray[i]);
            }
            return array;
        }

        static private void GetSequende(int[] array)
        {
            var unique = array.Distinct();
            foreach (int i in unique)
            {
                string s = $"{nameof(array)}[{i}]";
            }
        }
        //static private void FirsTask(int place)
        //{
        //    var addiction = place;
        //}

        //static private void SecondTask(int place)
        //{
        //    var addiction = place;
        //}

        //static private void ThirdTask(int place)
        //{
        //    var addiction = place;
        //}

        //static private void FourthTask(int place)
        //{
        //    var addiction = place;
        //}

        //static private void FifthTask(int place)
        //{
        //    var addiction = place;
        //}

        //static private void SixthTask(int place)
        //{
        //    var addiction = place;
        //}
    }

    class IAmTask
    {
        public string name;
        public string addiction;
        public bool isAddicted = false;
        public bool canItWork = true;
    }
}

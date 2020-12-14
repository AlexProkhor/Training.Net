using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DictionaryLineSplitting
{
    /// <summary>
    /// Проверить существует ли способ разбить строку (слово) на несколько частей, каждая из которых входит в словарь.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите строку: ");
            var str = Console.ReadLine();
            var dictionary = new List<string>();
            dictionary.Add("cat");
            dictionary.Add("dog");
            dictionary.Add("frog");
            dictionary.Add("banana");
            dictionary.Add("cow");
            dictionary.Add("pow");
            var result = FindWords(str, dictionary);
            Console.WriteLine(result.Item1);
            Console.WriteLine(result.Item2);
        }

        private static (string, string) FindWords(string str, List<string> dictionary)
        {
            var strBuilder = new StringBuilder();
            var count = 0;
            foreach (string t in dictionary)
            {
                if (str.Contains(t))
                {
                    str.Except(t);
                    strBuilder.Append(t);
                    strBuilder.Append(" ");
                    count++;
                }
            }
            if (str.Length == (strBuilder.Length - count))
            {
                return ("It can split:", strBuilder.ToString());
            }
            else
            {
                return ("It cant split. Difference:", str);
            }
        }

    }
}

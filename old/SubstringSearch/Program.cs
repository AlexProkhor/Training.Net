#nullable enable



namespace SubstringSearch
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    class Program
    {
        static string GetListContent(List<string> list, int position)
        {
            var strContent = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                if (i != position)
                {
                    strContent.Append(list[i]);
                }
            }

            return strContent.ToString();
        }
        static void Main()
        {
            var list2 = new List<string>();
            var list = new List<string>();
            list.Add("abchhhcdaa");
            list.Add("abcpppcddd");
            list.Add("abctttcdda");
            int l = 10;
            int position = 0;
            (int lenght, int position) isItMin = (int.MaxValue, int.MaxValue);
            string? vat = null;
            //для каждого элемента в списке
            for (int i = 0; i < l; i++)
            {
                //выделение элемента
                var str = list[i];
                var listContent = GetListContent(list, i);
                //для каждого элемента в строке
                for (int j = 0; j < str.Length; j++)
                {
                    if (listContent.Contains(str[j]) != false)
                    {
                        vat += str[j];
                    }
                    else if (vat != null && vat.Length < isItMin.lenght)
                    {
                        isItMin.lenght = vat.Length;
                        isItMin.position = position;
                        position++;
                        list2.Add(vat);
                    }

                    vat = null;
                }

                Console.WriteLine($"1я кратчайшая подстрока: {list2[isItMin.position]}");
            }
        }
    }
}

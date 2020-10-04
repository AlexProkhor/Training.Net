using System;
using System.Diagnostics.CodeAnalysis;

namespace ABDT_HW2
{
	class Program
	{
		static long Pow(long val, long pow)
		{
			long result = 1;
			for (long j = 1; j <= pow; j++)
			{
				result = result * val;
			}
			return result;
		}

		static int CaluclateNDigit(long n)
		{
			long i = 1;
			long sum = 0;
			long add = 9;
			// 12345678910111213...
			// xxxx - 9000 * 4
			while (n > sum + add)
			{
				sum += add;
				i++;
				add = 9 * Pow(10, i - 1) * i;
			}
			// убираем сумму цифр всех чисел меньшей разрядности
			n = n - sum - 1;
			// находим число рядом с которым надо искать
			long k = Pow(10, i-1) + n / i;
			unchecked
			{
				return (int)((k / Pow(10, i - (n % i)-1)) % 10);
			}
		}

		static void Main(string[] args)
		{
			long n;
			bool continueCalc = true;
			while (continueCalc)
			{
				Console.WriteLine("Введите N");
				long.TryParse(Console.ReadLine(), out n);
				if (n == 0)
				{
					continueCalc = false;
					break;
				}
				Console.WriteLine(CaluclateNDigit(n));
			}
		}
	}
}

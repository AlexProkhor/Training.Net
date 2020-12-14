using System;
using System.Linq.Expressions;

namespace ExpressionTreeDerivation
{
	class Program
	{
		static void Main(string[] args)
		{
			Expression<Func<double,double>> func = x => x * Math.Sin(10 * x);

			Expression<Func<double, double>> derFunc = Matan.Differentiate(func);

			Console.WriteLine(derFunc);


			Expression<Func<double, double>> f = x => Math.Cos(x);

			derFunc = Matan.ParseDerivative(f);
			derFunc = Matan.ParseDerivative(derFunc);
			Console.WriteLine(derFunc);
		}
	}
}

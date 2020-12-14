using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace CalculatorApplication
{
    public class Calculator
    {
        public static double Calculate(CalculatorOperations operation, double val1, double val2)
        {
            var result = operation switch
            {
                CalculatorOperations.Plus => val1 + val2,
                CalculatorOperations.Minus => val1 - val2,
                CalculatorOperations.Multiply => val1 * val2,
                CalculatorOperations.Divide => val1 / val2,
                _ => throw new NotSupportedException($"Operation \"{operation}\" is not supported")
            };

            return result;
        }
    }
}

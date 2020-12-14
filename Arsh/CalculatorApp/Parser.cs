using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CalculatorApplication
{
    public class Parser
    {
        public static void WriteResult(double result)
        {
            var str = double.IsInfinity(result)
                ? "Error: 0 division"
                : result.ToString(CultureInfo.CurrentCulture);
            Console.WriteLine($"Result: {str}");
        }

        public static bool TryParseOperation(string strOperation, out CalculatorOperations operation)
        {
            switch (strOperation)
            {
                case "+":
                    operation = CalculatorOperations.Plus;
                    return true;
                case "-":
                    operation = CalculatorOperations.Minus;
                    return true;
                case "*":
                    operation = CalculatorOperations.Multiply;
                    return true;
                case "/":
                    operation = CalculatorOperations.Divide;
                    return true;
            }

            operation = default;
            Console.WriteLine($"Error: {strOperation} not supported operation");
            return false;
        }

        public static bool TryParseValue(string arg, string paramName, out double val)
        {
            var flag = double.TryParse(arg, out val);
            if (!flag)
            {
                Console.WriteLine($"Error: {paramName} is not valid double");
                return false;
            }
            return true;
        }
    }
}

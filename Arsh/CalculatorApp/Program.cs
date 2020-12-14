using System;

namespace CalculatorApplication
{
    public class Program
    {
        public static int Main(string[] args)
        {
            if (!CheckArgs(args))
            {
                return 1;
            }

            if(!Parser.TryParseValue(args[0], "val1", out var val1)
                || !Parser.TryParseOperation(args[1], out var operation)
                || !Parser.TryParseValue(args[2], "val2", out var val2))
            {
                return 2;
            }

            var result = Calculator.Calculate(operation, val1, val2);
            Parser.WriteResult(result);
            return 0;
        }
        
        public static bool CheckArgs(string[] args)
        {
            if(args.Length < 3)
            {
                Console.WriteLine($"Please provide 3 arguments.");
                return false;
            }
            return true;
        }

       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace AcmeCompany.FizzBussinator.Console
{
    public class Program
    {
        public static void Main(params string[] args)
        {
            var max = ParseArgs(args);

            //this just happens to match the 'default' config as well
            var config = new Dictionary<int, string>() { { 3, "fizz" }, { 5, "buzz" } };

            var fizzBuzzinator = new FizzBuzzinator(config);

            for (int i = 0; i < max; i++)
            {
                var number = (i + 1);
                var message = fizzBuzzinator.Fizzer(number);
                System.Console.WriteLine("{0} {1}", message.PadRight(10), number);
            }
        }

        /// <summary>
        /// CLI parser that will default to 100 if nothing is present.
        /// Otherwise it will attempt to extract an interger value or
        /// also look for the string max which will Run'em All™
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        private static int ParseArgs(string[] args)
        {
            int max;
            if (args.IsNullOrEmpty())
                max = 100;
            else
            {
                if (!int.TryParse(args.First(), out max))
                {
                    //If we can't parse the value then check for a 'max' string
                    max = String.Equals(args.First(), "max", StringComparison.OrdinalIgnoreCase) ? int.MaxValue : 100;
                }
            }
            return max;
        }
    }

    internal static class CollectionExtensions
    {
        public static bool IsNullOrEmpty(this IEnumerable<string> source)
        {
            return source == null || !source.Any();
        }
    }
}

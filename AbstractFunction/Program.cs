using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace AbstractFunction
{
    internal class Program
    {
        /// <summary>
        ///     Точка входа в приложение.
        /// </summary>
        private static void Main()
        {
            try
            {
                var functions = ReadFunctionsFromFile();

                foreach (var function in functions) Console.WriteLine(function.ToString());
            }
            catch (Exception e)
            {
                // debug
                Console.WriteLine(e.GetType() + " " + e.Message);
            }
        }

        private static IEnumerable<Function> ReadFunctionsFromFile()
        {
            IFormatProvider doublesFormatter = new NumberFormatInfo {NumberDecimalSeparator = "."};

            var functionCount = 0;

            using var sr = new StreamReader("input.txt", Encoding.Default);
            string line;

            if ((line = sr.ReadLine()) != null) functionCount = int.Parse(line);

            var functions = new List<Function>();

            for (var i = 0; i < functionCount; i++)
                if ((line = sr.ReadLine()) != null)
                {
                    Function f;

                    var tokens = line.Split(" ");
                    var functionType = tokens[0];
                    var coefs = tokens
                        .Skip(1)
                        .Select(token => double.Parse(token, doublesFormatter))
                        .ToArray();

                    switch (functionType)
                    {
                        case "line":
                            f = new Line(coefs);
                            functions.Add(f);
                            break;
                        case "quadratic":
                            f = new Quadratic(coefs);
                            functions.Add(f);
                            break;
                        case "cubic":
                            f = new Cubic(coefs);
                            functions.Add(f);
                            break;
                        default:
                            throw new FormatException("invalid function type: " + tokens[0]);
                    }
                }

            return functions;
        }
    }
}
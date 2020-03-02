using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace AbstractFunction
{
    internal class Program
    {
        /// <summary>
        /// Входной файл по умолчанию.
        /// </summary>
        private const string InputFilePath = "input.txt";

        /// <summary>
        /// Выходной файл для сериализации в XML.
        /// </summary>
        private const string SerializerFilePath = "functions.xml";

        /// <summary>
        ///     Точка входа в приложение.
        /// </summary>
        private static void Main()
        {
            Trace.Listeners.Add(new ConsoleTraceListener());

            try
            {
                var functions = ReadFunctionsFromFile();
                var enumerable = functions as Function[] ?? functions.ToArray();

                Console.WriteLine("Значение функций в точке x:");
                foreach (var function in enumerable) Console.WriteLine(function.ToString());

                if (File.Exists(SerializerFilePath)) File.Delete(SerializerFilePath);
                foreach (var function in enumerable) function.Serialize(SerializerFilePath);
            }
            catch (Exception e)
            {
                // debug
                Console.WriteLine(e.GetType() + " " + e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }

        /// <summary>
        /// Читает набор функций из текстового файла (по умолчанию input.txt).
        /// </summary>
        /// <returns>Коллекция функций</returns>
        private static IEnumerable<Function> ReadFunctionsFromFile()
        {
            Trace.WriteLine($"reading functions from {InputFilePath}...");

            IFormatProvider doublesFormatter = new NumberFormatInfo {NumberDecimalSeparator = "."};

            var functionCount = 0;

            using var sr = new StreamReader(InputFilePath, Encoding.Default);
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

            Trace.WriteLine("finished reading functions");

            return functions;
        }
    }
}
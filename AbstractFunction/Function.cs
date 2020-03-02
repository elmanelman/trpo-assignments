using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace AbstractFunction
{
    /// <summary>
    ///     Абстрактная функция.
    /// </summary>
    /// <remarks>
    ///     Поддерживает вычисление значения в точке.
    /// </remarks>
    public abstract class Function
    {
        /// <summary>
        ///     Вычисление значения функции в точке x.
        /// </summary>
        /// <param name="x">Точка x.</param>
        /// <returns>Значение функции в точке x.</returns>
        public abstract double Evaluate(double x);

        /// <summary>
        ///     Создание строкового представления функции.
        /// </summary>
        /// <returns>Строка с представлением.</returns>
        public abstract override string ToString();

        /// <summary>
        ///     Сериализует объект в файл XML.
        /// </summary>
        /// <param name="path">Путь до файла для сериализации.</param>
        public abstract void Serialize(string path);
    }

    /// <summary>
    ///     Одночлен от переменной x.
    /// </summary>
    public class Monomial : Function
    {
        public double Scale { get; }
        public uint Degree { get; }

        public Monomial()
        {
            Scale = 0.0;
            Degree = 0;
        }

        public Monomial(double scale, uint degree)
        {
            Scale = scale;
            Degree = degree;
        }

        public override double Evaluate(double x)
        {
            Trace.WriteLine($"evaluating monomial {this} at point {x}");

            return Scale * Math.Pow(x, Degree);
        }

        public override string ToString()
        {
            return Degree switch
            {
                0 => $"{Scale}",
                1 => $"({Scale} * x)",
                _ => $"({Scale} * x^{Degree})"
            };
        }

        public override void Serialize(string path)
        {
            var s = new XmlSerializer(typeof(Monomial));
            TextWriter writer = new StreamWriter(path, true);

            s.Serialize(writer, this);

            writer.Close();
        }
    }

    /// <summary>
    ///     Линейная функция от переменной x.
    ///     Вид: a * x + b
    /// </summary>
    public class Line : Function
    {
        private const int MonomialCount = 2;

        public Monomial[] Monomials;

        public Line()
        {
            Monomials = new[]
            {
                new Monomial(0.0, 0),
                new Monomial(0.0, 1)
            };
        }

        public Line(params double[] coefs)
        {
            Monomials = new Monomial[MonomialCount];

            if (coefs.Length != MonomialCount)
                throw new ArgumentException("invalid coefficient count");

            for (var i = 0; i < Monomials.Length; ++i) Monomials[i] = new Monomial(coefs[i], (uint) i);
        }

        public override double Evaluate(double x)
        {
            Trace.WriteLine($"evaluating {GetType()} function {this} at point {x}");

            return Monomials.Sum(monomial => monomial.Evaluate(x));
        }

        public override string ToString()
        {
            return string.Join(" + ", Monomials.Select(monomial => monomial.ToString()));
        }

        public override void Serialize(string path)
        {
            var s = new XmlSerializer(typeof(Line));
            TextWriter writer = new StreamWriter(path, true);

            s.Serialize(writer, this);

            writer.Close();
        }
    }

    /// <summary>
    ///     Квадратичная функция от переменной x.
    /// </summary>
    /// <remarks>
    ///     Вид: a * x^2 + b * x + c
    /// </remarks>
    public class Quadratic : Function
    {
        private const int MonomialCount = 3;

        public Monomial[] Monomials;

        public Quadratic()
        {
            Monomials = new[]
            {
                new Monomial(0.0, 0),
                new Monomial(0.0, 0),
                new Monomial(0.0, 1)
            };
        }

        public Quadratic(params double[] coefs)
        {
            Monomials = new Monomial[MonomialCount];

            if (coefs.Length != MonomialCount)
                throw new ArgumentException("invalid coefficient count");

            for (var i = 0; i < Monomials.Length; ++i) Monomials[i] = new Monomial(coefs[i], (uint) i);
        }

        public override double Evaluate(double x)
        {
            Trace.WriteLine($"evaluating {GetType()} function {this} at point {x}");

            return Monomials.Sum(monomial => monomial.Evaluate(x));
        }

        public override string ToString()
        {
            return string.Join(" + ", Monomials.Select(monomial => monomial.ToString()));
        }

        public override void Serialize(string path)
        {
            var s = new XmlSerializer(typeof(Quadratic));
            TextWriter writer = new StreamWriter(path, true);

            s.Serialize(writer, this);

            writer.Close();
        }
    }

    /// <summary>
    ///     Кубическая функция от переменной x.
    /// </summary>
    /// <remarks>
    ///     Вид: a * x^3 + b * x^2 + c * x + d
    /// </remarks>
    public class Cubic : Function
    {
        private const int MonomialCount = 4;

        public Monomial[] Monomials;

        public Cubic()
        {
            Monomials = new[]
            {
                new Monomial(0.0, 0),
                new Monomial(0.0, 0),
                new Monomial(0.0, 0),
                new Monomial(0.0, 1)
            };
        }

        public Cubic(params double[] coefs)
        {
            Monomials = new Monomial[MonomialCount];

            if (coefs.Length != MonomialCount)
                throw new ArgumentException("invalid coefficient count");

            for (var i = 0; i < Monomials.Length; ++i) Monomials[i] = new Monomial(coefs[i], (uint) i);
        }

        public override double Evaluate(double x)
        {
            Trace.WriteLine($"evaluating {GetType()} function {this} at point {x}");

            return Monomials.Sum(monomial => monomial.Evaluate(x));
        }

        public override string ToString()
        {
            return string.Join(" + ", Monomials.Select(monomial => monomial.ToString()));
        }

        public override void Serialize(string path)
        {
            var s = new XmlSerializer(typeof(Cubic));
            TextWriter writer = new StreamWriter(path, true);

            s.Serialize(writer, this);

            writer.Close();
        }
    }
}
using System;
using System.Diagnostics;
using System.Linq;

namespace AbstractFunction
{
    /// <summary>
    ///     Абстрактная функция.
    /// </summary>
    /// <remarks>
    ///     Поддерживает вычисление значения в точке.
    /// </remarks>
    internal abstract class Function
    {
        /// <summary>
        /// Вычисление значения функции в точке x.
        /// </summary>
        /// <param name="x">Точка x.</param>
        /// <returns>Значение функции в точке x.</returns>
        public abstract double Evaluate(double x);

        /// <summary>
        /// Создание строкового представления функции.
        /// </summary>
        /// <returns>Строка с представлением.</returns>
        public abstract override string ToString();
    }

    /// <summary>
    ///     Одночлен от переменной x.
    /// </summary>
    internal class Monomial : Function
    {
        private double Scale { get; }
        private uint Degree { get; }

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
    }

    /// <summary>
    ///     Линейная функция от переменной x.
    ///     Вид: a * x + b
    /// </summary>
    internal class Line : Function
    {
        private const int MonomialCount = 2;

        public Monomial[] Monomials;

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
    }

    /// <summary>
    ///     Квадратичная функция от переменной x.
    /// </summary>
    /// <remarks>
    ///     Вид: a * x^2 + b * x + c
    /// </remarks>
    internal class Quadratic : Function
    {
        private const int MonomialCount = 3;

        public Monomial[] Monomials;

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
    }

    /// <summary>
    ///     Кубическая функция от переменной x.
    /// </summary>
    /// <remarks>
    ///     Вид: a * x^3 + b * x^2 + c * x + d
    /// </remarks>
    internal class Cubic : Function
    {
        private const int MonomialCount = 4;

        public Monomial[] Monomials;

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
    }
}
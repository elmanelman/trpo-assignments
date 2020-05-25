using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalculatorForm : Form
    {
        /// <summary>
        /// Словарь строковых представлений операторов
        /// </summary>
        public Dictionary<Action?, string> OperatorToString = new Dictionary<Action?, string>()
        {
            { Action.Add, "+" },
            { Action.Subtract, "-" },
            { Action.Multiply, "*" },
            { Action.Divide, "/" },
        };

        public Calculator Calculator = new Calculator();

        public CalculatorForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик кнопки "вычислить"
        /// </summary>
        private void ButtonEvaluate_Click(object sender, EventArgs e)
        {
            Calculator.PressAction(Action.Evaluate);

            var previousValueString = Calculator.PreviousValue.ToString(CultureInfo.InvariantCulture);
            if (Calculator.Operator != null)
            {
                var operatorString = OperatorToString[Calculator.Operator];
                var currentValueString = Calculator.CurrentValue.ToString(CultureInfo.InvariantCulture);

                TextBoxUpper.Text = $"{previousValueString} {operatorString} {currentValueString} =";
            }

            TextBoxResult.Text = Calculator.Result.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Обработчик кнопки "ноль"
        /// </summary>
        private void ButtonZero_Click(object sender, EventArgs e)
        {
            Calculator.PressDigit(0);
            TextBoxResult.Text = Calculator.CurrentValue.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Обработчик кнопки "один"
        /// </summary>
        private void ButtonOne_Click(object sender, EventArgs e)
        {
            Calculator.PressDigit(1);
            TextBoxResult.Text = Calculator.CurrentValue.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Обработчик кнопки "два"
        /// </summary>
        private void ButtonTwo_Click(object sender, EventArgs e)
        {
            Calculator.PressDigit(2);
            TextBoxResult.Text = Calculator.CurrentValue.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Обработчик кнопки "три"
        /// </summary>
        private void ButtonThree_Click(object sender, EventArgs e)
        {
            Calculator.PressDigit(3);
            TextBoxResult.Text = Calculator.CurrentValue.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Обработчик кнопки "четыре"
        /// </summary>
        private void ButtonFour_Click(object sender, EventArgs e)
        {
            Calculator.PressDigit(4);
            TextBoxResult.Text = Calculator.CurrentValue.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Обработчик кнопки "пять"
        /// </summary>
        private void ButtonFive_Click(object sender, EventArgs e)
        {
            Calculator.PressDigit(5);
            TextBoxResult.Text = Calculator.CurrentValue.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Обработчик кнопки "шесть"
        /// </summary>
        private void ButtonSix_Click(object sender, EventArgs e)
        {
            Calculator.PressDigit(6);
            TextBoxResult.Text = Calculator.CurrentValue.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Обработчик кнопки "семь"
        /// </summary>
        private void ButtonSeven_Click(object sender, EventArgs e)
        {
            Calculator.PressDigit(7);
            TextBoxResult.Text = Calculator.CurrentValue.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Обработчик кнопки "восемь"
        /// </summary>
        private void ButtonEight_Click(object sender, EventArgs e)
        {
            Calculator.PressDigit(8);
            TextBoxResult.Text = Calculator.CurrentValue.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Обработчик кнопки "девять"
        /// </summary>
        private void ButtonNine_Click(object sender, EventArgs e)
        {
            Calculator.PressDigit(9);
            TextBoxResult.Text = Calculator.CurrentValue.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Обработчик кнопки "очистить"
        /// </summary>
        private void ButtonCE_Click(object sender, EventArgs e)
        {
            Calculator.PressAction(Action.ClearEntry);
            if (Calculator.IsEvaluated)
            {
                TextBoxUpper.Text = "";
            }
            TextBoxResult.Text = Calculator.CurrentValue.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Обработчик кнопки "прибавить"
        /// </summary>
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            Calculator.PressAction(Action.Add);
            TextBoxUpper.Text = Calculator.PreviousValue.ToString(CultureInfo.InvariantCulture) + " + ";
            TextBoxResult.Text = Calculator.CurrentValue.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Обработчик кнопки "вычесть"
        /// </summary>
        private void ButtonSubtract_Click(object sender, EventArgs e)
        {
            Calculator.PressAction(Action.Subtract);
            TextBoxUpper.Text = Calculator.PreviousValue.ToString(CultureInfo.InvariantCulture) + " - ";
            TextBoxResult.Text = Calculator.CurrentValue.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Обработчик кнопки "умножить"
        /// </summary>
        private void ButtonMultiply_Click(object sender, EventArgs e)
        {
            Calculator.PressAction(Action.Multiply);
            TextBoxUpper.Text = Calculator.PreviousValue.ToString(CultureInfo.InvariantCulture) + " * ";
            TextBoxResult.Text = Calculator.CurrentValue.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Обработчик кнопки "разделить"
        /// </summary>
        private void ButtonDivide_Click(object sender, EventArgs e)
        {
            Calculator.PressAction(Action.Divide);
            TextBoxUpper.Text = Calculator.PreviousValue.ToString(CultureInfo.InvariantCulture) + " / ";
            TextBoxResult.Text = Calculator.CurrentValue.ToString(CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Обработчик кнопки "точка"
        /// </summary>
        private void ButtonPoint_Click(object sender, EventArgs e)
        {
            Calculator.PressAction(Action.Point);
            TextBoxResult.Text = Calculator.CurrentValue.ToString(CultureInfo.InvariantCulture) + ".";
        }

        /// <summary>
        /// Реализует ввод с клавиатуры
        /// </summary>
        private void CalculatorForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9')
            {
                Calculator.PressDigit(e.KeyChar - '0');
                TextBoxResult.Text = Calculator.CurrentValue.ToString(CultureInfo.InvariantCulture);
            }

            var op = OperatorToString.FirstOrDefault(x => x.Value == e.KeyChar.ToString()).Key;

            if (op != null)
            {
                Calculator.PressAction((Action)op);
                TextBoxUpper.Text = Calculator.PreviousValue.ToString(CultureInfo.InvariantCulture) + $" {e.KeyChar} ";
                TextBoxResult.Text = Calculator.CurrentValue.ToString(CultureInfo.InvariantCulture);
            }

            if (e.KeyChar == '.')
            {
                Calculator.PressAction(Action.Point);
                TextBoxResult.Text = Calculator.CurrentValue.ToString(CultureInfo.InvariantCulture) + ".";
            }
        }

        /// <summary>
        /// Реализует сохранение результата в буфер обмена
        /// </summary>
        private void TextBoxResult_TextChanged(object sender, EventArgs e)
        {
            Clipboard.SetText(TextBoxResult.Text);
        }
    }
}

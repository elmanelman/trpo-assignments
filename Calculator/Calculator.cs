using System;

namespace Calculator
{
    /// <summary>
    /// Действия калькулятора
    /// </summary>
    public enum Action
    {
        ClearEntry, Evaluate, Point, Add, Subtract, Multiply, Divide
    }

    /// <summary>
    /// Реализация сущности "последовательный калькулятор"
    /// </summary>
    public class Calculator
    {
        public double PreviousValue { get; private set; }
        public double CurrentValue { get; private set; }
        public double Result { get; private set; }
        public Action? Operator { get; private set; }
        public bool IsEvaluated { get; private set; }

        private bool HasPoint { get; set; }
        private int DigitsAfterPoint { get; set; }

        public void PressDigit(int digit)
        {
            IsEvaluated = false;

            if (digit >= 0 && digit <= 9)
            {
                if (HasPoint)
                {
                    CurrentValue += digit / Math.Pow(10, DigitsAfterPoint++);
                }
                else
                {
                    CurrentValue = 10 * CurrentValue + digit;
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(digit), digit, "digit must be in the range from 0 to 9");
            }
        }

        public void PressAction(Action action)
        {
            switch (action)
            {
                case Action.ClearEntry:
                    if (IsEvaluated)
                    {
                        PreviousValue = 0.0;
                        Result = 0.0;
                        Operator = null;
                        HasPoint = false;
                        DigitsAfterPoint = 0;
                    }
                    CurrentValue = 0.0;
                    break;
                case Action.Evaluate:
                    Evaluate();
                    break;
                case Action.Point:
                    if (!HasPoint)
                    {
                        if (IsEvaluated) CurrentValue = Result;
                        HasPoint = true;
                        DigitsAfterPoint = 1;
                    }
                    break;
                case Action.Add:
                case Action.Subtract:
                case Action.Multiply:
                case Action.Divide:
                    if (action == Operator)
                    {
                        Evaluate();
                    }
                    else
                    {
                        Operator = action;
                        PreviousValue = CurrentValue;
                        CurrentValue = 0.0;
                        HasPoint = false;
                        DigitsAfterPoint = 0;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(action), action, "invalid action");
            }
        }

        private void Evaluate() 
        {
            if (Operator == null) return;
            
            if (IsEvaluated && Operator != null)
            {
                PreviousValue = Result;
            }

            switch (Operator)
            {
                case Action.Add:
                    Result = PreviousValue + CurrentValue;
                    break;
                case Action.Subtract:
                    Result = PreviousValue - CurrentValue;
                    break;
                case Action.Multiply:
                    Result = PreviousValue * CurrentValue;
                    break;
                case Action.Divide:
                    Result = PreviousValue / CurrentValue;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            IsEvaluated = true;
        }
    }
}

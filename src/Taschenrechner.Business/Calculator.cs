using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Taschenrechner.WinForms {

    public class Calculator {
        public string currentCalculationString = "";
        private readonly List<Token> currentCalculation;
        private readonly List<string> history = new List<string>(9);
        private readonly HashSet<string> Numbers = new HashSet<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        private readonly HashSet<string> Operators = new HashSet<string> { "+", "-", "*", "/", "^" };
        private readonly HashSet<string> Parenthesis = new HashSet<string> { "(", ")" };
        private string historyString = "";
        private bool lastActionWasEvaluation;

        public Calculator() {
            currentCalculation = new List<Token>();
        }

        public event EventHandler CalculationChanged;
        public event EventHandler HistoryChanged;
        public bool AddCharacter(string character) {
            if (!IsValidCharacter(character)) {
                return false;
            }

            if (lastActionWasEvaluation && !Operators.Contains(character)) {
                currentCalculation.Clear();
            }

            lastActionWasEvaluation = false;

            var lastToken = currentCalculation.LastOrDefault();

            if (Operators.Contains(character)) {
                if (lastToken == null || lastToken.Type == Token.TokenType.Operator) {
                    return false;
                }
                currentCalculation.Add(new Token(character, true));
                OnCalculationChanged();
                return true;
            }

            if (Parenthesis.Contains(character)) {
                if (lastToken?.Type == Token.TokenType.Number && character == "(") {
                    currentCalculation.Add(new Token("*", true));
                }
                currentCalculation.Add(new Token(character, true, true));
                OnCalculationChanged();
                return true;
            }

            if (lastToken?.Type == Token.TokenType.Number) {
                currentCalculation[currentCalculation.Count - 1] = new Token(lastToken.NumberString + character);
            }
            else {
                currentCalculation.Add(new Token(character));
            }
            OnCalculationChanged();
            return true;
        }

        public bool AddDecimalPoint() {
            if (currentCalculation.Count > 0 && currentCalculation[currentCalculation.Count - 1].Type == Token.TokenType.Number) {
                var lastToken = currentCalculation[currentCalculation.Count - 1];
                if (!lastToken.NumberString.Contains(".")) {
                    var newNumberString = lastToken.NumberString + ".";
                    currentCalculation[currentCalculation.Count - 1] = new Token(newNumberString);
                    OnCalculationChanged();
                    return true;
                }
            }
            else {
                currentCalculation.Add(new Token("0."));
                OnCalculationChanged();
                return true;
            }
            return false;
        }

        public void AppendHistory(string result) {
            history.Insert(0, result);
            if (history.Count > 9) {
                history.RemoveAt(9);
            }
            historyString = string.Join("\r\n", history);
            OnHistoryChanged();
        }

        public bool Backspace() {
            if (!currentCalculation.Any() || lastActionWasEvaluation) {
                Clear();
                return false;
            }

            var lastToken = currentCalculation[currentCalculation.Count - 1];

            if (lastToken.Type == Token.TokenType.Number) {
                var newNumberString = lastToken.NumberString.Remove(lastToken.NumberString.Length - 1);
                if (string.IsNullOrEmpty(newNumberString)) {
                    currentCalculation.RemoveAt(currentCalculation.Count - 1);
                }
                else {
                    currentCalculation[currentCalculation.Count - 1] = new Token(newNumberString);
                }
            }
            else {
                currentCalculation.RemoveAt(currentCalculation.Count - 1);
            }
            OnCalculationChanged();
            return true;
        }

        public bool CE() {
            if (currentCalculation.Any()) {
                currentCalculation.RemoveAt(currentCalculation.Count - 1);
                OnCalculationChanged();
                return true;
            }
            else { return false; }
        }

        public void Clear() {
            currentCalculation.Clear();
            OnCalculationChanged();
        }

        public bool ClearHistory() {
            history.Clear();
            historyString = string.Empty;
            OnHistoryChanged();
            return true;
        }

        public string ConvertToPostfix(List<Token> infixTokens) {
            Stack<string> stack = new Stack<string>();
            StringBuilder output = new StringBuilder();

            foreach (var token in infixTokens) {
                if (token.Type == Token.TokenType.Number) {
                    output.Append(token.NumberString).Append(' ');
                }
                else if (token.Type == Token.TokenType.Operator) {
                    while (stack.Count > 0 && Operators.Contains(stack.Peek()) && GetPrecedence(token.Operator) <= GetPrecedence(stack.Peek())) {
                        output.Append(stack.Pop()).Append(' ');
                    }
                    stack.Push(token.Operator);
                }
                else if (token.Type == Token.TokenType.Parenthesis) {
                    if (token.Parenthesis == "(") {
                        stack.Push(token.Parenthesis);
                    }
                    else if (token.Parenthesis == ")") {
                        while (stack.Count > 0 && stack.Peek() != "(") {
                            output.Append(stack.Pop()).Append(' ');
                        }
                        stack.Pop();
                    }
                }
            }

            while (stack.Count > 0) {
                output.Append(stack.Pop()).Append(' ');
            }

            return output.ToString().Trim();
        }

        public void Evaluate() {
            if (currentCalculation.Any()) {
                try {
                    string postfix = ConvertToPostfix(currentCalculation);
                    double result = EvaluatePostfix(postfix);
                    Clear();
                    currentCalculation.Add(new Token(result));
                    lastActionWasEvaluation = true;
                    string formattedResult = FormatNumber(result);
                    AppendHistory(formattedResult);
                    currentCalculationString = formattedResult;
                    OnCalculationChanged();
                }
                catch (DivideByZeroException) {
                    currentCalculationString = "Cannot divide by 0";
                }
                catch (InvalidOperationException) {
                    currentCalculationString = "Invalid Expression";
                }
            }
            else currentCalculationString = "";
        }

        public void GetCurrentCalculation() {
            StringBuilder sb = new StringBuilder();
            foreach (var token in currentCalculation) {
                switch (token.Type) {
                    case Token.TokenType.Number:
                        sb.Append(token.NumberString); break;
                    case Token.TokenType.Operator:
                        sb.Append(token.Operator); break;
                    case Token.TokenType.Parenthesis:
                        sb.Append(token.Parenthesis); break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            currentCalculationString = sb.ToString();
        }

        public string HistoryString(string separator) {
            return string.Join(separator, history);
        }
        public bool ToggleSign() {
            if (currentCalculation.Count > 0 && currentCalculation[currentCalculation.Count - 1].Type == Token.TokenType.Number) {
                var lastNumber = currentCalculation[currentCalculation.Count - 1].Number;
                currentCalculation[currentCalculation.Count - 1] = new Token(-lastNumber);
                OnCalculationChanged();
                return true;
            }
            return false;
        }

        protected virtual void OnCalculationChanged() {
            GetCurrentCalculation();
            CalculationChanged?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnHistoryChanged() {
            HistoryChanged?.Invoke(this, EventArgs.Empty);
        }


        private static int GetDecimalPlaces(double number) {
            string str = number.ToString("G", CultureInfo.InvariantCulture);
            int index = str.IndexOf('.');
            if (index == -1) {
                return 0;
            }
            else return str.Length - index - 1;
        }

        private double ApplyOperator(string op, double left, double right) {
            switch (op) {
                case "+":
                    return left + right;

                case "-":
                    return left - right;

                case "*":
                    return left * right;

                case "/":
                    return left / right;

                case "^":
                    return Math.Pow(left, right);

                default:
                    throw new InvalidOperationException("Invalid operator");
            }
        }

        double EvaluatePostfix(string postfix) {
            Stack<double> stack = new Stack<double>();
            string[] tokens = postfix.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string token in tokens) {
                if (double.TryParse(token, NumberStyles.Any, CultureInfo.InvariantCulture, out double number)) {
                    stack.Push(number);
                }
                else if (Operators.Contains(token)) {
                    double right = stack.Pop();
                    double left = stack.Pop();
                    if (token == "/" && right == 0) {
                        throw new DivideByZeroException("Cannot divide by zero");
                    }
                    stack.Push(ApplyOperator(token, left, right));
                }
            }
            return stack.Pop();
        }

        private string FormatNumber(double number) {
            bool useScientific = Math.Abs(number) >= 1e15 || Math.Abs(number) < 1e-2;
            string format = useScientific ? "E" : "N";
            int decimalPlaces = GetDecimalPlaces(number);
            var nfi = new NumberFormatInfo { NumberGroupSeparator = "'", NumberDecimalDigits = decimalPlaces };
            string formattedNumber = number.ToString(format, nfi);
            return formattedNumber;
        }

        private int GetPrecedence(string op) {
            return op == "+" || op == "-" ? 1 : 2;
        }

        private bool IsValidCharacter(string character) {
            return Numbers.Contains(character) || Operators.Contains(character) || Parenthesis.Contains(character);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner.WinForms {

    internal class Calculator {
        private bool lastActionWasEvaluation;
        private readonly List<Token> currentCalculation;

        public Calculator() {
            currentCalculation = new List<Token>();
        }

        public bool AddCharacter(string character) {
            if (IsValidCharacter(character)) {
                if (lastActionWasEvaluation) {
                    if (IsOperator(character)) {
                        string result = Evaluate();
                        currentCalculation.Clear();
                        currentCalculation.Add(new Token(result));
                        lastActionWasEvaluation = false;
                    }
                    else {
                        currentCalculation.Clear();
                        lastActionWasEvaluation = false;
                    }
                }
                if (IsOperator(character)) {
                    if (!currentCalculation.Any()) {
                        return false;
                    }
                    // Check if the last token is also an operator
                    if (currentCalculation.Count > 0 && currentCalculation[currentCalculation.Count - 1].Type == Token.TokenType.Operator) {
                        currentCalculation[currentCalculation.Count - 1] = new Token(character, true);
                    }
                    else {
                        // Add the operator as a new token
                        currentCalculation.Add(new Token(character, true));
                    }
                }
                else if (IsParenthesis(character)) {
                    // Add the parenthesis as a new token
                    currentCalculation.Add(new Token(character, false, true));
                }
                else {
                    // Handle numbers
                    if (currentCalculation.Count > 0 && currentCalculation[currentCalculation.Count - 1].Type == Token.TokenType.Number) {
                        var lastToken = currentCalculation[currentCalculation.Count - 1];
                        var newNumberString = lastToken.NumberString + character;
                        currentCalculation[currentCalculation.Count - 1] = new Token(newNumberString);
                    }
                    else {
                        currentCalculation.Add(new Token(character));
                    }
                }
                return true;
            }
            return false;
        }

        public bool AddDecimalPoint() {
            if (currentCalculation.Count > 0 && currentCalculation[currentCalculation.Count - 1].Type == Token.TokenType.Number) {
                var lastToken = currentCalculation[currentCalculation.Count - 1];
                if (!lastToken.NumberString.Contains(".")) {
                    var newNumberString = lastToken.NumberString + ".";
                    currentCalculation[currentCalculation.Count - 1] = new Token(newNumberString);
                    return true;
                }
            }
            else {
                currentCalculation.Add(new Token("0."));
                return true;
            }
            return false;
        }

        public bool Backspace() {
            if (currentCalculation.Any()) {
                currentCalculation.RemoveAt(currentCalculation.Count - 1);
                return true;
            }
            else { return false; }
        }

        public void Clear() {
            currentCalculation.Clear();
        }

        public string Evaluate() {
            string postfix = ConvertToPostfix(currentCalculation);
            double result = EvaluatePostfix(postfix);
            lastActionWasEvaluation = true;
            return FormatNumber(result);
        }

        public string GetCurrentCalculation() {
            List<string> parts = new List<string>();
            foreach (var token in currentCalculation) {
                parts.Add(token.ToString());
            }
            return string.Join("", parts);
        }

        public bool ToggleSign() {
            if (currentCalculation.Count > 0 && currentCalculation[currentCalculation.Count - 1].Type == Token.TokenType.Number) {
                var lastNumber = currentCalculation[currentCalculation.Count - 1].Number;
                currentCalculation[currentCalculation.Count - 1] = new Token(-lastNumber);
                return true;
            }
            return false;
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

                default:
                    throw new InvalidOperationException("Invalid operator");
            }
        }

        private string ConvertToPostfix(List<Token> infixTokens) {
            Stack<string> stack = new Stack<string>();
            List<string> output = new List<string>();

            foreach (var token in infixTokens) {
                if (token.Type == Token.TokenType.Number) {
                    output.Add(token.NumberString);
                }
                else if (token.Type == Token.TokenType.Operator) {
                    while (stack.Count > 0 && IsOperator(stack.Peek()) && GetPrecedence(token.Operator) <= GetPrecedence(stack.Peek())) {
                        output.Add(stack.Pop());
                    }
                    stack.Push(token.Operator);
                }
                else if (token.Type == Token.TokenType.Parenthesis) {
                    if (token.Parenthesis == "(") {
                        stack.Push(token.Parenthesis);
                    }
                    else {
                        while (stack.Count > 0 && stack.Peek() != "(") {
                            output.Add(stack.Pop());
                        }
                        stack.Pop(); // Remove the '(' from the stack
                    }
                }
            }

            while (stack.Count > 0) {
                output.Add(stack.Pop());
            }

            return string.Join(" ", output);
        }

        private double EvaluatePostfix(string postfix) {
            Stack<double> stack = new Stack<double>();
            string[] tokens = postfix.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string token in tokens) {
                if (double.TryParse(token, NumberStyles.Any, CultureInfo.InvariantCulture, out double number)) {
                    stack.Push(number);
                }
                else if (IsOperator(token)) {
                    double right = stack.Pop();
                    double left = stack.Pop();
                    stack.Push(ApplyOperator(token, left, right));
                }
            }

            return stack.Pop();
        }

        private string FormatNumber(double number) {
            var nfi = new NumberFormatInfo { NumberGroupSeparator = "'", NumberDecimalDigits = 0 };
            string formattedNumber = number.ToString("N", nfi);
            return formattedNumber;
        }

        private int GetPrecedence(string op) {
            return op == "+" || op == "-" ? 1 : 2;
        }

        private bool IsOperator(string character) {
            return character == "+" || character == "-" || character == "*" || character == "/";
        }

        private bool IsParenthesis(string character) {
            return character == "(" || character == ")";
        }

        private bool IsValidCharacter(string character) {
            return !string.IsNullOrEmpty(character);
        }
    }
}
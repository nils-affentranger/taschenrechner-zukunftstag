using System.Globalization;
using System;

namespace Taschenrechner {
    public class Token {
        public enum TokenType {
            Number,
            Operator
        }

        public TokenType Type { get; }
        public string NumberString { get; }
        public double Number {
            get {
                if (double.TryParse(NumberString, NumberStyles.Any, CultureInfo.InvariantCulture, out double result)) {
                    return result;
                }
                throw new ArgumentException("Invalid number string");
            }
        }
        public string Operator { get; }

        public Token(double number) {
            Type = TokenType.Number;
            NumberString = number.ToString(CultureInfo.InvariantCulture);
        }

        public Token(string numberString) {
            Type = TokenType.Number;
            NumberString = numberString;
        }

        public Token(string operatorSymbol, bool isOperator) {
            Type = TokenType.Operator;
            Operator = operatorSymbol;
        }

        public override string ToString() {
            return Type == TokenType.Number ? NumberString : Operator;
        }
    }
}

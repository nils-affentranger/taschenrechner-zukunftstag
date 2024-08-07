using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner.WinForms {
    internal class Token {
        public enum TokenType {
            Number,
            Operator
        }

        public TokenType Type { get; }
        public double Number { get; }
        public string Operator { get; }

        public Token(double number) {
            Type = TokenType.Number;
            Number = number;
        }

        public Token(string operatorSymbol) {
            Type = TokenType.Operator;
            Operator = operatorSymbol;
        }

        public override string ToString() {
            return Type == TokenType.Number ? Number.ToString() : Operator;
        }
    }
}

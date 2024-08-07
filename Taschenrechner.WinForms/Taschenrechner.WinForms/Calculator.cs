using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taschenrechner.WinForms {

    internal class Calculator {
        private string currentCalculation;

        public bool AddCharacter(string character) {
            if (IsValidCharacter(character)) {
                if (IsOperator(character) && IsOperator(currentCalculation.Last().ToString())) {
                    currentCalculation = currentCalculation.Remove(currentCalculation.Length - 1);
                }
                currentCalculation = currentCalculation + character;
                return true;
            }
            else return false;
        }

        public void Clear() {
            currentCalculation = string.Empty;
        }

        public string GetCurrentCalculation() {
            return currentCalculation;
        }

        private bool IsOperator(string character) {
            return character == "+" || character == "*" || character == "-" || character == "/";
        }

        private bool IsValidCharacter(string character) {
            if (string.IsNullOrEmpty(character)) {
                return false;
            }
            if (int.TryParse(character, out _)) {
                return true;
            }
            if (IsOperator(character)) {
                return true;
            }
            else return false;
        }
    }
}
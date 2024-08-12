using System;
using System.Windows.Forms;

namespace Taschenrechner.WinForms {

    public partial class CalculatorForm : Form {
        private readonly Calculator calculator;

        public CalculatorForm() {
            InitializeComponent();
            calculator = new Calculator();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            bool shiftPressed = (keyData & Keys.Shift) == Keys.Shift;
            Keys key = keyData & ~Keys.Shift;

            if (HandleNumericKey(key, shiftPressed) ||
                HandleOperatorKey(key, shiftPressed) ||
                HandleSpecialKey(key)) {
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private bool HandleNumericKey(Keys key, bool shiftPressed) {
            if (key >= Keys.D0 && key <= Keys.D9 || key >= Keys.NumPad0 && key <= Keys.NumPad9) {
                char digit = (char)('0' + (key & Keys.KeyCode) - (key <= Keys.D9 ? Keys.D0 : Keys.NumPad0));
                if (shiftPressed) {
                    HandleShiftedNumericKey(digit);
                }
                else {
                    AddCharacterToCalculation(digit.ToString());
                }
                return true;
            }
            return false;
        }

        private void HandleShiftedNumericKey(char digit) {
            switch (digit) {
                case '0': EvaluateExpression(); break;
                case '1': AddCharacterToCalculation("+"); break;
                case '3': AddCharacterToCalculation("*"); break;
                case '7': AddCharacterToCalculation("/"); break;
                case '8': AddCharacterToCalculation("("); break;
                case '9': AddCharacterToCalculation(")"); break;
            }
        }

        private bool HandleOperatorKey(Keys key, bool shiftPressed) {
            switch (key) {
                case Keys.Add:
                case Keys.Oemplus:
                    AddCharacterToCalculation("+");
                    return true;

                case Keys.Subtract:
                case Keys.OemMinus:
                    AddCharacterToCalculation("-");
                    return true;

                case Keys.Multiply:
                    AddCharacterToCalculation("*");
                    return true;

                case Keys.Divide:
                case Keys.OemQuestion:
                    AddCharacterToCalculation("/");
                    return true;

                default:
                    return false;
            }
        }

        private bool HandleSpecialKey(Keys key) {
            switch (key) {
                case Keys.Enter:
                    EvaluateExpression();
                    return true;

                case Keys.Delete:
                    ClearCalculation();
                    return true;

                case Keys.OemPeriod:
                    AddDecimalPoint();
                    return true;

                case Keys.Back:
                    Backspace();
                    return true;

                default:
                    return false;
            }
        }

        private void AddCharacterToCalculation(string character) {
            calculator.AddCharacter(character);
            inputLabel.Text = calculator.GetCurrentCalculation();
        }

        private void EvaluateExpression() {
            try {
                string result = calculator.Evaluate();
                inputLabel.Text = result;
                historyBox.Text = calculator.HistoryString;
            }
            catch (Exception) {
                inputLabel.Text = "Invalid Expression";
                calculator.Clear();
            }
        }

        private void ClearCalculation() {
            calculator.Clear();
            inputLabel.Text = calculator.GetCurrentCalculation();
        }

        private void AddDecimalPoint() {
            if (calculator.AddDecimalPoint()) {
                inputLabel.Text = calculator.GetCurrentCalculation();
            }
        }

        private void Backspace() {
            calculator.Backspace();
            inputLabel.Text = calculator.GetCurrentCalculation();
        }

        private void ToggleSign() {
            calculator.ToggleSign();
            inputLabel.Text = calculator.GetCurrentCalculation();
        }

        private void CE() {
            calculator.CE();
            inputLabel.Text = calculator.GetCurrentCalculation();
        }
    }

    // Implement other necessary methods (button click event handlers, etc.)
}
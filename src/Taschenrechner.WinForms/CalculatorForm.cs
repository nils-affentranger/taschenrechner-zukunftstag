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
            if (HandleSpecialKey(keyData)) {
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        protected override void OnKeyPress(KeyPressEventArgs e) {
            base.OnKeyPress(e);

            char keyChar = e.KeyChar;
            if (HandleCharacterInput(keyChar)) {
                e.Handled = true;
            }
        }

        private bool HandleCharacterInput(char keyChar) {
            if (char.IsDigit(keyChar)) {
                AddCharacterToCalculation(keyChar.ToString());
                return true;
            }

            switch (keyChar) {
                case '+':
                case '-':
                case '*':
                case '/':
                case '(':
                case ')':
                case '.':
                    AddCharacterToCalculation(keyChar.ToString());
                    return true;

                case '=':
                    EvaluateExpression();
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
            inputLabel.Text = "";
        }

        private void Backspace() {
            calculator.Backspace();
            inputLabel.Text = calculator.GetCurrentCalculation();
        }

        private void AddDecimalPoint() {
            if (calculator.AddDecimalPoint()) {
                inputLabel.Text = calculator.GetCurrentCalculation();
            }
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
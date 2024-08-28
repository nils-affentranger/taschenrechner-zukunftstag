using System;
using System.Windows.Forms;

namespace Taschenrechner.WinForms {

    public partial class CalculatorForm : Form {
        private readonly Calculator calculator;

        public CalculatorForm() {
            InitializeComponent();
            calculator = new Calculator();

            calculator.CalculationChanged += Calculator_CalculationChanged;
            calculator.HistoryChanged += Calculator_HistoryChanged;
        }

        protected override void OnKeyPress(KeyPressEventArgs e) {
            base.OnKeyPress(e);
            char keyChar = e.KeyChar;
            if (HandleCharacterInput(keyChar)) {
                e.Handled = true;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            if (HandleSpecialKey(keyData)) {
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void backButton_Click(object sender, EventArgs e) {
            tabControl1.SelectedIndex = 0;
        }

        private void Backspace() {
            calculator.Backspace();
        }

        private void button0_Click(object sender, EventArgs e) {
            calculator.AddCharacter("0");
        }

        private void button1_Click(object sender, EventArgs e) {
            calculator.AddCharacter("1");
        }

        private void button2_Click(object sender, EventArgs e) {
            calculator.AddCharacter("2");
        }

        private void button3_Click(object sender, EventArgs e) {
            calculator.AddCharacter("3");
        }

        private void button4_Click(object sender, EventArgs e) {
            calculator.AddCharacter("4");
        }

        private void button5_Click(object sender, EventArgs e) {
            calculator.AddCharacter("5");
        }
        private void button6_Click(object sender, EventArgs e) {
            calculator.AddCharacter("6");
        }

        private void button7_Click(object sender, EventArgs e) {
            calculator.AddCharacter("7");
        }

        private void button8_Click(object sender, EventArgs e) {
            calculator.AddCharacter("8");
        }

        private void button9_Click(object sender, EventArgs e) {
            calculator.AddCharacter("9");
        }

        private void buttonAdd_Click(object sender, EventArgs e) {
            calculator.AddCharacter("+");
        }

        private void buttonBackspace_Click(object sender, EventArgs e) {
            Backspace();
        }

        private void buttonC_Click(object sender, EventArgs e) {
            ClearCalculation();
        }

        private void buttonCE_Click(object sender, EventArgs e) {
            CE();
        }

        private void buttonDecimal_Click(object sender, EventArgs e) {
            calculator.AddDecimalPoint();
        }

        private void buttonDivide_Click(object sender, EventArgs e) {
            calculator.AddCharacter("/");
        }

        private void buttonEvaluate_Click(object sender, EventArgs e) {
            calculator.Evaluate();
        }

        private void buttonLeftBrace_Click(object sender, EventArgs e) {
            calculator.AddCharacter("(");
        }

        private void buttonMultiply_Click(object sender, EventArgs e) {
            calculator.AddCharacter("*");
        }

        private void buttonPlusMinus_Click(object sender, EventArgs e) {
            calculator.ToggleSign();
        }

        private void buttonPower_Click(object sender, EventArgs e) {
            calculator.AddCharacter("^");
        }

        private void buttonRightBrace_Click(object sender, EventArgs e) {
            calculator.AddCharacter(")");
        }

        private void buttonSettings_Click(object sender, EventArgs e) {
            tabControl1.SelectedIndex = 1;
        }

        private void buttonSubtract_Click(object sender, EventArgs e) {
            calculator.AddCharacter("-");
        }

        private void CE() {
            calculator.CE();
        }

        private void ClearCalculation() {
            calculator.Clear();
        }

        private bool HandleCharacterInput(char keyChar) {
            if (char.IsDigit(keyChar)) {
                calculator.AddCharacter(keyChar.ToString());
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
                    calculator.AddCharacter(keyChar.ToString());
                    return true;

                case '=':
                    calculator.Evaluate();
                    return true;

                default:
                    return false;
            }
        }

        private bool HandleSpecialKey(Keys key) {
            switch (key) {
                case Keys.Enter:
                    calculator.Evaluate();
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

        private void Calculator_CalculationChanged(object sender, EventArgs e) {
            inputLabel.Text = calculator.currentCalculationString;
        }

        private void Calculator_HistoryChanged(object sender, EventArgs e) {
            historyBox.Text = calculator.HistoryString("\r\n");
        }
    }
}
using System;
using System.Windows.Forms;

namespace Taschenrechner.WinForms {

    public partial class CalculatorForm : Form {
        private readonly Calculator calculator;

        public CalculatorForm() {
            InitializeComponent();
            calculator = new Calculator();
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
        private void AddCharacterToCalculation(string character) {
            calculator.AddCharacter(character);
            inputLabel.Text = calculator.GetCurrentCalculation();
        }

        private void AddDecimalPoint() {
            if (calculator.AddDecimalPoint()) {
                inputLabel.Text = calculator.GetCurrentCalculation();
            }
        }

        private void backButton_Click(object sender, EventArgs e) {
            tabControl1.SelectedIndex = 0;
        }

        private void Backspace() {
            calculator.Backspace();
            inputLabel.Text = calculator.GetCurrentCalculation();
        }

        private void button0_Click(object sender, EventArgs e) {
            AddCharacterToCalculation("0");
        }

        private void button1_Click(object sender, EventArgs e) {
            AddCharacterToCalculation("1");
        }

        private void button2_Click(object sender, EventArgs e) {
            AddCharacterToCalculation("2");
        }

        private void button3_Click(object sender, EventArgs e) {
            AddCharacterToCalculation("3");
        }

        private void button4_Click(object sender, EventArgs e) {
            AddCharacterToCalculation("4");
        }

        private void button5_Click(object sender, EventArgs e) {
            AddCharacterToCalculation("5");
        }
        private void button6_Click(object sender, EventArgs e) {
            AddCharacterToCalculation("6");
        }

        private void button7_Click(object sender, EventArgs e) {
            AddCharacterToCalculation("7");
        }

        private void button8_Click(object sender, EventArgs e) {
            AddCharacterToCalculation("8");
        }

        private void button9_Click(object sender, EventArgs e) {
            AddCharacterToCalculation("9");
        }

        private void buttonAdd_Click(object sender, EventArgs e) {
            AddCharacterToCalculation("+");
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
            AddDecimalPoint();
        }

        private void buttonDivide_Click(object sender, EventArgs e) {
            AddCharacterToCalculation("/");
        }

        private void buttonEvaluate_Click(object sender, EventArgs e) {
            EvaluateExpression();
        }

        private void buttonLeftBrace_Click(object sender, EventArgs e) {
            AddCharacterToCalculation("(");
        }

        private void buttonMultiply_Click(object sender, EventArgs e) {
            AddCharacterToCalculation("*");
        }

        private void buttonPlusMinus_Click(object sender, EventArgs e) {
            ToggleSign();
        }

        private void buttonPower_Click(object sender, EventArgs e) {
            AddCharacterToCalculation("^");
        }

        private void buttonRightBrace_Click(object sender, EventArgs e) {
            AddCharacterToCalculation(")");
        }

        private void buttonSettings_Click(object sender, EventArgs e) {
            tabControl1.SelectedIndex = 1;
        }

        private void buttonSubtract_Click(object sender, EventArgs e) {
            AddCharacterToCalculation("-");
        }

        private void CalculatorForm_Load(object sender, EventArgs e) {

        }

        private void CE() {
            calculator.CE();
            inputLabel.Text = calculator.GetCurrentCalculation();
        }

        private void ClearCalculation() {
            calculator.Clear();
            inputLabel.Text = "";
        }

        private void EvaluateExpression() {
            try {
                string result = calculator.Evaluate();
                inputLabel.Text = result;
                historyBox.Text = calculator.HistoryString("\r\n");
            }
            catch (Exception) {
                inputLabel.Text = "Invalid Expression";
                calculator.Clear();
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
        private void tabPage1_Click(object sender, EventArgs e) {

        }

        private void ToggleSign() {
            calculator.ToggleSign();
            inputLabel.Text = calculator.GetCurrentCalculation();
        }
    }
}
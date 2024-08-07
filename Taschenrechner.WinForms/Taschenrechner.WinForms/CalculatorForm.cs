using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taschenrechner.WinForms {
    public partial class CalculatorForm : Form {

        private Calculator calculator;

        public CalculatorForm() {
            InitializeComponent();
            calculator = new Calculator();
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            switch (keyData) {
                case Keys.D0:
                case Keys.NumPad0:
                    buttonNumber_Click(button0, EventArgs.Empty);
                    return true;
                case Keys.D1:
                case Keys.NumPad1:
                    buttonNumber_Click(button1, EventArgs.Empty);
                    return true;
                case Keys.D2:
                case Keys.NumPad2:
                    buttonNumber_Click(button2, EventArgs.Empty);
                    return true;
                case Keys.D3:
                case Keys.NumPad3:
                    buttonNumber_Click(button3, EventArgs.Empty);
                    return true;
                case Keys.D4:
                case Keys.NumPad4:
                    buttonNumber_Click(button4, EventArgs.Empty);
                    return true;
                case Keys.D5:
                case Keys.NumPad5:
                    buttonNumber_Click(button5, EventArgs.Empty);
                    return true;
                case Keys.D6:
                case Keys.NumPad6:
                    buttonNumber_Click(button6, EventArgs.Empty);
                    return true;
                case Keys.D7:
                case Keys.NumPad7:
                    buttonNumber_Click(button7, EventArgs.Empty);
                    return true;
                case Keys.D8:
                case Keys.NumPad8:
                    buttonNumber_Click(button8, EventArgs.Empty);
                    return true;
                case Keys.D9:
                case Keys.NumPad9:
                    buttonNumber_Click(button9, EventArgs.Empty);
                    return true;
                case Keys.Add:
                case Keys.Oemplus when (Control.ModifierKeys & Keys.Shift) != 0:
                    buttonOperator_Click(buttonAdd, EventArgs.Empty);
                    return true;
                case Keys.Subtract:
                case Keys.OemMinus:
                    buttonOperator_Click(buttonSubtract, EventArgs.Empty);
                    return true;
                case Keys.Multiply:
                    calculator.AddCharacter("*");
                    UpdateDisplay();
                    return true;
                case Keys.Divide:
                case Keys.OemQuestion:
                    calculator.AddCharacter("/");
                    UpdateDisplay();
                    return true;
                case Keys.Enter:
                    buttonEvaluate_Click(buttonEvaluate, EventArgs.Empty);
                    return true;
                case Keys.Delete:
                case Keys.Back:
                    buttonClear_Click(buttonClear, EventArgs.Empty);
                    return true;
                case Keys.OemPeriod:
                    buttonDecimal_Click(buttonDecimal, EventArgs.Empty);
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void buttonNumber_Click(object sender, EventArgs e) {
            Button button = sender as Button;
            if (button != null) {
                calculator.AddCharacter(button.Text);
                UpdateDisplay();
            }
        }

        private void buttonOperator_Click(object sender, EventArgs e) {
            Button button = sender as Button;
            if (button != null) {
                calculator.AddCharacter(button.Text);
                UpdateDisplay();
            }
        }

        private void buttonMultiply_Click(object sender, EventArgs e) {
            Button button = sender as Button;
            if (button != null) {
                calculator.AddCharacter("*");
                UpdateDisplay();
            }
        }

        private void buttonPlusMinus_Click(object sender, EventArgs e) {
            if (calculator.ToggleSign()) {
                UpdateDisplay();
            }
        }

        private void buttonDecimal_Click(object sender, EventArgs e) {
            if (calculator.AddDecimalPoint()) {
                UpdateDisplay();
            }
        }


        private void buttonDivide_Click(object sender, EventArgs e) {
            Button button = sender as Button;
            if (button != null) {
                calculator.AddCharacter("/");
                UpdateDisplay();
            }
        }

        private void buttonClear_Click(object sender, EventArgs e) {
            calculator.Clear();
            UpdateDisplay();
        }

        private void buttonEvaluate_Click(object sender, EventArgs e) {
            try {
                double result = calculator.Evaluate();
                inputLabel.Text = result.ToString(CultureInfo.InvariantCulture);
            }
            catch (Exception ex) {
                MessageBox.Show("Invalid expression: " + ex.Message);
            }
        }

        private void UpdateDisplay() {
            inputLabel.Text = calculator.GetCurrentCalculation();
        }
    }
}

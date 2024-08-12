using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taschenrechner.WinForms {

    public partial class CalculatorForm : Form {
        public Calculator calculator;

        public CalculatorForm() {
            InitializeComponent();
            calculator = new Calculator();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            bool shiftPressed = (keyData & Keys.Shift) == Keys.Shift;
            switch (keyData & ~Keys.Shift) {
                case Keys.D0:
                case Keys.NumPad0:
                    if (shiftPressed) {
                        buttonEvaluate_Click(buttonEvaluate, EventArgs.Empty);
                    }
                    else if (calculator.AddCharacter("0")) {
                        inputLabel.Text = Convert.ToString(calculator.GetCurrentCalculation());
                    }
                    return true;

                case Keys.D1:
                case Keys.NumPad1:
                    if (shiftPressed) {
                        buttonNumber_Click(buttonAdd, EventArgs.Empty);
                    }
                    else {
                        buttonNumber_Click(button1, EventArgs.Empty);
                    }
                    return true;

                case Keys.D2:
                case Keys.NumPad2:
                    buttonNumber_Click(button2, EventArgs.Empty);
                    return true;

                case Keys.D3:
                case Keys.NumPad3:
                    if (shiftPressed) {
                        buttonMultiply_Click(buttonMultiply, EventArgs.Empty);
                    }
                    else {
                        buttonNumber_Click(button3, EventArgs.Empty);
                    }
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
                    if (shiftPressed) {
                        buttonDivide_Click(buttonDivide, EventArgs.Empty);
                    }
                    else {
                        buttonNumber_Click(button7, EventArgs.Empty);
                    }
                    return true;

                case Keys.D8:
                case Keys.NumPad8:
                    if (shiftPressed) {
                        buttonNumber_Click(buttonLeftBrace, EventArgs.Empty);
                    }
                    else {
                        buttonNumber_Click(button8, EventArgs.Empty);
                    }
                    return true;

                case Keys.D9:
                case Keys.NumPad9:
                    if (shiftPressed) {
                        buttonNumber_Click(buttonRightBrace, EventArgs.Empty);
                    }
                    else {
                        buttonNumber_Click(button9, EventArgs.Empty);
                    }
                    return true;

                case Keys.Add:
                case Keys.Oemplus when (Control.ModifierKeys & Keys.Shift) != 0:
                    buttonNumber_Click(buttonAdd, EventArgs.Empty);
                    return true;

                case Keys.Subtract:
                case Keys.OemMinus:
                    buttonNumber_Click(buttonSubtract, EventArgs.Empty);
                    return true;

                case Keys.Multiply:
                    calculator.AddCharacter("*");
                    inputLabel.Text = Convert.ToString(calculator.GetCurrentCalculation());
                    return true;

                case Keys.Divide:
                case Keys.OemQuestion:
                    calculator.AddCharacter("/");
                    inputLabel.Text = Convert.ToString(calculator.GetCurrentCalculation());
                    return true;

                case Keys.Enter:
                    buttonEvaluate_Click(buttonEvaluate, EventArgs.Empty);
                    return true;

                case Keys.Delete:
                    buttonClear_Click(buttonCE, EventArgs.Empty);
                    return true;

                case Keys.OemPeriod:
                    buttonDecimal_Click(buttonDecimal, EventArgs.Empty);
                    return true;

                case Keys.Back:
                    buttonBackspace_Click(buttonBackspace, EventArgs.Empty);
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void buttonNumber_Click(object sender, EventArgs e) {
            Button button = sender as Button;
            if (button != null) {
                calculator.AddCharacter(button.Text);
                inputLabel.Text = Convert.ToString(calculator.GetCurrentCalculation());
            }
        }

        private void buttonMultiply_Click(object sender, EventArgs e) {
            Button button = sender as Button;
            if (button != null) {
                calculator.AddCharacter("*");
                inputLabel.Text = Convert.ToString(calculator.GetCurrentCalculation());
            }
        }

        private void buttonPlusMinus_Click(object sender, EventArgs e) {
            if (calculator.ToggleSign()) {
                inputLabel.Text = Convert.ToString(calculator.GetCurrentCalculation());
            }
        }

        private void buttonDecimal_Click(object sender, EventArgs e) {
            if (calculator.AddDecimalPoint()) {
                inputLabel.Text = Convert.ToString(calculator.GetCurrentCalculation());
            }
        }

        private void buttonDivide_Click(object sender, EventArgs e) {
            Button button = sender as Button;
            if (button != null) {
                calculator.AddCharacter("/");
                inputLabel.Text = Convert.ToString(calculator.GetCurrentCalculation());
            }
        }

        private void buttonPower_Click(object sender, EventArgs e) {
            calculator.AddCharacter("^");
            inputLabel.Text = Convert.ToString(calculator.GetCurrentCalculation());
        }

        private void buttonClear_Click(object sender, EventArgs e) {
            calculator.Clear();
            inputLabel.Text = Convert.ToString(calculator.GetCurrentCalculation());
        }

        private void buttonBackspace_Click(object sender, EventArgs e) {
            calculator.Backspace();
            inputLabel.Text = Convert.ToString(calculator.GetCurrentCalculation());
        }

        private void buttonEvaluate_Click(object sender, EventArgs e) {
            try {
                string result = calculator.Evaluate();
                inputLabel.Text = result;
                historyBox.Text = calculator.historyString;
            }
            catch (Exception ex) {
                inputLabel.Text = "Invalid Expression";
                calculator.Clear();
            }
        }

        private void buttonCE_Click(object sender, EventArgs e) {
            calculator.CE();
            inputLabel.Text = Convert.ToString(calculator.GetCurrentCalculation());
        }

        private void historyBox_Click(object sender, EventArgs e) {
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) {
        }
    }
}
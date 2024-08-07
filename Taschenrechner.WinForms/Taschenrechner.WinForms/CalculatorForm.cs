using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taschenrechner.WinForms {
    public partial class CalculatorForm : Form {

        Calculator c = new Calculator();

        public CalculatorForm() {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e) {

        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void button0_Click(object sender, EventArgs e) {
            c.AddCharacter("0");
        }

        private void button1_Click(object sender, EventArgs e) {
            c.AddCharacter("1");
        }

        private void button2_Click(object sender, EventArgs e) {
            c.AddCharacter("2");
        }

        private void button3_Click(object sender, EventArgs e) {
            c.AddCharacter("3");
        }

        private void button4_Click(object sender, EventArgs e) {
            c.AddCharacter("4");
        }

        private void button5_Click(object sender, EventArgs e) {
            c.AddCharacter("5");
        }

        private void button6_Click(object sender, EventArgs e) {
            c.AddCharacter("6");
        }

        private void button7_Click(object sender, EventArgs e) {
            c.AddCharacter("7");
        }

        private void button8_Click(object sender, EventArgs e) {
            c.AddCharacter("8");
        }

        private void button9_Click(object sender, EventArgs e) {
            c.AddCharacter("9");
        }
        private void buttonDivide_Click(object sender, EventArgs e) {
            c.AddCharacter("/");
        }
        private void buttonMultiply_Click(object sender, EventArgs e) {
            c.AddCharacter("*");
        }
        private void buttonSubtract_Click(object sender, EventArgs e) {
            c.AddCharacter("-");
        }
        private void buttonAdd_Click(object sender, EventArgs e) {
            c.AddCharacter("+");
        }
        private void buttonSolve_Click(object sender, EventArgs e) {

        }
        private void buttonDot_Click(object sender, EventArgs e) {

        }
        private void buttonPlusMinus_Click(object sender, EventArgs e) {

        }
    }
}

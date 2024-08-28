using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using Taschenrechner.WinForms;

namespace Taschenrechner.Web {

    public partial class _Default : Page {
        private Calculator _calculator;

        protected Calculator calculator {
            get {
                if (_calculator == null) {
                    _calculator = new Calculator();
                    _calculator.CalculationChanged += Calculator_CalculationChanged;
                    _calculator.HistoryChanged += Calculator_HistoryChanged;
                }
                return _calculator;
            }
        }

        protected void Button0_Click(object sender, EventArgs e) {
            AddCharacterToCalculation("0");
        }

        protected void Button1_Click(object sender, EventArgs e) {
            AddCharacterToCalculation("1");
        }

        protected void Button2_Click(object sender, EventArgs e) {
            AddCharacterToCalculation("2");
        }

        protected void Button3_Click(object sender, EventArgs e) {
            AddCharacterToCalculation("3");
        }

        protected void Button4_Click(object sender, EventArgs e) {
            AddCharacterToCalculation("4");
        }

        protected void Button5_Click(object sender, EventArgs e) {
            AddCharacterToCalculation("5");
        }

        protected void Button6_Click(object sender, EventArgs e) {
            AddCharacterToCalculation("6");
        }

        protected void Button7_Click(object sender, EventArgs e) {
            AddCharacterToCalculation("7");
        }

        protected void Button8_Click(object sender, EventArgs e) {
            AddCharacterToCalculation("8");
        }

        protected void Button9_Click(object sender, EventArgs e) {
            AddCharacterToCalculation("9");
        }

        protected void ButtonBack_Click(object sender, EventArgs e) {
            Backspace();
        }

        protected void ButtonCE_Click(object sender, EventArgs e) {
            calculator.CE();
            CalcLabel.Text = calculator.GetCurrentCalculation();
        }

        protected void ButtonDecimal_Click(object sender, EventArgs e) {
            calculator.AddDecimalPoint();
            CalcLabel.Text = calculator.GetCurrentCalculation();
        }

        protected void ButtonDivide_Click(object sender, EventArgs e) {
            AddCharacterToCalculation("/");
        }

        protected void ButtonEvaluate_Click(object sender, EventArgs e) {
            EvaluateExpression();
        }

        protected void ButtonMinus_Click(object sender, EventArgs e) {
            AddCharacterToCalculation("-");
        }

        protected void ButtonMultiply_Click(object sender, EventArgs e) {
            AddCharacterToCalculation("*");
        }

        protected void ButtonParenthesisLeft_Click(object sender, EventArgs e) {
            AddCharacterToCalculation("(");
        }

        protected void ButtonParenthesisRight_Click(object sender, EventArgs e) {
            AddCharacterToCalculation(")");
        }

        protected void ButtonPlus_Click(object sender, EventArgs e) {
            AddCharacterToCalculation("+");
        }

        protected void ButtonPower_Click(object sender, EventArgs e) {
            AddCharacterToCalculation("^");
        }

        protected void ButtonToggleSign_Click(object sender, EventArgs e) {
            calculator.ToggleSign();
            CalcLabel.Text = calculator.GetCurrentCalculation();
        }

        protected void ButtonC_Click(object sender, EventArgs e) {
            calculator.Clear();
        }

        protected void ClearHistoryButton_Click(object sender, EventArgs e) {
            calculator.ClearHistory();
        }

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                if (Session["Calculator"] == null) {
                    Session["Calculator"] = new Calculator();
                }
                ViewState["IsDarkTheme"] = false;
                _calculator = (Calculator)Session["Calculator"];
                _calculator.CalculationChanged += Calculator_CalculationChanged;
                _calculator.HistoryChanged += Calculator_HistoryChanged;
            }
            else {
                bool isDarkTheme = Convert.ToBoolean(ViewState["IsDarkTheme"]);
                string script = isDarkTheme ? "setDarkTheme();" : "setLightTheme();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "InitTheme", script, true);
                _calculator = (Calculator)Session["Calculator"];
                _calculator.CalculationChanged += Calculator_CalculationChanged;
                _calculator.HistoryChanged += Calculator_HistoryChanged;
            }

            UpdateDisplay();
        }

        private void Calculator_CalculationChanged(object sender, EventArgs e) {
            CalcLabel.Text = calculator.GetCurrentCalculation();
        }

        private void Calculator_HistoryChanged(object sender, EventArgs e) {
            HistoryBox.Text = calculator.HistoryString("<br>");
        }

        private void UpdateDisplay() {
            CalcLabel.Text = calculator.GetCurrentCalculation();
            HistoryBox.Text = calculator.HistoryString("<br>");
        }

        protected void ThemeToggle_Click(object sender, EventArgs e) {
            bool isDarkTheme = Convert.ToBoolean(ViewState["IsDarkTheme"] ?? false);
            isDarkTheme = !isDarkTheme;
            ViewState["IsDarkTheme"] = isDarkTheme;

            string script = isDarkTheme ? "setDarkTheme();" : "setLightTheme();";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ThemeScript", script, true);
        }
        private void AddCharacterToCalculation(string character) {
            calculator.AddCharacter(character);
        }

        private void Backspace() {
            calculator.Backspace();
        }

        private void EvaluateExpression() {
            try {
                string result = calculator.Evaluate();
            }
            catch (DivideByZeroException) {
                CalcLabel.Text = "Cannot divide by 0";
            }
            catch (InvalidOperationException) {
                CalcLabel.Text = "Invalid Expression";
                calculator.Clear();
            }
        }
    }
}
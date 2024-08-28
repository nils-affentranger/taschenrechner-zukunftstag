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
            calculator.Backspace();
        }

        protected void ButtonC_Click(object sender, EventArgs e) {
            calculator.Clear();
        }

        protected void ButtonCE_Click(object sender, EventArgs e) {
            calculator.CE();
        }

        protected void ButtonDecimal_Click(object sender, EventArgs e) {
            calculator.AddDecimalPoint();
        }

        protected void ButtonDivide_Click(object sender, EventArgs e) {
            AddCharacterToCalculation("/");
        }

        protected void ButtonEvaluate_Click(object sender, EventArgs e) {
            calculator.Evaluate();
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
        }
        protected void ClearHistoryButton_Click(object sender, EventArgs e) {
            calculator.ClearHistory();
        }

        protected void Page_Init(object sender, EventArgs e) {
            if (!IsPostBack) {
                calculator.CalculationChanged += Calculator_CalculationChanged;
                calculator.HistoryChanged += Calculator_HistoryChanged;
            }
        }

        private void Calculator_CalculationChanged1(object sender, EventArgs e) {
            throw new NotImplementedException();
        }

        protected void Page_Load(object sender, EventArgs e) {

            if (Session["Calculator"] == null) {
                Session["Calculator"] = new Calculator();
            }

            _calculator = (Calculator)Session["Calculator"];

            _calculator.CalculationChanged -= Calculator_CalculationChanged;
            _calculator.HistoryChanged -= Calculator_HistoryChanged;
            _calculator.CalculationChanged += Calculator_CalculationChanged;
            _calculator.HistoryChanged += Calculator_HistoryChanged;

            if (!IsPostBack) {
                ViewState["IsDarkTheme"] = false;
            }
            else {
                bool isDarkTheme = Convert.ToBoolean(ViewState["IsDarkTheme"]);
                string script = isDarkTheme ? "setDarkTheme();" : "setLightTheme();";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "InitTheme", script, true);
            }
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

        private void Calculator_CalculationChanged(object sender, EventArgs e) {
            CalcLabel.Text = _calculator.currentCalculationString;
        }

        private void Calculator_HistoryChanged(object sender, EventArgs e) {
            HistoryBox.Text = _calculator.HistoryString("<br>");
        }
    }
}
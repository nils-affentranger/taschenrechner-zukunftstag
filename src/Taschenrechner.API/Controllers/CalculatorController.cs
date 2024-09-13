using System.Web;
using System.Web.Http;
using Taschenrechner.API.Models;
using Taschenrechner.WinForms;

namespace Taschenrechner.API.Controllers {

    public class CalculatorController : ApiController {
        private Calculator calculator = new Calculator();

        private void LoadSession() {
            if (RechnerIsInSession()) {
                calculator = (Calculator)HttpContext.Current.Session["calculator"];
            }
            else {
                calculator = new Calculator();
            }
        }

        private bool RechnerIsInSession() {
            return HttpContext.Current.Session["calculator"] != null;
        }

        private void SaveSession() {
            HttpContext.Current.Session["calculator"] = calculator;
        }

        [HttpPost]
        [Route("api/calculator/addcharacter")]
        public CurrentCalculationResponse AddCharacter(CharacterInput request) {
            LoadSession();
            calculator.AddCharacter(request.Character);
            SaveSession();
            return new CurrentCalculationResponse(calculator.currentCalculationString);
        }

        [HttpPost]
        [Route("api/calculator/evaluate")]
        public CurrentCalculationResponse Evaluate() {
            LoadSession();
            calculator.Evaluate();
            SaveSession();
            return new CurrentCalculationResponse(calculator.currentCalculationString);
        }

        [HttpPost]
        [Route("api/calculator/evaluatepretty")]
        public CurrentCalculationResponse EvaluatePretty() {
            LoadSession();
            calculator.EvaluatePretty();
            SaveSession();
            return new CurrentCalculationResponse(calculator.currentCalculationString);
        }

        [HttpPost]
        [Route("api/calculator/clear")]
        public CurrentCalculationResponse Clear() {
            LoadSession();
            calculator.Clear();
            SaveSession();
            return new CurrentCalculationResponse(calculator.currentCalculationString);
        }

        [HttpPost]
        [Route("api/calculator/clearentry")]
        public CurrentCalculationResponse ClearEntry() {
            LoadSession();
            calculator.CE();
            SaveSession();
            return new CurrentCalculationResponse(calculator.currentCalculationString);
        }

        [HttpPost]
        [Route("api/calculator/backspace")]
        public CurrentCalculationResponse BackSpace() {
            LoadSession();
            calculator.Backspace();
            SaveSession();
            return new CurrentCalculationResponse(calculator.currentCalculationString);
        }

        [HttpPost]
        [Route("api/calculator/clearhistory")]
        public HistoryResponse ClearHistory() {
            LoadSession();
            calculator.ClearHistory();
            SaveSession();
            return new HistoryResponse(calculator.HistoryString(", "));
        }

        [HttpGet]
        [Route("api/calculator/getcalculation")]
        public CurrentCalculationResponse GetCalculation() {
            LoadSession();
            return new CurrentCalculationResponse(calculator.currentCalculationString);
        }

        [HttpPost]
        [Route("api/calculator/gethistory")]
        public HistoryResponse GetHistory(HistorySeparator separator) {
            LoadSession();
            return new HistoryResponse(calculator.HistoryString(separator.Separator));
        }

        [HttpPost]
        [Route("api/calculator/togglesign")]
        public CurrentCalculationResponse ToggleSign() {
            LoadSession();
            calculator.ToggleSign();
            SaveSession();
            return new CurrentCalculationResponse(calculator.currentCalculationString);
        }

        [HttpPost]
        [Route("api/calculator/adddecimalpoint")]
        public CurrentCalculationResponse AddDecimalPoint() {
            LoadSession();
            calculator.AddDecimalPoint();
            SaveSession();
            return new CurrentCalculationResponse(calculator.currentCalculationString);
        }
    }
}
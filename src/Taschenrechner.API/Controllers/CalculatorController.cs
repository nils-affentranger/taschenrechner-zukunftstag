using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Taschenrechner.WinForms;

namespace Taschenrechner.API.Controllers {
    public class CalculatorController : ApiController {
        private static readonly Calculator _calculator = new Calculator();

        [HttpPost]
        [Route("api/calculator/addcharacter")]
        public IHttpActionResult AddCharacter([FromBody] string character) {
            bool success = _calculator.AddCharacter(character);
            return Ok(new { success, currentCalculation = _calculator.currentCalculationString });
        }

        [HttpPost]
        [Route("api/calculator/evaluate")]
        public IHttpActionResult Evaluate() {
            _calculator.Evaluate();
            return Ok(new { result = _calculator.currentCalculationString });
        }

        [HttpPost]
        [Route("api/calculator/clear")]
        public IHttpActionResult Clear() {
            _calculator.Clear();
            return Ok(new { currentCalculation = _calculator.currentCalculationString });
        }

        [HttpPost]
        [Route("api/calculator/clearhistory")]
        public IHttpActionResult ClearHistory() {
            _calculator.ClearHistory();
            return Ok(_calculator.HistoryString(", "));
        }

        [HttpGet]
        [Route("api/calculator/getcalculation")]
        public IHttpActionResult GetCalculation() {
            return Ok(_calculator.currentCalculationString);
        }

        [HttpGet]
        [Route("api/calculator/gethistory")]
        public IHttpActionResult GetHistory() {
            return Ok(_calculator.HistoryString(", "));
        }

        [HttpPost]
        [Route("api/calculator/togglesign")]
        public IHttpActionResult ToggleSign() {
            bool success = _calculator.ToggleSign();
            return Ok(new { success, currentCalculation = _calculator.currentCalculationString });
        }

        [HttpPost]
        [Route("api/calculator/adddecimalpoint")]
        public IHttpActionResult AddDecimalPoint() {
            bool success = _calculator.AddDecimalPoint();
            return Ok(new { success, currentCalculation = _calculator.currentCalculationString });
        }

        [HttpPost]
        [Route("api/calculator/backspace")]
        public IHttpActionResult Backspace() {
            bool success = _calculator.Backspace();
            return Ok(new { success, currentCalculation = _calculator.currentCalculationString });
        }
    }
}
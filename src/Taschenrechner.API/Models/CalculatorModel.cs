using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taschenrechner.WinForms;

namespace Taschenrechner.API.Models {
    public class CharacterInput {
        public string Character { get; set; }
    }

    public class CurrentCalculationResponse {
        public string Response { get; set; }

        public CurrentCalculationResponse(string response) {
            Response = response;
        }
    }

    public class HistoryResponse {
        public string Response { get; set; }

        public HistoryResponse(string response) {
            Response = response;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Taschenrechner.WinForms;

namespace Taschenrechner.API.Models {
        public class CharacterInput {
            public string Character { get; set; }
        }

        public class CalculationResponse {
            public bool Success { get; set; }
            public string CurrentCalculation { get; set; }
        }

        public class EvaluationResponse {
            public string Result { get; set; }
        }

        public class HistoryResponse {
            public string History { get; set; }
        }
}
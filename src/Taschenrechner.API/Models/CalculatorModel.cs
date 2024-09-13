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

    public class HistorySeparator {
        public string Separator { get; set; }
    }

    public class HistoryResponse {
        public string Response { get; set; }

        public HistoryResponse(string response) {
            Response = response;
        }
    }

    public class NumberInput {
        public int Number { get; set; }
    }
}
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RateQuoteApplication.Models
{
    public class GetRateQuoteResponse
    {
        public List<RateQuote> RateQuote { get; set; }
        public int Code { get; set; }
        public List<Error> Errors { get; set; }
        public List<string> Messages { get; set; }
    }
}
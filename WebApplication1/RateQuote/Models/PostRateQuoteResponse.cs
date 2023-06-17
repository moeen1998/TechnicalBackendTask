using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateQuoteApplication.Models
{
    public class PostRateQuoteResponse
    {
        public int Code { get; set; }
        public List<Error> Errors { get; set; }
        public List<string> Messages { get; set; }
        public RateQuote RateQuote { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateQuoteApplication.Models
{
    public class CategorizedMessage
    {
        public List<string> GeneralMessages { get; set; }
        public List<string> TransitMessages { get; set; }
        public List<string> RatesMessages { get; set; }
    }
}

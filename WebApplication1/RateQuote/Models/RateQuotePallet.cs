using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateQuoteApplication.Models
{
    public class RateQuotePallet
    {
        public string Code { get; set; }
        public int Weight { get; set; } = 0;
        public int Quantity { get; set; } = 0;
    }
}

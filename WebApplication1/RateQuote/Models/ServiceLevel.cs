using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateQuoteApplication.Models
{
    public class ServiceLevel
    {
        public string? QuoteNumber { get; set; }
        public int ServiceDays { get; set; }
        public string? Charge { get; set; }
        public string? NetCharge { get; set; }
        public HourlyWindow? HourlyWindow { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
    }
}

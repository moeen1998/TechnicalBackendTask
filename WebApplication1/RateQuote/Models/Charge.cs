using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateQuoteApplication.Models
{
    public class Charge
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string Weight { get; set; }
        public string Rate { get; set; }
        public string Amount { get; set; }
    }
}

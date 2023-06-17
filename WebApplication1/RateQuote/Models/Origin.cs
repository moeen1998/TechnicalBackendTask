using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateQuoteApplication.Models
{
    public class Origin
    {
        public string City { get; set; }
        public string StateOrProvince { get; set; }
        public string ZipOrPostalCode { get; set; }
        public string CountryCode { get; set; } = "USA";
    }
}

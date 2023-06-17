using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RateQuoteApplication.Models
{
    public  class Error
    {
        public string Property { get; set; }
        public string ErrorMessage { get; set; }
        public string ExceptionMessage { get; set; }
    }
}

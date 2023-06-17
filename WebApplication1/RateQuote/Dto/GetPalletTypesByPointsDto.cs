using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateQuoteApplication.Dto
{
    public class GetPalletTypesByPointsDto
    {
        public string originCity { get; set; }
        public string originZip { get; set; }
        public string destinationCity { get; set; }
        public string destinationZip { get; set; }
        
    }
}

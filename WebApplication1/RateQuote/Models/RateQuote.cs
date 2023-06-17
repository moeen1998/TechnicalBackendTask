using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateQuoteApplication.Models
{
    public class RateQuote
    {
        public Origin Origin { get; set; }

        public OriginServiceCenter? OriginServiceCenter { get; set; }
        public OriginServiceCenter? DestinationServiceCenter { get; set; }
        public string? CustomerDiscounts { get; set; }
        public List<Charge>? Charges { get; set; }
        public List<ServiceLevel>? ServiceLevels { get; set; }
        public CategorizedMessage? CategorizedMessages { get; set; }
        public string? Ocean { get; set; }

        public Destination Destination { get; set; }
        public List<Item> Items { get; set; }
        public string? PickupDate { get; set; }
        public int CODAmount { get; set; } = 0;
        public int DeclaredValue { get; set; } = 0;
        public List<RateQuotePallet>? Pallets { get; set; }
        public List<string>? AdditionalServices { get; set; }
        public List<OverDimension>? OverDimensions { get; set; }

        public int Code { get; set; }
        public List<Error>? Errors { get; set; }
        public List<string>? Messages { get; set; }

    }
}

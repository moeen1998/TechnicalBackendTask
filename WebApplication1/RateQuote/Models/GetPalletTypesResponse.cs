namespace RateQuoteApplication.Models
{
    public class GetPalletTypesResponse
    {
        public List<Pallet> PalletTypes { get; set; }
        public int Code { get; set; }
        public List<Error> Errors { get; set; }
        public List<string> Messages { get; set; }
    }
}
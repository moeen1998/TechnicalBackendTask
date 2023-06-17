using RateQuoteApplication.Dto;
using RateQuoteApplication.Models;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace RateQuoteApplication
{
    public class RateQuoteSample
    {

        public string apiKey { get; set; }
        public string baseurl { get; set; } = "https://api.rlc.com/";
        public RateQuoteSample(string ApiKey)
        {
            apiKey = ApiKey;
        }
        
        //done 4
        //Post
        public PostRateQuoteResponse PostRateQuote(PostRateQuoteRequest Request)
        {
            var request = Request ?? new PostRateQuoteRequest()
            {
                RateQuote = PopulateRateQuote()
            };

            var response = new PostRateQuoteResponse();
            var url = $"{baseurl}/RateQuote";
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Add("apiKey", apiKey);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var apiResponse = client.PostAsJsonAsync(url, request).Result;
                response = apiResponse.Content.ReadAsAsync<PostRateQuoteResponse>().Result;
            }
            return response;

        }
        private RateQuote PopulateRateQuote()
        {
            var origin = new Origin()
            {
                City = "Wilmington",
                StateOrProvince = "OH",
                ZipOrPostalCode = "45177",
                CountryCode = "USA"
            };
            var destination = new Destination()
            {
                City = "Ocala",
                StateOrProvince = "FL",
                ZipOrPostalCode = "34471",
                CountryCode = "USA"
            };
            var item = new Item()
            {
                Class = "60",
                Weight = 300
            };
            var rateQuote = new RateQuote()
            {
                Origin = origin,
                Destination = destination,
                Items = new() { item }
            };
            return rateQuote;
        }

        //done 3
        //GET
        public GetRateQuoteResponse GetRateQuote(string QuoteNumber)
        {
            var response = new GetRateQuoteResponse();
            var quoteNumber = QuoteNumber ?? "11111111";
            var url = string.Format($"{baseurl}/RateQuote?QuoteNumber={quoteNumber}");

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("apiKey", apiKey);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var apiResponse = client.GetAsync(url).Result;
                response = apiResponse.Content.ReadAsAsync<GetRateQuoteResponse>().Result;
            }
            return response;
        }

        //done 2
        //GET
        public GetPalletTypesResponse GetPalletTypesByPoints(GetPalletTypesByPointsDto dto)
        {
            var response = new GetPalletTypesResponse();
            var url = $"{baseurl}/RateQuote/GetPalletTypesByPoints";
            var originCity = dto.originCity ?? "Wilmington";
            var originZip = dto.originZip ?? "45177";
            var destinationCity = dto.destinationCity ?? "Ocala";
            var destinationZip = dto.destinationZip ?? "34471";
            url += "?OriginCity=" + originCity + "&OriginZip=" + originZip + "&DestinationCity=" + destinationCity + "&DestinationZip=" + destinationZip;
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("apiKey", apiKey);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var apiResponse = client.GetAsync(url).Result;
                response = apiResponse.Content.ReadAsAsync<GetPalletTypesResponse>().Result;
            }
            return response;
        }

        //done 1
        //GET
        public GetPalletTypesResponse GetPalletTypes()
        {
            var response = new GetPalletTypesResponse();
            var url = $"{baseurl}/RateQuote/GetPalletTypes";
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("apiKey", apiKey);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var apiResponse = client.GetAsync(url).Result;
                response = apiResponse.Content.ReadAsAsync<GetPalletTypesResponse>().Result;
            }
            return response;
        }
    }
}
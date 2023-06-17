using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RateQuoteApplication;
using RateQuoteApplication.Dto;
using RateQuoteApplication.Models;
using WebApplication1.Services;


namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RateQuoteController : ControllerBase
    {
        private RateQuoteSample rqs { get; set; }

        public RateQuoteController()
        {
            rqs = new RateQuoteSample( ApiKey : "YtM2MThzE3M1JiNjMtMWNhNi00MDA5LWEzMjZTQ0MkN2NzQjC");
        }

        [HttpGet("GetPalletTypes")]
        public IActionResult GetPalletTypes()
        {
            return Ok(rqs.GetPalletTypes());
        }

        [HttpPost("GetPalletTypesByPoints")]
        public IActionResult GetPalletTypesByPoints(GetPalletTypesByPointsDto dto)
        {
            if (!ModelState.IsValid) { return BadRequest("invalid data"); }

            return Ok(rqs.GetPalletTypesByPoints(dto) );
        }

        [HttpGet("GetRateQuote")]
        public IActionResult GetRateQuote(string QuoteNumber)
        {
            if (!ModelState.IsValid) { return BadRequest(new { msg = "invalid data" }); }

            return Ok(rqs.GetRateQuote(QuoteNumber));
        }

        [HttpPost("PostRateQuote")]
        public IActionResult PostRateQuote(PostRateQuoteRequest PostRateQuoteRequestDto)
        {
            if (!ModelState.IsValid) { return BadRequest("invalid data"); }

            return Ok(rqs.PostRateQuote(PostRateQuoteRequestDto));
        }
    }
}

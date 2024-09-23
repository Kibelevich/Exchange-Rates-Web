using BL.API;
using BL.Implementation;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeRatesController : ControllerBase
    {
        private readonly IExchangeRateService exchangeRateService;

        public ExchangeRatesController(IExchangeRateService exchangeRateService)
        {
            this.exchangeRateService = exchangeRateService;
        }

        // GET: api/ExchangeRates/5
        [HttpGet("{baseCode}")]
        public ActionResult<ExchangeRate> GetExchangeRate(string baseCode)
        {
            try
            {
                ExchangeRate exchangeRate = exchangeRateService.Get(baseCode);
                return Ok(exchangeRate);
            }
            catch (HttpRequestException ex)
            when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

    }
}

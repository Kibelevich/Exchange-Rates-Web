using Microsoft.AspNetCore.Mvc;
using DAL.Models;
using BL.API;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        private readonly ICurrencyService currencyService;
        public CurrenciesController(ICurrencyService currencyService)
        {
            this.currencyService = currencyService;
        }
        // GET: api/Currencies
        [HttpGet]
        public ActionResult<List<Currency>> GetCurrencies()
        {
            try
            {
                List<Currency> currencies = currencyService.GetAll();
                return Ok(currencies);
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

using Microsoft.AspNetCore.Mvc;
using DAL.Models;
using BL.API;
using BL.Implementation;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController(CurrencyService service) : ControllerBase
    {
        private readonly ICurrencyService currencyService = service;

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

using backend.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class CurrencyController : ControllerBase
{
    private readonly ExchangeRateService _exchangeRateService;

    public CurrencyController(ExchangeRateService exchangeRateService)
    {
        _exchangeRateService = exchangeRateService;
    }

    [HttpGet]
    public async Task<ActionResult<List<string>>> GetAvailableCurrencies()
    {
        try
        {
            var currencies = await _exchangeRateService.GetAvailableCurrencies();
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

    [HttpGet("{currency}")]
    public async Task<ActionResult<Dictionary<string, decimal>>> GetExchangeRates(string currency)
    {
        try
        {
            var exchangeRates = await _exchangeRateService.GetExchangeRates(currency.ToUpper());
            return Ok(exchangeRates);
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
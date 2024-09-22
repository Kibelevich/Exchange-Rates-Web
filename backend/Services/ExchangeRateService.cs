using backend.Models;

namespace backend.Services;

public class ExchangeRateService
{
    private readonly HttpClient _client;

    public ExchangeRateService(HttpClient client)
    {
        _client = client;
        _client.BaseAddress = new Uri("https://v6.exchangerate-api.com");
    }

    public async Task<List<string>> GetAvailableCurrencies()
    {
        ExchangeRates response = await _client.GetFromJsonAsync<ExchangeRates>("/v6/016119487a4fbe75f94a4941/latest/USD")
            ?? throw new HttpRequestException("No currencies found", null, System.Net.HttpStatusCode.NotFound);
        if (response.conversion_rates == null || response.conversion_rates.Count == 0)
        {
            throw new HttpRequestException("No currencies found", null, System.Net.HttpStatusCode.NotFound);
        }

        return [.. response.conversion_rates.Keys];
    }

    public async Task<Dictionary<string, decimal>> GetExchangeRates(string baseCurrency)
    {
        ExchangeRates response = await _client.GetFromJsonAsync<ExchangeRates>($"/v6/016119487a4fbe75f94a4941/latest/{baseCurrency}")
            ?? throw new HttpRequestException("No exchange rates found", null, System.Net.HttpStatusCode.NotFound);
        if (response == null || response.conversion_rates == null || response.conversion_rates.Count == 0)
        {
            throw new HttpRequestException("No exchange rates found", null, System.Net.HttpStatusCode.NotFound);
        }

        return response.conversion_rates;
    }
}




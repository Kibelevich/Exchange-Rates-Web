using BL.API;
using DAL.Implementation;
using DAL.Models;


namespace BL.Implementation;

public class ExchangeRateService : IExchangeRateService
{
    private readonly ExchangeRatesRepo exchangeRatesRepo = new();
    public ExchangeRate Get(string baseCode)
    {
        ExchangeRate? exchangeRates;
        try
        {
            exchangeRates = exchangeRatesRepo.Get(baseCode);
        }catch (Exception ex)
        {
            throw new HttpRequestException(ex.Message, null, System.Net.HttpStatusCode.InternalServerError);
        }
        if (exchangeRates == null ||
            exchangeRates.ConversionRates == null || 
            exchangeRates.BaseCode == null)
            throw new HttpRequestException("No exchange rates found", null, System.Net.HttpStatusCode.NotFound);
        return exchangeRates;
    }
}

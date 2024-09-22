using DAL.Models;

namespace DAL.API;

internal interface IExchangeRatesRepo
{
    public ExchangeRate? Get(string baseCode);
}

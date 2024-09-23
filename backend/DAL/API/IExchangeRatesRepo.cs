using DAL.Models;

namespace DAL.API;

public interface IExchangeRatesRepo
{
    public ExchangeRate? Get(string baseCode);
}

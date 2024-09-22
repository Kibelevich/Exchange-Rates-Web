using DAL.Models;
namespace BL.API;

public interface IExchangeRateService
{
    public ExchangeRate Get(string baseCode);

}

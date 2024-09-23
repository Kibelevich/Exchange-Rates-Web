using BL.API;
using DAL.Implementation;
using DAL.Models;

namespace BL.Implementation;

public class CurrencyService : ICurrencyService
{
    private readonly CurrenciesRepo currenciesRepo;
    public CurrencyService(CurrenciesRepo currenciesRepo)
    {
        this.currenciesRepo = currenciesRepo;
    }
    public List<Currency> GetAll()
    {
        List<Currency> currencies;
        currencies = currenciesRepo.GetAll() ??
        throw new HttpRequestException("No currencies found", null, System.Net.HttpStatusCode.NotFound);
        return currencies;
    }
}

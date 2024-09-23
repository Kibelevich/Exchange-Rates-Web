using DAL.API;
using DAL.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DAL.Implementation;

public class CurrenciesRepo : ICurrenciesRepo
{
    public List<Currency>? GetAll()
    {
        List<string> currencies = ["USD", "EUR", "GBP", "CNY", "ILS"];
        return currencies.Select(currency=> new Currency(currency)).ToList();
    }
}

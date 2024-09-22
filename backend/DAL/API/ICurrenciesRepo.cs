using DAL.Models;

namespace DAL.API;

public interface ICurrenciesRepo
{
    public List<Currency>? GetAll();
}

using DAL.Models;

namespace BL.API;
public interface ICurrencyService
{
    public List<Currency> GetAll();
}

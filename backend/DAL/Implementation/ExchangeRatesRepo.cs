using DAL.API;
using DAL.Models;
using Newtonsoft.Json;

namespace DAL.Implementation;

public class ExchangeRatesRepo : IExchangeRatesRepo
{

    public ExchangeRate? Get(string baseCode)
    {
        string URL = $"https://v6.exchangerate-api.com/v6/016119487a4fbe75f94a4941/latest/{baseCode}";
        using System.Net.WebClient webClient = new();
        var json = webClient.DownloadString(URL);
        API_Obj api_obj = JsonConvert.DeserializeObject<API_Obj>(json) ??
            throw new Exception("No exchange rates found");
        return new ExchangeRate(api_obj.base_code, api_obj.conversion_rates);
    }
}

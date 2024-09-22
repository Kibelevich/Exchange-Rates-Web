namespace DAL.Models;

public class ExchangeRate(string baseCode, ConversionRate? conversionRates)
{
    public string BaseCode { get; set; } = baseCode;
    public ConversionRate? ConversionRates { get; set; } = conversionRates;
}

using System.Text.Json.Serialization;

namespace cube_practice.Models;

public class CurrencyDetailResponse
{
    [JsonPropertyName("code")] 
    public string Code { get; set; }
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; }
    [JsonPropertyName("rate")]
    public string Rate { get; set; }
    [JsonPropertyName("description")]
    public string Description { get; set; }
    [JsonPropertyName("rate-float")]
    public string RateFloat { get; set; }

    public CurrencyDetail ToCurrencyDetail(List<CurrencyNameDomain> currencyNameDomains)
    {
        return new CurrencyDetail
        {
            Code = Code,
            ChineseName = currencyNameDomains.First(xx=> xx.Code == Code).ChineseName,
            Rate = Rate
        };
    }
}
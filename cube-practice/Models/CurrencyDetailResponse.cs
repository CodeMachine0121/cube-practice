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
        var currencyNameDomain = currencyNameDomains.FirstOrDefault(xx=> xx.Code == Code);

        return new CurrencyDetail
        {
            Code = Code,
            ChineseName = currencyNameDomain?.ChineseName ?? "not-found",
            Rate = Rate
        };
    }
}
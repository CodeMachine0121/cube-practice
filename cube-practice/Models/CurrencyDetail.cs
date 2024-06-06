using System.Text.Json.Serialization;

namespace cube_practice.Models;

public class CurrencyDetail
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
   
}
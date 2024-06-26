using System.Text.Json.Serialization;
using cube_practice.Controllers;

namespace cube_practice.Models;

public class CurrencyRateResponse
{
    [JsonPropertyName("time")]
    public UpdateTime Time { get; set; }
    [JsonPropertyName("disclaimer")]
    public string Disclaimer { get; set; }
    [JsonPropertyName("chartName")]
    public string chartName { get; set; }
    [JsonPropertyName("bpi")]
    public Dictionary<string, CurrencyDetailResponse> Bpi { get; set; }
}
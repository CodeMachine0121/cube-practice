using System.Text.Json.Serialization;

namespace cube_practice.Models;

public class UpdateTime
{
    [JsonPropertyName("updated")]
    public string Updated { get; set; }
    [JsonPropertyName("updatedISO")]
    public DateTime UpdatedIso { get; set; }
    [JsonPropertyName("updateduk")]
    public string UpdatedUk { get; set; }
}
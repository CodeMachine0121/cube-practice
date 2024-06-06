using cube_practice.Controllers;

namespace cube_practice.Models;

public class CurrenctPrice
{
    public UpdateTime Time { get; set; }
    public string Disclaimer { get; set; }
    public string chartName { get; set; }
    public Dictionary<string, CurrencyDetail> Bpi { get; set; }
}
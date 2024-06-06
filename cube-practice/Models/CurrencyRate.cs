namespace cube_practice.Models;

public class CurrencyRate
{
    public DateTime UpdatedOn { get; set; }
    public List<CurrencyDetail> Detail { get; set; }
}
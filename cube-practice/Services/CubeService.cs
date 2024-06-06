using cube_practice.Models;
using cube_practice.Proxies.Interfaces;

namespace cube_practice.Services;

public class CubeService(ICubeProxy cubeProxy)
{

    public async Task<CurrencyRate> GetCoinDesk()
    {
        var currencyRateResponse = await cubeProxy.GetCoinDesk();
        
        
        return  new CurrencyRate
        {
            UpdatedOn = currencyRateResponse.Time.UpdatedIso,
            Detail = currencyRateResponse.Bpi.Values.Select(x=> new CurrencyDetail
            {
                Code = x.Code,
                ChineseName = "",
                Rate = x.Rate
            }).ToList()
        };
    }
}
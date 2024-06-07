using cube_practice.Models;
using cube_practice.Proxies.Interfaces;
using cube_practice.Repositories.Interfaces;
using cube_practice.Services.Interfaces;

namespace cube_practice.Services;

public class CubeService(ICubeProxy cubeProxy, ICubeRepository cubeRepository) : ICubeService
{

    public async Task<CurrencyRate> GetCoinDesk()
    {
        var currencyRateResponse = await cubeProxy.GetCoinDesk();
        var currencyNameDomains = await cubeRepository.Fetch();


        return  new CurrencyRate
        {
            UpdatedOn = currencyRateResponse.Time.UpdatedIso,
            Detail = currencyRateResponse.Bpi.Values.Select(x=> x.ToCurrencyDetail(currencyNameDomains)).ToList()
        };
    }

}
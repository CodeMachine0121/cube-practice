using cube_practice.Models;

namespace cube_practice.Proxies.Interfaces;

public interface ICubeProxy
{
    Task<CurrencyRateResponse> GetCoinDesk();
}
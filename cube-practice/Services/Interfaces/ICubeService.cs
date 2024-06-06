using cube_practice.Models;

namespace cube_practice.Services.Interfaces;

public interface ICubeService
{
    Task<CurrencyRate> GetCoinDesk();
}
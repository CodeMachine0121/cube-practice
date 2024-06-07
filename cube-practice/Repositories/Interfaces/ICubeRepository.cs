using cube_practice.Models;

namespace cube_practice.Repositories.Interfaces;

public interface ICubeRepository
{
    Task<List<CurrencyNameDomain>> Fetch();
    Task Insert(CurrencyNameApiDto currencyNameApiDto);
    Task Update(CurrencyNameApiDto currencyNameApiDto);
    Task DeleteBy(int id);
    Task<CurrencyNameDomain> FetchBy(int id);
}
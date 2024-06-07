using cube_practice.Models;

namespace cube_practice.Repositories.Interfaces;

public interface ICubeRepository
{
    List<CurrencyNameDomain> Fetch();
    void Insert(CurrencyNameApiDto currencyNameApiDto);
    void Update(CurrencyNameApiDto currencyNameApiDto);
    void DeleteBy(int id);
    CurrencyNameDomain FetchBy(int id);
}
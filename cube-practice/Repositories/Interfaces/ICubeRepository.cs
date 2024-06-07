using cube_practice.Models;

namespace cube_practice.Repositories.Interfaces;

public interface ICubeRepository
{
    List<CurrencyNameDomain> Fetch();
    void Insert(CurrencyNameApiDto currencyNameApiDto);
}
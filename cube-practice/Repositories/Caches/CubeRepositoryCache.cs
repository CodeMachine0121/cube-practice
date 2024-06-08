using cube_practice.Models;
using cube_practice.Repositories.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace cube_practice.Repositories.Caches;

public class CubeRepositoryCache(ICubeRepository cubeRepository, IMemoryCache memoryCache) : ICubeRepository
{
    public async Task<List<CurrencyNameDomain>> Fetch()
    {
        return (await memoryCache.GetOrCreateAsync($"{nameof(CubeRepositoryCache)}- {nameof(Fetch)}",
            entry => cubeRepository.Fetch()))!;
    }

    public Task Insert(CurrencyNameApiDto currencyNameApiDto)
    {
        throw new NotImplementedException();
    }

    public Task Update(CurrencyNameApiDto currencyNameApiDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteBy(int id)
    {
        throw new NotImplementedException();
    }

    public Task<CurrencyNameDomain> FetchBy(int id)
    {
        throw new NotImplementedException();
    }
}
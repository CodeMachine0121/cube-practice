using cube_practice.Models;
using cube_practice.Repositories.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace cube_practice.Repositories.Caches;

public class CubeRepositoryCache(ICubeRepository cubeRepository, IMemoryCache memoryCache) : ICubeRepository
{
    public async Task<List<CurrencyNameDomain>> Fetch()
    {
        return (await memoryCache.GetOrCreateAsync($"{nameof(CubeRepositoryCache)}- {nameof(Fetch)}",
            entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromMinutes(10);
                return cubeRepository.Fetch();
            }))!;
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

    public async Task<CurrencyNameDomain> FetchBy(int id)
    {
        return (await memoryCache.GetOrCreateAsync($"{nameof(CubeRepositoryCache)}- {nameof(FetchBy)}",
            entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromMinutes(10);
                return cubeRepository.FetchBy(id);
            }))!;
    }
}
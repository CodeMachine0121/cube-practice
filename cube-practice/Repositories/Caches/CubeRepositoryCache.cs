using cube_practice.Models;
using cube_practice.Repositories.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace cube_practice.Repositories.Caches;

public class CubeRepositoryCache(ICubeRepository cubeRepository, IMemoryCache memoryCache) : ICubeRepository
{
    public async Task<List<CurrencyNameDomain>> Fetch()
    {
        var currencyNameDomains = await memoryCache.GetOrCreateAsync($"{nameof(CubeRepositoryCache)}-{nameof(Fetch)}",
            entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromMinutes(10);
                return cubeRepository.Fetch();
            });
        return currencyNameDomains!;
    }

    public async Task Insert(CurrencyNameApiDto currencyNameApiDto)
    {
        await cubeRepository.Insert(currencyNameApiDto);
        memoryCache.Remove($"{nameof(CubeRepositoryCache)}-{nameof(Fetch)}");
    }

    public async Task Update(CurrencyNameApiDto currencyNameApiDto)
    {
        await cubeRepository.Update(currencyNameApiDto);
        memoryCache.Remove($"{nameof(CubeRepositoryCache)}-{nameof(FetchBy)}-{currencyNameApiDto.Id}");
        memoryCache.Remove($"{nameof(CubeRepositoryCache)}-{nameof(ICubeRepository.Fetch)}");
    }

    public async Task DeleteBy(int id)
    {
        await cubeRepository.DeleteBy(id);
        memoryCache.Remove($"{nameof(CubeRepositoryCache)}-{nameof(Fetch)}");
        memoryCache.Remove($"{nameof(CubeRepositoryCache)}-{nameof(FetchBy)}-{id}");
    }

    public async Task<CurrencyNameDomain> FetchBy(int id)
    {
        return (await memoryCache.GetOrCreateAsync($"{nameof(CubeRepositoryCache)}-{nameof(FetchBy)}-{id}",
            entry =>
            {
                entry.SlidingExpiration = TimeSpan.FromMinutes(10);
                return cubeRepository.FetchBy(id);
            }))!;
    }
}
using cube_practice.Models;
using cube_practice.Repositories.Caches;
using cube_practice.Repositories.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using NSubstitute;
using NUnit.Framework;

namespace UnitTests.Caches;

[TestFixture]
public class CubeRepositoryCacheTests
{
    private ICubeRepository? _cubeRepository;
    private CubeRepositoryCache _cubeRepositoryCache;
    private IMemoryCache? _memoryCache;

    [SetUp]
    public void SetUp()
    {
        _cubeRepository = Substitute.For<ICubeRepository>();
        _memoryCache = Substitute.For<IMemoryCache>();

        _cubeRepositoryCache = new CubeRepositoryCache(_cubeRepository, _memoryCache);
    }

    [Test]
    public async Task should_get_by_repository()
    {
        await _cubeRepositoryCache.Fetch();
        await _cubeRepository.Received()!.Fetch();
    }

    [Test]
    public async Task should_get_by_cache()
    {
        await _cubeRepositoryCache!.Fetch();

        await _memoryCache.Received()!.GetOrCreateAsync<List<CurrencyNameDomain>>(Arg.Any<string>(),
            x => _cubeRepository!.Fetch());
    }
}
using cube_practice.Proxies.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace UnitTests.Services;

[TestFixture]
public class CubeServiceTests
{

    private ICubeProxy? _cubeProxy;
    private CubeService _cubeService;

    [SetUp]
    public void SetUp()
    {
        _cubeProxy = Substitute.For<ICubeProxy>();
        _cubeService = new CubeService(_cubeProxy);
    }

    [Test]
    public async Task should_get_data_by_proxy()
    {
        await _cubeService.GetCoinDesk();
        await _cubeProxy.Received()!.GetCoinDesk();
    }
}

public class CubeService(ICubeProxy cubeProxy)
{

    public async Task GetCoinDesk()
    {
        await cubeProxy.GetCoinDesk();
    }
}
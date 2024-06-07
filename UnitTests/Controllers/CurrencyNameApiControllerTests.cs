using cube_practice.Controllers;
using cube_practice.Enums;
using cube_practice.Models;
using cube_practice.Repositories.Interfaces;
using FluentAssertions;
using NSubstitute;
using NSubstitute.Core;
using NUnit.Framework;

namespace UnitTests.Controllers;

[TestFixture]
public class CurrencyNameApiControllerTests
{
    private ICubeRepository? _cubeRepository;
    private CurrencyNameApiController _currencyNameApiController;

    [SetUp]
    public void SetUp()
    {
        _cubeRepository = Substitute.For<ICubeRepository>();
        _currencyNameApiController = new CurrencyNameApiController(_cubeRepository);
    }

    [Test]
    public async Task should_get_by_repo()
    {
        GivenCurrencyDomains(
            new CurrencyNameDomain()
        );

        var apiResponse = await _currencyNameApiController.Fetch();

        apiResponse.Status.Should().Be(ApiStatus.Success);
        apiResponse.Data!.GetType().Should().Be(typeof(List<CurrencyNameDomain>));
    }

    [Test]
    public async Task should_insert_by_repo()
    {
        var apiResponse = await _currencyNameApiController.Insert(new CurrencyNameApiRequest()
        {
            Code = "any-currency-code",
            ChinessName = "any-chinese-name",
            Operator = "any-operator"
        });
        
        await _cubeRepository.Received()!.Insert(Arg.Any<CurrencyNameApiDto>());
        apiResponse.Status.Should().Be(ApiStatus.Success);
    }

    [Test]
    public async Task should_update_by_repo()
    {
        var apiResponse = await _currencyNameApiController.Update(new CurrencyNameApiRequest(), 1);

        await _cubeRepository.Received()!.Update(Arg.Any<CurrencyNameApiDto>());
        
        apiResponse.Status.Should().Be(ApiStatus.Success);
    }

    [Test]
    public async Task should_delete_by_repo()
    {
        var apiResponse = await _currencyNameApiController.Delete(1);

        await _cubeRepository.Received()!.DeleteBy(1);
        
        apiResponse.Status.Should().Be(ApiStatus.Success);
    }

    [Test]
    public async Task should_get_by_id()
    {
        _cubeRepository!.FetchBy(Arg.Any<int>()).Returns(new CurrencyNameDomain());
        
        var apiResponse = await _currencyNameApiController.FetchById(1);
        
        await _cubeRepository.Received()!.FetchBy(Arg.Any<int>());
        apiResponse.Status.Should().Be(ApiStatus.Success);
        apiResponse.Data!.GetType().Should().Be(typeof(CurrencyNameDomain));
    }

    private void GivenCurrencyDomains(params CurrencyNameDomain[] currencyNameDomains)
    {
        _cubeRepository!.Fetch().Returns(currencyNameDomains.ToList());
    }
}
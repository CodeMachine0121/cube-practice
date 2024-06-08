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
    private CurrencyNameController _currencyNameController;

    [SetUp]
    public void SetUp()
    {
        _cubeRepository = Substitute.For<ICubeRepository>();
        _currencyNameController = new CurrencyNameController(_cubeRepository);
    }

    [Test]
    public async Task should_get_by_repo()
    {
        GivenCurrencyDomains(
            new CurrencyNameDomain()
        );

        var apiResponse = await _currencyNameController.Fetch();

        apiResponse.Status.Should().Be(ApiStatus.Success);
        apiResponse.Data!.GetType().Should().Be(typeof(List<CurrencyNameDomain>));
    }

    [Test]
    public async Task should_insert_by_repo()
    {
        var apiResponse = await _currencyNameController.Insert(new CurrencyNameApiRequest()
        {
            Code = "any-currency-code",
            ChineseName = "any-chinese-name",
            Operator = "any-operator"
        });
        
        await _cubeRepository.Received()!.Insert(Arg.Any<CurrencyNameApiDto>());
        apiResponse.Status.Should().Be(ApiStatus.Success);
    }

    [Test]
    public async Task should_update_by_repo()
    {
        var apiResponse = await _currencyNameController.Update(new CurrencyNameApiRequest(), 1);

        await _cubeRepository.Received()!.Update(Arg.Any<CurrencyNameApiDto>());
        
        apiResponse.Status.Should().Be(ApiStatus.Success);
    }

    [Test]
    public async Task should_delete_by_repo()
    {
        var apiResponse = await _currencyNameController.Delete(1);

        await _cubeRepository.Received()!.DeleteBy(1);
        
        apiResponse.Status.Should().Be(ApiStatus.Success);
    }

    [Test]
    public async Task should_get_by_id()
    {
        _cubeRepository!.FetchBy(Arg.Any<int>()).Returns(new CurrencyNameDomain());
        
        var apiResponse = await _currencyNameController.FetchById(1);
        
        await _cubeRepository.Received()!.FetchBy(Arg.Any<int>());
        apiResponse.Status.Should().Be(ApiStatus.Success);
        apiResponse.Data!.GetType().Should().Be(typeof(CurrencyNameDomain));
    }

    private void GivenCurrencyDomains(params CurrencyNameDomain[] currencyNameDomains)
    {
        _cubeRepository!.Fetch().Returns(currencyNameDomains.ToList());
    }
}
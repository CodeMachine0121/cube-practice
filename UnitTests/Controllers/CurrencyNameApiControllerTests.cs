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
    public void should_get_by_repo()
    {
        GivenCurrencyDomains(
            new CurrencyNameDomain()
        );

        var apiResponse = _currencyNameApiController.Fetch();

        apiResponse.Status.Should().Be(ApiStatus.Success);
        apiResponse.Data!.GetType().Should().Be(typeof(List<CurrencyNameDomain>));
    }

    private void GivenCurrencyDomains(params CurrencyNameDomain[] currencyNameDomains)
    {
        _cubeRepository!.Fetch().Returns(currencyNameDomains.ToList());
    }
}
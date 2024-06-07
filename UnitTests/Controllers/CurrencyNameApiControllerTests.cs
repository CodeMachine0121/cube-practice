using cube_practice.Models;
using cube_practice.Repositories.Interfaces;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace UnitTests.Controllers;

[TestFixture]
public class CurrencyNameApiControllerTests
{
    [Test]
    public void should_get_by_repo()
    {
        var cubeRepository = Substitute.For<ICubeRepository>();
        cubeRepository.Fetch().Returns(new List<CurrencyNameDomain>()
        {
            new()
        });
        var currencyNameApiController = new CurrencyNameApiController(cubeRepository);
        var apiResponse = currencyNameApiController.Fetch();
        
        cubeRepository.Received().Fetch();
        
        apiResponse.Status.Should().Be(ApiStatus.Success);
        apiResponse.Data!.GetType().Should().Be(typeof(List<CurrencyNameDomain>));
        
    }
}

public class CurrencyNameApiController(ICubeRepository cubeRepository)
{
    public ApiResponse Fetch()
    {
        var currencyNameDomains = cubeRepository.Fetch();
        return new ApiResponse()
        {
            Status = ApiStatus.Success,
            Data = currencyNameDomains
        };
    }
}

public class ApiResponse
{

    public ApiStatus Status { get; set; }
    public object Data { get; set; }
}

public enum ApiStatus
{
    Success,
    Fail
}
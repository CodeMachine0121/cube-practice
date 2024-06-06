using cube_practice.Models;
using cube_practice.Proxies.Interfaces;
using cube_practice.Services;
using FluentAssertions;
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
    public async Task should_get_data_with_domain_type()
    {
        var updatedOn = DateTime.Now;

        _cubeProxy!.GetCoinDesk().Returns(new CurrencyRateResponse
        {
            Time = new UpdateTime
            {
                UpdatedIso = updatedOn,
            },
            Bpi = new Dictionary<string, CurrencyDetailResponse>()
            {
                {"any-currency-code", new CurrencyDetailResponse
                    {
                        Code = "any-currency-code",
                        Symbol = "&any",
                        Rate = "any-rate",
                        RateFloat = "any-flow-rate" 
                    }
                },
            } 
        });
        var coinDesk = await _cubeService.GetCoinDesk();

        coinDesk.Should().BeEquivalentTo(new CurrencyRate()
        {
            UpdatedOn = updatedOn,
            Detail = new List<CurrencyDetail>()
            {
                new()
                {
                    Code = "any-currency-code",
                    ChineseName = "",
                    Rate = "any-rate"
                }
            }
        });
    }

}
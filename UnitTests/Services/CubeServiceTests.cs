using cube_practice.Models;
using cube_practice.Proxies.Interfaces;
using cube_practice.Services;
using FluentAssertions;
using NSubstitute;
using NSubstitute.Core;
using NUnit.Framework;

namespace UnitTests.Services;

[TestFixture]
public class CubeServiceTests
{

    private ICubeProxy? _cubeProxy;
    private CubeService _cubeService;
    private DateTime _updatedOn;

    [SetUp]
    public void SetUp()
    {
        _cubeProxy = Substitute.For<ICubeProxy>();
        _cubeService = new CubeService(_cubeProxy);
        _updatedOn = DateTime.Now;
    }

    [Test]
    public async Task should_get_data_with_domain_type()
    {
        GivenCoinDesk(new Dictionary<string, CurrencyDetailResponse>()
        {
            {"any-currency-code", new CurrencyDetailResponse
                {
                    Code = "any-currency-code",
                    Symbol = "&any",
                    Rate = "any-rate",
                    RateFloat = "any-flow-rate" 
                }
            },
        });
        
        var coinDesk = await _cubeService.GetCoinDesk();
        
        coinDesk.Should().BeEquivalentTo(new CurrencyRate()
        {
            UpdatedOn = _updatedOn,
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

    private void GivenCoinDesk(Dictionary<string, CurrencyDetailResponse> bpi)
    {
        _cubeProxy!.GetCoinDesk().Returns(CreateCurrencyRateResponse(bpi));
    }

    private CurrencyRateResponse CreateCurrencyRateResponse( Dictionary<string, CurrencyDetailResponse> bpi)
    {
        return new CurrencyRateResponse
        {
            Time = new UpdateTime
            {
                UpdatedIso = _updatedOn,
            },
            Bpi = bpi 
        };
    }

}
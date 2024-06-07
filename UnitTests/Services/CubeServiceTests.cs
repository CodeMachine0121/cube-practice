using cube_practice.Models;
using cube_practice.Proxies.Interfaces;
using cube_practice.Repositories.Interfaces;
using cube_practice.Services;
using FluentAssertions;
using NSubstitute;

namespace UnitTests.Services;

[TestFixture]
public class CubeServiceTests
{
    private ICubeProxy? _cubeProxy;
    private ICubeRepository? _cubeRepository;
    private CubeService _cubeService;
    private DateTime _updatedOn;

    [SetUp]
    public void SetUp()
    {
        _cubeProxy = Substitute.For<ICubeProxy>();
        _cubeRepository = Substitute.For<ICubeRepository>();

        _cubeService = new CubeService(_cubeProxy, _cubeRepository);
        _updatedOn = DateTime.Now;
    }

    [Test]
    public async Task should_get_data_with_domain_type()
    {
        GivenCoinDesk(new Dictionary<string, CurrencyDetailResponse>()
        {
            {
                "any-currency-code", new CurrencyDetailResponse
                {
                    Code = "any-currency-code",
                    Symbol = "&any",
                    Rate = "any-rate",
                    RateFloat = "any-flow-rate"
                }
            },
        });

        GivenCurrencyNames(
            new CurrencyNameDomain()
            {
                Code = "any-currency-code",
                ChineseName = "any-chinese-name"
            }
        );

        var coinDesk = await _cubeService.GetCoinDesk();

        coinDesk.Should().BeEquivalentTo(new CurrencyRate()
        {
            UpdatedOn = _updatedOn,
            Detail = new List<CurrencyDetail>()
            {
                new()
                {
                    Code = "any-currency-code",
                    ChineseName = "any-chinese-name",
                    Rate = "any-rate"
                }
            }
        });
    }

    [Test]
    public async Task should_get_not_found_chinese_name_when_db_no_exist_data()
    {
        GivenCoinDesk(new Dictionary<string, CurrencyDetailResponse>()
        {
            {
                "any-currency-code", new CurrencyDetailResponse
                {
                    Code = "any-currency-code",
                    Symbol = "&any",
                    Rate = "any-rate",
                    RateFloat = "any-flow-rate"
                }
            },
        });

        GivenCurrencyNames(
            new CurrencyNameDomain()
            {
                Code = "any-currency-code2",
                ChineseName = "any-chinese-name2"
            }
        );

        var coinDesk = await _cubeService.GetCoinDesk();

        coinDesk.Should().BeEquivalentTo(new CurrencyRate()
        {
            UpdatedOn = _updatedOn,
            Detail = new List<CurrencyDetail>()
            {
                new()
                {
                    Code = "any-currency-code",
                    ChineseName = "not-found",
                    Rate = "any-rate"
                }
            }
        });
    }

    [Test]
    public async Task should_get_data_with_order()
    {
        GivenCoinDesk(new Dictionary<string, CurrencyDetailResponse>()
        {
            {
                "any-currency-code2", new CurrencyDetailResponse
                {
                    Code = "any-currency-code2",
                }
            },
            {
                "any-currency-code1", new CurrencyDetailResponse
                {
                    Code = "any-currency-code1",
                }
            }
        });

        GivenCurrencyNames(
            new CurrencyNameDomain()
            {
                Code = "any-currency-code2",
                ChineseName = "any-chinese-name2"
            },
            new CurrencyNameDomain()
            {
                Code = "any-currency-code1",
                ChineseName = "any-chinese-name1"
            }
        );

        var coinDesk = await _cubeService.GetCoinDesk();

        coinDesk.Detail.First().Should().BeEquivalentTo(new CurrencyDetail()
        {
            Code = "any-currency-code1",
            ChineseName = "any-chinese-name1",
        });
    }

    private void GivenCurrencyNames(params CurrencyNameDomain[] currencyNameDomains)
    {
        _cubeRepository!.Fetch().Returns(currencyNameDomains.ToList());
    }

    private void GivenCoinDesk(Dictionary<string, CurrencyDetailResponse> bpi)
    {
        _cubeProxy!.GetCoinDesk().Returns(CreateCurrencyRateResponse(bpi));
    }

    private CurrencyRateResponse CreateCurrencyRateResponse(Dictionary<string, CurrencyDetailResponse> bpi)
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
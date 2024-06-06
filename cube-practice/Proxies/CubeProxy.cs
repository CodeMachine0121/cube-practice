using System.Text.Json;
using cube_practice.Controllers;
using cube_practice.Models;
using cube_practice.Proxies.Interfaces;

namespace cube_practice.Proxies;

public class CubeProxy(HttpClient httpClient) : ICubeProxy
{

    public async Task<CurrencyRateResponse> GetCoinDesk()
    {
        var getAsync = await httpClient.GetAsync("/v1/bpi/currentprice.json");
        getAsync.EnsureSuccessStatusCode();

        var response = await getAsync.Content.ReadAsStreamAsync();

        return (await JsonSerializer.DeserializeAsync<CurrencyRateResponse>(response))!;
    }
}
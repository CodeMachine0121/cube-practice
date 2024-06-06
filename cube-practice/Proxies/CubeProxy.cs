using cube_practice.Controllers;
using cube_practice.Models;
using cube_practice.Proxies.Interfaces;

namespace cube_practice.Proxies;

public class CubeProxy(HttpClient httpClient) : ICubeProxy
{

    public CurrenctPrice GetCoinDesk()
    {
        return new CurrenctPrice();
    }
}
using cube_practice.Enums;
using cube_practice.Models;
using cube_practice.Repositories.Interfaces;

namespace cube_practice.Controllers;

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
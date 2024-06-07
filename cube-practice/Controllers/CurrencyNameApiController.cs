using cube_practice.Enums;
using cube_practice.Models;
using cube_practice.Repositories.Interfaces;

namespace cube_practice.Controllers;

public class CurrencyNameApiController(ICubeRepository cubeRepository)
{
    public ApiResponse Fetch()
    {
        var currencyNameDomains = cubeRepository.Fetch();
        return ApiResponse.SuccessWithData(currencyNameDomains);
    }


    public ApiResponse Insert(CurrencyNameApiRequest request)
    {
        cubeRepository.Insert(new CurrencyNameApiDto()
        {
            Code = request.Code,
            ChineseName = request.ChinessName
        });
        
        return ApiResponse.Success();
    }

    public ApiResponse Update(CurrencyNameApiRequest request)
    {
        cubeRepository.Update(new CurrencyNameApiDto()
        {
           Id = request.Id,
           ChineseName = request.ChinessName,
           Code = request.Code
        });
        
        return ApiResponse.Success();
    }

    public ApiResponse Delete(int id)
    {
        cubeRepository.DeleteBy(id);
        return ApiResponse.Success();
    }
}
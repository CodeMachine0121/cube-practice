using cube_practice.Models;
using cube_practice.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cube_practice.Controllers;

[Route("api/[controller]")]
public class CurrencyNameApiController(ICubeRepository cubeRepository)
{
    [HttpGet]
    public ApiResponse Fetch()
    {
        var currencyNameDomains = cubeRepository.Fetch();
        return ApiResponse.SuccessWithData(currencyNameDomains);
    }


    [HttpPost]
    public ApiResponse Insert(CurrencyNameApiRequest request)
    {
        cubeRepository.Insert(new CurrencyNameApiDto()
        {
            Code = request.Code,
            ChineseName = request.ChinessName
        });
        
        return ApiResponse.Success();
    }

    [HttpPatch]
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

    [HttpDelete("/{id}")]
    public ApiResponse Delete(int id)
    {
        cubeRepository.DeleteBy(id);
        return ApiResponse.Success();
    }
}
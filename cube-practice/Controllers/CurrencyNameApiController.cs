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
    public ApiResponse Insert([FromBody] CurrencyNameApiRequest request)
    {
        cubeRepository.Insert(new CurrencyNameApiDto()
        {
            Code = request.Code,
            ChineseName = request.ChinessName,
            Operator = request.Operator
        });
        
        return ApiResponse.Success();
    }

    [HttpPatch("/{id}")]
    public ApiResponse Update([FromBody] CurrencyNameApiRequest request, int id)
    {
        cubeRepository.Update(new CurrencyNameApiDto()
        {
           Id = id,
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

    [HttpGet("/{id}")]
    public ApiResponse FetchById(int id)
    {
        var currencyNameDomain = cubeRepository.FetchBy(id);
        return ApiResponse.SuccessWithData(currencyNameDomain);
    }
}
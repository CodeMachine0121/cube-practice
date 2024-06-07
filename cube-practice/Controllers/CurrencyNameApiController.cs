using cube_practice.Models;
using cube_practice.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace cube_practice.Controllers;

[Route("api/[controller]")]
public class CurrencyNameApiController(ICubeRepository cubeRepository)
{
    [HttpGet]
    public async Task<ApiResponse> Fetch()
    {
        var currencyNameDomains = await cubeRepository.Fetch();
        return ApiResponse.SuccessWithData(currencyNameDomains);
    }


    [HttpPost]
    public async Task<ApiResponse> Insert([FromBody] CurrencyNameApiRequest request)
    {
        await cubeRepository.Insert(new CurrencyNameApiDto()
        {
            Code = request.Code,
            ChineseName = request.ChinessName,
            Operator = request.Operator
        });
        
        return ApiResponse.Success();
    }

    [HttpPatch("/{id}")]
    public async Task<ApiResponse> Update([FromBody] CurrencyNameApiRequest request, int id)
    {
        await cubeRepository.Update(new CurrencyNameApiDto()
        {
            Id = id,
            ChineseName = request.ChinessName,
            Code = request.Code
        });
        
        return ApiResponse.Success();
    }

    [HttpDelete("/{id}")]
    public async Task<ApiResponse> Delete(int id)
    {
        await cubeRepository.DeleteBy(id);
        return ApiResponse.Success();
    }

    [HttpGet("/{id}")]
    public async Task<ApiResponse> FetchById(int id)
    {
        var currencyNameDomain = await cubeRepository.FetchBy(id);
        return ApiResponse.SuccessWithData(currencyNameDomain);
    }
}
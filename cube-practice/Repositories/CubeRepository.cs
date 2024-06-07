using cube_practice.DataBase;
using cube_practice.DataBase.Entities;
using cube_practice.Models;
using cube_practice.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace cube_practice.Repositories;

public class CubeRepository(CubeDbContext cubeDbContext) : ICubeRepository
{
    private readonly DbSet<CurrencyName> _currencyNames = cubeDbContext.CurrencyNames;

    public List<CurrencyNameDomain> Fetch()
    {
        return _currencyNames.Select(x=> new CurrencyNameDomain()
        {
            ChineseName = x.ChineseName,
            Code = x.Code
        }).ToList();
    }
}
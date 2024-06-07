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

    public void Insert(CurrencyNameApiDto currencyNameApiDto)
    {
        _currencyNames.Add(new CurrencyName
        {
            CreatedOn = DateTime.Now,
            CreatedBy = currencyNameApiDto.Operator,
            Code = currencyNameApiDto.Code,
            ChineseName = currencyNameApiDto.ChineseName
        });

        cubeDbContext.SaveChanges();
    }

    public void Update(CurrencyNameApiDto currencyNameApiDto)
    {
    }

    public void DeleteBy(int id)
    {
        
    }

    public CurrencyNameDomain FetchBy(int id)
    {
        return new CurrencyNameDomain();
    }
}
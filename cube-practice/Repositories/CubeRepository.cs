using cube_practice.DataBase;
using cube_practice.DataBase.Entities;
using cube_practice.Models;
using cube_practice.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace cube_practice.Repositories;

public class CubeRepository(CubeDbContext cubeDbContext) : ICubeRepository
{
    private readonly DbSet<CurrencyName> _currencyNames = cubeDbContext.CurrencyNames;

    public async Task<List<CurrencyNameDomain>> Fetch()
    {
        return await _currencyNames.Select(x => new CurrencyNameDomain()
        {
            Id = x.Id,
            ChineseName = x.ChineseName,
            Code = x.Code
        }).ToListAsync();
    }

    public async Task Insert(CurrencyNameApiDto currencyNameApiDto)
    {
        await _currencyNames.AddAsync(new CurrencyName
        {
            CreatedOn = DateTime.Now,
            CreatedBy = currencyNameApiDto.Operator,
            Code = currencyNameApiDto.Code,
            ChineseName = currencyNameApiDto.ChineseName
        });

        cubeDbContext.SaveChanges();
    }

    public async Task Update(CurrencyNameApiDto currencyNameApiDto)
    {
        var target = await _currencyNames.FirstAsync(x => x.Id == currencyNameApiDto.Id);
        target.ChineseName = currencyNameApiDto.ChineseName;
        target.Code = currencyNameApiDto.Code;
        await cubeDbContext.SaveChangesAsync();
    }

    public async Task DeleteBy(int id)
    {
        var target = await _currencyNames.FirstAsync(x => x.Id == id);
        _currencyNames.Remove(target);
        await cubeDbContext.SaveChangesAsync();
    }

    public async Task<CurrencyNameDomain> FetchBy(int id)
    {
        var target = await _currencyNames.FirstOrDefaultAsync(x => x.Id == id);

        return new CurrencyNameDomain()
        {
            Id = target?.Id ?? -1,
            ChineseName = target?.ChineseName ?? "",
            Code = target?.Code ?? ""
        };
    }
}
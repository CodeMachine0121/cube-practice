using cube_practice.DataBase.Entities;
using cube_practice.Models;
using Microsoft.EntityFrameworkCore;

namespace cube_practice.DataBase;

public class CubeDbContext(DbContextOptions<CubeDbContext> contextOptions): DbContext(contextOptions)
{
    public DbSet<CurrencyName> CurrencyName { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CurrencyName>().HasKey(x=> x.Id);
    }
}
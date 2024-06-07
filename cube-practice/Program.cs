using cube_practice.Controllers;
using cube_practice.DataBase;
using cube_practice.Proxies;
using cube_practice.Proxies.Interfaces;
using cube_practice.Repositories;
using cube_practice.Repositories.Interfaces;
using cube_practice.Services;
using cube_practice.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();


builder.Services.AddHttpClient<ICubeProxy, CubeProxy>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("CoinDeskUrl")!);
});


builder.Services.AddDbContext<CubeDbContext>(options =>
{
    var connectionString = builder.Configuration.GetValue<string>("Sql");
    connectionString = connectionString!.Replace("${DB_NAME}", Environment.GetEnvironmentVariables()["DB_NAME"]!.ToString());
    connectionString = connectionString!.Replace("${DB_USER}", Environment.GetEnvironmentVariables()["DB_USER"]!.ToString());
    connectionString = connectionString!.Replace("${DB_PASS}", Environment.GetEnvironmentVariables()["DB_PASS"]!.ToString());
    
    options.UseSqlServer(connectionString);
}, ServiceLifetime.Transient);



builder.Services.AddTransient<ICubeRepository, CubeRepository>();
builder.Services.AddTransient<ICubeService, CubeService>();


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.MapControllers();
app.Run();
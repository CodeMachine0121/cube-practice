using cube_practice.DataBase;
using cube_practice.Middlewares;
using cube_practice.Proxies;
using cube_practice.Proxies.Interfaces;
using cube_practice.Repositories;
using cube_practice.Repositories.Caches;
using cube_practice.Repositories.Interfaces;
using cube_practice.Services;
using cube_practice.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConfiguration(builder.Configuration.GetSection("Logging"));
builder.Logging.SetMinimumLevel(builder.Configuration.GetValue<LogLevel>("Logging:LogLevel:Default"));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddSingleton<IMemoryCache, MemoryCache>();

builder.Services.AddHttpClient<ICubeProxy, CubeProxy>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("CoinDeskUrl")!);
});


builder.Services.AddDbContext<CubeDbContext>(options =>
{
    var connectionString = builder.Configuration.GetValue<string>("Sql");
    connectionString = connectionString.Replace("${DB_SERVER}", Environment.GetEnvironmentVariables()["DB_SERVER"]!.ToString());
    connectionString = connectionString.Replace("${DB_NAME}", Environment.GetEnvironmentVariables()["DB_NAME"]!.ToString());
    connectionString = connectionString.Replace("${DB_USER}", Environment.GetEnvironmentVariables()["DB_USER"]!.ToString());
    connectionString = connectionString.Replace("${DB_PASS}", Environment.GetEnvironmentVariables()["DB_PASS"]!.ToString());
    
    options.UseSqlServer(connectionString);
}, ServiceLifetime.Transient);



builder.Services.AddTransient<ICubeRepository, CubeRepository>();
builder.Services.Decorate<ICubeRepository, CubeRepositoryCache>();
builder.Services.AddTransient<ICubeService, CubeService>();


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<RequestLoggingMiddleware>();
app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseRouting();
app.MapControllers();
app.Run();
using cube_practice.Controllers;
using cube_practice.Proxies;
using cube_practice.Proxies.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();


builder.Services.AddHttpClient<ICubeProxy, CubeProxy>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("CoinDeskUrl"));
});


var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.MapControllers();
app.Run();
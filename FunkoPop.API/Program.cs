using FunkoMania.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

//add serilog
builder.Host.ConfigureSerilog();//Alterei aqui

builder.Services.ConfigureStartupConfiguration(builder.Configuration);

var app = builder.Build().UseStartupConfiguration();//Alterei aqui

app.Run();

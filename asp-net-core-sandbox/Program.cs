using asp_net_core_sandbox.Extensions;
using asp_net_core_sandbox.Interceptors;
using asp_net_core_sandbox.Providers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IWeatherService, WeatherService>();

builder.Services.Decorate<IWeatherService, DecoratedWeatherService>();

builder.Services.AddInterceptedSingleton<IWeatherService, WeatherService, LoggingInterceptor>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.MapControllers();

app.Run();

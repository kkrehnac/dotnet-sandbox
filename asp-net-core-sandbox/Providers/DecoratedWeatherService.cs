namespace asp_net_core_sandbox.Providers;

public class DecoratedWeatherService : IWeatherService
{
    private readonly IWeatherService _weatherService;

    public DecoratedWeatherService(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    public WeatherForecast GetForecast()
    {
        Console.WriteLine("I am a decorator!");
        return _weatherService.GetForecast();
    }
}

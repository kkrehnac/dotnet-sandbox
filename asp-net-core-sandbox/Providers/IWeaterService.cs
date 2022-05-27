namespace asp_net_core_sandbox.Providers;

public interface IWeatherService
{
    public WeatherForecast GetForecast();
}

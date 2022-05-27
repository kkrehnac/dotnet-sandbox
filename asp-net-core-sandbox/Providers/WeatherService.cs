namespace asp_net_core_sandbox.Providers;

public class WeatherService : IWeatherService
{
    public WeatherForecast GetForecast()
    {
        return new WeatherForecast()
        {
            Text = "Wonderful weather"
        };
    }
}

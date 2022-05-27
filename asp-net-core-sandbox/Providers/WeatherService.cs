namespace asp_net_core_sandbox.Providers;

public class WeatherService : IWeatherService
{
    public WeatherForecast GetForecast()
    {
        Console.WriteLine("I am bottom level service method GetForecast");
        return new WeatherForecast()
        {
            Text = "Wonderful weather"
        };
    }
}

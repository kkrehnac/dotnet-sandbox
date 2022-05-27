
using System;



using asp_net_core_sandbox.Providers;
using Microsoft.AspNetCore.Mvc;

namespace asp_net_core_sandbox.Controllers;

[Route("api/[controller]")]
public class WeatherController : ControllerBase
{




    private readonly IWeatherService _weatherService;

    public WeatherController(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    [HttpGet]
    public async Task<ActionResult<WeatherForecast>> GetWeathers()
    {
        return Ok(_weatherService.GetForecast());
    }
}

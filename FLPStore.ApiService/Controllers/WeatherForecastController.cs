using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FLPStore.ApiService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class WeatherForecastController : ControllerBase
{
    string[] summaries = ["Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"];
    [HttpGet]
    public IActionResult GetWeatherForecast()
    {
        var forecast = Enumerable.Range(1, 5).Select(index =>
       new WeatherForecast
       (
           DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
           Random.Shared.Next(-20, 55),
           summaries[Random.Shared.Next(summaries.Length)]
       ))
       .ToArray();
        return Ok(forecast);
    }
}
record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

/*
    Api Controller and Route are called 'Attributes!' (used in c#)
    These are essentially stickers or tag we can slap on a class that tell
    asp.net how to treat the class.

    [Route("[controller]")] - (the address label)
    This attribute defines where our api lives on the internet.
    [Route(...)] - Tells the server, "to get to this class, the URL must look like this..."
    "[controller]" - A smart variable (placeholder). It is a shortcut that says 
    "take the ClassName, chop off the word controller, and use what's left."
    so our WeatherForecaseController endpoint will looklike "/weatherforecast"
    Why is useful? if we change the class name, we don't have to go and find any hardcoded values which saves time
    when refactoring or making updates.

    [ApiController] - (The smart assistant)
    If we have [ApiController] we must also have the [Route()] attribute as well.
    ApiController makes the route attribute to be a requiernment. 
    3 Main Opiniated Behaviors that the ApiController attribute  let's us use on our controller classes.
    1) Automatic Validation - It automatically checks your data against the rules (like "Price must be a number")
        If the data is bad, it instantly sends a 400 error. You don't have to write code to check if the data is valid.
        (Saving a lot of time.)
        Example: The API expects a number (e.g. ID: 4) but the user sends text (ID: "apple")
        With [ApiController], the API automatically stops the request and sends a 400 bad request error before it reaches the code.
        Without [ApiController], you have to write an if statement to check if the data is valid, and then manually return an error.
    2) Parameter Source Inference - It automatically figures out where your data is hiding. For example, if we ask for an id, it assumes the
        data is coming from the URL. If we ask for a Pizza object, it assumes it's in the JSON body.
    3) Attribute Routing Requirenment - It forces us to use the [Route(...)] attribute. This is in place to ensure that our api URLs remain
        consistent.

*/
[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }



    //Name = "GetWeatherForecast"
    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}

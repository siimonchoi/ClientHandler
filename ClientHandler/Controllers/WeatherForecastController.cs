using Microsoft.AspNetCore.Mvc;

namespace ClientHandler.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IPokedexClient pokedexClient;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IPokedexClient pokedexClient)
        {
            _logger = logger;
            this.pokedexClient = pokedexClient;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var pokemon = this.pokedexClient.GetPokemonAsync("pikachu").Result;

            var s = pokemon.Name;


            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
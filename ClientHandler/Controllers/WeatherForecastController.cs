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
        private readonly IPokedexClient1 pokedexClient;
        private readonly IPokedexClient2 pokedexClient2;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IPokedexClient1 pokedexClient, IPokedexClient2 pokedexClient2)
        {
            _logger = logger;
            this.pokedexClient = pokedexClient;
            this.pokedexClient2 = pokedexClient2;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var pokemon = this.pokedexClient.GetPokemonAsync("pikachu").Result;
            var s = pokemon.ResponseHeader;

            var pokemon2 = this.pokedexClient2.GetPokemonAsync("pikachu").Result;
            var t = pokemon2.ResponseHeader;

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
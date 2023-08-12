using System.Net;
using System.Text.Json;

namespace ClientHandler
{
    public class PokedexClient : IPokedexClient1, IPokedexClient2
    {
        private readonly HttpClient httpClient;

        public PokedexClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Pokemon> GetPokemonAsync(string name)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, $"pokemon/{name}");

            var response = await this.httpClient.SendAsync(request);

            if (response == null || response.Content == null) { throw new Exception("response is null."); }

            if (response.StatusCode == HttpStatusCode.NotFound) { throw new Exception("Not found."); }

            var content = await response!.Content.ReadAsStringAsync();

            var pokemon = JsonSerializer.Deserialize<Pokemon>(content);

            if (response.Headers.TryGetValues("ResponseHeader", out var headerValue))
            {
                pokemon!.ResponseHeader = headerValue.FirstOrDefault();
            }

            return pokemon!;
        }
    }
}

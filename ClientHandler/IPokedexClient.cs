namespace ClientHandler
{
    public interface IPokedexClient
    {
        Task<Pokemon> GetPokemonAsync(string name);
    }
}

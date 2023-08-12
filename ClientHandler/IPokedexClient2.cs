namespace ClientHandler
{
    public interface IPokedexClient2
    {
        Task<Pokemon> GetPokemonAsync(string name);
    }
}

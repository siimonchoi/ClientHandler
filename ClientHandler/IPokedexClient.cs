﻿namespace ClientHandler
{
    public interface IPokedexClient1
    {
        Task<Pokemon> GetPokemonAsync(string name);
    }
}

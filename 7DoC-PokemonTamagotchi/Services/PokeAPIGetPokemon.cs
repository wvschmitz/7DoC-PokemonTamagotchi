using System;

namespace _7DoC_PokemonTamagotchi.Services;

internal class PokeAPIGetPokemon : PokeAPI
{
    public void GetPokemon(string name)
    {
        var response = GetUrl($"https://pokeapi.co/api/v2/pokemon/{name}");
        Console.WriteLine(response.Content);
    }
}

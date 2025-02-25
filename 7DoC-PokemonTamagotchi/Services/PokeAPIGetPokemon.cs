using System;
using _7DoC_PokemonTamagotchi.Response;
using Newtonsoft.Json;

namespace _7DoC_PokemonTamagotchi.Services;

internal class PokeAPIGetPokemon : PokeAPI
{
    public ResponsePokemon GetPokemon(string name)
    {
        var response = GetUrl($"https://pokeapi.co/api/v2/pokemon/{name}");

        return JsonConvert.DeserializeObject<ResponsePokemon>(response.Content);
    }
}

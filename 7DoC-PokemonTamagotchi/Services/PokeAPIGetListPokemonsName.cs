using _7DoC_PokemonTamagotchi.Response;
using Newtonsoft.Json;

namespace _7DoC_PokemonTamagotchi.Services;

internal class PokeAPIGetListPokemonsName : PokeAPI
{
    private string _next_url = "https://pokeapi.co/api/v2/pokemon/";
    private string _previous_url = "";

    private ResponseNamedAPIResourceList GetListPokemon(string url)
    {
        var response = GetUrl(url);

        var obj = JsonConvert.DeserializeObject<ResponseNamedAPIResourceList>(response.Content);

        _next_url = obj.Next;
        _previous_url = obj.Previous;

        return obj;
    }

    public ResponseNamedAPIResourceList NextPage()
    {
        return GetListPokemon(_next_url);
    }

    public ResponseNamedAPIResourceList PreviusPage()
    {
        return GetListPokemon(_previous_url);
    }

    public bool HasPreviousPage()
    {
        return _previous_url != null;
    }
}

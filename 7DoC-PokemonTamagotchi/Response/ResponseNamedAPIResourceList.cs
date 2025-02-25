namespace _7DoC_PokemonTamagotchi.Response;

// https://pokeapi.co/docs/v2#NamedAPIResourceList
internal class ResponseNamedAPIResourceList
{
    public int Count { get; set; }
    public string Next { get; set; }
    public string Previous { get; set; }
    public List<ResponseNamedAPIResource> Results { get; set; }
}

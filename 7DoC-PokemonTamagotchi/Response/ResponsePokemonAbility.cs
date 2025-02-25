namespace _7DoC_PokemonTamagotchi.Response;

// https://pokeapi.co/docs/v2#pokemonability
internal class ResponsePokemonAbility
{
    public bool Is_hidden { get; set; }
    public int Slot { get; set; }
    public ResponseAbility Ability { get; set; }
}

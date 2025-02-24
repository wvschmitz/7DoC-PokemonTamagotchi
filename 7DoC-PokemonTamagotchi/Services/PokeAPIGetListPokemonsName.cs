namespace _7DoC_PokemonTamagotchi.Services;

internal class PokeAPIGetListPokemonsName : PokeAPI
{
    private string _next_url = "https://pokeapi.co/api/v2/pokemon";
    private string _previous_url = "";

    private void GetListPokemon(string url)
    {
        var response = GetUrl(url);
        Console.WriteLine(response.Content);

        /* To-Do
         * Realizar o processamento do retorno do next_url e previous_url
         * Realizar o processamento dos nomes do pokemons
         */
    }

    public void NextPage()
    {
        GetListPokemon(_next_url);
    }

    public void PreviusPage()
    {
        GetListPokemon(_previous_url);
    }

    public bool HasPreviousPage()
    {
        return _previous_url != null;
    }
}

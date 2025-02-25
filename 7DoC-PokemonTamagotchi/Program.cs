using _7DoC_PokemonTamagotchi.Services;

Console.WriteLine("Hello");

var apiAll = new PokeAPIGetListPokemonsName();
var list = apiAll.NextPage();

foreach (var pokemon in list.Results)
{
    Console.WriteLine(pokemon.Name);
}

Console.WriteLine("\n");
list = apiAll.NextPage();

foreach (var pokemon in list.Results)
{
    Console.WriteLine(pokemon.Name);
}

Console.WriteLine("\n");
list = apiAll.PreviusPage();

foreach (var pokemon in list.Results)
{
    Console.WriteLine(pokemon.Name);
}

Console.WriteLine("\n\n\n");

var apiPokemon = new PokeAPIGetPokemon();
var pokemom = apiPokemon.GetPokemon("bulbasaur");

Console.WriteLine($"Pokemom {pokemom.Name}");
Console.WriteLine($" - Altura {pokemom.Height}");
Console.WriteLine($" - Peso {pokemom.Weight}");
Console.WriteLine($" - Habilidades");

foreach (var ability in pokemom.Abilities)
{
    Console.WriteLine($"   - {ability.Ability.Name}");
}

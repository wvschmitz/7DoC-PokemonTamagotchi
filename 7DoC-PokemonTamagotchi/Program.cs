using _7DoC_PokemonTamagotchi.Services;

Console.WriteLine("Hello");

//var apiAll = new PokeAPIGetListPokemonsName();
//apiAll.NextPage();


var apiPokemon = new PokeAPIGetPokemon();
apiPokemon.GetPokemon("clefairy");
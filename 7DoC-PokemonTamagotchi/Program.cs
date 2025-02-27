using _7DoC_PokemonTamagotchi.Menu;
using _7DoC_PokemonTamagotchi.Modelo;

Console.WriteLine("Qual seu nome");
Jogador jogador = new Jogador();
jogador.Nome = Console.ReadLine();

var menu = new Menu();
menu.Exibir();
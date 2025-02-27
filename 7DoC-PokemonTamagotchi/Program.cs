using _7DoC_PokemonTamagotchi.Menus;
using _7DoC_PokemonTamagotchi.Modelos;

Console.WriteLine("Qual seu nome");
Jogador jogador = new Jogador();
jogador.Nome = Console.ReadLine();

var menu = new Menu();
menu.Exibir();
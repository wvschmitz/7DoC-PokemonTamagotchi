using _7DoC_PokemonTamagotchi.Menus;
using _7DoC_PokemonTamagotchi.Modelos;

Console.WriteLine("Qual seu nome");
Jogador jogador = new Jogador();
jogador.Nome = Console.ReadLine();

Dictionary<int, Menu> menus = new();
menus.Add(1, new MenuAdotarMascote());
menus.Add(2, new MenuMascotesAdotados());
menus.Add(3, new MenuSair());

void ExibirMenuPrincipal()
{
    Console.Clear();

    foreach (var menu in menus)
    {
        Console.WriteLine($"{menu.Key} - {menu.Value.TituloMenu}");
    }

    Console.Write("\nDigite a opção desejadad: ");
    int opcao = int.Parse(Console.ReadLine());

    if (menus.ContainsKey(opcao))
    {
        menus[opcao].Executar();

        if (!(menus[opcao] is MenuSair)) ExibirMenuPrincipal();
    }
    else
    {
        Console.WriteLine("Opção inválida!");
        Thread.Sleep(2000);
        ExibirMenuPrincipal();
    }
}

ExibirMenuPrincipal();
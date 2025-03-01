using _7DoC_PokemonTamagotchi.Controller;

namespace _7DoC_PokemonTamagotchi.Menu;

internal class Menu
{
    Dictionary<int, BaseController> _controllers = new();

    public Menu()
    {
        _controllers.Add(1, new AdotarMascoteController());
        _controllers.Add(2, new MascotesAdotadosController());
        _controllers.Add(3, new SairController());
    }

    public void Exibir()
    {
        Console.Clear();

        foreach (var menu in _controllers)
        {
            Console.WriteLine($"{menu.Key} - {menu.Value.TituloMenu}");
        }

        Console.Write("\nDigite a opção desejada: ");

        int opcao;
        if ((int.TryParse(Console.ReadLine(), out opcao)) && (_controllers.ContainsKey(opcao)))
        {
            _controllers[opcao].Executar();

            if (!(_controllers[opcao] is SairController)) Exibir();
        }
        else
        {
            Console.WriteLine("Opção inválida!");
            Thread.Sleep(2000);
            Exibir();
        }
    }
}

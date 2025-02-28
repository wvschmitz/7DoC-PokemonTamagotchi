using _7DoC_PokemonTamagotchi.Controller;

namespace _7DoC_PokemonTamagotchi.View;

internal abstract class BaseView
{
    protected BaseController _controller;
    protected BaseView(BaseController controller)
    {
        _controller = controller;
    }

    public void ExibirCaption(string texto)
    {
        Console.Clear();
        string asteriscos = string.Empty.PadLeft(texto.Length, '*');
        Console.WriteLine(asteriscos);
        Console.WriteLine(texto.ToUpper());
        Console.WriteLine(asteriscos + "\n");
    }
}

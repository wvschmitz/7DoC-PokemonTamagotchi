namespace _7DoC_PokemonTamagotchi.View;

internal abstract class BaseView
{
    public void ExibirCaption(string texto)
    {
        Console.Clear();
        string asteriscos = string.Empty.PadLeft(texto.Length, '*');
        Console.WriteLine(asteriscos);
        Console.WriteLine(texto.ToUpper());
        Console.WriteLine(asteriscos + "\n");
    }
}

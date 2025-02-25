namespace _7DoC_PokemonTamagotchi.Menus;

internal abstract class Menu
{
    public string TituloMenu { get; protected set; }

    public abstract void Executar();

    public void ExibirCaption(string texto)
    {
        Console.Clear();
        string asteriscos = string.Empty.PadLeft(texto.Length, '*');
        Console.WriteLine(asteriscos);
        Console.WriteLine(texto.ToUpper());
        Console.WriteLine(asteriscos + "\n");
    }
}

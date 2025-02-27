namespace _7DoC_PokemonTamagotchi.Controller;

internal abstract class BaseController
{
    public string TituloMenu { get; protected set; }
    public abstract void Executar();
}

using _7DoC_PokemonTamagotchi.Model;

namespace _7DoC_PokemonTamagotchi.Modelo;

internal class Jogador
{
    // Instância Singleton
    private static Jogador _instacia = new Jogador();
    public static Jogador Instacia { get => _instacia; }

    public string Nome { get; set; }
    public List<Mascote> Mascotes { get; private set; } = new List<Mascote>();

    private Jogador()
    {
    }

    public void AdotarMascote(Mascote mascote)
    {
        Mascotes.Add(mascote);
    }
}

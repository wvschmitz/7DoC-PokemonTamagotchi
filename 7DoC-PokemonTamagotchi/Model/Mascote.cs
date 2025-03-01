using System.Security.Cryptography;
using System.Text;
using _7DoC_PokemonTamagotchi.Response;

namespace _7DoC_PokemonTamagotchi.Model;

internal class Mascote
{
    public string Nome { get; set; }
    public int Altura { get; set; }
    public int Peso { get; set; }
    public int Alimentacao { get; private set; }
    public int Humor { get; private set; }
    public int Energia { get; private set; }
    public List<Habilidade> Habilidades { get; private set; } = new List<Habilidade>();
    
    public Mascote()
    {
        Alimentacao = RandomNumberGenerator.GetInt32(0, 10);
        Humor = RandomNumberGenerator.GetInt32(0, 10);
        Energia = RandomNumberGenerator.GetInt32(0, 10);
    }

    public void AddHabilidade(Habilidade habilidades)
    {
        Habilidades.Add(habilidades);
    }

    public void Alimentar()
    {
        Alimentacao = Math.Min(Alimentacao +1, 10);
        Energia = Math.Max(Energia -1, 0);
    }

    public void Brincar()
    {
        Humor = Math.Min(Humor +1, 10);
        Alimentacao = Math.Max(Alimentacao -1, 0);
    }

    public void Dormir()
    {
        Energia = Math.Min(Energia +1, 10);
        Humor = Math.Max(Humor -1, 0);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($" - Altura: {Altura}");
        sb.AppendLine($" - Peso: {Peso}");
        sb.AppendLine($" - Alimentação: {Alimentacao}");
        sb.AppendLine($" - Humor: {Humor}");
        sb.AppendLine($" - Energia: {Energia}");

        sb.AppendLine($" - Habilidades");
        foreach (Habilidade h in Habilidades)
        {
            sb.AppendLine($"   - {h.Nome}");
        }

        return sb.ToString();
    }
}

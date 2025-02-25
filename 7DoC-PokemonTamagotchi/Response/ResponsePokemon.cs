using System.Text;

namespace _7DoC_PokemonTamagotchi.Response;

// https://pokeapi.co/docs/v2#pokemon
internal class ResponsePokemon
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public int Height { get; set; }
    public int Weight { get; set; }
    public List<ResponsePokemonAbility> Abilities { get; set; }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($" - Altura: {Height}");
        sb.AppendLine($" - Peso: {Weight}");

        sb.AppendLine($" - Habilidades");
        foreach ( ResponsePokemonAbility ability in Abilities ) 
        { 
            sb.AppendLine($"   - {ability.Ability.Name}"); 
        }

        return sb.ToString();

    }
}
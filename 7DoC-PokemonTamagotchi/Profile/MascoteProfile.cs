using _7DoC_PokemonTamagotchi.Model;
using _7DoC_PokemonTamagotchi.Response;

namespace _7DoC_PokemonTamagotchi.Profile;

internal class MascoteProfile : AutoMapper.Profile
{
    public MascoteProfile()
    {
        CreateMap<ResponsePokemon, Mascote>()
            .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Altura, opt => opt.MapFrom(src => src.Height))
            .ForMember(dest => dest.Peso, opt => opt.MapFrom(src => src.Weight))
            .ForMember(dest => dest.Habilidades, opt => opt.MapFrom(src => src.Abilities.Select(a => new Habilidade { Nome = a.Ability.Name })));
    }

}

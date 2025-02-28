using System.Xml.Linq;
using _7DoC_PokemonTamagotchi.Enum;
using _7DoC_PokemonTamagotchi.Model;
using _7DoC_PokemonTamagotchi.Modelo;
using _7DoC_PokemonTamagotchi.Response;
using _7DoC_PokemonTamagotchi.Service;
using _7DoC_PokemonTamagotchi.View;

namespace _7DoC_PokemonTamagotchi.Controller;

internal class AdotarMascoteController : BaseController
{
    private AdotarMascoteView _view;
    private PokeAPIGetListPokemonsName _api;

    public AdotarMascoteController()
    {
        _view = new AdotarMascoteView(this);
        _api = new PokeAPIGetListPokemonsName();
        TituloMenu = "Adotar um mascote";
    }

    public override void Executar()
    {
        var pagina = _api.NextPage();

        bool continuar = true;
        while (continuar)
        {
            var selecionado = ExibirMascotes(pagina.Results);

            switch (selecionado)
            {
                case OpcaoAdocao.osProximaPagina:
                    pagina = _api.NextPage();
                    break;
                case OpcaoAdocao.osVoltarPagina:
                    pagina = _api.PreviusPage();
                    break;
                case OpcaoAdocao.osSair:
                    continuar = false;
                    break;
                default:
                    break;
            }
        }
    }

    private OpcaoAdocao ExibirMascotes(List<ResponseNamedAPIResource> mascotes)
    {
        string opcao = _view.ExibirMascotes(mascotes, _api.Pagina, _api.HasPreviousPage());

        var detalhe = mascotes.FirstOrDefault(x => x.Name == opcao);
        
        if (detalhe != null)
        {
            PokeAPIGetPokemon pokeAPIGetPokemon = new PokeAPIGetPokemon();
            var pokemom = pokeAPIGetPokemon.GetPokemon(detalhe.Name);

            OpcaoAdocao selecionado = _view.ExibirDetalhesMascote(pokemom);

            if (selecionado == OpcaoAdocao.osAdotar)
            {
                Jogador.Instacia.AdotarMascote(Mascote.LoadFromResponse(pokemom));

                Console.WriteLine($"{detalhe.Name} adotado");
                Thread.Sleep(2000);
                return OpcaoAdocao.osSair;
            }
            else
            {
                return selecionado;
            }
        }

        if (opcao == "1") return OpcaoAdocao.osSair;
        if (opcao == "2") return  OpcaoAdocao.osProximaPagina;
        if (opcao == "3" && _api.HasPreviousPage()) return OpcaoAdocao.osVoltarPagina;

        Console.WriteLine("Não localizamos o Pokémon digitado ou a opção informada está incorreta");
        Thread.Sleep(2000);

        return OpcaoAdocao.osReexibir;
    }
}

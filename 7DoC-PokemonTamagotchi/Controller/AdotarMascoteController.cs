using System.Xml.Linq;
using _7DoC_PokemonTamagotchi.Enum;
using _7DoC_PokemonTamagotchi.Response;
using _7DoC_PokemonTamagotchi.Services;
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
                case OpcaoSelecionada.osProximaPagina:
                    pagina = _api.NextPage();
                    break;
                case OpcaoSelecionada.osVoltarPagina:
                    pagina = _api.PreviusPage();
                    break;
                case OpcaoSelecionada.osSair:
                    continuar = false;
                    break;
                default:
                    break;
            }
        }
    }

    private OpcaoSelecionada ExibirMascotes(List<ResponseNamedAPIResource> mascotes)
    {
        string opcao = _view.ExibirMascotes(mascotes, _api.Pagina, _api.HasPreviousPage());

        var detalhe = mascotes.FirstOrDefault(x => x.Name == opcao);
        
        if (detalhe != null)
        {
            OpcaoSelecionada selecionado = _view.ExibirDetalhesMascote(detalhe);

            if (selecionado == OpcaoSelecionada.osAdotar)
            {
                Console.WriteLine($"{detalhe.Name} adotado");
                Thread.Sleep(2000);
                return OpcaoSelecionada.osSair;
            }
            else
            {
                return selecionado;
            }
        }

        if (opcao == "1") return OpcaoSelecionada.osSair;
        if (opcao == "2") return  OpcaoSelecionada.osProximaPagina;
        if (opcao == "3" && _api.HasPreviousPage()) return OpcaoSelecionada.osVoltarPagina;

        Console.WriteLine("Não localizamos o Pokémon digitado ou a opção informada está incorreta");
        Thread.Sleep(2000);

        return OpcaoSelecionada.osReexibir;
    }
}

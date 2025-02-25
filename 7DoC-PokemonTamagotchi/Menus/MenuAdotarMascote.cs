using _7DoC_PokemonTamagotchi.Response;
using _7DoC_PokemonTamagotchi.Services;

namespace _7DoC_PokemonTamagotchi.Menus;

internal enum OpcaoSelecionada
{
    osProximaPagina,
    osVoltarPagina,
    osReexibir,
    osSair
}

internal class MenuAdotarMascote : Menu
{
    private PokeAPIGetListPokemonsName api;
    public MenuAdotarMascote()
    {
        TituloMenu = "Adotar um mascote";
    }

    public override void Executar()
    {
        api = new PokeAPIGetListPokemonsName();

        var pagina = api.NextPage();

        bool continuar = true;
        while (continuar)
        {
            switch (ExibirMascotes(pagina.Results))
            {
                case OpcaoSelecionada.osProximaPagina:
                    pagina = api.NextPage();
                    break;
                case OpcaoSelecionada.osVoltarPagina:
                    pagina = api.PreviusPage();
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
        ExibirCaption(TituloMenu);
        Console.WriteLine("Mascotes disponíveis");
        Console.WriteLine($"Página {api.Pagina}\n");

        foreach (var pokemom in mascotes)
        {
            Console.WriteLine(pokemom.Name);
        }

        Console.WriteLine("\n1 - Voltar ao menu anterior");
        Console.WriteLine("2 - Próxima pagina");
        if (api.HasPreviousPage()) Console.WriteLine("3 - Voltar página");
        Console.WriteLine("Digite o nome do Pokémon para saber mais ou adotar:");
        
        string opcao = Console.ReadLine();
        var detalhe = mascotes.Any(x => x.Name == opcao);

        if (detalhe)
        {
            return ExibirDetalhesMascote(opcao);
        }

        if (opcao == "1") return OpcaoSelecionada.osSair;
        if (opcao == "2") return OpcaoSelecionada.osProximaPagina;
        if (opcao == "3" && api.HasPreviousPage()) return OpcaoSelecionada.osVoltarPagina;

        Console.WriteLine("Não localizamos o Pokémon digitado ou a opção informada está incorreta");
        Thread.Sleep(2000);

        return OpcaoSelecionada.osReexibir;
    }

    private OpcaoSelecionada ExibirDetalhesMascote(string name)
    {
        ExibirCaption($"Informações do {name}");

        PokeAPIGetPokemon pokeAPIGetPokemon = new PokeAPIGetPokemon();
        var pokemom = pokeAPIGetPokemon.GetPokemon(name);
        Console.WriteLine(pokemom.ToString());

        Console.WriteLine($"\n1 - Adotar o {name}");
        Console.WriteLine("2 - Voltar a listagem");

        int opcao = int.Parse(Console.ReadLine());

        if (opcao == 1)
        {
            Console.WriteLine($"{name} adotado");
            return OpcaoSelecionada.osSair;
        }
        
        return OpcaoSelecionada.osReexibir;
    }
}

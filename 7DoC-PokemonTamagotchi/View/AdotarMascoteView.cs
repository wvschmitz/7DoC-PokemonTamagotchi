using System.Xml.Linq;
using _7DoC_PokemonTamagotchi.Controller;
using _7DoC_PokemonTamagotchi.Enum;
using _7DoC_PokemonTamagotchi.Response;
using _7DoC_PokemonTamagotchi.Service;

namespace _7DoC_PokemonTamagotchi.View;

internal class AdotarMascoteView : BaseView
{
    BaseController _controller;

    public AdotarMascoteView(BaseController controller)
    {
        _controller = controller;
    }

    public string ExibirMascotes(List<ResponseNamedAPIResource> mascotes, int pagina, bool possuiPaginaAnterior)
    {
        ExibirCaption(_controller.TituloMenu);
        Console.WriteLine("Mascotes disponíveis");
        Console.WriteLine($"Página {pagina}\n");

        foreach (var pokemom in mascotes)
        {
            Console.WriteLine(pokemom.Name);
        }

        Console.WriteLine("\n1 - Voltar ao menu anterior");
        Console.WriteLine("2 - Próxima pagina");
        if (possuiPaginaAnterior) Console.WriteLine("3 - Voltar página");
        Console.WriteLine("Digite o nome do Pokémon para saber mais ou adotar:");

        return Console.ReadLine();
    }

    public OpcaoSelecionada ExibirDetalhesMascote(ResponseNamedAPIResource mascote)
    {
        ExibirCaption($"Informações do {mascote.Name}");

        PokeAPIGetPokemon pokeAPIGetPokemon = new PokeAPIGetPokemon();
        var pokemom = pokeAPIGetPokemon.GetPokemon(mascote.Name);
        Console.WriteLine(pokemom.ToString());

        Console.WriteLine($"\n1 - Adotar o {mascote.Name}");
        Console.WriteLine("2 - Voltar a listagem");

        int opcao = int.Parse(Console.ReadLine());

        if (opcao == 1) return OpcaoSelecionada.osAdotar;

        return OpcaoSelecionada.osReexibir;
    }
}

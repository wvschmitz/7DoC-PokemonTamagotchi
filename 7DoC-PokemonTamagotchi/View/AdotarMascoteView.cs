using _7DoC_PokemonTamagotchi.Controller;
using _7DoC_PokemonTamagotchi.Enum;
using _7DoC_PokemonTamagotchi.Response;

namespace _7DoC_PokemonTamagotchi.View;

internal class AdotarMascoteView : BaseView
{
    public AdotarMascoteView(BaseController controller) : base(controller)
    {
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

    public OpcaoAdocao ExibirDetalhesMascote(ResponsePokemon mascote)
    {
        ExibirCaption($"Informações do {mascote.Name}");

        Console.WriteLine(mascote.ToString());

        Console.WriteLine($"\n1 - Adotar o {mascote.Name}");
        Console.WriteLine("2 - Voltar a listagem");

        int opcao = int.Parse(Console.ReadLine());

        if (opcao == 1) return OpcaoAdocao.osAdotar;

        return OpcaoAdocao.osReexibir;
    }
}

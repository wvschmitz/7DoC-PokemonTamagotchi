using _7DoC_PokemonTamagotchi.Controller;
using _7DoC_PokemonTamagotchi.Enum;
using _7DoC_PokemonTamagotchi.Model;
using _7DoC_PokemonTamagotchi.Modelo;

namespace _7DoC_PokemonTamagotchi.View;

internal class MascotesAdotadosView : BaseView 
{
    public MascotesAdotadosView(BaseController controller) : base(controller)
    {
    }

    public string SelecionarMascote()
    {
        ExibirCaption(_controller.TituloMenu);
        Console.WriteLine("Mascotes disponíveis");

        foreach (var mascote in Jogador.Instacia.Mascotes)
        {
            Console.WriteLine(mascote.Nome);
        }

        Console.WriteLine("\nDigite o nome do mascote para interagir:");
        Console.WriteLine("1 - Sair");
        return Console.ReadLine();
    }

    public OpcaoInteracao ExibirInteracao(string nome)
    {
        while (true)
        {
            ExibirCaption($"Interagir com {nome}");
            Console.WriteLine($"1 - Saúde");
            Console.WriteLine($"2 - Alimentar");
            Console.WriteLine($"3 - Brincar");
            Console.WriteLine($"4 - Dormir");
            Console.WriteLine($"5 - Sair");

            string opcao = Console.ReadLine();
            if (opcao == "1") return OpcaoInteracao.oiSaude;
            if (opcao == "2") return OpcaoInteracao.oiAlimentar;
            if (opcao == "3") return OpcaoInteracao.oiBrincar;
            if (opcao == "4") return OpcaoInteracao.oiDormir;
            if (opcao == "5") return OpcaoInteracao.oiSair;

            Console.WriteLine("Opção inválida, informe novamente!");
            Thread.Sleep(2000);
        }
    }

    public void ExibirSaude(Mascote mascote)
    {
        Console.WriteLine(mascote.ToString());
    }

    public void ExibirAlimentado()
    {
        Console.WriteLine("Você alimentou seu mascote!");
    }

    public void ExibirBrincado()
    {
        Console.WriteLine("Você brincou com seu mascote!");
    }

    public void ExibirDormir()
    {
        Console.WriteLine("Seu pet adormeceu!");
    }
}

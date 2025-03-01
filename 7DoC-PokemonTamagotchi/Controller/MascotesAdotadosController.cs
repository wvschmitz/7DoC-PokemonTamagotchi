using _7DoC_PokemonTamagotchi.Enum;
using _7DoC_PokemonTamagotchi.Model;
using _7DoC_PokemonTamagotchi.Modelo;
using _7DoC_PokemonTamagotchi.View;

namespace _7DoC_PokemonTamagotchi.Controller;

internal class MascotesAdotadosController : BaseController
{
    private MascotesAdotadosView _view;

    public MascotesAdotadosController()
    {
        _view = new MascotesAdotadosView(this);
        TituloMenu = "Visualizar mascotes adotados";
    }

    public override void Executar()
    {
        while (true)
        {
            string nome = _view.SelecionarMascote();

            if (nome == "1") return;

            var mascote = Jogador.Instacia.Mascotes.FirstOrDefault(m => m.Nome == nome);

            if (mascote != null)
            {
                Interagir(mascote);
                break;
            }

            Console.WriteLine("Não localizamos seu mascote digitado, informe novamente!");
            Thread.Sleep(2000);
        }
    }

    private void Interagir(Mascote mascote)
    {
        while (true)
        {
            var opcao = _view.ExibirInteracao(mascote.Nome);

            if (opcao == OpcaoInteracao.oiSair) break;

            switch (opcao)
            {
                case OpcaoInteracao.oiAlimentar:
                    {
                        mascote.Alimentar();
                        _view.ExibirAlimentado();
                        break;
                    }
                case OpcaoInteracao.oiBrincar:
                    {
                        mascote.Brincar();
                        _view.ExibirBrincado();
                        break;
                    }
                case OpcaoInteracao.oiDormir:
                    {
                        mascote.Dormir();
                        _view.ExibirDormir();
                        break;
                    }
            }

            _view.ExibirSaude(mascote);
            Thread.Sleep(2000);
        }
    }
}
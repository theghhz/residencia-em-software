using System;

public class MenuPrincipal
{
    private readonly MenuCadastroPaciente _menuCadastroPaciente;
    private readonly MenuAgenda _menuAgenda;

    public MenuPrincipal(MenuCadastroPaciente menuCadastroPaciente, MenuAgenda menuAgenda)
    {
        _menuCadastroPaciente = menuCadastroPaciente;
        _menuAgenda = menuAgenda;
    }

    public async Task Exibir()
    {
        int opcao;
        do
        {
            Console.WriteLine("\nMenu Principal");
            Console.WriteLine("1 - Cadastro de Pacientes");
            Console.WriteLine("2 - Agenda de Consultas");
            Console.WriteLine("3 - Sair");

            opcao = int.Parse(Console.ReadLine());


            switch (opcao)
            {
                case 1:
                   await _menuCadastroPaciente.Exibir();
                    break;
                case 2:
                    await _menuAgenda.Exibir();
                    break;
                case 3:
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        } while (opcao != 3);
    }
}

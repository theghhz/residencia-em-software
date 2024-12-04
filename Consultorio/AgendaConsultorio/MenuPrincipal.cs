
public class MenuPrincipal
{
    public static void Exibir()
    {   
        int opcao;
        do{
            Console.WriteLine("\n\nMenu Principal");
            Console.WriteLine("1 - Cadastro de Pacientes");
            Console.WriteLine("2 - Agenda de Consultas");
            Console.WriteLine("3 - Sair");

            opcao = int.Parse(Console.ReadLine());

        
            switch (opcao)
            {
                case 1:
                    MenuCadastroPaciente.Exibir();
                    break;
                case 2:
                    MenuAgenda.Exibir();
                    break;
                case 3:
                    Console.WriteLine("Saindo...");
                    break;
                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }
        }while(opcao != 3);
    }
}
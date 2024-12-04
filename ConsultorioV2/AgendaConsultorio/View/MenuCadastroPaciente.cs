using System;
using System.Collections.Generic;
using System.Runtime;
//refatorar todos os readlines
public class MenuCadastroPaciente
{

    private readonly ConsultorioContext _context;
    private readonly ControleConsultorio _controleConsultorio;
    public MenuCadastroPaciente(ConsultorioContext context)
    {
        _context = context;
        _controleConsultorio = new ControleConsultorio(context);
    }

    public async Task Exibir()
    {
        Console.WriteLine("\n\nMenu do Cadastro de Pacientes");
        Console.WriteLine("1 - Cadastrar novo Paciente");
        Console.WriteLine("2 - Excluir Paciente");
        Console.WriteLine("3 - Listar Pacientes (Ordenado pelo CPF)");
        Console.WriteLine("4 - Listar Pacientes (Ordenado pelo Nome)");
        Console.WriteLine("5 - Voltar p/ Menu Principal");

        int opcao = int.Parse(Console.ReadLine());

        //var debud = new Debud();
        // await debud.ImprimirPacientes();

        switch (opcao)
        {
            case 1:

                // Console.Write("\nCPF:");

                // string CPF = ControleDados.PacienteCPF();

                // do{
                //     if(CPF == string.Empty){
                //         Console.WriteLine("CPF inválido\nCPF:");
                //         CPF = ControleDados.PacienteCPF();
                //     }

                // }while(CPF == string.Empty);

                // if(await _controleConsultorio.ExistePaciente(CPF)){
                //     Console.WriteLine("CPF já cadastrado.");
                //     break;
                // }

                // Console.Write("\nNome:");

                // string nome = ControleDados.PacienteNome();

                // do{

                //     if(nome == null){
                //         Console.WriteLine("Nome inválido\nNome:");
                //         nome = ControleDados.PacienteNome();
                //     }

                // }while(nome == null);

                // Console.Write("Data de Nascimento: ");

                // DateTime dataNascimento = ControleDados.PacienteDataNascimento();
                // do{

                // if(dataNascimento == DateTime.MinValue){
                //     Console.WriteLine("Data inválida. Use o formato DDMMAAAA.\nData de Nascimento:");
                //     dataNascimento = ControleDados.PacienteDataNascimento();
                // }

                // if((DateTime.Now.Year - dataNascimento.Year) < 13){
                //     Console.WriteLine("Erro: paciente deve ter pelo menos 13 anos.\nData de Nascimento: ");
                // }

                // }while(dataNascimento == DateTime.MinValue);

                // await _controleConsultorio.CadastrarPaciente(nome,CPF,dataNascimento);

                // Console.WriteLine("Paciente cadastrado com sucesso.");

                string CPF = ControleDados.PacienteCPF();

                try
                {
                    Console.WriteLine("LEUCPF");
                    if (await _controleConsultorio.ExistePaciente(CPF))
                    {
                        Console.WriteLine("CPF já cadastrado.");
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ocorreu um erro ao cadastrar o paciente: {ex.Message}");
                }
                
                string nome = ControleDados.PacienteNome();
                DateTime dataNascimento = ControleDados.PacienteDataNascimento();
                Console.WriteLine("LEU NOME");
                try
                {
                    await _controleConsultorio.CadastrarPaciente(nome, CPF, dataNascimento);
                    Console.WriteLine("Paciente cadastrado com sucesso.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao cadastrar paciente: {ex.Message}");
                }
                break;

            case 2:
                Console.Write("\nCPF:");
                string excluirCPF = ControleDados.PacienteCPF();

                if (excluirCPF == string.Empty)
                {
                    Console.WriteLine("CPF inválido\nCPF:");
                    break;
                }

                if (!await _controleConsultorio.ExistePaciente(excluirCPF))
                {
                    Console.WriteLine("Paciente não encontrado.");
                    break;
                }

                if (!await _controleConsultorio.ExcluirPaciente(excluirCPF))
                {
                    Console.WriteLine("Paciente possui consultas agendadas.");
                    break;
                }

                Console.WriteLine("Paciente excluído com sucesso.");

                break;
            case 3:
                Paciente.ListarPacientesPorCPF();
                break;
            case 4:
                Paciente.ListarPacientesPeloNome();
                break;
            case 5:
                break;
            default:
                Console.WriteLine("Opção inválida");
                break;
        }
    }
}
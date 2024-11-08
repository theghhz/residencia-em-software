using System;
using System.Collections.Generic;

public class MenuCadastroPaciente {
    public static void Exibir() {
        Console.WriteLine("\n\nMenu do Cadastro de Pacientes");
        Console.WriteLine("1 - Cadastrar novo Paciente");
        Console.WriteLine("2 - Excluir Paciente");
        Console.WriteLine("3 - Listar Pacientes (Ordenado pelo CPF)");
        Console.WriteLine("4 - Listar Pacientes (Ordenado pelo Nome)");
        Console.WriteLine("5 - Voltar p/ Menu Principal");

      int opcao = int.Parse(Console.ReadLine());

        switch (opcao) {
            case 1:

                Console.WriteLine("\nCPF:");
                string CPF = Console.ReadLine();

                ControleConsultorio.PacienteCPF(CPF);

                do{
                    
                    if(CPF == string.Empty){
                        Console.WriteLine("CPF inválido\nCPF:");
                        CPF = Console.ReadLine();
                    }
                    
                    ControleConsultorio.PacienteCPF(CPF);
                    
                }while(CPF == null);
                
                if(ControleConsultorio.ExistePaciente(CPF)){
                    Console.WriteLine("CPF já cadastrado.");
                    break;
                }

                Console.WriteLine("\nNome:");
                string nome = Console.ReadLine();

                ControleConsultorio.PacienteNome(nome);

                do{
                    
                    if(nome == null){
                        Console.WriteLine("Nome inválido\nNome:");
                        nome = ControleConsultorio.PacienteNome(nome);
                    }

                }while(nome == null);

                Console.WriteLine("\nData de Nascimento: ");
                string dataNascimento = Console.ReadLine();

                DateTime data = ControleConsultorio.PacienteDataNascimento(dataNascimento);

                do{
                    if(data == DateTime.MinValue){
                        Console.WriteLine("Data de nascimento inválida\nData de Nascimento: ");
                        dataNascimento = Console.ReadLine();
                        ControleConsultorio.PacienteDataNascimento(dataNascimento);
                    }
                    
                    if((DateTime.Now.Year - data.Year) < 13){
                        Console.WriteLine("Erro: paciente deve ter pelo menos 13 anos.\nData de Nascimento: ");
                        return;
                    }
                    
                }while(data == DateTime.MinValue);

                
                ControleConsultorio.CadastrarPaciente(nome,CPF,data);

                Console.WriteLine("Paciente cadastrado com sucesso.");

                break;
            case 2:
                Console.WriteLine("\nCPF:");
                string excluirCPF = Console.ReadLine();

                if(excluirCPF == string.Empty){
                    Console.WriteLine("CPF inválido\nCPF:");
                    break;
                }
                
                if(!ControleConsultorio.ExistePaciente(excluirCPF)){
                    Console.WriteLine("Paciente não encontrado.");
                    break;
                }

                bool pacienteRemovido = ControleConsultorio.ExcluirPaciente(excluirCPF);
                
                if(!pacienteRemovido){
                    Console.WriteLine("Paciente possui consultas agendadas.");
                    break;
                }

                Console.WriteLine("Paciente excluído com sucesso.");

                break;
            case 3:
                ControleConsultorio.ListarPacientesPorCPF();
                break;
            case 4:
                ControleConsultorio.ListarPacientesPeloNome();
                break;
            case 5:
                break;
            default:
                Console.WriteLine("Opção inválida");
                break;
        }
    }
}
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
                ControleConsultorio.CadastrarPaciente();
                break;
            case 2:
                ControleConsultorio.ExcluirPaciente();
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
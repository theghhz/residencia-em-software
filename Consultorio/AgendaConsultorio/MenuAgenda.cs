using System;
using System.Collections.Generic;

public class MenuAgenda {
    public static void Exibir() {
        Console.WriteLine("\n\nAgenda");
        Console.WriteLine("1 - Agendar Consulta");
        Console.WriteLine("2 - Cancelar Agendamento");
        Console.WriteLine("3 - Listar Agenda");
        Console.WriteLine("4 - Voltar p/ Menu Principal");

        int opcao = int.Parse(Console.ReadLine());

        switch (opcao) {
            case 1:
                Console.WriteLine("\nCPF:");
                string CPF = Console.ReadLine();

                if(CPF == string.Empty){
                    Console.WriteLine("CPF inválido\nCPF:");
                    break;
                }
                
                if(!ControleConsultorio.ExistePaciente(CPF)){
                    Console.WriteLine("Paciente não encontrado.");
                    break;
                }
                
                Console.Write("Data da consulta: ");
                DateTime dataConsulta = DateTime.Parse(Console.ReadLine());

                if(dataConsulta < DateTime.Now){
                   Console.WriteLine("Data inválida.");
                   return;
                }

                Console.Write("Hora Inicial: ");
                TimeSpan horaInicial = TimeSpan.Parse(Console.ReadLine());
                Console.Write("Hora Final: ");
                TimeSpan horaFinal = TimeSpan.Parse(Console.ReadLine());

                if(horaInicial >= horaFinal){
                    Console.WriteLine("Horário final deve ser maior que o horário inicial.");
                    return;
                }

                if(ControleConsultorio.AgendarConsultas(CPF, dataConsulta, horaInicial, horaFinal)){
                    Console.WriteLine("Consulta agendada com sucesso.");
                    break;
                } else {
                    Console.WriteLine("Já existe uma consulta marcada nesse horário.");
                
                }
                break;
            case 2:
                Console.WriteLine("CPF: ");

                string cancelarCPF = Console.ReadLine(); 

                if(cancelarCPF == string.Empty){
                    Console.WriteLine("CPF inválido\nCPF:");
                    break;
                }

                if(!ControleConsultorio.ExistePaciente(cancelarCPF)){
                    Console.WriteLine("Paciente não encontrado.");
                    break;
                }

                Console.Write("Data da consulta: ");
                DateTime dataConsultaCancelar = DateTime.Parse(Console.ReadLine());

                if(dataConsultaCancelar < DateTime.Now){
                   Console.WriteLine("Data inválida.");
                   return;
                }

                Console.Write("Hora Inicial: ");
                TimeSpan horaInicialCancelar = TimeSpan.Parse(Console.ReadLine());
                
                if (!TimeSpan.TryParse(Console.ReadLine(), out horaInicial)) {
                    Console.WriteLine("Hora inicial inválida.");
                    return;
                }

                if(ControleConsultorio.CancelarAgendamento(cancelarCPF, dataConsultaCancelar, horaInicialCancelar)){
                    Console.WriteLine("Consulta cancelada com sucesso.");
                    break;
                } else {
                    Console.WriteLine("Consulta não encontrada.");
                } 
                
                break;
            case 3:
                ControleConsultorio.ListarAgenda();
                break;
            case 4:
                break;
            default:
                Console.WriteLine("Opção inválida");
                break;
        }
    }
}
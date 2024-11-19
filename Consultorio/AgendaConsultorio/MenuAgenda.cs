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

                if(CPF == string.Empty && !ControleConsultorio.ExistePaciente(CPF)){
                    Console.WriteLine("CPF inválido ou Paciente não encontrado\nCPF:");
                    break;
                }
                
                Console.Write("Data da consulta: ");
                string dataInput = Console.ReadLine();
                DateTime dataConsulta;

                if (!DateTime.TryParseExact(dataInput, "ddMMyyyy", null, System.Globalization.DateTimeStyles.None, out dataConsulta))
                {
                    Console.WriteLine("Data inválida. Use o formato DDMMAAAA.");
                    break;
                }

                Console.Write("Hora Inicial: ");
                string horaInicialInput = Console.ReadLine();
                TimeSpan horaInicial;
                
                if (!TimeSpan.TryParseExact(horaInicialInput, "hhmm", null, out horaInicial))
                {
                    Console.WriteLine("Hora inicial inválida. Use o formato HHMM.");
                    break;
                }
                 if (dataConsulta < DateTime.Today || (dataConsulta == DateTime.Today && horaInicial <= DateTime.Now.TimeOfDay))
                {
                   Console.WriteLine("Data inválida e horário inválido.");
                   break;
                }

                Console.Write("Hora Final: ");
                string horaFinalInput = Console.ReadLine();
                TimeSpan horaFinal;
                if (!TimeSpan.TryParseExact(horaFinalInput, "hhmm", null, out horaFinal))
                {
                    Console.WriteLine("Hora final inválida. Use o formato HHMM.");
                    break;
                }

                 if(horaInicial >= horaFinal){
                    Console.WriteLine("Horário final deve ser maior que o horário inicial.");
                    break;
                }

                if (horaInicial < TimeSpan.FromHours(8) || horaFinal > TimeSpan.FromHours(19))
                {
                    Console.WriteLine("O horário de agendamento deve estar entre 08:00 e 19:00.");
                    break;
                }

                 if (horaInicial.Minutes % 15 != 0 || horaFinal.Minutes % 15 != 0)
                {
                    Console.WriteLine("Os horários devem estar em intervalos de 15 minutos.");
                    break;
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

                if(cancelarCPF == string.Empty && !ControleConsultorio.ExistePaciente(cancelarCPF)){
                    Console.WriteLine("CPF inválido ou Paciente não encontrado\nCPF:");
                    break;
                }

                Console.Write("Data da consulta: ");
                string dataInputCancelar = Console.ReadLine();
                DateTime dataConsultaCancelar;

                if (!DateTime.TryParseExact(dataInputCancelar, "ddMMyyyy", null, System.Globalization.DateTimeStyles.None, out dataConsultaCancelar))
                {
                    Console.WriteLine("Data inválida. Use o formato DDMMAAAA.");
                    break;
                }

                Console.Write("Hora Inicial: ");
                string horaInicialInputCancelar = Console.ReadLine();
                TimeSpan horaInicialCancelar;
                
                if (!TimeSpan.TryParseExact(horaInicialInputCancelar, "hhmm", null, out horaInicialCancelar))
                {
                    Console.WriteLine("Hora inicial inválida. Use o formato HHMM.");
                    break;
                }
                 if (dataConsultaCancelar < DateTime.Today || (dataConsultaCancelar == DateTime.Today && horaInicialCancelar <= DateTime.Now.TimeOfDay))
                {
                   Console.WriteLine("Data inválida e horário inválido.");
                   break;
                }

                if(dataConsultaCancelar > DateTime.Now || (dataConsultaCancelar == DateTime.Now && horaInicialCancelar > DateTime.Now.TimeOfDay)){
                    Console.WriteLine("Somente consultas futuras podem ser canceladas.");
                    break;
                }

                if(ControleConsultorio.CancelarAgendamento(cancelarCPF, dataConsultaCancelar, horaInicialCancelar)){
                    Console.WriteLine("Consulta cancelada com sucesso.");
                    break;
                } else {
                    Console.WriteLine("Consulta não encontrada.");
                } 
                
                break;
            case 3:
                Console.WriteLine("Apresentar a agenda T-Toda ou P-Periodo: ");
                string opcaoAgenda = Console.ReadLine();

                if(opcaoAgenda == "T"){
                    ControleConsultorio.ListarAgenda(DateTime.MinValue, TimeSpan.MinValue);
                    break;
                }

                Console.Write("Data da consulta: ");
                string dataListar = Console.ReadLine();
                DateTime dataListarAgenda;

                if (!DateTime.TryParseExact(dataListar, "ddMMyyyy", null, System.Globalization.DateTimeStyles.None, out dataListarAgenda))
                {
                    Console.WriteLine("Data inválida. Use o formato DDMMAAAA.");
                    break;
                }

                Console.Write("Hora Inicial: ");
                string horaListar = Console.ReadLine();
                TimeSpan horaListarAgenda;
                
                if (!TimeSpan.TryParseExact(horaListar, "hhmm", null, out horaListarAgenda))
                {
                    Console.WriteLine("Hora inicial inválida. Use o formato HHMM.");
                    break;
                }

                ControleConsultorio.ListarAgenda(dataListarAgenda, horaListarAgenda);

                break;
            
            case 4:
                break;
            default:
                Console.WriteLine("Opção inválida");
                break;
        }
    }
}
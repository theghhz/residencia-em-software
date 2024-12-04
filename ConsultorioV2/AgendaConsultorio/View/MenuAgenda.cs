using System;
using System.Collections.Generic;

public class MenuAgenda
{
    private static ControleConsultorio _controleConsultorio;

    public async Task Exibir()
    {
        Console.WriteLine("\n\nAgenda");
        Console.WriteLine("1 - Agendar Consulta");
        Console.WriteLine("2 - Cancelar Agendamento");
        Console.WriteLine("3 - Listar Agenda");
        Console.WriteLine("4 - Voltar p/ Menu Principal");

        int opcao = int.Parse(Console.ReadLine());

        switch (opcao)
        {
            case 1:
                Console.WriteLine("\nCPF:");
                string CPF = ControleDados.PacienteCPF();

                if (CPF == string.Empty || !await _controleConsultorio.ExistePaciente(CPF))
                {
                    Console.WriteLine("CPF inválido ou Paciente não encontrado\nCPF:");
                    break;
                }

                Console.Write("Data da consulta: ");
                DateTime dataConsulta = ControleDados.DataConsulta();

                if (dataConsulta == DateTime.MinValue)
                {
                    Console.WriteLine("Data inválida. Use o formato DDMMAAAA.");
                    break;
                }

                Console.Write("Hora Inicial: ");
               TimeSpan horaInicial = ControleDados.HoraConsulta();
                
                if (horaInicial == TimeSpan.MinValue)
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
                TimeSpan horaFinal = ControleDados.HoraConsulta();
                
                if (horaFinal == TimeSpan.MinValue)
                {
                    Console.WriteLine("Hora final inválida. Use o formato HHMM.");
                    break;
                }

                if (horaInicial >= horaFinal)
                {
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

                if (await _controleConsultorio.AgendarConsultas(CPF, dataConsulta, horaInicial, horaFinal))
                {
                    Console.WriteLine("Consulta agendada com sucesso.");
                    break;
                }
                else
                {
                    Console.WriteLine("Já existe uma consulta marcada nesse horário.");
                }

                break;
            case 2:
                Console.WriteLine("CPF: ");

                string cancelarCPF = ControleDados.PacienteCPF();

                if (cancelarCPF == string.Empty && !await _controleConsultorio.ExistePaciente(cancelarCPF))
                {
                    Console.WriteLine("CPF inválido ou Paciente não encontrado\nCPF:");
                    break;
                }

                Console.Write("Data da consulta: ");
                
                DateTime dataConsultaCancelar = ControleDados.DataConsulta();

                if (dataConsultaCancelar == DateTime.MinValue)
                {
                    Console.WriteLine("Data inválida. Use o formato DDMMAAAA.");
                    break;
                }

                Console.Write("Hora Inicial: ");
                
                TimeSpan horaInicialCancelar = ControleDados.HoraConsulta();

                if (horaInicialCancelar == TimeSpan.MinValue)
                {
                    Console.WriteLine("Hora inicial inválida. Use o formato HHMM.");
                    break;
                }

                if (dataConsultaCancelar < DateTime.Today || (dataConsultaCancelar == DateTime.Today && horaInicialCancelar <= DateTime.Now.TimeOfDay))
                {
                    Console.WriteLine("Data inválida e horário inválido.");
                    break;
                }

                if (dataConsultaCancelar > DateTime.Now || (dataConsultaCancelar == DateTime.Now && horaInicialCancelar > DateTime.Now.TimeOfDay))
                {
                    Console.WriteLine("Somente consultas futuras podem ser canceladas.");
                    break;
                }

                if (await _controleConsultorio.CancelarAgendamento(cancelarCPF, dataConsultaCancelar, horaInicialCancelar))
                {
                    Console.WriteLine("Consulta cancelada com sucesso.");
                    break;
                }
                else
                {
                    Console.WriteLine("Consulta não encontrada.");
                }

                break;
            case 3:
                Console.WriteLine("Apresentar a agenda T-Toda ou P-Periodo: ");
                string opcaoAgenda = Console.ReadLine();

                if (opcaoAgenda == "T" || opcaoAgenda == "t")
                {   
                    Agendamento.ListarAgenda(DateTime.MinValue, TimeSpan.MinValue,true);
                    break;
                }

                Console.Write("Data da consulta: ");
                
                DateTime dataListarAgenda = ControleDados.DataConsulta();

                if (dataListarAgenda == DateTime.MinValue)
                {
                    Console.WriteLine("Data inválida. Use o formato DDMMAAAA.");
                    break;
                }

                Console.Write("Hora Inicial: ");
                TimeSpan horaListarAgenda = ControleDados.HoraConsulta();

                if (horaListarAgenda == TimeSpan.MinValue)
                {
                    Console.WriteLine("Hora inicial inválida. Use o formato HHMM.");
                    break;
                }

                Agendamento.ListarAgenda(dataListarAgenda, horaListarAgenda,false);

                break;

            case 4:
                break;
            default:
                Console.WriteLine("Opção inválida");
                break;
        }
    }
}
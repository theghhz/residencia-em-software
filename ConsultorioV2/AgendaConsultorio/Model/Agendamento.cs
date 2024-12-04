using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Agendamento {
    [Key]
    public int AgendamentoId { get; set; }
    [Required]
    public DateTime Data { get; set; }
    [Required]
    public TimeSpan HoraInicial { get; set; }
    [Required]
    public TimeSpan HoraFinal { get; set; }
    [Required]
    [MaxLength(11)] 
    public string CPF { get; set; } 
    
    [ForeignKey("CPF")]
    public Paciente Paciente { get; set; }
    
    private static ControleConsultorio _controleConsultorio;

    public Agendamento() { }

    public Agendamento(DateTime data, TimeSpan horaInicial, TimeSpan horaFinal, Paciente paciente) {
        Data = data;
        HoraInicial = horaInicial;
        HoraFinal = horaFinal;
        Paciente = paciente;
    }

    public TimeSpan TempoConsulta() {

        return HoraFinal - HoraInicial;
    }
    
    public static void ListarAgenda(DateTime data, TimeSpan horaInicial, bool todosAgendamentos)
    {   
        if(!todosAgendamentos && data == DateTime.MinValue)
        {
            Console.WriteLine("Data informada inválida.");
            return;
        }

        Console.WriteLine("\n\n---------------------------------------------------------------------");
        Console.WriteLine("Data       H.Ini  H.Fim  Tempo Nome                       Dt.Nasc.");
        Console.WriteLine("---------------------------------------------------------------------");
        
        var agendamentosFiltrados = _controleConsultorio.AgendamentosFiltrados(data, horaInicial, todosAgendamentos).Result;
        if (agendamentosFiltrados.Count == 0)
        {
            Console.WriteLine("Nenhum agendamento encontrado para o período especificado.");
        }
        else
        {
            foreach (var agendamento in agendamentosFiltrados)
            {
                var tempo = agendamento.TempoConsulta();

                Console.WriteLine("{0:dd/MM/yyyy} {1:hh\\:mm}  {2:hh\\:mm}  {3,5} {4,-25}  {5:dd/MM/yyyy}",
                    agendamento.Data,
                    agendamento.HoraInicial,
                    agendamento.HoraFinal,
                    tempo.ToString(@"hh\:mm"),
                    agendamento.Paciente.Nome.Length > 25 ? agendamento.Paciente.Nome.Substring(0, 25) : agendamento.Paciente.Nome,
                    agendamento.Paciente.DataNascimento);
            }
        }

        Console.WriteLine("---------------------------------------------------------------------\n");
    }

}

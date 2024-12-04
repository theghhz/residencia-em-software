public class Agendamento {
    public DateTime Data { get; private set; }
    public TimeSpan HoraInicial { get; private set; }
    public TimeSpan HoraFinal { get; private set; }
    public Paciente Paciente { get; private set; }
    
    public Agendamento(DateTime data, TimeSpan horaInicial, TimeSpan horaFinal, Paciente paciente) {
        Data = data;
        HoraInicial = horaInicial;
        HoraFinal = horaFinal;
        Paciente = paciente;
    }

    public TimeSpan TempoConsulta() {

        return HoraFinal - HoraInicial;
    }

    public void Exibir() {
        Console.WriteLine($"Consulta em {Data:dd/MM/yyyy}, das {HoraInicial:hh\\:mm} às {HoraFinal:hh\\:mm}");
    }
}

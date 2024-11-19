using System.Reflection.Metadata;

public class ControleConsultorio {
    private static Dictionary<string, Paciente> Pacientes = new Dictionary<string, Paciente>();
    private static List<Agendamento> Agenda = new List<Agendamento>();

    public static void CadastrarPaciente(string nome, string cpf, DateTime dataNascimento)
    {
        Paciente paciente = new Paciente(nome, cpf, dataNascimento);
        Pacientes.Add(cpf, paciente);

    }

    public static string PacienteNome(string nome){

        ValidacaoDados.ValidarNome(nome);

        if (string.IsNullOrEmpty(nome))
            return string.Empty;
        
        return nome;
    }

    public static string PacienteCPF(string CPF){
        bool cpfValidado = ValidacaoDados.ValidarCPF(CPF);
        
        if (!cpfValidado)
            return string.Empty;

        return CPF;
    }

    public static DateTime PacienteDataNascimento(DateTime dataNascimento){

        if(dataNascimento == DateTime.MinValue){
            return DateTime.MinValue;
        }
   
        bool dataValidada = ValidacaoDados.ValidarDataNascimento(dataNascimento);
        
        if (!dataValidada)
            return DateTime.MinValue;

        return dataNascimento;
    }

    public static bool ExistePaciente(string CPF){
        
        if (Pacientes.ContainsKey(CPF)) 
            return true;
        return false;

    }
    public static bool ExcluirPaciente(string CPF) {
        
        if(!Pacientes.TryGetValue(CPF, out Paciente paciente)){
            return false;
        }

        List<Agendamento> agendamentoFuturos = ObterAgendamentosFuturosPaciente(paciente);

        if(agendamentoFuturos.Count > 0){
            return false;
        }

        Pacientes.Remove(CPF);
        Agenda.RemoveAll(a => a.Paciente == paciente); //(a => a.Paciente == paciente && a.Data <= DateTime.Now);
        return true;
    }

    public static bool AgendarConsultas(string CPF, DateTime dataConsulta, TimeSpan horaInicial, TimeSpan horaFinal) {

        if (Pacientes.TryGetValue(CPF, out Paciente paciente)) {
           
            if (horarioDisponivel(horaInicial, horaFinal, dataConsulta)) {
                return false;
            }
            
            Agendamento agendamento = new Agendamento(dataConsulta, horaInicial, horaFinal, paciente);
            Agenda.Add(agendamento);
            
        } 

        return true;
    }

    private static bool horarioDisponivel(TimeSpan horaInicial, TimeSpan horaFinal, DateTime dataConsulta) {
        return Agenda.Any(a => a.Data.Date == dataConsulta.Date &&
                                            ((horaInicial >= a.HoraInicial && horaInicial < a.HoraFinal) ||
                                            (horaFinal > a.HoraInicial && horaFinal <= a.HoraFinal) ||
                                            (horaInicial <= a.HoraInicial && horaFinal >= a.HoraFinal)));
    }

    public static bool CancelarAgendamento(string CPF, DateTime dataConsulta, TimeSpan horaInicial) {

        if (!Pacientes.TryGetValue(CPF, out Paciente paciente)) {
            return false;
        }

        Agendamento agendamentoParaCancelar = Agenda.FirstOrDefault(
            a => a.Paciente == paciente && a.Data.Date == dataConsulta.Date && a.HoraInicial == horaInicial
        );

        if (agendamentoParaCancelar != null) {
            Agenda.Remove(agendamentoParaCancelar);
            return true;
        } 
        return false;
    }

    public static void ListarPacientesPorCPF(){
        var pacientes = Pacientes.Values.OrderBy(p => p.CPF).ToList();
        if (pacientes.Count > 0) {
            foreach (var paciente in pacientes) {
                Console.WriteLine("\nNome: {0}\nCPF: {1}\nData de Nascimento: {2:dd/MM/yyyy}",
                    paciente.Nome, paciente.CPF, paciente.DataNascimento);
            }
        } else {
            Console.WriteLine("Nenhum paciente cadastrado.");
        }
    }

    public static void ListarPacientesPeloNome(){
        var pacientes = Pacientes.Values.OrderBy(p => p.Nome).ToList();
        if (pacientes.Count > 0) {
            foreach (var paciente in pacientes) {
                Console.WriteLine("\nNome: {0}\nCPF: {1}\nData de Nascimento: {2:dd/MM/yyyy}",
                    paciente.Nome, paciente.CPF, paciente.DataNascimento);
            }
        } else {
            Console.WriteLine("Nenhum paciente cadastrado.");
        }
    }
    
    public static List<Agendamento> ObterAgendamentosFuturosPaciente(Paciente paciente)
    {
        return Agenda.FindAll(a => a.Paciente == paciente && a.Data > DateTime.Now);
    }
    
    public static void ListarAgenda(DateTime data, TimeSpan horaInicial)
    {   

        Console.WriteLine("\n\n---------------------------------------------------------------------");
        Console.WriteLine("Data       H.Ini  H.Fim  Tempo Nome                       Dt.Nasc.");
        Console.WriteLine("---------------------------------------------------------------------");

        var agendamentosFiltrados = Agenda;

        if (data != DateTime.MinValue)
        {
            agendamentosFiltrados = Agenda
            .Where(a => a.Data.Date == data.Date && a.HoraInicial >= horaInicial)
            .ToList();
        }
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

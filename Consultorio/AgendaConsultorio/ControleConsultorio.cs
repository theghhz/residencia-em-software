    public class ControleConsultorio {
    private static Dictionary<string, Paciente> Pacientes = new Dictionary<string, Paciente>();
    private static List<Agendamento> Agenda = new List<Agendamento>();

    public static void CadastrarPaciente()
    {
        string cpf = ValidacaoDados.LerCPF();
        
        if (cpf == null)
        {
            Console.WriteLine("\nCPF inválido. Cadastro cancelado.");
            return ;
        }

        if (Pacientes.ContainsKey(cpf))
        {
            Console.WriteLine("\nCPF já cadastrado. Cadastro cancelado.");
            return ;
        }

        string nome = ValidacaoDados.LerNome();
        if (string.IsNullOrEmpty(nome))
        {
            Console.WriteLine("\nNome inválido. Cadastro cancelado.");
            return ;
        }

        DateTime dataNascimento = ValidacaoDados.LerDataNascimento();
        if (dataNascimento == DateTime.MinValue)
        {
            Console.WriteLine("\nCadastro cancelado.");
            return;
        }

        Paciente paciente = new Paciente(nome, cpf, dataNascimento);
        Pacientes.Add(cpf, paciente);
        Console.WriteLine("\nPaciente cadastrado com sucesso.");
    }

    public static void ExcluirPaciente() {
        string cpf = ValidacaoDados.LerCPF();
        if (Pacientes.TryGetValue(cpf, out Paciente paciente)) {

            if (Agenda.TrueForAll(a => a.Data < DateTime.Now)) {
                Pacientes.Remove(cpf);
                Console.WriteLine("Paciente excluído com sucesso.");
            } else {
                Console.WriteLine("Paciente possui consulta futura agendada e não pode ser excluído.");
            }
        } else {
            Console.WriteLine("Paciente não encontrado.");
        }
    }

    public static void AgendarConsultas(){
        string cpf = ValidacaoDados.LerCPF();
        if (Pacientes.TryGetValue(cpf, out Paciente paciente)) {
            Console.Write("Data da consulta : ");
            DateTime dataConsulta = DateTime.Parse(Console.ReadLine());

            if(dataConsulta < DateTime.Now){
                Console.WriteLine("Data inválida.");
                return;
            }
            
            Console.Write("Hora Inicial : ");
            TimeSpan horaInicial = TimeSpan.Parse(Console.ReadLine());
            Console.Write("Hora Final : ");
            TimeSpan horaFinal = TimeSpan.Parse(Console.ReadLine());

            bool horarioOcupado = Agenda.Any(a => a.Data.Date == dataConsulta.Date &&
                                            ((horaInicial >= a.HoraInicial && horaInicial < a.HoraFinal) ||
                                            (horaFinal > a.HoraInicial && horaFinal <= a.HoraFinal) ||
                                            (horaInicial <= a.HoraInicial && horaFinal >= a.HoraFinal)));
        
            if (horarioOcupado) {
                Console.WriteLine("Já existe uma consulta marcada nesse horário.");
                return;
            }

            if (horaFinal > horaInicial) {
                Agendamento agendamento = new Agendamento(dataConsulta, horaInicial, horaFinal, paciente);
                Agenda.Add(agendamento);
                Console.WriteLine("Consulta agendada com sucesso.");
            } else {
                Console.WriteLine("Horário final deve ser maior que o horário inicial.");
            }
        } else {
            Console.WriteLine("CPF não encontrado.");
        }
    }

    public static void CancelarAgendamento() {
        string cpf = ValidacaoDados.LerCPF();

        if (!Pacientes.TryGetValue(cpf, out Paciente paciente)) {
            Console.WriteLine("Paciente não encontrado.");
            return;
        }

        Console.Write("Data da consulta a ser cancelada: ");
        DateTime dataConsulta;
        if (!DateTime.TryParse(Console.ReadLine(), out dataConsulta)) {
            Console.WriteLine("Data inválida.");
            return;
        }

        Console.Write("Hora Inicial da consulta: ");
        TimeSpan horaInicial;
        if (!TimeSpan.TryParse(Console.ReadLine(), out horaInicial)) {
            Console.WriteLine("Hora inicial inválida.");
            return;
        }

        
        Agendamento agendamentoParaCancelar = Agenda.FirstOrDefault(
            a => a.Paciente == paciente && a.Data.Date == dataConsulta.Date && a.HoraInicial == horaInicial
        );

        if (agendamentoParaCancelar != null) {
            Agenda.Remove(agendamentoParaCancelar);
            Console.WriteLine("Consulta cancelada com sucesso.");
        } else {
            Console.WriteLine("Consulta não encontrada para a data e horário informados.");
        }
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
    
    public static void ListarAgenda()
    {
        Console.WriteLine("\n\n---------------------------------------------------------------------");
        Console.WriteLine("Data       H.Ini  H.Fim  Tempo Nome                       Dt.Nasc.");
        Console.WriteLine("---------------------------------------------------------------------");

        foreach (var agendamento in Agenda)
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

        Console.WriteLine("---------------------------------------------------------------------\n");
    }
}

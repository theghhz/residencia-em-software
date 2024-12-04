
    using Microsoft.EntityFrameworkCore;

    public class ControleConsultorio {
        // private static Dictionary<string, Paciente> Pacientes = new Dictionary<string, Paciente>();
        // private static List<Agendamento> Agenda = new List<Agendamento>();
        
        private readonly ConsultorioContext _context;
        
        public ControleConsultorio(ConsultorioContext context)
        {
            _context = context;
        }

        public async Task CadastrarPaciente(string nome, string cpf, DateTime dataNascimento)
        {
            Paciente paciente = new Paciente(nome, cpf, dataNascimento);
            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();
        }

        // public static void CadastrarPaciente(string nome, string cpf, DateTime dataNascimento)
        // {   
            
        //     Paciente paciente = new Paciente(nome, cpf, dataNascimento);
        //     Pacientes.Add(cpf, paciente);

        // }

        public async Task<bool> ExcluirPaciente(string cpf)
        {
            var paciente = await _context.Pacientes.FirstOrDefaultAsync(p => p.CPF == cpf);
            if (paciente == null)
            {
                return false;
            }

            List<Agendamento> agendamentoFuturos = await ObterAgendamentosFuturosPaciente(paciente);

            if (agendamentoFuturos.Count > 0)
            {
                return false;
            }

            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> ExistePaciente(string cpf)
        {
            return await _context.Pacientes.AnyAsync(p => p.CPF == cpf);
        }

        // public static bool ExistePaciente(string CPF){
            
        //     if (Pacientes.ContainsKey(CPF)) 
        //         return true;
        //     return false;

        // }
        // public static bool ExcluirPaciente(string CPF) {
            
        //     if(!Pacientes.TryGetValue(CPF, out Paciente paciente)){
        //         return false;
        //     }

        //     List<Agendamento> agendamentoFuturos = ObterAgendamentosFuturosPaciente(paciente);

        //     if(agendamentoFuturos.Count > 0){
        //         return false;
        //     }

        //     Pacientes.Remove(CPF);
        //     Agenda.RemoveAll(a => a.Paciente == paciente); //(a => a.Paciente == paciente && a.Data <= DateTime.Now);
        //     return true;
        // }

        public async Task<bool> AgendarConsultas(string cpf, DateTime dataConsulta, TimeSpan horaInicial, TimeSpan horaFinal)
        {
            var paciente = await _context.Pacientes.FirstOrDefaultAsync(p => p.CPF == cpf);
            if (paciente == null)
            {
                return false;
            }

            if (await horarioDisponivel(horaInicial, horaFinal, dataConsulta))
            {
                return false;
            }

            Agendamento agendamento = new Agendamento(dataConsulta, horaInicial, horaFinal, paciente);
            _context.Agendamentos.Add(agendamento);
            await _context.SaveChangesAsync();
            return true;
        }

        // public static bool AgendarConsultas(string CPF, DateTime dataConsulta, TimeSpan horaInicial, TimeSpan horaFinal) {

        //     if (Pacientes.TryGetValue(CPF, out Paciente paciente)) {
            
        //         if (horarioDisponivel(horaInicial, horaFinal, dataConsulta)) {
        //             return false;
        //         }
                
        //         Agendamento agendamento = new Agendamento(dataConsulta, horaInicial, horaFinal, paciente);
        //         Agenda.Add(agendamento);
                
        //     } 

        //     return true;
        // }

        private async Task<bool> horarioDisponivel(TimeSpan horaInicial, TimeSpan horaFinal, DateTime dataConsulta)
        {
            return await _context.Agendamentos.AnyAsync(a => a.Data.Date == dataConsulta.Date &&
                                                ((horaInicial >= a.HoraInicial && horaInicial < a.HoraFinal) ||
                                                (horaFinal > a.HoraInicial && horaFinal <= a.HoraFinal) ||
                                                (horaInicial <= a.HoraInicial && horaFinal >= a.HoraFinal)));
        }

        // private static bool horarioDisponivel(TimeSpan horaInicial, TimeSpan horaFinal, DateTime dataConsulta) {
        //     return Agenda.Any(a => a.Data.Date == dataConsulta.Date &&
        //                                         ((horaInicial >= a.HoraInicial && horaInicial < a.HoraFinal) ||
        //                                         (horaFinal > a.HoraInicial && horaFinal <= a.HoraFinal) ||
        //                                         (horaInicial <= a.HoraInicial && horaFinal >= a.HoraFinal)));
        // }

        public async Task<bool> CancelarAgendamento(string cpf, DateTime dataConsulta, TimeSpan horaInicial)
        {
            var paciente = await _context.Pacientes.FirstOrDefaultAsync(p => p.CPF == cpf);
            if (paciente == null)
            {
                return false;
            }

            Agendamento agendamentoParaCancelar = await _context.Agendamentos.FirstOrDefaultAsync(
                a => a.Paciente == paciente && a.Data.Date == dataConsulta.Date && a.HoraInicial == horaInicial
            );

            if (agendamentoParaCancelar != null)
            {
                _context.Agendamentos.Remove(agendamentoParaCancelar);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
        // public static bool CancelarAgendamento(string CPF, DateTime dataConsulta, TimeSpan horaInicial) {

        //     if (!Pacientes.TryGetValue(CPF, out Paciente paciente)) {
        //         return false;
        //     }

        //     Agendamento agendamentoParaCancelar = Agenda.FirstOrDefault(
        //         a => a.Paciente == paciente && a.Data.Date == dataConsulta.Date && a.HoraInicial == horaInicial
        //     );

        //     if (agendamentoParaCancelar != null) {
        //         Agenda.Remove(agendamentoParaCancelar);
        //         return true;
        //     } 
        //     return false;
        // }

        public async Task<List<Paciente>> ListarPacientesPorCPF()
        {
            return await _context.Pacientes.OrderBy(p => p.CPF).ToListAsync();
        }

        // public static List<Paciente> ListaPacienteCPF(){
        //     return Pacientes.Values.OrderBy(p => p.CPF).ToList();
        // }

        public async Task<List<Paciente>> ListarPacientesPeloNome()
        {
            return await _context.Pacientes.OrderBy(p => p.Nome).ToListAsync();
        }

        // public static List<Paciente> ListaPacientesPeloNome(){
        //     return Pacientes.Values.OrderBy(p => p.Nome).ToList();
        // }
        
        public async Task<List<Agendamento>> ObterAgendamentosFuturosPaciente(Paciente paciente)
        {
            return await _context.Agendamentos.Where(a => a.Paciente == paciente && a.Data > DateTime.Now).ToListAsync();
        }

        // public static List<Agendamento> ObterAgendamentosFuturosPaciente(Paciente paciente)
        // {
        //     return Agenda.FindAll(a => a.Paciente == paciente && a.Data > DateTime.Now);
        // }
        
        public async Task<List<Agendamento>> AgendamentosFiltrados(DateTime data, TimeSpan horaInicial, bool todosAgendamentos = false)
        {
            if (todosAgendamentos)
            {
                return await _context.Agendamentos.ToListAsync();
            }

            return await _context.Agendamentos.Where(a => a.Data.Date == data.Date && a.HoraInicial >= horaInicial).ToListAsync();
        }

        // public static List<Agendamento> agendamentosFiltrados(DateTime data, TimeSpan horaInicial, bool todosAgendamentos = false){
            
        //     if(todosAgendamentos){
        //         return Agenda
        //             .ToList();
        //     }

        //     return Agenda
        //         .Where(a => a.Data.Date == data.Date && a.HoraInicial >= horaInicial)
        //         .ToList();
        // }
    }

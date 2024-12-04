
    using Microsoft.EntityFrameworkCore;

    public class ControleConsultorio {

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

        private async Task<bool> horarioDisponivel(TimeSpan horaInicial, TimeSpan horaFinal, DateTime dataConsulta)
        {
            return await _context.Agendamentos.AnyAsync(a => a.Data.Date == dataConsulta.Date &&
                                                ((horaInicial >= a.HoraInicial && horaInicial < a.HoraFinal) ||
                                                (horaFinal > a.HoraInicial && horaFinal <= a.HoraFinal) ||
                                                (horaInicial <= a.HoraInicial && horaFinal >= a.HoraFinal)));
        }

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

        public async Task<List<Paciente>> ListarPacientesPorCPF()
        {
            return await _context.Pacientes.OrderBy(p => p.CPF).ToListAsync();
        }

        public async Task<List<Paciente>> ListarPacientesPeloNome()
        {
            return await _context.Pacientes.OrderBy(p => p.Nome).ToListAsync();
        }

        public async Task<List<Agendamento>> ObterAgendamentosFuturosPaciente(Paciente paciente)
        {
            return await _context.Agendamentos.Where(a => a.Paciente == paciente && a.Data > DateTime.Now).ToListAsync();
        }
        
        public async Task<List<Agendamento>> AgendamentosFiltrados(DateTime data, TimeSpan horaInicial, bool todosAgendamentos = false)
        {
            if (todosAgendamentos)
            {
                return await _context.Agendamentos.ToListAsync();
            }

            return await _context.Agendamentos.Where(a => a.Data.Date == data.Date && a.HoraInicial >= horaInicial).ToListAsync();
        }
    }

public class Paciente {
    public string Nome { get; private set; }
    public string CPF { get; private set; }
    public DateTime DataNascimento { get; private set; }
    
    public Paciente(string nome, string cpf, DateTime dataNascimento)
    {
        Nome = nome;
        CPF = cpf;
        DataNascimento = dataNascimento;
    }

    public int CalcularIdade()
    {
        int idade = DateTime.Now.Year - DataNascimento.Year;
        if (DateTime.Now < DataNascimento.AddYears(idade)) idade--;
        return idade;
    }

    public void Exibir()
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"CPF: {CPF}");
        Console.WriteLine($"Data de Nascimento: {DataNascimento:dd/MM/yyyy}");

        var agendamentosFuturos = ControleConsultorio.ObterAgendamentosFuturosPaciente(this);
        
        if (agendamentosFuturos.Count > 0)
        {
            Console.WriteLine("Possui agendamento(s) futuro(s):");
            foreach (var agendamento in agendamentosFuturos)
            {
                agendamento.Exibir();
            }
        }
        else
        {
            Console.WriteLine("Não possui agendamentos futuros.");
        }
    }

}
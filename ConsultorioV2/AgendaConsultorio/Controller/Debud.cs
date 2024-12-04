
using Microsoft.EntityFrameworkCore;

class Debud
{
    private readonly ConsultorioContext _context;
    public async Task<List<Paciente>> ListarTodosPacientes()
    {
        return await _context.Pacientes.ToListAsync();
    }

    public async Task ImprimirPacientes()
    {
        var pacientes = await ListarTodosPacientes();
        Console.WriteLine("\n|----------------------------------------------|");
        Console.WriteLine("---------------------DEBUG---------------------");
        Console.WriteLine("|----------------------------------------------|");

        foreach (var paciente in pacientes)
        {
            Console.WriteLine($"Nome: {paciente.Nome}, CPF: {paciente.CPF}, Data de Nascimento: {paciente.DataNascimento}");
        }

        Console.WriteLine("|----------------------------------------------|");
    }

}
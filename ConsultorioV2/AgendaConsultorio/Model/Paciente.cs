using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class Paciente {
    [Key]
    [Required]
    [MaxLength(11)]
    public string CPF { get; set; }

    [Required]
    [MaxLength(100)]
    public string Nome { get; set; }
    [Required]
    public DateTime DataNascimento { get; set; }
    public ICollection<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();

    private static ControleConsultorio _controleConsultorio;

    public Paciente() { }
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
    
    public static async void ListarPacientesPorCPF(){

        var pacientes = await _controleConsultorio.ListarPacientesPorCPF();
        if (pacientes.Count > 0) {
            foreach (var paciente in pacientes) {
                Console.WriteLine("\nNome: {0}\nCPF: {1}\nData de Nascimento: {2:dd/MM/yyyy}",
                    paciente.Nome, paciente.CPF, paciente.DataNascimento);
            }
        } else {
            Console.WriteLine("Nenhum paciente cadastrado.");
        }
    }

    public static async void ListarPacientesPeloNome(){
        var pacientes = await _controleConsultorio.ListarPacientesPeloNome();
        if (pacientes.Count > 0) {
            foreach (var paciente in pacientes) {
                Console.WriteLine("\nNome: {0}\nCPF: {1}\nData de Nascimento: {2:dd/MM/yyyy}",
                    paciente.Nome, paciente.CPF, paciente.DataNascimento);
            }
        } else {
            Console.WriteLine("Nenhum paciente cadastrado.");
        }
    }

}
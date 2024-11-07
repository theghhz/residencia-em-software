using System;
using System.Collections.Generic;

public class MenuAgenda {
    public static void Exibir() {
        Console.WriteLine("\n\nAgenda");
        Console.WriteLine("1 - Agendar Consulta");
        Console.WriteLine("2 - Cancelar Agendamento");
        Console.WriteLine("3 - Listar Agenda");
        Console.WriteLine("4 - Voltar p/ Menu Principal");

        int opcao = int.Parse(Console.ReadLine());

        switch (opcao) {
            case 1:
                ControleConsultorio.AgendarConsultas();
                break;
            case 2:
                ControleConsultorio.CancelarAgendamento();
                break;
            case 3:
                ControleConsultorio.ListarAgenda();
                break;
            case 4:
                break;
            default:
                Console.WriteLine("Opção inválida");
                break;
        }
    }
}
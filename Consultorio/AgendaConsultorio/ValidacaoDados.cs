using System;
using System.Text.RegularExpressions;

public class ValidacaoDados
{
    private static bool ValidarCpf(string CPF){
        if(CPF.Length != 11){
            return false;
        }
        if(Regex.IsMatch(CPF, @"^(\d)\1{10}$")){
            return false;
        }

        int[] verificacaoDigito1 = [10, 9, 8, 7, 6, 5, 4, 3, 2];
        int[] verificacaoDigito2 = [11, 10, 9, 8, 7, 6, 5, 4, 3, 2]; 

        string CPFSubstring = CPF.Substring(0, 9);

        int soma = 0;

        for(int i = 0; i < 9; i++){
            soma += int.Parse(CPFSubstring[i].ToString()) * verificacaoDigito1[i];
        }

        int resto = soma % 11;

        if(resto < 2){
            resto = 0;
        }else{
            resto = 11 - resto;
        }

        string Digito = resto.ToString();
        CPFSubstring += Digito;
        soma = 0;

        for(int i = 0; i < 10; i++){
            soma += int.Parse(CPFSubstring[i].ToString()) * verificacaoDigito2[i];
        }
        
        resto = soma % 11;

        if(resto < 2){
            resto = 0;
        }else{
            resto = 11 - resto;
        }

        string Digito2 = resto.ToString();
        CPFSubstring += Digito2;
        
        return CPFSubstring == CPF;
    }

    public static string LerCPF(){
        string CPF;
        Console.Write("\nDigite o CPF: ");

        CPF = Console.ReadLine();

        if(!ValidarCpf(CPF)){
            return null;
        }
        
        return CPF;
    }

    public static string LerNome(){
        
        string nome;
        
        Console.Write("Nome: ");
        nome = Console.ReadLine();

        if(nome.Length < 5){
            return null;
        }
        
        return nome;
    }

    public static DateTime LerDataNascimento(){
        DateTime dataNascimento;
        
        Console.Write("Data de Nascimento: ");
        string data = Console.ReadLine();
        if (string.IsNullOrEmpty(data))
        {
            Console.WriteLine("Data de nascimento inválida");
            return DateTime.MinValue;
        }
        dataNascimento = DateTime.Parse(data);

        if((DateTime.Now.Year - dataNascimento.Year) < 13){
            Console.WriteLine("Erro: paciente deve ter pelo menos 13 anos.");
            return DateTime.MinValue;
        }

        if(dataNascimento > DateTime.Now){
            Console.WriteLine("Data de nascimento inválida");
            return DateTime.MinValue;
        }
                
        return dataNascimento;
    }
}
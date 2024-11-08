using System;
using System.Text.RegularExpressions;

public class ValidacaoDados
{
    public static bool ValidarCPF(string CPF){
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

    public static string ValidarNome(string nome){
    
        if(nome.Length < 5){
           
            nome = string.Empty;
        }

        return nome;
    }

    public static bool ValidarDataNascimento(DateTime dataNascimento){

        if(dataNascimento > DateTime.Now)
            return false;
            
        if((DateTime.Now.Year - dataNascimento.Year) > 130)
            return false;
            
        return true;
    }
}
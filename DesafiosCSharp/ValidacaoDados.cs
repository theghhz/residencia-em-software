using System.Text.RegularExpressions;

public class ValidacaoDados{
    public string Nome { get; private set; }
    public string CPF { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public float RendaMensal { get; private set; }
    public char EstadoCivil { get; private set; }
    public int Dependentes { get; private set; }

    public void LerDados(){
        Nome = LerNome();
        CPF = LerCPF();
        DataNascimento = LerDataNascimento();
        RendaMensal = LerRendaMensal();
        EstadoCivil = LerEstadoCivil();
        Dependentes = LerDependentes();
    }

    private string LerNome(){
        
        string nome;
        do
        {
            Console.Write("Digite o nome (Necessário ter no mínimo 5 caracteres): ");
            nome = Console.ReadLine();
        }while(nome.Length < 5);
        
        return nome;
    }

    private bool ValidarCpf(string CPF){
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

    private string LerCPF(){
        string CPF;
        do
        {
            Console.Write("Digite o CPF: ");
            CPF = Console.ReadLine();
        
        }while(!ValidarCpf(CPF));
        
        return CPF;
    }

    private char LerEstadoCivil(){
        char estadoCivil;
        do
        {
            Console.Write("Digite o estado civil (S, C, V, D): ");
            estadoCivil = Console.ReadKey().KeyChar;
            Console.WriteLine();

            if(estadoCivil != 'S' && estadoCivil != 's' && estadoCivil != 'C' && estadoCivil != 'c' && estadoCivil != 'V' && estadoCivil != 'v' && estadoCivil != 'D' && estadoCivil != 'd'){
                Console.WriteLine("Estado civil inválido");
            }

        }while(estadoCivil != 'S' && estadoCivil != 's' && estadoCivil != 'C' && estadoCivil != 'c' && estadoCivil != 'V' && estadoCivil != 'v' && estadoCivil != 'D' && estadoCivil != 'd');
        
        return estadoCivil;
    }

    private int LerDependentes(){
        int dependentes;
        do
        {
            Console.Write("Digite o número de dependentes: ");
            dependentes = int.Parse(Console.ReadLine());

            if(dependentes < 0 || dependentes > 10){
                Console.WriteLine("Número de dependentes inválido");
            }

        }while(dependentes < 0 || dependentes > 10);
        
        return dependentes;
    }

    private DateTime LerDataNascimento(){
        DateTime dataNascimento;
        do
        {
            Console.Write("Digite a data de nascimento: ");
            dataNascimento = DateTime.Parse(Console.ReadLine());

            if((DateTime.Now.Year - dataNascimento.Year) < 18){
                Console.WriteLine("A pessoa deve ser maior de idade");
            }

            if(dataNascimento > DateTime.Now){
                Console.WriteLine("Data de nascimento inválida");
            }

        }while(dataNascimento > DateTime.Now);
        
        return dataNascimento;
    }

    private float LerRendaMensal(){
        float rendaMensal;
        do
        {
            Console.Write("Digite a renda mensal: ");
            rendaMensal = float.Parse(Console.ReadLine());
            
        }while(rendaMensal < 0);
        
        return rendaMensal;
    }
    public void ImprimirDados(){
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"CPF: {CPF}");
        Console.WriteLine($"Data de Nascimento: {DataNascimento}");
        Console.WriteLine($"Renda Mensal: R${RendaMensal}");
        Console.WriteLine($"Estado Civil: {EstadoCivil}");
        Console.WriteLine($"Dependentes: {Dependentes}");
    }
}
public class ControleDados
{

    public static T LerEntrada<T>(string mensagem, Func<string, T> conversor, Func<T, bool> validador, string mensagemErro)
    {
        T resultado;
        do
        {
            Console.Write(mensagem);
            string entrada = Console.ReadLine();

            try
            {
                resultado = conversor(entrada);
                if (validador(resultado))
                    return resultado;
            }
            catch
            {
                // Ignora erros de conversão e continua o loop
            }

            Console.WriteLine(mensagemErro);
        } while (true);
    }

    public static string PacienteCPF()
    {
        return LerEntrada(
            "Digite o CPF: ",
            entrada => entrada, // Conversão direta
            ValidacaoDados.ValidarCPF, // Usa o método já existente
            "CPF inválido. Tente novamente."
        );
    }
    public static string PacienteNome()
    {
        return LerEntrada(
            "Digite o Nome: ",
            entrada => entrada, // Conversão direta
            nome => nome.Length >= 5, // Valida se o nome é válido
            "Nome inválido. Deve ter ao menos 5 caracteres."
        );
    }
    public static DateTime PacienteDataNascimento()
    {
        return LerEntrada(
            "Digite a Data de Nascimento (DDMMAAAA): ",
            entrada => DateTime.ParseExact(entrada, "ddMMyyyy", null), // Converte para DateTime
            ValidacaoDados.ValidarDataNascimento, // Usa o método de validação
            "Data inválida ou fora do intervalo permitido. Tente novamente."
        );
    }


    // public static string PacienteCPF()
    // {

    //     string CPF = Console.ReadLine();

    //     if (!ValidacaoDados.ValidarCPF(CPF))
    //         return string.Empty;

    //     return CPF;
    // }

    // public static string PacienteNome()
    // {

    //     string nome = Console.ReadLine();

    //     if (ValidacaoDados.ValidarNome(nome) == string.Empty)
    //         return string.Empty;

    //     return nome;
    // }

    // public static DateTime PacienteDataNascimento()
    // {

    //     var dataInput = Console.ReadLine();
    //     DateTime dataNascimento;

    //     if (!DateTime.TryParseExact(dataInput, "ddMMyyyy", null, System.Globalization.DateTimeStyles.None, out dataNascimento))
    //     {
    //         return DateTime.MinValue;
    //     }

    //     if (dataNascimento == DateTime.MinValue)
    //     {
    //         return DateTime.MinValue;
    //     }

    //     bool dataValidada = ValidacaoDados.ValidarDataNascimento(dataNascimento);

    //     if (!dataValidada)
    //         return DateTime.MinValue;

    //     return dataNascimento;
    // }

    public static DateTime DataConsulta()
    {

        var dataInput = Console.ReadLine();
        DateTime dataConsulta;

        if (!DateTime.TryParseExact(dataInput, "ddMMyyyy", null, System.Globalization.DateTimeStyles.None, out dataConsulta))
        {
            return DateTime.MinValue;
        }

        if (dataConsulta < DateTime.Today)
        {
            return DateTime.MinValue;
        }

        return dataConsulta;
    }

    public static TimeSpan HoraConsulta()
    {

        var horaInicialInput = Console.ReadLine();
        TimeSpan horaInicial;

        if (!TimeSpan.TryParseExact(horaInicialInput, "hhmm", null, out horaInicial))
        {
            return TimeSpan.MinValue;
        }

        if (horaInicial == TimeSpan.MinValue)
        {
            return TimeSpan.MinValue;
        }

        return horaInicial;
    }
}
public class ConversorDados{

    public static string LerMoeda()
    {
        string? moeda = Console.ReadLine()?.ToUpper();

        if(moeda == "")
        {
            return " ";
        }

        return moeda;
    }

    public static decimal LerValor()
    {
        if (decimal.TryParse(Console.ReadLine(), out decimal valor))
        {
            return valor;
        }

        return 0;
    }
    
    public static bool VerificarMoedas(string moedaOrigem, string moedaDestino)
    {   
        if(VerificarMoeda(moedaOrigem) && VerificarMoeda(moedaDestino))
        {
            return true;
        }

        if (moedaOrigem == null || moedaDestino == null || moedaOrigem == moedaDestino)
        {
            return true;
        }
        
        return false;
    }

    private static bool VerificarMoeda(string moeda)
    {
        if (moeda.Length != 3)
        {
            return false;
        }

        return true;
    }

    public static bool VerificarValor(decimal valor)
    {
        if (valor <= 0)
        {
            return false;
        }

        return true;
    }
    
}
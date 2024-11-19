public class Menu{
    public static string Exibir(){   
        
            string moedaOrigem= " ";
                Console.Write("Moeda origem (ex: BRL): ");
                moedaOrigem = ConversorDados.LerMoeda();
                
                if(moedaOrigem == " "){
                    return "EXIT";
                }

                Console.Write("Moeda destino (ex: USD): ");
                string moedaDestino = ConversorDados.LerMoeda();

                if(!ConversorDados.VerificarMoedas(moedaOrigem, moedaDestino)){
                    Console.WriteLine("Uma ou mais moedas inválidas.");
                    return "MENU";
                }

                Console.Write("Valor a ser convertido: ");
                decimal valor = ConversorDados.LerValor();

                if (!ConversorDados.VerificarValor(valor)){
                    Console.WriteLine("Valor inválido.");
                    return "MENU";
                }
                
                try
                {
                    Conversor conversor = new Conversor(moedaOrigem, moedaDestino, valor);
                    
                    var (success, resultado) = conversor.ConverterMoeda().Result;

                    if (success)
                    {
                        Console.WriteLine($"{moedaOrigem} {valor} => {moedaDestino} {resultado:F2}");
                        Console.WriteLine($"Taxa de conversão: {conversor.TaxaConversao:F6}");
                    }
                    else
                    {
                        Console.WriteLine($"Erro :{resultado} ");
                    }
                }catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            return "MENU";
        }
}

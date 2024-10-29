public class Motor{
    public Double Cilindrada { get; }

    public Motor(Double cilindrada){
        if(cilindrada <= 0){
            throw new Exception("Cilindrada deve ser maior que zero");
        }
    
        Cilindrada = cilindrada;
    }

    
}
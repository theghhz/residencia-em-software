public class Carro{
    public string Placa { get; set; }
    public string Modelo { get; set; }
    private Motor _motor;
    public Motor Motor{ get => _motor; private set => _motor = value; }

    
    public Carro(string placa, string modelo, Motor motor){
        if(placa == null){
            throw new ArgumentNullException(nameof(placa),"Placa não pode ser nula");
        }
        if(modelo == null){
            throw new ArgumentNullException(nameof(modelo), "Modelo não pode ser nulo");
        }
        if(motor == null){
            throw new ArgumentNullException(nameof(motor), "Motor não pode ser nulo");
        }
        Placa = placa;
        Modelo = modelo;
        Motor = motor;
    }

    public void TrocaMotor(Motor NovoMotor){
        if(NovoMotor == null){
            throw new ArgumentNullException(nameof(NovoMotor), "Motor não pode ser nulo");
        }
        Motor = NovoMotor;
    }
}
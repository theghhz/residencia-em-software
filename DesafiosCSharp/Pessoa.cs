public class Pessoa{
    public string Nome { get;}
    public CertidaoNascimento Certidao { get;}

    public Pessoa(String nome, CertidaoNascimento? certidao = null){
        
        if(nome == null){
             throw new ArgumentNullException(nameof(nome),"Nome não pode ser nulo");
        }

        Nome = nome;
        Certidao = certidao;
    }
}
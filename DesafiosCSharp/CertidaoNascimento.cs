public class CertidaoNascimento{
    public DateTime DataEmissao { get; }
    public Pessoa Pessoa { get; }

    public CertidaoNascimento(DateTime dataEmissao, Pessoa pessoa){
        if(dataEmissao > DateTime.Now){
            throw new ArgumentException("Data de emissão não pode ser futura");
        }

        if(pessoa == null){
            throw new ArgumentNullException(nameof(pessoa),"Pessoa não pode ser nula");
        }

        DataEmissao = dataEmissao;
        this.Pessoa = pessoa;
    }
}
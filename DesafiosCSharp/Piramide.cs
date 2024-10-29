public class Piramide{
    private int n;

    public int N{
        get { return n; }
        set{
            if (value < 1)
                throw new ArgumentException("O valor de N deve ser maior ou igual a 1.");
            n = value;
        }
    }

    public Piramide(int n){
        if (n < 1)
            throw new ArgumentException("O valor de N deve ser maior ou igual a 1.");
        this.n = n;
    }

    public void Desenha(){
        for (int i = 1; i <= n; i++){
            for (int j = 1; j <= i; j++)
                Console.Write(j);

            for (int j = i - 1; j >= 1; j--)
                Console.Write(j);

            Console.WriteLine();
        }
    }
}

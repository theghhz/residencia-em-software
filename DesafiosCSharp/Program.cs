using System;

class Program {
    static void Main(){
        
        // Piramide
        try{
            Piramide piramide = new Piramide(4);
            piramide.Desenha();
        }
        catch (ArgumentException e){
            Console.WriteLine(e.Message);
        }

        // Vertices
        Vertice v1 = new Vertice(1.0, 2.0);
        Vertice v2 = new Vertice(4.0, 6.0);

        Console.WriteLine($"Distância entre v1 e v2: {v1.Distancia(v2)}");

        v1.Move(4.0, 6.0);
        Console.WriteLine($"v1 movido para ({v1.X}, {v1.Y})");

        Console.WriteLine($"v1 e v2 são iguais? {(v1.VerticeIgual(v2)?"Sim":"Não")}");

        // Triangulo
        try{
            Vertice t1 = new Vertice(0.0, 0.0);
            Vertice t2 = new Vertice(2.0, 0.0);
            Vertice t3 = new Vertice(1.0, 2.0);

            Triangulo triangulo = new Triangulo(t1, t2, t3);
            Triangulo triangulo2 = new Triangulo(t2, t1, t3);

            Console.WriteLine($"Perímetro do triângulo: {triangulo.Perimetro}");
            Console.WriteLine($"Área do triângulo: {triangulo.Area}");
            Console.WriteLine($"Tipo do triângulo: {triangulo.Tipo}");
            Console.WriteLine($"Triângulo 1 e 2 são iguais? {(triangulo.TrianguloIgual(triangulo2)?"Sim":"Não")}");
        }   
        catch (ArgumentException e){
            Console.WriteLine(e.Message);
        }
        
        // Poligono
        try{
            Vertice a1 = new Vertice(0.0, 0.0);
            Vertice a2 = new Vertice(2.0, 0.0);
            Vertice a3 = new Vertice(4.0, 2.0);

            List<Vertice> verticesIniciais = new List<Vertice> { a1, a2, a3 };

            Poligono poligono = new Poligono(verticesIniciais);

            Vertice a4 = new Vertice(2, 2);
            
            poligono.AddVertice(a4);

            Console.WriteLine($"Perímetro do polígono: {poligono.Perimetro()}");
            Console.WriteLine($"Quantidade de vértices: {poligono.QuantidadeVertices}");

            poligono.RemoveVertice(a4);

            Console.WriteLine($"Quantidade de vértices pós remoção: {poligono.QuantidadeVertices}");
        }
        catch (ArgumentException e){
            Console.WriteLine(e.Message);
        }
        catch (InvalidOperationException e){
            Console.WriteLine(e.Message);
        }
        
        //Intervalo 
        try{
            DateTime inicio1 = new DateTime(2024, 10, 28, 8, 0, 0);
            DateTime fim1 = new DateTime(2024, 10, 28, 10, 0, 0);
            Intervalo intervalo1 = new Intervalo(inicio1, fim1);

            DateTime inicio2 = new DateTime(2024, 10, 28, 9, 30, 0);
            DateTime fim2 = new DateTime(2024, 10, 28, 11, 0, 0);
            Intervalo intervalo2 = new Intervalo(inicio2, fim2);
            
            Console.WriteLine($"Duração do intervalo 1: {intervalo1.Duracao}");
        
            Console.WriteLine($"Os intervalos têm interseção? {(intervalo1.Intersecao(intervalo2)? "Sim":"Não")}");

            Console.WriteLine($"Os intervalos são iguais? {(intervalo1.IntervaloIgual(intervalo2)? "Sim":"Não")}");

        }catch (ArgumentException e){
            Console.WriteLine(e.Message);
        }

        //Lista de Intervalos

        ListaIntervalos listaIntervalos = new ListaIntervalos();

        Intervalo intervalo3 = new Intervalo(new DateTime(2024, 10, 28, 8, 0, 0), new DateTime(2024, 10, 28, 10, 0, 0));
        Intervalo intervalo4 = new Intervalo(new DateTime(2024, 10, 28, 10, 30, 0), new DateTime(2024, 10, 28, 12, 0, 0));
        Intervalo intervalo5 = new Intervalo(new DateTime(2024, 10, 28, 9, 0, 0), new DateTime(2024, 10, 28, 10, 30, 0));

        Console.WriteLine($"Intervalo 3 adicionado: {(listaIntervalos.Add(intervalo3)? "Sim":"Não")}"); 
        Console.WriteLine($"Intervalo 4 adicionado: {(listaIntervalos.Add(intervalo4)? "Sim":"Não")}"); 
        Console.WriteLine($"Intervalo 5 adicionado: {(listaIntervalos.Add(intervalo5)? "Sim":"Não")}"); 

        Console.WriteLine("Intervalos na lista:");
        foreach (var intervalo in listaIntervalos.Intervalos){
            Console.WriteLine($"Início: {intervalo.DataHoraInicio}, Fim: {intervalo.DataHoraFim}");
        }

       // Armstrong

        Console.WriteLine("Números de Armstrong de 1 a 10000:");

        for (int i = 1; i <= 10000; i++)
        {
            if (i.IsArmstrong())
            {
                Console.Write(i+" ");
            }
        }
        
        //Pessoa

        Pessoa pessoa = new Pessoa("João");
        CertidaoNascimento certidao = new CertidaoNascimento(DateTime.Now, pessoa);

        Console.WriteLine($"\nNome: {pessoa.Nome}");
        Console.WriteLine($"Data de Emissão da Certidão: {certidao.DataEmissao}");

        //Carro

        Motor motor1 = new Motor(1.6);
        Carro carro1 = new Carro("LOP-0987", "Sedan", motor1);

        Console.WriteLine($"Placa: {carro1.Placa}, Modelo: {carro1.Modelo}");

        Motor motor2 = new Motor(2.2);

        carro1.TrocaMotor(motor2);
        Console.WriteLine($"Novo Motor Cilindrada: {carro1.Motor.Cilindrada}");

        //ValidacaoDados
        
        ValidacaoDados validacao = new ValidacaoDados();
        validacao.LerDados();
        validacao.ImprimirDados();


    }
}

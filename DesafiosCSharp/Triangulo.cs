using System;
public enum TrianguloTipo{
    Equilatero,
    Isosceles,
    Escaleno
}

public class Triangulo{

    public Vertice lado1 { get; private set; }
    public Vertice lado2 { get; private set; }
    public Vertice lado3 { get; private set; }

    public Triangulo(Vertice lado1, Vertice lado2, Vertice lado3){
        this.lado1 = lado1;
        this.lado2 = lado2;
        this.lado3 = lado3;

        if(!EhTriangulo()){
            throw new ArgumentException("Os valores informados não formam um triângulo.");
        }
    }

    private bool EhTriangulo(){
        double a = lado1.Distancia(lado2);
        double b = lado2.Distancia(lado3);
        double c = lado3.Distancia(lado1);

        return (a + b > c) && (a + c > b) && (b + c > a);
    }

    public bool TrianguloIgual(Triangulo T){
        return (lado1.VerticeIgual(T.lado1) && lado2.VerticeIgual(T.lado2) && lado3.VerticeIgual(T.lado3)) ||
        (lado1.VerticeIgual(T.lado2) && lado2.VerticeIgual(T.lado3) && lado3.VerticeIgual(T.lado1)) ||
        (lado1.VerticeIgual(T.lado3) && lado2.VerticeIgual(T.lado1) && lado3.VerticeIgual(T.lado2)) ||
        (lado1.VerticeIgual(T.lado3) && lado2.VerticeIgual(T.lado2) && lado3.VerticeIgual(T.lado1)) ||
        (lado1.VerticeIgual(T.lado2) && lado2.VerticeIgual(T.lado1) && lado3.VerticeIgual(T.lado3)) ||
        (lado1.VerticeIgual(T.lado1) && lado2.VerticeIgual(T.lado3) && lado3.VerticeIgual(T.lado2));

    }

    public double Perimetro{
        get{
            return lado1.Distancia(lado2) + lado2.Distancia(lado3) + lado3.Distancia(lado1);
        }
    }

    public TrianguloTipo Tipo{
        get{
            double a = lado1.Distancia(lado2);
            double b = lado2.Distancia(lado3);
            double c = lado3.Distancia(lado1);


            if(a == b && b == c){
                return TrianguloTipo.Equilatero;
            }
            else if(a == b || b == c || c == a){
                return TrianguloTipo.Isosceles;
            }
            else{
                return TrianguloTipo.Escaleno;
            }
        }
    }

    public double Area{
        get{
            double a = lado1.Distancia(lado2);
            double b = lado2.Distancia(lado3);
            double c = lado3.Distancia(lado1);

            double p = (a + b + c) / 2;

            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
    }
}
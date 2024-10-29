using System;

public class Vertice
{
    public double X { get; private set; }
    public double Y { get; private set; }

    public Vertice(double x, double y){
        X = x;
        Y = y;
    }

    public double Distancia(Vertice outro){
        double dx = outro.X - X;
        double dy = outro.Y - Y;
        return Math.Sqrt(dx * dx + dy * dy);
    }

    public void Move(double novoX, double novoY){
        X = novoX;
        Y = novoY;
    }

    public bool VerticeIgual(Vertice outro){
        return X == outro.X && Y == outro.Y;
    }
}


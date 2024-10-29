using System;
using System.Collections.Generic;

public class Poligono{
    private List<Vertice> vertices;
    public int QuantidadeVertices => vertices.Count;
    public Poligono(List<Vertice> verticesIniciais){
        if (verticesIniciais == null || verticesIniciais.Count < 3){
            throw new ArgumentException("O polígono deve ter pelo menos 3 vértices.");
        }
        
        vertices = new List<Vertice>();

        foreach (var vertice in verticesIniciais){
            AddVertice(vertice);
        }
    }
    public bool AddVertice(Vertice v){

        foreach (var vertice in vertices){
            if (vertice.VerticeIgual(v)){
                return false;
            }
        }

        vertices.Add(v);
        return true;
    }

    public void RemoveVertice(Vertice v){
        
        if (vertices.Count <= 3){
            throw new InvalidOperationException("O polígono deve ter pelo menos 3 vértices.");
        }

        bool removed = vertices.Remove(v);
        
        if (!removed){
            throw new ArgumentException("O vértice não foi encontrado no polígono.");
        }
    }


    public double Perimetro(){
        double perimetro = 0.0;

        for (int i = 0; i < vertices.Count; i++){
            Vertice verticeAtual = vertices[i];
            Vertice proximoVertice = vertices[(i + 1) % vertices.Count];
            perimetro += verticeAtual.Distancia(proximoVertice);
        }

        return perimetro;
    }
}

// Em proximoVertice, se o proximoVertice for 2, em um total de 5 vértices, o resultado será 2 % 5 = 2, com o 3 ficaria 3 % 5 = 3
// No caso do último vertice ficaria x % x que daria 0, e o vertice 0 seria o primeiro vertice, assim retornando ao primeiro vertice pois são ligados.

using System.Collections.ObjectModel;

public class ListaIntervalos{

    private readonly List<Intervalo> intervalos;

    public ListaIntervalos(){
        intervalos = new List<Intervalo>();
    }

    public ReadOnlyCollection<Intervalo> Intervalos => intervalos.OrderBy(i => i.DataHoraInicio).ToList().AsReadOnly();

    public bool Add(Intervalo intervalo){
        foreach (Intervalo i in intervalos){
            if (i.Intersecao(intervalo))
                return false;
        }
        intervalos.Add(intervalo);
        return true;
    }
}
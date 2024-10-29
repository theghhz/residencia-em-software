
using System;
public class Intervalo {
    
    public DateTime DataHoraInicio { get;}
    public DateTime DataHoraFim { get; }

    public TimeSpan Duracao => DataHoraFim - DataHoraInicio;

    public Intervalo(DateTime DataHoraInicio, DateTime DataHoraFim){
        if (DataHoraInicio > DataHoraFim){
            throw new ArgumentException("A data de início deve ser anterior à data de fim.");
        }
        this.DataHoraInicio = DataHoraInicio;
        this.DataHoraFim = DataHoraFim;
    }
    
    public bool IntervaloIgual(Intervalo i){
        return DataHoraInicio == i.DataHoraInicio && DataHoraFim == i.DataHoraFim;
    }
    
    public bool Intersecao(Intervalo i){
        return DataHoraInicio < i.DataHoraFim && DataHoraFim > i.DataHoraInicio;
    }
}
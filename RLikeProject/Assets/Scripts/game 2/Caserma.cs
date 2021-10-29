using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//edificio di prova, essendo tutte le funzioni gia' presenti in Soldiers.cs diventerebbero solo ripetizioni
//da completare una volta finito i bilanciamenti, probabilmente terra' le variabili contatori del reclutamento (da decidere)
public class Caserma : MonoBehaviour
{
    public void reclutaSwordman (Soldiers.Swordsmen swordman, int x)
    {
        swordman.setTempTotal(x);
    }
    public void reclutaArchers(Soldiers.Archers archer, int x)
    {
        archer.setTempTotal(x);
    }
    public void reclutaRiders(Soldiers.Riders  rider, int x)
    {
        rider.setTempTotal(x);
    }


}

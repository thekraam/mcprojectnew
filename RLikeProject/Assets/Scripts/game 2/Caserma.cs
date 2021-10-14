using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//edificio di prova, essendo tutte le funzioni già presenti in Soldiers.cs diventerebbero solo ripetizioni
//da completare una volta finito i bilanciamenti, probabilmente terrà le variabili contatori del reclutamento (da decidere)
public class Caserma : MonoBehaviour
{
    public void reclutaSwordman (Soldiers.Swordsmen swordman, int x)
    {
        swordman.setTempTotal(x);

    }
}

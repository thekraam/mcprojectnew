using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//edificio di prova, essendo tutte le funzioni gia' presenti in Soldiers.cs diventerebbero solo ripetizioni
//da completare una volta finito i bilanciamenti, probabilmente terra' le variabili contatori del reclutamento (da decidere)
public class Caserma : MonoBehaviour
{
    int lvl = 1;
    int reclutamentoMAX = 10;
    float bonusBarrack = 0;

    public void lvlUpBarrack()
    {
        lvl = lvl + 1;
        if (lvl == 2)
        {
            reclutamentoMAX = 20;
            bonusBarrack = 3;
        }
        else if (lvl == 3)
        {
            reclutamentoMAX = 30;
            bonusBarrack = 4;
        }
        else if (lvl == 4)
        {
            reclutamentoMAX = 40;
            bonusBarrack = 5;
        }
        else if (lvl == 5)
        {
            reclutamentoMAX = 50;
            bonusBarrack = 7.5f;
        }
    }


    public int getLvl ()
    {
        return lvl;
    }
    public int getReclutamentoMax()
    {
        return reclutamentoMAX;
    }
    public float getBonusBarrack()
    {
        return bonusBarrack;
    }


    //----------------------------------prossimo livello----------------------
    public int getNextlvlBarrack()
    {
        return lvl + 1;
    }
    public int getNextlvlReclutamentoMax()
    {
        return reclutamentoMAX + 10;
    }
    public float getNextLvlBonusBarrack()
    {
        if (lvl == 1)
        {
            return 3;
        }
        if (lvl == 2)
        {
            return 4;
        }
        if (lvl == 3)
        {
            return 5;
        }
        else
        {
            return 7.5f;
        }
    }
    //-------------------------------------------------------------------------



    //--------------------- tasti reclutamento -------------------

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

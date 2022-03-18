using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caserma : MonoBehaviour
{
    public int lvl = 1;
    public int reclutamentoMAX = 10;
    public float bonusBarrack = 0;
    public int reclutamentoMaxMoment = 10;
    public int costo = 1000;

    public void lvlUpBarrack()
    {
        lvl = lvl + 1;
        if (lvl == 2)
        {
            costo = 1500;
            reclutamentoMAX = 20;
            bonusBarrack = 3;
        }
        else if (lvl == 3)
        {
            costo = 2000;
            reclutamentoMAX = 30;
            bonusBarrack = 4;
        }
        else if (lvl == 4)
        {
            costo = 3000;
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
    public int getReclutamentoMaxMoment()
    {
        return reclutamentoMaxMoment;
    }
    public void setReclutamentoMaxMoment(int x)
    {
        reclutamentoMaxMoment = reclutamentoMaxMoment - x;
    }
    public void aggiornaMax()
    {
        reclutamentoMaxMoment = reclutamentoMAX;
    }
    public int getcosto()
    {
        return costo;
    }

    //----------------------------------prossimo livello----------------------
    public string getNextlvlBarrack()
    {
        if (lvl == 1)
        {
            return "2";
        }
        if (lvl == 2)
        {
            return "3";
        }
        if (lvl == 3)
        {
            return "4";
        }
        if (lvl == 4)
        {
            return "5";
        }
        else
        {
            return "max";
        }
     }
    public string getNextlvlReclutamentoMax()
    {
        if (lvl == 1)
        {
            return "20";
        }
        if (lvl == 2)
        {
            return "30";
        }
        if (lvl == 3)
        {
            return "40";
        }
        if (lvl == 4)
        {
            return "50";
        }
        else
        {
            return "MAX";
        }
    }

    public string getNextLvlBonusBarrack()
    {
        if (lvl == 1)
        {
            return "+3";
        }
        if (lvl == 2)
        {
            return "+4";
        }
        if (lvl == 3)
        {
            return "+5";
        }
        if (lvl == 4)
        {
            return "+7.5";
        }
        else
        {
            return "MAX";
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

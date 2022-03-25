using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miniera : MonoBehaviour
{
    public int lvl = 1;
    public int gold = 100;
    public bool carboneHigh = false;
    public int costo = 1000;

    public void lvlUpMiniera ()
    {
        lvl = lvl + 1;
        if (lvl == 2)
        {
            costo = 2000;
            gold = 200;
        }
        else if (lvl == 3)
        {
            costo = 3000;
            gold = 400;
        }
        else if (lvl == 4)
        {
            costo = 4000;
            gold = 600; 
        }
        else if (lvl == 5)
        {
            gold = 1000;
            carboneHigh = true;
        }
    }

    //-----------------------getters-------------------------
    public int getLvlMiniera()
    {
        return lvl;
    }
    public int getgoldMiniera()
    {
        return gold;
    }
    public bool getCarboneHigh()
    {
        return carboneHigh;
    }
    public string getNextlvl()
    {
        if (lvl < 5)
        {
            return "" + lvl;
        }
        else
        {
            return "max";
        }
    }

    public int getcosto()
    {
        return costo;
    }

    public string getgoldnext()
    {
        if (lvl == 1)
        {
            return "+" + (gold + 100);
        }
        if (lvl == 2)
        {
            return "+" + (gold + 200);
        }
        if (lvl == 3)
        {
            return "+" + (gold + 200);
        }
        if (lvl == 4)
        {
            return "+" + (gold + 400);
        }
        else
            return "MAX";
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fattoria : MonoBehaviour
{
    private int lvl = 1;
    private int abitantiMax = 100;
    public int crescitaAbitanti = 15;
    public int gold = 0;


    //------------funzione per il lvl up della fattoria----------
    public void lvlUpFattoria()
    {
        lvl = lvl + 1;
        if (lvl == 2)
        {
            abitantiMax = 200;
            crescitaAbitanti = 20;
            gold = 20;
        }
        else if (lvl == 3)
        {
            abitantiMax = 300;
            crescitaAbitanti= 25;
            gold = 40;
        }
        else if (lvl == 4)
        {
            abitantiMax = 400;
            crescitaAbitanti = 30;
            gold = 80;
        }
        else if (lvl == 5)
        {
            abitantiMax = 500;
            crescitaAbitanti = 40;
            gold = 160;
        }
    }





    //----------------------------getters fattoria reale--------------------------

    public int getLvlFattoria()
    {
        return lvl;
    }
    public int getAbitantiMax()
    {
        return abitantiMax;
    }
    public int getCrescitaAbitanti()
    {
        return crescitaAbitanti;
    }
    public int getGoldFattoria()
    {
        return gold;
    }

    //----------------------------getters fattoria PROSSIMO LIVELLO--------------------------

    public int getNextLvlFattoria()
    {
        return lvl+1;
    }
    public int getNextAbitantiMax()
    {
        return abitantiMax + 100;
    }
    public int getNextCrescitaAbitanti()
    {
        if (lvl + 1 == 5)
            return 40;
        else
            return crescitaAbitanti + 5;
    }
    public int getNextGoldFattoria()
    {
        return gold*2;
    }

}
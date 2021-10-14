using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fattoria : MonoBehaviour
{
    int lvl = 1;
    int abitantiMax = 100;
    public int crescitaAbitanti = 15;
    public int gold = 0;


    //------------funzione per il lvl up della fattoria----------
    public void lvlUpFattoria()
    {
        lvl = lvl + 1;
        if (lvl == 2)
        {
            aumentaAbitantiMax(100);
            aumentaCrescitaAbitanti(5);
            gold = 20;
        }
        else if (lvl == 3)
        {
            aumentaAbitantiMax(100);
            aumentaCrescitaAbitanti(10);
            gold = 40;
        }
        else if (lvl == 4)
        {
            aumentaAbitantiMax(100);
            aumentaCrescitaAbitanti(20);
            gold = 80;
        }
        else if (lvl == 5)
        {
            aumentaAbitantiMax(100);
            aumentaCrescitaAbitanti(25);
            gold = 160;
        }
    }
    //---------------------------------------------------------

    public void aumentaAbitantiMax(int x)
    {
        abitantiMax = abitantiMax + x;
    }

    public void aumentaCrescitaAbitanti(int x)
    {
        crescitaAbitanti = crescitaAbitanti + x;
    }

    //----------------------------getters--------------------------

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
}
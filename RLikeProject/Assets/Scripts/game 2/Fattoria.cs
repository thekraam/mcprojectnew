using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fattoria : MonoBehaviour
{
    private int lvl = 1;
    private int abitantiMax = 100;
    public int crescitaAbitanti = 15;
    public int gold = 0;
    public int farmLvlUpCost = 1000;


    //------------funzione per il lvl up della fattoria----------
    public void lvlUpFattoria()
    {
        lvl = lvl + 1;
        if (lvl == 2)
        {
            abitantiMax = 200;
            crescitaAbitanti = 20;
            gold = 20;
            farmLvlUpCost = 2000;
        }
        else if (lvl == 3)
        {
            abitantiMax = 300;
            crescitaAbitanti= 25;
            gold = 40;
            farmLvlUpCost = 3500;
        }
        else if (lvl == 4)
        {
            abitantiMax = 400;
            crescitaAbitanti = 30;
            gold = 80;
            farmLvlUpCost = 5000;
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

    public void setLvlFattoria(int modifier)
    {
        lvl = modifier;
    }
    public void setAbitantiMax(int modifier)
    {
        abitantiMax = modifier;
    }
    public void setCrescitaAbitanti(int modifier)
    {
        crescitaAbitanti = modifier;
    }
    public void setGoldFattoria(int modifier)
    {
        gold = modifier;
    }
    public void setLvlUpCost(int modifier)
    {
        farmLvlUpCost = modifier;
    }
    
    //---------------------------------------------------getters fattoria PROSSIMO LIVELLO----------------------------------------------

    public int getLvlUpCost()
    {
        return farmLvlUpCost;
    }

    public string getNextLvlFattoria()
    {
        if (lvl == 1)
            return "2";
        if (lvl == 2)
            return "3";
        if (lvl == 3)
            return "4";
        if (lvl == 4)
            return "5";
        if (lvl == 5)
            return "max";
        else
            return "";
    }
    public string getNextAbitantiMax()
    {
        if (lvl == 1)
            return "+200";
        if (lvl == 2)
            return "+300";
        if (lvl == 3)
            return "+400";
        if (lvl == 4)
            return "+500";
        if (lvl == 5)
            return "MAX";
        else
            return "";
    }
    public string getNextCrescitaAbitanti()
    {
        if (lvl == 1)
            return "+20";
        if (lvl == 2)
            return "+25";
        if (lvl == 3)
            return "+30";
        if (lvl == 4)
            return "+40";
        if (lvl == 5)
            return "MAX";
        else
            return "";
    }
    public string getNextGoldFattoria()
    {
        if (lvl == 1)
            return "+20";
        if (lvl == 2)
            return "+40";
        if (lvl == 3)
            return "+80";
        if (lvl == 4)
            return "+160";
        if (lvl == 5)
            return "MAX";
        else
            return "";
    }
    
    public int calcoloCosto ()
    {
        int x = 0;
        if (lvl == 1)
        {
            x = 1000;
        }
        if (lvl == 2)
        {
            x = 2000;
        }
        if (lvl == 3)
        {
            x = 3500;
        }
        if (lvl == 4)
        {
            x = 5000;
        }
        return x;
    }




}
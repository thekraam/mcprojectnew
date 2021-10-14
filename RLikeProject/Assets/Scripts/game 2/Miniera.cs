using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miniera : MonoBehaviour
{
    int lvl = 1;
    public int gold = 100;
    bool carboneHigh = false;

    public void lvlUpMiniera ()
    {
        lvl = lvl + 1;
        if (lvl == 2)
        {
            gold = 200;
        }
        else if (lvl == 3)
        {
            gold = 400;
        }
        else if (lvl == 4)
        {
            gold = 600; 
        }
        else if (lvl == 5)
        {
            gold = 1000;
            bool carboneHigh = true;
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




}

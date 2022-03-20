using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gilda : MonoBehaviour
{
    int lvl = 1;
    int costo = 1000;
    int sped1 = 1;
    int sped2 = 0;
    int sped3 = 0;
    int sped4 = 0;
    int sped5 = 0;




    public void lvlup()
    {
        lvl = lvl + 1;
        if (lvl == 2)
        {
            sped2 = 1;
            costo = 2000;
        }
        if (lvl == 3)
        {
            sped3 = 1;
            costo = 3000;
        }
        if (lvl == 4)
        {
            sped4 = 1;
            costo = 4000;
        }
        if (lvl == 5)
        {
            sped5 = 1;
        }
    }


    public int getlvl()
    {
        return lvl;
    }
    public int getcosto()
    {
        return costo;
    }















    public  void lvlUPWall(Player player)
    {
        player.bonusWall = player.bonusWall + 5;
    }

    public void lvlupCity (Player player)
    {
        player.bonusCity = player.bonusCity + 5;
    }

    public void cambiaCapitano (Captain1 capitano)
    {
        capitano.resetCaptain();
    }



    public void spedizione (Player player,Soldiers.Swordsmen swordmen, Soldiers.Archers archers, Soldiers.Riders riders, int x)
    {
        int y = 0;

        if (x == 1)
        {
            swordmen.setRapidTotal(-5);
            archers.setRapidTotal(-5);
        }
        if (x == 2)
        {
            swordmen.setRapidTotal(-10);
            archers.setRapidTotal(-10);
        }
        if (x == 3)
        {
            swordmen.setRapidTotal(-10);
            archers.setRapidTotal(-10);
            riders.setRapidTotal(-10);
        }
        if (x == 4)
        {
            swordmen.setRapidTotal(-15);
            archers.setRapidTotal(-15);
            riders.setRapidTotal(-10);
        }
        if (x == 5)
        {
            swordmen.setRapidTotal(-20);
            archers.setRapidTotal(-20);
            riders.setRapidTotal(-10);
        }




        y = (int)Random.Range(1f, 5f);


        if (x == 1 && y == 1)
        {

            //dialogo da mettere 
            swordmen.setRapidTotal(5);
            archers.setRapidTotal(5);


        }




    }






}

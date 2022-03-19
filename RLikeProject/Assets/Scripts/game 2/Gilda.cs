using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gilda : MonoBehaviour
{
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

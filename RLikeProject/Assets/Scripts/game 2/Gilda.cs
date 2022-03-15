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





}

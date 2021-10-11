using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    float player_citizens = 10;
    float player_money = 100;


    public float getCitizens()
    {
        return player_citizens;
    }

    public void setCitizens(int modifier)
    {
        player_citizens = player_citizens + modifier;
    }

    public float getMoney()
    {
        return player_money;
    }

    public void setMoney(int modifier)
    {
        player_money = player_money + modifier;
    }
    // prova swordsmen generica
    /* Soldiers.Swordsmen swordsmen = new Soldiers.Swordsmen();
    int x = swordsmen.getTotal();*/

}

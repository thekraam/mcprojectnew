using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    int player_citizens = 10;
    int temp_player_citizens = 0;
    int player_money = 100;
    int temp_player_money = 0;

    // funzione di conteggio da spostare
    public float countTotalCitizens(Player p, Soldiers.Swordsmen a, Soldiers.Archers b, Soldiers.Riders c)
    {
        return p.getCitizens() + a.getTotal() + b.getTotal() + c.getTotal();
    }


    public float getCitizens()
    {
        return player_citizens;
    }

    public void setCitizens(int modifier)
    {
        player_citizens = temp_player_citizens;
        temp_player_citizens = 0;
    }

    public int getTempCitizens()
    {
        return temp_player_citizens;
    }
    public void setTempCitizens(int modifier)
    {
        temp_player_citizens = temp_player_citizens + modifier;
    }
    public int getMoney()
    {
        return player_money;
    }

    public void setMoney()
    {
        player_money = temp_player_money;
        temp_player_money = 0;
    }
    public int getTempMoney()
    {
        return temp_player_money;
    }
    public void setTempMoney(int modifier)
    {
        temp_player_money = temp_player_money + modifier;
    }
    // prova swordsmen generica
    /* Soldiers.Swordsmen swordsmen = new Soldiers.Swordsmen();
    int x = swordsmen.getTotal();*/

}

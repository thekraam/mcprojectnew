using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    int player_citizens = 10;
    int player_population = 10;
    int temp_player_citizens = 0;
    int player_citizensMAX = 100;
    int temp_player_citizensMAX = 0;
    int player_money = 100;
    int skip_player_money = 0;
    public int player_turn = 1;
    

    public int getTurn()
    {
        return player_turn;
    }

    public void nextTurn()
    {
        player_turn++;
    }
    public void setTurn(int modifier)
    {
        player_turn += modifier;
    }

    // funzione di conteggio da spostare
    public int getPopulation()
    {
        return player_population;
    }

    public void setPopulation(int modifier)
    {
        player_population += modifier;
    }



    public float getCitizens()
    {
        return player_citizens;
    }

    public void setCitizens()
    {
        player_citizens = player_citizens + temp_player_citizens;
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

    public int getCitizensMax()
    {
        return player_citizensMAX;
    }

    public void setCitizensMax()
    {
        player_citizensMAX = player_citizensMAX + temp_player_citizensMAX;
    }

    public void setTempCitizensMax(int modifier)
    {
        temp_player_citizensMAX = temp_player_citizensMAX + modifier;
    }


    public int getMoney()
    {
        return player_money;
    }

    public void setRapidMoney(int modifier)
    {
        player_money += modifier;
    }

    public void setMoney()
    {
        player_money = player_money + skip_player_money;
        skip_player_money = 0;
    }
    public int getSkipMoney()
    {
        return skip_player_money;
    }
    public void setSkipMoney(int modifier)
    {
        skip_player_money = skip_player_money + modifier;
    }
    // prova swordsmen generica
    /* Soldiers.Swordsmen swordsmen = new Soldiers.Swordsmen();
    int x = swordsmen.getTotal();*/

}

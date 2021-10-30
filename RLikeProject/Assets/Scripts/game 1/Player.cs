using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    int player_citizens = 40;
    int player_population = 40;
    int temp_player_citizens = 15;
    int player_citizensMAX = 100;
    int temp_player_citizensMAX = 0;
    int player_money = 100;
    int skip_player_money = 0;
    public int player_turn = 1;

    //bonus territoriali
    float bonusWall = 0;
    float bonusCity = 0;
    float bonusFar = 0;
    float bonusDemoniac = 0;




    
    //------------------------------------------turni---------------------
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

    //----------------------------------------popolazione-------------------
    public float getPopulation()
    {
        return player_population;
    }

    public void setPopulation(int modifier)
    {
        player_population = 0;
        player_population += modifier;
    }


    public int getCitizens()
    {
        return player_citizens;
    }

    public void setCitizens()
    {
        int x = player_citizensMAX-player_population;
        if (temp_player_citizens>x)
        {
            temp_player_citizens = x;
        }
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

    public void setCitizensMax(int x)
    {
        player_citizensMAX = x;

    }

    //--------------------------------------------golds----------------------------
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


    public float getBonusWall ()
    {
        return bonusWall;
    }

    public float getBonusCity()
    {
        return bonusCity;
    }

    public float getBonusFar()
    {
        return bonusFar;
    }

    public float getBonusDemoniac()
    {
        return bonusDemoniac;
    }


}

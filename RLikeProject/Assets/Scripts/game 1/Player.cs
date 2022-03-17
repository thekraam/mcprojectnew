using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int player_citizens = 40;
    public int player_population = 40;
    public int temp_player_citizens = 0;
    public int player_citizensMAX = 100;
    public int temp_player_citizensMAX = 0;
    public int player_money = 100;
    int skip_player_money = 0;
    public int player_turn = 1;

    //bonus battaglia e territoriali
    public float bonusBattle = 0;
    public float bonusWall = 0;
    public float bonusCity = 0;
    public float bonusFar = 0;
    public float bonusDemoniac = 0;


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
        player_turn = modifier;
    }

    //----------------------------------------popolazione-------------------
    public int getPopulation()
    {
        return player_population;
    }

    public void setPopulation(int modifier)
    {
        player_population = modifier;
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

    public void setCitizensMax(int modifier)
    {
        player_citizensMAX = modifier;

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









    //-----------------------Bonus--------------------
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
    public float getBonusBattle()
    {
        return bonusBattle;
    }

    public void setBonusWall(int x)
    {
        bonusWall = bonusWall + x;
    }

    public void setBonusCity(int x)
    {
        bonusCity = bonusCity + x;
    }

    public void setBonusFar(int x)
    {
        bonusFar = bonusFar + x;
    }

    public void setBonusDemoniac(int x)
    {
        bonusDemoniac = bonusDemoniac + x;
    }
    public void setBonusBattle(int x)
    {
        bonusBattle = bonusBattle + x;
    }



}

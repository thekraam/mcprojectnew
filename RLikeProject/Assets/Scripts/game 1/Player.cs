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
    public int player_money = 100000;
    int skip_player_money = 0;
    public int player_turn = 1;

    //bonus battaglia e territoriali
    public float bonusBattle = 0;
    public float bonusWall = 0;
    public float bonusCity = 0;
    public float bonusFar = 0;
    public float bonusDemoniac = 0;

    public int lvlwall = 0;
    public int lvlfield = 0;

    public int soldiersaway = 0;

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
       // Debug.Log("cittadini massimi è uguale a = " + player_citizensMAX);
       // Debug.Log("popolazione è uguale a = " + player_population);
       // Debug.Log("soldiersaway è uguale a = " + soldiersaway);
        int x = player_citizensMAX-player_population-soldiersaway;
       // Debug.Log("x è uguale a = " + x);
        if (temp_player_citizens>x)
        {
            Debug.Log("entro dentro l'if");
            temp_player_citizens = x;
            if (x < 0)
            {
                temp_player_citizens = 0;
            }
        }
        player_citizens = player_citizens + temp_player_citizens;
        temp_player_citizens = 0;
    }

    public void setRapidCitizens(int modifier)
    {
        player_citizens += modifier;
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
    public void addCitizensMax(int modifier)
    {
        player_citizensMAX = player_citizensMAX + modifier;

    }

    //--------------------------------------------golds----------------------------
    public int getMoney()
    {
        return player_money;
    }

    public void setRapidMoney(int modifier)
    {
        if ((player_money + modifier) < 0) player_money = 0;
        else player_money += modifier;
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


    public int getlvlwall()
    {
        return lvlwall;
    }
    public int getlvlfield()
    {
        return lvlfield;
    }
    public void lvlupWall()
    {
        lvlwall = lvlwall + 1 ;
        bonusWall = bonusWall + 5;
    }
    public void lvlupfield()
    {
        lvlfield = lvlfield + 1;
        bonusCity = bonusCity + 5;
    }

    public int getcostowall()
    {
        if (lvlwall == 0) return 500;
        if (lvlwall == 1) return 1000;
        if (lvlwall == 2) return 1500;
        if (lvlwall == 3) return 2000;
        else return 2500;
    }

    public string getcostowallmex()
    {
        if (lvlwall == 0) return "Cost: " + "500";
        if (lvlwall == 1) return "Cost: " + "1000";
        if (lvlwall == 2) return "Cost: " + "1500";
        if (lvlwall == 3) return "Cost: " + "2000";
        else return "max lvl reached";
    }

    public int getcostofield()
    {
        if (lvlfield == 0) return 500;
        if (lvlfield == 1) return 1000;
        if (lvlfield == 2) return 1500;
        if (lvlfield == 3) return 2000;
        else return 2500;
    }

    public string getcostofieldmex()
    {
        if (lvlfield == 0) return "Cost: " + "500";
        if (lvlfield == 1) return "Cost: " + "1000";
        if (lvlfield == 2) return "Cost: " + "1500";
        if (lvlfield == 3) return "Cost: " + "2000";
        else return "max lvl reached";
    }




    public int getsoldiersaway()
    {
        return soldiersaway;
    }

    public void setsoldiersaway(int x)
    {
        soldiersaway = soldiersaway + x;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Soldiers : MonoBehaviour
{
    public class Swordsmen
    {
        int total_swordsmen = 0;
        int temp_total_swordsmen = 0;
        int atk_swordsmen = 4;
        int temp_atk_swordsmen = 0;
        int def_swordsmen = 8;
        int temp_def_swordsmen = 0;
        float bonus_swordsmen = 0;


        // num totale spadaccini
        public int getTotal()
        {
            return total_swordsmen;
        }
        //modifica totale spadaccini
        public void setTotal()
        {
            total_swordsmen = total_swordsmen + temp_total_swordsmen;
            temp_total_swordsmen = 0;
        }
        public void setRapidTotal(int modifier)
        {
            total_swordsmen = total_swordsmen + modifier;
        }
        public int getTempTotal()
        {
            return temp_total_swordsmen;
        }
        public void setTempTotal(int modifier)
        {
            temp_total_swordsmen = temp_total_swordsmen + modifier;
        }
        // atk spadaccini
        public int getAtk()
        {
            return atk_swordsmen;
        }
        // modifica atk spadaccini
        public void setAtk()
        {
            atk_swordsmen = atk_swordsmen + temp_atk_swordsmen;
            temp_atk_swordsmen = 0;
        }
        public int getTempAtk()
        {
            return temp_atk_swordsmen;
        }
        public void setTempAtk(int modifier)
        {
            temp_atk_swordsmen = temp_atk_swordsmen + modifier;
        }
        // def spadaccini
        public int getDef()
        {
            return def_swordsmen;
        }
        // modifica def spadaccini
        public void setDef()
        {
            def_swordsmen = def_swordsmen + temp_def_swordsmen;
            temp_def_swordsmen = 0;
        }
        public int getTempDef()
        {
            return temp_def_swordsmen;
        }
        public void setTempDef(int modifier)
        {
            temp_def_swordsmen = temp_def_swordsmen + modifier;
        }
        // bonus per soldato - generale
        public float getBonus()
        {
            return bonus_swordsmen;
        }
        public void setBonus(float modifier)
        {
            bonus_swordsmen = bonus_swordsmen + modifier;
        }

    }
    public class Archers
    {
        int total_archers = 0;
        int temp_total_archers = 0;
        int atk_archers = 9;
        int temp_atk_archers = 9;
        int def_archers = 3;
        int temp_def_archers = 3;
        float bonus_archers = 0;

        // dammi num totale arcieri
        public int getTotal()
        {
            return total_archers;
        }
        //modifica totale arcieri
        public void setTotal()
        {
            total_archers = total_archers + temp_total_archers;
            temp_total_archers = 0;
        }
        public void setRapidTotal(int modifier)
        {
            total_archers = total_archers + modifier;
        }
        public int getTempTotal()
        {
            return temp_total_archers;
        }
        public void setTempTotal(int modifier)
        {
            temp_total_archers = temp_total_archers + modifier;
        }
        // dammi atk arcieri
        public int getAtk()
        {
            return atk_archers;
        }
        // modifica atk arcieri
        public void setAtk()
        {
            atk_archers = atk_archers + temp_atk_archers;
            temp_atk_archers = 0;
        }
        public int getTempAtk()
        {
            return temp_atk_archers;
        }
        public void setTempAtk(int modifier)
        {
            temp_atk_archers = temp_atk_archers + modifier;
        }
        // dammi def arcieri
        public int getDef()
        {
            return def_archers;
        }
        // modifica def arcieri
        public void setDef()
        {
            def_archers = def_archers + temp_def_archers;
            temp_def_archers = 0;
        }
        public int getTempDef()
        {
            return temp_def_archers;
        }
        public void setTempDef(int modifier)
        {
            temp_def_archers = temp_def_archers + modifier;
        }
        // bonus per arcieri - generale
        public float getBonus()
        {
            return bonus_archers;
        }
        public void setBonus(float modifier)
        {
            bonus_archers = bonus_archers + modifier;
        }
    }
    public class Riders
    {
        int total_riders = 0;
        int temp_total_riders = 0;
        int atk_riders = 8;
        int temp_atk_riders = 8;
        int def_riders = 5;
        int temp_def_riders = 5;
        float bonus_riders = 0;

        // dammi num totale riders
        public int getTotal()
        {
            return total_riders;
        }
        //modifica totale riders
        public void setTotal()
        {
            total_riders = total_riders + temp_total_riders;
            temp_total_riders = 0;
        }
        public void setRapidTotal(int modifier)
        {
            total_riders = total_riders + modifier;
        }
        public int getTempTotal()
        {
            return temp_total_riders;
        }
        public void setTempTotal(int modifier)
        {
            temp_total_riders = temp_total_riders + modifier;
        }
        // dammi atk riders
        public int getAtk()
        {
            return atk_riders;
        }
        // modifica atk riders
        public void setAtk()
        {
            atk_riders = atk_riders + temp_atk_riders;
            temp_atk_riders = 0;
        }
        public int getTempAtk()
        {
            return temp_atk_riders;
        }
        public void setTempAtk(int modifier)
        {
            temp_atk_riders = temp_atk_riders + modifier;
        }
        // dammi def riders
        public int getDef()
        {
            return def_riders;
        }
        // modifica def riders
        public void setDef()
        {
            def_riders = def_riders + temp_def_riders;
            temp_def_riders = 0;
        }
        public int getTempDef()
        {
            return temp_def_riders;
        }
        public void setTempDef(int modifier)
        {
            temp_def_riders = temp_def_riders + modifier;
        }
        // bonus per riders - generale
        public float getBonus()
        {
            return bonus_riders;
        }
        public void setBonus(float modifier)
        {
            bonus_riders = bonus_riders + modifier;
        }
    }

}

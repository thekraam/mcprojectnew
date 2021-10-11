using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Soldiers : MonoBehaviour
{
   public class Swordsmen
    {
        int total_swordsmen = 0;
        int atk_swordsmen = 4;
        int def_swordsmen = 8;
        float bonus_swordsmen = 0;
        
        // num totale spadaccini
        public int getTotal()
        {
            return total_swordsmen;
        }
        //modifica totale spadaccini
        public void setTotal(int modifier)
        {
            total_swordsmen = total_swordsmen + modifier;
        }
        // atk spadaccini
        public int getAtk()
        {
            return atk_swordsmen;
        }
        // modifica atk spadaccini
        public void setAtk(int modifier)
        {
            atk_swordsmen = atk_swordsmen + modifier;
        }
        // def spadaccini
        public int getDef()
        {
            return def_swordsmen;
        }
        // modifica def spadaccini
        public void setDef(int modifier)
        {
            def_swordsmen = def_swordsmen + modifier;
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
        int atk_archers = 9;
        int def_archers = 3;
        float bonus_archers = 0;

        // dammi num totale arcieri
        public int getTotal()
        {
            return total_archers;
        }
        //modifica totale arcieri
        public void setTotal(int modifier)
        {
            total_archers = total_archers + modifier;
        }
        // dammi atk arcieri
        public int getAtk()
        {
            return atk_archers;
        }
        // modifica atk arcieri
        public void setAtk(int modifier)
        {
            atk_archers = atk_archers + modifier;
        }
        // dammi def arcieri
        public int getDef()
        {
            return def_archers;
        }
        // modifica def arcieri
        public void setDef(int modifier)
        {
            def_archers = def_archers + modifier;
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
        int atk_riders = 8;
        int def_riders = 5;
        float bonus_riders = 0;

        // dammi num totale riders
        public int getTotal()
        {
            return total_riders;
        }
        //modifica totale riders
        public void setTotal(int modifier)
        {
            total_riders = total_riders + modifier;
        }
        // dammi atk riders
        public int getAtk()
        {
            return atk_riders;
        }
        // modifica atk riders
        public void setAtk(int modifier)
        {
            atk_riders = atk_riders + modifier;
        }
        // dammi def riders
        public int getDef()
        {
            return def_riders;
        }
        // modifica def riders
        public void setDef(int modifier)
        {
            def_riders = def_riders + modifier;
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

    public int totalSoldiers()
    {
        Soldiers.Swordsmen swordsmen = new Soldiers.Swordsmen();
        Soldiers.Archers archers = new Soldiers.Archers();
        Soldiers.Riders riders = new Soldiers.Riders();
        return swordsmen.getTotal() + archers.getTotal() + riders.getTotal();
    }
}

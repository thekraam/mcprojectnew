using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    int totalSoldier = 0;
    int lvl = 1;

    public class ESwordsmen
    {
        int total_swordsmen = 0;
        int atk_swordsmen = 5;
        int def_swordsmen = 8;
        float bonus_swordsmen = 0;

        public void lvlup()
        {
            atk_swordsmen = atk_swordsmen + 1;
            def_swordsmen = def_swordsmen + 1;
            bonus_swordsmen = bonus_swordsmen + 1;
        }
        public void reset()
        {
            total_swordsmen = 0;
            atk_swordsmen = 5;
            def_swordsmen = 8;
            bonus_swordsmen = 0;
        }

        public int getTotal()
        {
            return total_swordsmen;
        }
        //modifica totale spadaccini
        public void setTotal(int x)
        {
            total_swordsmen = total_swordsmen + x;
        }
        public void setRapidTotal(int modifier)
        {
            total_swordsmen = total_swordsmen + modifier;
        }
        public int getAtk()
        {
            return atk_swordsmen;
        }
        // modifica atk spadaccini
        public void setAtk(int x)
        {
            atk_swordsmen = atk_swordsmen + x;
        }
        public int getDef()
        {
            return def_swordsmen;
        }
        // modifica def spadaccini
        public void setDef(int x)
        {
            def_swordsmen = def_swordsmen + x;
        }
        public float getBonus()
        {
            return bonus_swordsmen;
        }
        public void setBonus(float modifier)
        {
            bonus_swordsmen = bonus_swordsmen + modifier;
        }



    }
    public class EArchers
    {
        int total_archers = 0;
        int atk_archers = 9;
        int def_archers = 3;
        float bonus_archers = 0;

        public void lvlup()
        {
            atk_archers = atk_archers + 1;
            def_archers = def_archers + 1;
            bonus_archers = bonus_archers + 1;
        }
        public void reset()
        {
            total_archers = 0;
            atk_archers = 9;
            def_archers = 3;
            bonus_archers = 0;
        }
        public int getTotal()
        {
            return total_archers;
        }
        //modifica totale arcieri
        public void setTotal(int x)
        {
            total_archers = total_archers + x;
        }
        public void setRapidTotal(int modifier)
        {
            total_archers = total_archers + modifier;
        }
        public int getAtk()
        {
            return atk_archers;
        }
        // modifica atk arcieri
        public void setAtk(int x)
        {
            atk_archers = atk_archers + x;
        }
        public int getDef()
        {
            return def_archers;
        }
        // modifica def arcieri
        public void setDef(int x)
        {
            def_archers = def_archers + x;
        }
        public float getBonus()
        {
            return bonus_archers;
        }
        public void setBonus(float modifier)
        {
            bonus_archers = bonus_archers + modifier;
        }

    }


    public class ERiders
    {
        int total_riders = 0;
        int atk_riders = 8;
        int def_riders = 5;
        float bonus_riders = 0;
        public void lvlup()
        {
            atk_riders = atk_riders + 1;
            def_riders = def_riders + 1;
            bonus_riders = bonus_riders + 1;
        }
        public void reset()
        {
            total_riders = 0;
            atk_riders = 8;
            def_riders = 5;
            bonus_riders = 0;
        }

        public int getTotal()
        {
            return total_riders;
        }
        //modifica totale riders
        public void setTotal(int x)
        {
            total_riders = total_riders + x;
        }
        public void setRapidTotal(int modifier)
        {
            total_riders = total_riders + modifier;
        }
        public int getAtk()
        {
            return atk_riders;
        }
        // modifica atk riders
        public void setAtk(int x)
        {
            atk_riders = atk_riders + x;
        }
        public int getDef()
        {
            return def_riders;
        }
        // modifica def riders
        public void setDef(int x)
        {
            def_riders = def_riders + x;
        }
        public float getBonus()
        {
            return bonus_riders;
        }
        public void setBonus(float modifier)
        {
            bonus_riders = bonus_riders + modifier;
        }
    }

    public int getLvl()
    {
        return lvl;
    }
    public int getTotalsoldier()
    {
        return totalSoldier;
    }


    //------------------------------------------------------creazione-----------------------------------------------------------------
    public void creazione(int totale, int livello, int swordmen, int archers, int riders, int lvlcapitano, Captain2 enemyCapitano, ESwordsmen swordman, EArchers archer, ERiders rider)
    {
        totalSoldier = totale;
        lvl = livello;
        swordman.reset();
        archer.reset();
        rider.reset();
        enemyCapitano.resetCaptain();
        enemyCapitano.lvlUpRapid(livello);

        if (livello == 2)
        {
            swordman.lvlup();
            archer.lvlup();
            rider.lvlup();
        }
        if (livello == 3)
        {
            swordman.lvlup();
            archer.lvlup();
            rider.lvlup();
            swordman.lvlup();
            archer.lvlup();
            rider.lvlup();
        }

        swordman.setTotal(swordmen);
        archer.setTotal(archers);
        rider.setTotal(riders);

    }


}

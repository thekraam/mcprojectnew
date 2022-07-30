using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int totalSoldier = 0;
    public int lvl = 1;

    public class ESwordsmen
    {
        public string alias = "swordsmen";
        public string aliasSingular = "swordsman";

        public int total_swordsmen = 0;
        public int atk_swordsmen = 5;
        public int def_swordsmen = 8;
        public float bonus_swordsmen = 0;

        public int deadEswordman = 0;

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

        public int getDeadESwordman()
        {
            return deadEswordman;
        }

        public void setDeadESwordman(int x)
        {
            deadEswordman = deadEswordman + x;
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
        public string alias = "archers";
        public string aliasSingular = "archer";

        public int total_archers = 0;
        public int atk_archers = 9;
        public int def_archers = 3;
        public float bonus_archers = 0;

        public int deadEArchers = 0;

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

        public int getDeadEArchers()
        {
            return deadEArchers;
        }

        public void setDeadEArchers(int x)
        {
            deadEArchers = deadEArchers + x;
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
        public string alias = "riders";
        public string aliasSingular = "rider";

        public int total_riders = 0;
        public int atk_riders = 8;
        public int def_riders = 5;
        public float bonus_riders = 0;

        public int deadERiders = 0;
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

        public int getDeadERiders()
        {
            return deadERiders;
        }

        public void setDeadERiders(int x)
        {
            deadERiders = deadERiders + x;
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
    public void creazione(int livello, int swordmen, int archers, int riders, string swordmenAlias, string swordmenAliasSingular, string archersAlias, string archersAliasSingular, string ridersAlias, string ridersAliasSingular, int lvlcapitano, Captain2 enemyCapitano, ESwordsmen swordman, EArchers archer, ERiders rider)
    {
        swordman.alias = swordmenAlias;
        swordman.aliasSingular = swordmenAliasSingular;

        archer.alias = archersAlias;
        archer.aliasSingular = archersAliasSingular;

        rider.alias = ridersAlias;
        rider.aliasSingular = ridersAliasSingular;


        totalSoldier = swordmen + archers + riders;
        lvl = livello;
        swordman.reset();
        archer.reset();
        rider.reset();
        enemyCapitano.resetCaptain();
        enemyCapitano.lvlUpRapid(lvlcapitano);

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

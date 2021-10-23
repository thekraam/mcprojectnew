using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Captain1 : MonoBehaviour
{
    int lvl = 1;
    int atk = 6;
    int def = 6;

    float bonusBattle = 0;

    float bonusWall = 0;
    float bonusCity = 0;
    float bonusFar = 0;
    float bonusDemoniac = 0;

    string nome = "error";


    //--------------------------------perks-----------------------------------
    string perk1 = "errorPerk1";
    string perk1comment = "errorPerk1comment";

    string perk2 = "errorPerk2";
    string perk2comment = "errorPerk2comment";

    string perk3 = "errorPerk3";
    string perk3comment = "errorPerk3comment";
    //-------------------------------------------------------------------------



    public void resetCaptain()
    {
        int lvl = 1;
        int atk = 6;
        int def = 6;

        float bonusBattle = 0;

        float bonusWall = 0;
        float bonusCity = 0;
        float bonusFar = 0;
        float bonusDemoniac = 0;

        giveName(nome);
        givePerk(perk1, perk1comment);

        string perk2 = "errorPerk2";
        string perk2comment = "errorPerk2comment";

        string perk3 = "errorPerk3";
        string perk3comment = "errorPerk3comment";

    }

    public void lvlup()
    {
        lvl = lvl + 1;
        if (lvl == 2)
        {
            atk = atk + (int)Random.Range(1f, 3f) + 2;
            def = def + (int)Random.Range(1f, 3f) + 2;
            bonusBattle = bonusBattle + 1;
        }

        if (lvl == 3)
        {
            atk = atk + (int)Random.Range(1f, 3f) + 2;
            def = def + (int)Random.Range(1f, 3f) + 2;
            bonusBattle = bonusBattle + 1;
            givePerk(perk2, perk2comment);
        }

        if (lvl == 4)
        {
            atk = atk + (int)Random.Range(1f, 3f) + 2;
            def = def + (int)Random.Range(1f, 3f) + 2;
            bonusBattle = bonusBattle + 1;
        }

        if (lvl == 5)
        {
            atk = atk + (int)Random.Range(1f, 3f) + 2;
            def = def + (int)Random.Range(1f, 3f) + 2;
            bonusBattle = bonusBattle + 1;
        }
        if (lvl == 6)
        {
            atk = atk + (int)Random.Range(1f, 3f) + 2;
            def = def + (int)Random.Range(1f, 3f) + 2;
            bonusBattle = bonusBattle + 1;
            givePerk(perk2, perk2comment);
        }



    }

        public void lvlUpRapid (int x)
    {
        if (x==2) {
            lvlup();
        }
        if (x == 3)
        {
            lvlup();
            lvlup();
        }
        if (x == 4)
        {
            lvlup();
            lvlup();
            lvlup();
        }
        if (x == 5)
        {
            lvlup();
            lvlup();
            lvlup();
            lvlup();
        }
        if (x == 6)
        {
            lvlup();
            lvlup();
            lvlup();
            lvlup();
            lvlup();
        }

    }


        public void givePerk(string perk, string perkcomment)
        {
            int x = (int)Random.Range(1f, 2f);
            int x1 = 0;
            int x2 = 0;
            if ((x == 1) && (x1 != 1))
            {
                x1 = 1;
                perk = "bravo";
                perkcomment = "cioè si è bravo";
            //i perk avranno poi dei modificatori di variabili ancora da decidere, per adesso lascio il nome del perk e il suo eventuale commento/spiegazione
            }

            else if ((x == 2) && (x2 != 1))
            {
                x2 = 1;
                perk = "grande";
                perkcomment = "cioè si è grande";
            }
        }

        public void giveName(string nome)
        {
            int x = (int)Random.Range(1f, 2f);
            if (x == 1)
            {
                nome = "Jack";
            }

            else if (x == 2)
            {
                nome = "Depp";
            }
        }


        public void aumentaAtk(int x)
        {
        atk = atk + x;
        }
        public void aumentaDef(int x)
        {
        def = def + x;
        }

    //----------------------------------------------getters------------------------------------------

    public string getName ()
    {
        return nome;
    }

    public int getAtk()
    {
        return atk;
    }
    public int getDef()
    {
        return def;
    }
    public int getLvl()
    {
        return lvl;
    }

    public float getBonusBattle()
    {
        return bonusBattle;
    }
    public float getBonusWall()
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

    public string getPerk1 ()
    {
        return perk1;
    }
    public string getPerk2()
    {
        return perk2;
    }
    public string getPerk3()
    {
        return perk3;
    }
    public string getPerk1comment()
    {
        return perk1comment;
    }
    public string getPerk2comment()
    {
        return perk2comment;
    }
    public string getPerk3comment()
    {
        return perk3comment;
    }
}





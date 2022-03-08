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

    //lista perk
    public int xcont = 0;
    public int x1 = 0;
    public int x2 = 0;
    public int x3 = 0;

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
        lvl = 1;
        atk = 6;
        def = 6;

        x1 = 0;
        x2 = 0;
        x3 = 0;
        xcont = 0;

        bonusBattle = 0;

        bonusWall = 0;
        bonusCity = 0;
        bonusFar = 0;
        bonusDemoniac = 0;

        giveName();
        perk1 = givePerk();
        perk1comment = givePerkComment();
        perk2 = "errorPerk2";
        perk2comment = "errorPerk2comment";

        perk3 = "errorPerk3";
        perk3comment = "errorPerk3comment";

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
            perk2 = givePerk();
            perk2comment = givePerkComment();
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
            perk3 = givePerk();
            perk3comment = givePerkComment();
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


    public string givePerk()
    {
        string perk = "error";
        int i = 0;
        while (i == 0)
        {
            int x = (int)Random.Range(1f, 4f);

            if ((x == 1) && (x1 != 1))
            {
                x1 = 1;
                perk = "bravo";
                xcont = 1;
                i = 1;
            }

            if ((x == 2) && (x2 != 1))
            {
                x2 = 1;
                i = 1;
                perk = "grande";
                xcont = 2;
            }
            else if ((x == 3) && (x3 != 1))
            {
                i = 1;
                x3 = 1;
                perk = "ottimo";
                xcont = 3;
            }
        }
        return perk;
    }

    public string givePerkComment()
    {
        string comment = "error";
        if (xcont == 1)
        {
            comment = "è un bravo ragazzo";
            xcont = 0;
        }
        if (xcont == 2)
        {
            comment = "è un grande ragazzo";
            xcont = 0;
        }
        if (xcont == 3)
        {
            comment = "è un ottimo ragazzo";
            xcont = 0;
        }
        return comment;
    }

    public void giveName()
    {
        int x = (int)Random.Range(1f, 3f);
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





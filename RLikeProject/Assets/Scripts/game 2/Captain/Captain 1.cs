using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Captain1 : MonoBehaviour
{
    bool creato = false;

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
    public int x4 = 0;
    public int x5 = 0;
    public int x6 = 0;
    public int x7 = 0;
    public int x8 = 0;
    public int x9 = 0;
    public int x10 = 0;

    //--------------------------------perks-----------------------------------
    string perk1 = "errorPerk1";
    string perk1comment = "errorPerk1comment";

    string perk2 = "errorPerk2";
    string perk2comment = "errorPerk2comment";

    string perk3 = "errorPerk3";
    string perk3comment = "errorPerk3comment";
    //-------------------------------------------------------------------------

    string finalcomment = "errorfinalcomment";
    int boolfinalcomment = 0;

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

                    giveFinalComment();
            boolfinalcomment = 1;

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
            int x = (int)Random.Range(1f, 11f);

            if ((x == 1) && (x1 != 3))
            {
                x1 = x1 + 1 ;
                
                if (x1 == 1)
                { 
                    perk = "Expert (Battle Bonus +2%)";
                    bonusBattle = bonusBattle + 2;
                }
                if (x1 == 2)
                {
                    perk = "Expert lvl 2 (Battle Bonus +2%) ";
                    bonusBattle = bonusBattle + 2;
                }
                if (x1 == 3)
                {
                    perk = "Expert lvl 3 (Battle Bonus +2%)";
                    bonusBattle = bonusBattle + 2;
                }
                xcont = 1;
                i = 1;
            }

            if ((x == 2) && (x2 != 3))
            {
                x2 = x2 + 1;

                if (x2 == 1)
                {
                    perk = "figher (+3 Atk, +3 Def)";
                    atk = atk + 3;
                    def = def + 3;
                }
                if (x2 == 2)
                {
                    perk = "figher lvl 2 (+3 Atk, +3 Def)";
                    atk = atk + 3;
                    def = def + 3;
                }
                if (x2 == 3)
                {
                    perk = "figher lvl 3 (+3 Atk, +3 Def)";
                    atk = atk + 3;
                    def = def + 3;
                }
                xcont = 2;
                i = 1;
            }
            if ((x == 3) && (x3 != 3))
            {
                x3 = x3 + 1;

                if (x3 == 1)
                {
                    perk = "Walls Master (Wall Bonus +5%)";
                    bonusWall = bonusWall + 5;
                }
                if (x3 == 2)
                {
                    perk = "Walls Master lvl 2 (Wall Bonus +5%)";
                    bonusWall = bonusWall + 5;
                }
                if (x3 == 3)
                {
                    perk = "Walls Master lvl 3 (Wall Bonus +5%)";
                    bonusWall = bonusWall + 5;
                }
                xcont = 3;
                i = 1;
            }

            if ((x == 4) && (x4 != 3))
            {
                x4 = x4 + 1;

                if (x4 == 1)
                {
                    perk = "Field Master (Fields Bonus +5%) ";
                    bonusCity = bonusCity + 5;
                }
                if (x4 == 2)
                {
                    perk = "Field Master  lvl 2 (Fields Bonus +5%)";
                    bonusCity = bonusCity + 5;
                }
                if (x4 == 3)
                {
                    perk = "Field Master  lvl 3 (Fields Bonus +5%)";
                    bonusCity = bonusCity + 5;
                }
                xcont = 4;
                i = 1;
            }
            if ((x == 5) && (x5 != 3))
            {
                x5 = x5 + 1;

                if (x5 == 1)
                {
                    perk = "Far Lands Master (Far Lands bonus +5%)";
                    bonusFar = bonusFar + 5;
                }
                if (x5 == 2)
                {
                    perk = "Far Lands Master lvl 2 (Far Lands bonus +5%)";
                    bonusFar = bonusFar + 5;
                }
                if (x5 == 3)
                {
                    perk = "Far Lands Master lvl 3 (Far Lands bonus +5%)";
                    bonusFar = bonusFar + 5;
                }
                xcont = 5;
                i = 1;
            }

            if ((x == 6 ) && (x6 != 3))
            {
                x6 = x6 + 1;

                if (x6 == 1)
                {
                    perk = "Demoniac Lands Master (Demoniac Lands bonus +5%)";
                    bonusDemoniac = bonusDemoniac + 5;
                }
                if (x6 == 2)
                {
                    perk = "Demoniac Lands Master lvl 2 (Demoniac Lands bonus +5%)";
                    bonusDemoniac = bonusDemoniac + 5;
                }
                if (x6 == 3)
                {
                    perk = "Demoniac Lands Master lvl 3 (Demoniac Lands bonus +5%)";
                    bonusDemoniac = bonusDemoniac + 5;
                }
                xcont = 6;
                i = 1;
            }
            if ((x == 7) && (x7 != 3))
            {
                x7 = x7 + 1;

                if (x7 == 1)
                {
                    perk = "aggressor (+6 ATK)";
                    atk = atk + 6;
                }
                if (x7 == 2)
                {
                    perk = "aggressor lvl 2 (+6 ATK)";
                    atk = atk + 6;
                }
                if (x7 == 3)
                {
                    perk = "aggressor lvl 3 (+6 ATK)";
                    atk = atk + 6;
                }
                xcont = 7;
                i = 1;
            }
            if ((x == 8) && (x8 != 3))
            {
                x8 = x8 + 1;

                if (x8 == 1)
                {
                    perk = "defender (+6 DEF)";
                    def = def + 6;
                }
                if (x8 == 2)
                {
                    perk = "defender lvl 2 (+6 DEF)";
                    def = def + 6;
                }
                if (x8 == 3)
                {
                    perk = "defender lvl 3 (+6 DEF)";
                    def = def + 6;
                }
                xcont = 8;
                i = 1;
            }
            if ((x == 9 ) && (x9 != 3))
            {
                x9 = x9 + 1;

                if (x9 == 1)
                {
                    perk = "Brute Force (+10 Atk, -2 Def)";
                    atk = atk + 10;
                    def = def - 2;
                }
                if (x9 == 2)
                {
                    perk = "Brute Force lvl 2 (+10 Atk, -2 Def)";
                    atk = atk + 10;
                    def = def - 2;
                }
                if (x9 == 3)
                {
                    perk = "Brute Force lvl 3 (+10 Atk, -2 Def)";
                    atk = atk + 10;
                    def = def - 2;
                }
                xcont = 9;
                i = 1;
            }
            if ((x == 10 ) && (x10 != 3))
            {
                x10 = x10 + 1;

                if (x10 == 1)
                {
                    perk = "Wall of Stone (+10 Def, -2 Atk)";
                    def = def + 10;
                    atk = atk - 2;
                }
                if (x10 == 2)
                {
                    perk = "Wall of Stone lvl 2 (+10 Def, -2 Atk)";
                    def = def + 10;
                    atk = atk - 2;
                }
                if (x10 == 3)
                {
                    perk = "Wall of Stone lvl 3 (+10 Def, -2 Atk)";
                    def = def + 10;
                    atk = atk - 2;
                }
                xcont = 10;
                i = 1;
            }
        }
        return perk;
    }

    public string givePerkComment()
    {
        string comment = "error";
        if (xcont == 1)
        {
            comment = "L'esperienza di cento battaglie aiuta sempre (Bonus di battaglia +2%) ";
            xcont = 0;
        }
        if (xcont == 2)
        {
            comment = "Capacità di combattere e vincere contro l'avversario (+3 Atk, +3 Def)";
            xcont = 0;
        }
        if (xcont == 3)
        {
            comment = "'Le mura son la migliore difesa della città' (Bonus nelle mura della città +5%) ";
            xcont = 0;
        }
        if (xcont == 4)
        {
            comment = "'Le battaglie campali son la mia specialità'(Bonus fuori dalla città +5%)";
            xcont = 0;
        }
        if (xcont == 5)
        {
            comment = "'Lontano da casa, non soffro la nostalgia'(Bonus nelle terre lontane +5%)";
            xcont = 0;
        }
        if (xcont == 6)
        {
            comment = "'The Slayer Has Entered The Building' (Bonus nelle terre demoniache +5%";
            xcont = 0;
        }
        if (xcont == 7)
        {
            comment = "'Chi colpisce per primo colpisce due volte' (+6 Atk)";
            xcont = 0;
        }
        if (xcont == 8)
        {
            comment = "Un buon scudo è tutto quello che mi serve' (+6 Def)";
            xcont = 0;
        }
        if (xcont == 9)
        {
            comment = "'La forza è l'unica verità' (+10 Atk, -2 Def)";
            xcont = 0;
        }
        if (xcont == 10)
        {
            comment = "'Renditi invincibile, poi combatti' (+10 Def, -2 Atk)";
            xcont = 0;
        }
        return comment;
    }


    public void giveFinalComment()
    {
        finalcomment = "";
        while (finalcomment == "")
        {
            int x = (int)Random.Range(1f, 22f);
            if (x == 1)
            {
                finalcomment = "'His body is made of swords'";
            }
            if (x == 2)
            {
                finalcomment = "'He's even got a wolf!'";
            }
            if (x == 3)
            {
                finalcomment = "'Deus Vult'";
            }
            if (x == 4)
            {
                finalcomment = "'Got a plus two in TPC'";
            }
            if (x == 5)
            {
                finalcomment = "'I will have order'";
            }
            if (x == 6)
            {
                finalcomment = "'If you really want something...'";
            }
            if (x == 7)
            {
                finalcomment = "'Ah s**t, here we go again...'";
            }
            if (x == 8 && name == "Jack")
            {
                finalcomment = "'The wind... is troubled today'";
            }
            if (x == 9)
            {
                finalcomment = "'Our enemy is already dead'";
            }
            if (x == 10)
            {
                finalcomment = "'Glory lies beyond the horizon'";
            }
            if (x == 11)
            {
                finalcomment = "'It's not like I want to protect your City or something'";
            }
            if (x == 12)
            {
                finalcomment = "'People die if they are killed'";
            }
            if (x == 13)
            {
                finalcomment = "'Useless, useless, useless!'";
            }
            if (x == 14)
            {
                finalcomment = "'Nothing ever goes as planned in this accursed world'";
            }
            if (x == 15)
            {
                finalcomment = "'It is at the moment of death that humanity has value'";
            }
            if (x == 16)
            {
                finalcomment = "'I feel like I fought for thousands of battles, but I didn't'";
            }
            if (x == 17)
            {
                finalcomment = "'Soldiers, follow my lead!'";
            }
            if (x == 18)
            {
                finalcomment = "'This time... I won't lose!'";
            }
            if (x == 19)
            {
                finalcomment = "'Finally it's' " + nome + "'s turn to shine!'";
            }
            if (x == 20)
            {
                finalcomment = "'Our army funding should be '" + FindObjectOfType<Game>().moneyUI.text + " Golds'";
            }
            if (x == 21)
            {
                finalcomment = "'Don't worry, I'm the strongest.'";
            }
        }
    }

        public void giveName()
    {
        nome = "";
        while (nome == "")
        {
            int x = (int)Random.Range(1f, 18f);
            if (x == 1)
            {
                nome = "Jack";
            }
            if (x == 2)
            {
                nome = "Depp";
            }
            if (x == 3)
            {
                nome = "Tadakuni";
            }
            if (x == 4)
            {
                nome = "Captain";
            }
            if (x == 5)
            {
                nome = "Markovich";
            }
            if (x == 6)
            {
                nome = "Hopper";
            }
            if (x == 7)
            {
                nome = "Wolf";
            }
            if (x == 8)
            {
                nome = "Aro";
            }
            if (x == 9)
            {
                nome = "Arvon";
            }
            if (x == 10)
            {
                nome = "Macy";
            }
            if (x == 11)
            {
                nome = "Lalatina";
            }
            if (x == 12)
            {
                nome = "Aldenee";
            }
            if (x == 13)
            {
                nome = "Edelfelt";
            }
            if (x == 14)
            {
                nome = "Venezo";
            }
            if (x == 15)
            {
                nome = "C. Marcs";
            }
            if (x == 16)
            {
                nome = "Ragnar";
            }
            if (x == 17)
            {
                nome = "Philip";
            }
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
    
    public bool getcreato()
    {
        return creato;
    }
    public void setcreato()
    {
        creato = true;
        resetCaptain();
    }    
    
    public void setAtk(int x)
    {
        atk = atk + x;
    }
    public void setDef(int x)
    {
        def = def + x;
    }

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
    public string getFinalComment()
    {
        return finalcomment;
    }
    public int getBoolFinalComment()
    {
        return boolfinalcomment;
    }
}





using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//nell'edificio fabbro metterò attualmente pochi potenziamenti per ora, in quanto son ancora in fase di decisione/bilanciamento
public class Fabbro : MonoBehaviour
{
    int lvl = 1;
    int costo = 1000;
    public void lvlup()
    {
        lvl = lvl + 1;
        if (lvl == 2)
        {
            costo = 1500;
        }
        if (lvl == 3)
        {
            costo = 2000;
        }
        if (lvl == 4)
        {
            costo = 2500;
        }
    }

    public int getlvl()
    {
        return lvl;
    }
    public int getcosto()
    {
        return costo;
    }
    

    //------------------ soldati ------------------------
    int armi = 0;
    int armature = 0;
    public int getArmi ()
    {
        return armi;
    }
    public int getArmature()
    {
        return armature;
    }
    public void powerUPArmi(Soldiers.Swordsmen swordman, Soldiers.Archers archer, Soldiers.Riders rider)
    {
        armi = armi + 1;
        swordman.setRapidAtk(1);
        archer.setRapidAtk(1);
        rider.setRapidAtk(1);
    }

    public void powerUPArmature(Soldiers.Swordsmen swordman, Soldiers.Archers archer, Soldiers.Riders rider)
    {
        armature = armature + 1;
        swordman.setRapidDef(1);
        archer.setRapidDef(1);
        rider.setRapidDef(1);
    }

    //----------------economia-------------------------

    public int zappa = 0;
    public int goldzappa = 0;
    
    public void powerUPZappa (Fattoria fattoria)
    {
        zappa = zappa + 1;
        int lvlfattoria = fattoria.getLvlFattoria();
            if (lvlfattoria == 1)
        {
            goldzappa = 0;
        }
            if (lvlfattoria == 2)
        {
            goldzappa = 2;
        }
            if (lvlfattoria == 3)
        {
            goldzappa = 4;
        }
            if (lvlfattoria == 4)
        {
            goldzappa = 8;
        }
            if (lvlfattoria == 5)
        {
            goldzappa = 16;
        }
    }

    public int getZappa()
    {
        return zappa;
    }
    public int getSoldiZappa()
    {
        return goldzappa * zappa;
    }
    
    
    
    public int piccone = 0;
    public int goldpiccone = 0;

    public void powerUPPiccone(Miniera miniera)
    {
        piccone = piccone + 1;
        int lvlminiera = miniera.getLvlMiniera();
        if (lvlminiera == 1)
        {
            goldpiccone = 5;
        }
        if (lvlminiera == 2)
        {
            goldpiccone = 10;
        }
        if (lvlminiera == 3)
        {
            goldpiccone = 20;
        }
        if (lvlminiera == 4)
        {
            goldpiccone = 30;
        }
        if (lvlminiera == 5)
        {
            goldpiccone = 50;
        }
    }
    public int getSoldiPiccone()
    {
        return goldpiccone * piccone;
    }
    public void powerUPPiccone()
    {
        piccone = piccone + 1;
    }
    public int getPiccone()
    {
        return piccone;
    }








    public string getnextpotenziamento(int x)
    {
        if (x == 1)
        {
            if (armi < 5)
            {
                return "+" + (armi + 1);
            }
            else
            {
                return "MAX";
            }
        }
        if (x == 2)
        {
            if (armature < 5)
            {
                return "+" + (armature + 1);
            }
            else
            {
                return "MAX";
            }
        }
        if (x == 3)
        {
            if (zappa < 5)
            {
                return "+" + (zappa + 1);
            }
            else
            {
                return "MAX";
            }
        }
        else
        {
            if (piccone < 5)
            {
                return "+" + (piccone + 1);
            }
            else
            {
                return "MAX";
            }
        }




    }

    int costoarmi = 0;
    int costoarmature = 0;
    int costoZappa = 0;
    int costoPiccone = 0;

    public string getCostoPotenziamenti(int x)
    {

        if (x == 1)
        {
            if (armi == 0)
            {
                return "cost: 300";
            }
            if (armi == 1)
            {
                return "cost: 400";
            }
            if (armi == 2)
            {
                return "cost: 500";
            }
            if (armi == 3)
            {
                return "cost: 600";
            }
            if (armi == 4)
            {
                return "cost: 700";
            }
            else
            {
                return "max level";
            }

        }
        if (x == 2)
        {
            if (armature == 0)
            {
                return "cost: 300";
            }
            if (armature == 1)
            {
                return "cost: 400";
            }
            if (armature == 2)
            {
                return "cost: 500";
            }
            if (armature == 3)
            {
                return "cost: 600";
            }
            if (armature == 4)
            {
                return "cost: 700";
            }
            else
            {
                return "max level";
            }

        }
        if (x == 3)
        {
            if (zappa == 0)
            {
                return "cost: 200";
            }
            if (zappa == 1)
            {
                return "cost: 250";
            }
            if (zappa == 2)
            {
                return "cost: 300";
            }
            if (zappa == 3)
            {
                return "cost: 350";
            }
            if (zappa == 4)
            {
                return "cost: 400";
            }
            else
            {
                return "max level";
            }

        }
        else
        {
            if (piccone == 0)
            {
                return "cost: 400";
            }
            if (piccone == 1)
            {
                return "cost: 450";
            }
            if (piccone == 2)
            {
                return "cost: 500";
            }
            if (piccone == 3)
            {
                return "cost: 550";
            }
            if (piccone == 4)
            {
                return "cost: 600";
            }
            else
            {
                return "max level";
            }


        }
    }
        public int getCostoNumPotenziamenti(int x)
        {

            if (x == 1)
            {
                if (armi == 0)
                {
                    return 300;
                }
                if (armi == 1)
                {
                    return 400;
                }
                if (armi == 2)
                {
                    return 500;
                }
                if (armi == 3)
                {
                    return 600;
                }
                else
                {
                    return 700;
                }


            }
            if (x == 2)
            {
                if (armature == 0)
                {
                    return 300;
                }
                if (armature == 1)
                {
                    return 400;
                }
                if (armature == 2)
                {
                    return 500;
                }
                if (armature == 3)
                {
                    return 600;
                }
                else
                {
                    return 700;
                }


            }
            if (x == 3)
            {
                if (zappa == 0)
                {
                    return 200;
                }
                if (zappa == 1)
                {
                    return 250;
                }
                if (zappa == 2)
                {
                    return 300;
                }
                if (zappa == 3)
                {
                    return 350;
                }
                else
                {
                    return 400;
                }

            }
            else
            {
                if (piccone == 0)
                {
                    return 400;
                }
                if (piccone == 1)
                {
                    return 450;
                }
                if (piccone == 2)
                {
                    return 500;
                }
                if (piccone == 3)
                {
                    return 550;
                }
                else
                {
                    return 600;
                }



            }

        }





























}





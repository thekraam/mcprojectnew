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
}





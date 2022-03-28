using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gilda : MonoBehaviour
{
    public int lvl = 1;
    public int costo = 1000;
    public int sped1 = 1;
    public int sped2 = 0;
    public int sped3 = 0;
    public int sped4 = 0;
    public int sped5 = 0;

    string[] message = new string[10]; // array di stringhe da mandare al dialogo


    public void lvlup()
    {
        lvl = lvl + 1;
        if (lvl == 2)
        {
            sped2 = 1;
            costo = 2000;
        }
        if (lvl == 3)
        {
            sped3 = 1;
            costo = 3000;
        }
        if (lvl == 4)
        {
            sped4 = 1;
            costo = 4000;
        }
        if (lvl == 5)
        {
            sped5 = 1;
        }
    }

    public int getsped1()
    {
        return sped1;
    }
    public int getsped2()
    {
        return sped2;
    }
    public int getsped3()
    {
        return sped3;
    }
    public int getsped4()
    {
        return sped4;
    }
    public int getsped5()
    {
        return sped5;
    }

    public void setsped1(int x)
    {
        sped1 = x;
    }
    public void setsped2(int x)
    {
        sped2 = x;
    }
    public void setsped3(int x)
    {
        sped3 = x;
    }
    public void setsped4(int x)
    {
        sped4 = x;
    }
    public void setsped5(int x)
    {
        sped5 = x;
    }












    public int getlvl()
    {
        return lvl;
    }
    public int getcosto()
    {
        return costo;
    }


    public  void lvlUPWall(Player player)
    {
        player.bonusWall = player.bonusWall + 5;
    }

    public void lvlupCity (Player player)
    {
        player.bonusCity = player.bonusCity + 5;
    }

    public void cambiaCapitano (Captain1 capitano)
    {
        capitano.resetCaptain();
    }














    public int controllosped1 = 0;
    public int controllosped2 = 0;

    public int getcontrollosped1()
    {
        return controllosped1;
    }
    public int getcontrollosped2()
    {
        return controllosped2;
    }
    public void setcontrollosped1(int modifier)
    {
        controllosped1 = modifier;
    }
    public void setcontrollosped2(int modifier)
    {
        controllosped2 = modifier;
    }





    public void spedizione (Player player,Soldiers.Swordsmen swordmen, Soldiers.Archers archers, Soldiers.Riders riders, int x, OldSoldiersManager manager)
    {
        Debug.LogError("Entro dentro gilda");
        Debug.LogError("controllo1 = " + controllosped1);
        Debug.LogError("controllo2 = " + controllosped2);
        int y = 0;

        if (controllosped1 == 0)
        {
            controllosped1 = 1;
        }
        else
        {
            controllosped2 = 1;
        }



        if (x == 1)
        {
            swordmen.setRapidTotal(-5);
            archers.setRapidTotal(-5);
            sped1 = 0;
            player.setsoldiersaway(10);
        }
        if (x == 2)
        {
            swordmen.setRapidTotal(-10);
            archers.setRapidTotal(-10);
            sped2 = 0;
            player.setsoldiersaway(20);
        }
        if (x == 3)
        {
            swordmen.setRapidTotal(-10);
            archers.setRapidTotal(-10);
            riders.setRapidTotal(-10);
            sped3 = 0;
            player.setsoldiersaway(30);
        }
        if (x == 4)
        {
            swordmen.setRapidTotal(-15);
            archers.setRapidTotal(-15);
            riders.setRapidTotal(-10);
            sped4 = 0;
            player.setsoldiersaway(40);
        }
        if (x == 5)
        {
            swordmen.setRapidTotal(-20);
            archers.setRapidTotal(-20);
            riders.setRapidTotal(-10);
            sped5 = 0;
            player.setsoldiersaway(50);
        }




        y = (int)Random.Range(1f, 5f);

        if (x == 1 && y == 1) //no battaglia
        {

            swordmen.setMomentSwordman(5);
            archers.setMomentArcher(5);
            Debug.LogError("y = 1");
            manager.salvasoldati(swordmen, archers, riders, 1);
            manager.gildaimpostamex(1,y, 5, 5, 0);
            /*
            // format invio stringhe
            string eventString1 = "Questo";
            string eventString2 = "�";
            string eventString3 = "un banale esempio";
         // string eventString4 = "possibile frase in pi�";
         // string eventString5 = "altra possibile frase in pi�, fino a 10 totali";

            string[] message = { eventString1, eventString2, eventString3 /*, eventString4, eventString5...*/// };

           // FindObjectOfType<DialogueManagerMINI>().StartDialogue(false, /* --> inserisci qui il nome di chi parla, se non lo vuoi metti "" --> */"Guild Master", message); 
   
    }
        if (x == 1 && y == 2) //battaglia persa
        {
            int s = ((int)Random.Range(1f, 6f));
            int a = ((int)Random.Range(1f, 6f));
            Debug.LogError("y =  2");
            swordmen.setMomentSwordman(s);
            archers.setMomentArcher(a);
            manager.salvasoldati(swordmen, archers, riders, 1);
            manager.gildaimpostamex(2,y, s, a, 0);
            
            //dialogo da mettere 
        }
        if (x == 1 && y == 3) //battaglia vinta
        {
            int s = ((int)Random.Range(3f, 6f));
            int a = ((int)Random.Range(3f, 6f));
            Debug.LogError("y = 3");
            swordmen.setMomentSwordman(s);
            archers.setMomentArcher(a);
            manager.salvasoldati(swordmen, archers, riders, 1);
            manager.gildaimpostamex(3,y, s, a, 0);
            
            //dialogo da mettere 
        }
        if (x == 1 && y == 4)//no battaglia ma bonus
        {

            swordmen.setMomentSwordman(5);
            archers.setMomentArcher(5);
            Debug.LogError("y = 4");
            manager.salvasoldati(swordmen, archers, riders, 1);
            manager.gildaimpostamex(4,y, 5, 5, 0);
            
            //dialogo da mettere 
        }

        //-------------------------------------------------------------------------
        if (x == 2 && y == 1) //no battaglia
        {

            swordmen.setMomentSwordman(10);
            archers.setMomentArcher(10);
            manager.salvasoldati(swordmen, archers, riders, 2);
            manager.gildaimpostamex(5,y, 10, 10, 0);
            //dialogo da mettere 
        }
        if (x == 2 && y == 2) //battaglia persa
        {
            int s = ((int)Random.Range(1f, 11f));
            int a = ((int)Random.Range(1f, 11f));
            swordmen.setMomentSwordman(s);
            archers.setMomentArcher(a);
            manager.salvasoldati(swordmen, archers, riders, 2);
            manager.gildaimpostamex(6,y, s, a, 0);
            //dialogo da mettere 
        }
        if (x == 2 && y == 3) //battaglia vinta
        {
            int s = ((int)Random.Range(6f, 11f));
            int a = ((int)Random.Range(6f, 11f));
            swordmen.setMomentSwordman(s);
            archers.setMomentArcher(a);
            manager.salvasoldati(swordmen, archers, riders, 2);
            manager.gildaimpostamex(7,y, s, a, 0);
            //dialogo da mettere 
        }
        if (x == 2 && y == 4)//no battaglia ma bonus
        {

            swordmen.setMomentSwordman(10);
            archers.setMomentArcher(10);
            manager.salvasoldati(swordmen, archers, riders, 2);
            manager.gildaimpostamex(8,y, 10, 10, 0);
            //dialogo da mettere 
        }


        //----------------------------------------------------------------------
        if (x == 3 && y == 1) //no battaglia
        {
            riders.setMomentRider(10);
            swordmen.setMomentSwordman(10);
            archers.setMomentArcher(10);
            manager.salvasoldati(swordmen, archers, riders, 2);
            manager.gildaimpostamex(9,y, 10, 10, 10);
            //dialogo da mettere 
        }
        if (x == 3 && y == 2) //battaglia persa
        {
            int s = ((int)Random.Range(1f, 11f));
            int a = ((int)Random.Range(1f, 11f));
            int r = ((int)Random.Range(1f, 11f));
            swordmen.setMomentSwordman(s);
            archers.setMomentArcher(a);
            riders.setMomentRider(r);
            manager.salvasoldati(swordmen, archers, riders, 2);
            manager.gildaimpostamex(10,y, s, a, r);
            //dialogo da mettere 
        }
        if (x == 3 && y == 3) //battaglia vinta
        {
            int s = ((int)Random.Range(7f, 11f));
            int a = ((int)Random.Range(7f, 11f));
            int r = ((int)Random.Range(7f, 11f));
            swordmen.setMomentSwordman(s);
            archers.setMomentArcher(a);
            riders.setMomentRider(r);
            manager.salvasoldati(swordmen, archers, riders, 2);
            manager.gildaimpostamex(11,y, s, a, r);
            //dialogo da mettere 
        }
        if (x == 3 && y == 4)//no battaglia ma bonus
        {
            riders.setMomentRider(10);
            swordmen.setMomentSwordman(10);
            archers.setMomentArcher(10);
            manager.salvasoldati(swordmen, archers, riders, 2);
            manager.gildaimpostamex(12,y, 10, 10, 10);
            //dialogo da mettere 
        }

        //----------------------------------------------------------------------------

        if (x == 4 && y == 1) //no battaglia
        {
            riders.setMomentRider(10);
            swordmen.setMomentSwordman(15);
            archers.setMomentArcher(15);
            manager.salvasoldati(swordmen, archers, riders, 3);
            manager.gildaimpostamex(13,y, 15, 15, 10);
            //dialogo da mettere 
        }
        if (x == 4 && y == 2) //battaglia persa
        {
            int s = ((int)Random.Range(1f, 16f));
            int a = ((int)Random.Range(1f, 16f));
            int r = ((int)Random.Range(1f, 11f));
            riders.setMomentRider(r);
            swordmen.setMomentSwordman(s);
            archers.setMomentArcher(a);
            manager.salvasoldati(swordmen, archers, riders, 3);
            manager.gildaimpostamex(14,y, s, a, r);
            //dialogo da mettere 
        }
        if (x == 4 && y == 3) //battaglia vinta
        {
            int s = ((int)Random.Range(10f, 16f));
            int a = ((int)Random.Range(10f, 16f));
            int r = ((int)Random.Range(17f, 11f));
            riders.setMomentRider(r);
            swordmen.setMomentSwordman(s);
            archers.setMomentArcher(a);
            manager.salvasoldati(swordmen, archers, riders, 3);
            manager.gildaimpostamex(15,y, s, a, r);
            //dialogo da mettere 
        }
        if (x == 4 && y == 4)//no battaglia ma bonus
        {
            riders.setMomentRider(10);
            swordmen.setMomentSwordman(15);
            archers.setMomentArcher(15);
            manager.salvasoldati(swordmen, archers, riders, 3);
            manager.gildaimpostamex(16,y, 15, 15, 10);
            //dialogo da mettere 
        }
        //-----------------------------------------------------------------------------------
        if (x == 5 && y == 1) //no battaglia
        {
            riders.setMomentRider(10);
            swordmen.setMomentSwordman(20);
            archers.setMomentArcher(20);
            manager.salvasoldati(swordmen, archers, riders, 4);
            manager.gildaimpostamex(17,y, 20, 20, 10);
            //dialogo da mettere 
        }
        if (x == 5 && y == 2) //battaglia persa
        {
            int s = ((int)Random.Range(1f, 21f));
            int a = ((int)Random.Range(1f, 21f));
            int r = ((int)Random.Range(1f, 11f));
            riders.setMomentRider(r);
            swordmen.setMomentSwordman(s);
            archers.setMomentArcher(a);
            manager.salvasoldati(swordmen, archers, riders, 4);
            manager.gildaimpostamex(18,y, s, a, r);
            //dialogo da mettere 
        }
        if (x == 5 && y == 3) //battaglia vinta
        {
            int s = ((int)Random.Range(15f, 21f));
            int a = ((int)Random.Range(15f, 21f));
            int r = ((int)Random.Range(7f, 11f));
            riders.setMomentRider(r);
            swordmen.setMomentSwordman(s);
            archers.setMomentArcher(a);
            manager.salvasoldati(swordmen, archers, riders, 4);
            manager.gildaimpostamex(19,y, s, a, r);
            //dialogo da mettere 
        }
        if (x == 5 && y == 4)//no battaglia ma bonus
        {
            riders.setMomentRider(10);
            swordmen.setMomentSwordman(20);
            archers.setMomentArcher(20);
            manager.salvasoldati(swordmen, archers, riders, 4);
            manager.gildaimpostamex(20,y, 20, 20, 10);
            //dialogo da mettere 
        }






        Debug.LogError("controllo1 = " + controllosped1);
        Debug.LogError("controllo2 = " + controllosped2);

        Debug.LogError("fine percorso");






    }









    public string segnalanumsped()
    {
        if (controllosped1 == 0 && controllosped2 == 0) { return "0/2"; }
        if (controllosped1 == 1 && controllosped2 == 0) { return "1/2"; }
        if (controllosped1 == 0 && controllosped2 == 1) { return "1/2"; }
        else { return "2/2"; }

    }


}

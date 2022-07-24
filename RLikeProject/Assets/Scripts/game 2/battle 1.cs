using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//riguardo i bonus territoriali : 1 mura citta, 2 fuori citta, 3 terre lontane, 4 terre demoniache
// riguardo la fine, : 1 sconfitta grave, 2 sconfitta, 3 vittoria, 4 vittoria decisiva


public class battle1 : MonoBehaviour
{


    public int battaglia(Captain1 capitano1, Captain2 capitano2, Soldiers.Swordsmen swordman, Soldiers.Archers archer, Soldiers.Riders rider, Enemy.ESwordsmen eswordman, Enemy.EArchers earcher, Enemy.ERiders erider, float terri, float bonusTerri, float bonusETerri, float bonusSoldier, float bonusEnemy)
    {
        //------------------------------------reset KillList-----------------------------------

        int ATKlist = (swordman.getAtk() * swordman.getMomentSwordman()) + (archer.getAtk() * archer.getMomentArcher()) + (rider.getAtk() * rider.getMomentRider());
        int DEFlist = (swordman.getDef() * swordman.getMomentSwordman()) + (archer.getDef() * archer.getMomentArcher()) + (rider.getDef() * rider.getMomentRider());
        int EATKlist = (eswordman.getAtk() * eswordman.getTotal()) + (earcher.getAtk() * earcher.getTotal()) + (erider.getAtk() * erider.getTotal());
        int EDEFlist = (eswordman.getDef() * eswordman.getTotal()) + (earcher.getDef() * earcher.getTotal()) + (erider.getDef() * erider.getTotal());

        int totS = 1 + swordman.getMomentSwordman() + archer.getMomentArcher() + rider.getMomentRider();
        int totES = 1 + eswordman.getTotal() + earcher.getTotal() + erider.getTotal();

        FindObjectOfType<KillList>().setKillList(totS, totES, ATKlist, DEFlist, EATKlist, EDEFlist);
        //------------------------------------reset morti-----------------------------------
        swordman.setMomentDeadSwordman(-swordman.getMomentDeadSwordman());
        archer.setMomentDeadArcher(-archer.getMomentDeadArcher());
        rider.setMomentDeadRider(-rider.getMomentDeadRider());
        //swordman.setMomentSwordman(0);
        //archer.setMomentArcher(0);
        //rider.setMomentRider(0);

        //----------------------------------------------------------------------------------
        int fine = 0;
        int rapporto1 = 0;
        int rapporto2 = 0;
        int turno = 1;
        //------------------------------------calcolo bonus---------------------------------
        float bonuscaptain = 0;
        if (terri == 1)
        {
            bonuscaptain = capitano1.getBonusWall();
        }
        if (terri == 2)
        {
            bonuscaptain = capitano1.getBonusCity();
        }
        if (terri == 3)
        {
            bonuscaptain = capitano1.getBonusFar();
        }
        if (terri == 4)
        {
            bonuscaptain = capitano1.getBonusDemoniac();
        }
        bonuscaptain = bonuscaptain + capitano1.getBonusBattle();

        float bonusEcaptain = 0;
        if (terri == 1)
        {
            bonusEcaptain = capitano2.getBonusWall();
        }
        if (terri == 2)
        {
            bonusEcaptain = capitano2.getBonusCity();
        }
        if (terri == 3)
        {
            bonusEcaptain = capitano2.getBonusFar();
        }
        if (terri == 4)
        {
            bonusEcaptain = capitano2.getBonusDemoniac();
        }
        bonusEcaptain = bonusEcaptain + capitano2.getBonusBattle();

        float bonustot = bonusTerri + bonusSoldier + bonuscaptain;
        float bonusEtot = bonusETerri + bonusEnemy + bonusEcaptain;
        //---------------------------------------------variabili dell'algoritmo--------------------------------------------------
        float ATK = 0;
        float DEF = 0;
        float EATK = 0;
        float EDEF = 0;

        float percswordman = 0;
        float percarcher = 0;
        float percrider = 0;
        float percEswordman = 0;
        float percEarcher = 0;
        float percErider = 0;

        float x1;
        float x2;
        float y1;
        float y2;
        float z1;
        float z2;

        float totalsoldiers = 0;
        float totalEsoldiers = 0;
        float deadsoldier = 0;
        float deadEsoldier = 0;
        float deadswordman = 0;
        float deadarcher = 0;
        float deadrider = 0;
        float deadeswordman = 0;
        float deadearcher = 0;
        float deaderider = 0;



        int contatorestampa = 0;
        int randomstampa = 0;
        int cont1 = 0;
        int cont2 = 0;
        int cont3 = 0;
        int cont4 = 0;
        int cont5 = 0;
        int cont6 = 0;





        //swordman.getMomentSwordman() + archer.getMomentArcher() + rider.getMomentRider()

        while (turno < 6)
        {
            cont1 = 0;
            cont2 = 0;
            cont3 = 0;
            cont4 = 0;
            cont5 = 0;
            cont6 = 0;
            //----------------------------------calcoli iniziali del ciclo----------------------------------------
            ATK = (swordman.getAtk() * swordman.getMomentSwordman()) + (archer.getAtk() * archer.getMomentArcher()) + (rider.getAtk() * rider.getMomentRider());
            DEF = (swordman.getDef() * swordman.getMomentSwordman()) + (archer.getDef() * archer.getMomentArcher()) + (rider.getDef() * rider.getMomentRider());

            EATK = (eswordman.getAtk() * eswordman.getTotal()) + (earcher.getAtk() * earcher.getTotal()) + (erider.getAtk() * erider.getTotal());
            EDEF = (eswordman.getDef() * eswordman.getTotal()) + (earcher.getDef() * earcher.getTotal()) + (erider.getDef() * erider.getTotal());

            percswordman = (100 * (swordman.getDef() * swordman.getMomentSwordman())) / DEF;
            percarcher = (100 * (archer.getDef() * archer.getMomentArcher())) / DEF;
            percrider = (100 * (rider.getDef() * rider.getMomentRider())) / DEF;

            percEswordman = (100 * (eswordman.getDef() * eswordman.getTotal())) / EDEF;
            percEarcher = (100 * (earcher.getDef() * earcher.getTotal())) / EDEF;
            percErider = (100 * (erider.getDef() * erider.getTotal())) / EDEF;

            ATK = ATK + capitano1.getAtk();
            DEF = DEF + capitano1.getDef();
            //Debug.LogError("EATK prova " + EATK);
            // Debug.LogError("EDEF prova " + EDEF);
            // Debug.LogError("Ecapitano ATK prova" + capitano2.getAtk());
            //Debug.LogError("Ecapitano DEF prova" + capitano2.getDef());
            EATK = EATK + capitano2.getAtk();
            EDEF = EDEF + capitano2.getDef();


            // Debug.LogError("EATK prova2 " + EATK);
            // Debug.LogError("EDEF prova2 " + EDEF);
            ATK = ATK + ((ATK / 100) * bonustot);
            DEF = DEF + ((DEF / 100) * bonustot);
            EATK = EATK + ((EATK / 100) * bonusEtot);
            EDEF = EDEF + ((EDEF / 100) * bonusEtot);

            //-----------------------------passaggio 1 ===> x, y, z -----------------------------------------------------------
            x1 = 0;
            x2 = 0;
            y1 = 0;
            y2 = 0;
            z1 = 0;
            z2 = 0;
            //Debug.LogError("ATK " + ATK);
            //Debug.LogError("EDEF" + EDEF);
            // Debug.LogError("EATK" + EATK);
            // Debug.LogError("DEF" + DEF);
            x1 = ATK - EDEF;

            x2 = EATK - DEF;

            y1 = (x1 * 100) / EDEF;
            // Debug.LogError("y1 " + y1);
            y2 = (x2 * 100) / DEF;
            // Debug.LogError("y2 " + y2);

            z1 = (int)Random.Range(1f, 16f);
            z1 = z1 + ((z1 / 100) * y1);
            // Debug.LogError("z1 " + z1);
            z2 = (int)Random.Range(1f, 16f);
            z2 = z2 + ((z2 / 100) * y2);
            // Debug.LogError("z2 " + z2);

            rapporto1 = (int)(rapporto1 + z1);
            // Debug.LogError("rapporto 1 " + rapporto1);
            rapporto2 = (int)(rapporto2 + z2);
            // Debug.LogError("rapporto 2 " + rapporto2);
            //-----------------------------passaggio 2 ===>  morte soldati -----------------------------------------------------------
            totalsoldiers = swordman.getMomentSwordman() + archer.getMomentArcher() + rider.getMomentRider();
            totalEsoldiers = eswordman.getTotal() + earcher.getTotal() + erider.getTotal();

            deadsoldier = (int)((totalsoldiers / 100) * z2);
            //Debug.LogError("deadsoldier " + deadsoldier );
            deadEsoldier = (int)((totalEsoldiers / 100) * z1);
            // Debug.LogError("deadEsoldier " + deadEsoldier);
            deadswordman = (int)((deadsoldier / 100) * percswordman);
            //  Debug.LogError("deadswordman " + deadswordman);
            swordman.setMomentDeadSwordman ((int)deadswordman);
            deadarcher = (int)((deadsoldier / 100) * percarcher);
            //   Debug.LogError("deadarcher " + deadarcher);
            archer.setMomentDeadArcher((int)deadarcher);
            deadrider = (int)((deadsoldier / 100) * percrider);
            //   Debug.LogError("deadrider " + deadrider);
            rider.setMomentDeadRider((int)deadrider);
            deadeswordman = (int)((deadEsoldier / 100) * percEswordman);
            //  Debug.LogError("deadEswordman " + deadeswordman);
            deadearcher = (int)((deadEsoldier / 100) * percEarcher);
            //  Debug.LogError("deadEarcher " + deadearcher);
            deaderider = (int)((deadEsoldier / 100) * percErider);
            //  Debug.LogError("deadErider " + deaderider);

            swordman.setMomentSwordman( swordman.getMomentSwordman() + (int)-deadswordman);
            if (swordman.getMomentSwordman() < 0)
            {
                swordman.setMomentSwordman(0);
            }
            archer.setMomentArcher(archer.getMomentArcher() + (int)-deadarcher);
            if (archer.getMomentArcher() < 0)
            {
                archer.setMomentArcher(0);
            }
            rider.setMomentRider(rider.getMomentRider() + (int)-deadrider);
            if (rider.getMomentRider() < 0)
            {
                rider.setMomentRider(0);
            }
            eswordman.setRapidTotal((int)-deadeswordman);
            if (eswordman.getTotal() < 0)
            {
                eswordman.setRapidTotal(-eswordman.getTotal());
            }
            earcher.setRapidTotal((int)-deadearcher);
            if (earcher.getTotal() < 0)
            {
                earcher.setRapidTotal(-earcher.getTotal());
            }
            erider.setRapidTotal((int)-deaderider);
            if (erider.getTotal() < 0)
            {
                erider.setRapidTotal(-erider.getTotal());
            }

            if (totalEsoldiers == 0 || totalsoldiers == 0)
            {
                turno = 6;
            }



            

            contatorestampa = 6;

            if (deadswordman == 0) { contatorestampa = contatorestampa - 1; }
            if (deadarcher == 0) { contatorestampa = contatorestampa - 1; }
            if (deadrider == 0) { contatorestampa = contatorestampa - 1; }
            if (deadeswordman == 0) { contatorestampa = contatorestampa - 1; }
            if (deadearcher == 0) { contatorestampa = contatorestampa - 1; }
            if (deaderider == 0) { contatorestampa = contatorestampa - 1; }

            while (contatorestampa > 0)
            {

                randomstampa = (int)Random.Range(1f, 7f);


                if (randomstampa == 1 && cont1 == 0 && deadswordman > 0)
                {
                    if (deadswordman == 1)
                    {
                        FindObjectOfType<KillList>().insertNewLine("You have lost " + deadswordman + " swordsman", 1);
                        FindObjectOfType<KillList>().setFightingSoldiers(0, (int)deadswordman, swordman.getAtk() , swordman.getDef() );
                    }
                    else
                    {
                        FindObjectOfType<KillList>().insertNewLine("You have lost " + deadswordman + " swordsmen", 1);
                        FindObjectOfType<KillList>().setFightingSoldiers(0, (int)deadswordman, swordman.getAtk()* (int)deadswordman, swordman.getDef()* (int)deadswordman);
                    }
                        cont1 = 1;
                    contatorestampa--;
                }
                if (randomstampa == 2 && cont2 == 0 && deadarcher > 0)
                {
                    if (deadarcher == 1)
                    {
                        FindObjectOfType<KillList>().insertNewLine("You have lost " + deadarcher + " archer", 1);
                        FindObjectOfType<KillList>().setFightingSoldiers(0, (int)deadarcher, archer.getAtk()*(int)deadarcher, archer.getDef()* (int)deadarcher);
                    }
                    else
                    {
                        FindObjectOfType<KillList>().insertNewLine("You have lost " + deadarcher + " archers", 1);
                        FindObjectOfType<KillList>().setFightingSoldiers(0, (int)deadarcher, archer.getAtk() * (int)deadarcher, archer.getDef() * (int)deadarcher);
                    }
                    cont2 = 1;
                    contatorestampa--;
                }
                if (randomstampa == 3 && cont3 == 0 && deadrider > 0)
                {
                    if (deadrider == 1)
                    {
                        FindObjectOfType<KillList>().insertNewLine("You have lost " + deadrider + " rider", 1);
                        FindObjectOfType<KillList>().setFightingSoldiers(0, (int)deadrider, rider.getAtk()* (int)deadrider , rider.getDef()* (int)deadrider );
                    }
                    else
                    {
                        FindObjectOfType<KillList>().insertNewLine("You have lost " + deadrider + " riders", 1);
                        FindObjectOfType<KillList>().setFightingSoldiers(0, (int)deadrider, rider.getAtk() * (int)deadrider, rider.getDef() * (int)deadrider);
                    }
                    cont3 = 1;
                    contatorestampa--;
                }
                if (randomstampa == 4 && cont4 == 0 && deadeswordman > 0)
                {
                    if (deadeswordman == 1)
                    {
                        FindObjectOfType<KillList>().insertNewLine("Enemy has lost " + deadeswordman + " swordsman", 2);
                        FindObjectOfType<KillList>().setFightingSoldiers(1, (int)deadeswordman, eswordman.getAtk()* (int)deadeswordman , eswordman.getDef()* (int)deadeswordman );
                    }
                    else
                    {
                        FindObjectOfType<KillList>().insertNewLine("Enemy has lost " + deadeswordman + " swordsmen", 2);
                        FindObjectOfType<KillList>().setFightingSoldiers(1, (int)deadeswordman, eswordman.getAtk() * (int)deadeswordman, eswordman.getDef() * (int)deadeswordman);
                    }
                    cont4 = 1;
                    contatorestampa--;
                }
                if (randomstampa == 5 && cont5 == 0 && deadearcher > 0)
                {
                    if (deadearcher == 1)
                    {
                        FindObjectOfType<KillList>().insertNewLine("Enemy has lost " + deadearcher + " archer", 2);
                        FindObjectOfType<KillList>().setFightingSoldiers(1, (int)deadearcher, earcher.getAtk()* (int)deadearcher,earcher.getDef()* (int)deadearcher );
                    }
                    else
                    {
                        FindObjectOfType<KillList>().insertNewLine("Enemy has lost " + deadearcher + " archers", 2);
                        FindObjectOfType<KillList>().setFightingSoldiers(1, (int)deadearcher, earcher.getAtk() * (int)deadearcher, earcher.getDef() * (int)deadearcher);
                    }
                    cont5 = 1;
                    contatorestampa--;
                }
                if (randomstampa == 6 && cont6 == 0 && deaderider > 0)
                {
                    if (deaderider == 1)
                    {
                        FindObjectOfType<KillList>().insertNewLine("Enemy has lost " + deaderider + " rider", 2);
                        FindObjectOfType<KillList>().setFightingSoldiers(1, (int)deaderider, erider.getAtk()* (int)deaderider , erider.getDef()* (int)deaderider );
                    }
                    else
                    {
                        FindObjectOfType<KillList>().insertNewLine("Enemy has lost " + deaderider + " riders", 2);
                        FindObjectOfType<KillList>().setFightingSoldiers(1, (int)deaderider, erider.getAtk() * (int)deaderider, erider.getDef() * (int)deaderider);
                    }
                    cont6 = 1;
                    contatorestampa--;
                }



            }















            turno++;
        }



        int random1 = (int)Random.Range(1f, 10f);
        int random2 = (int)Random.Range(1f, 10f);
        float casorapporto = (((float)(rapporto1) / 100) * random1);
        float casorapporto2 = (((float)(rapporto2) / 100) * random2);
        // Debug.LogError("casorapporto1 " + casorapporto);
        // Debug.LogError("casorapporto2" + casorapporto2);
        // Debug.LogError("rapporto 1 quasi finale " + rapporto1);
        // Debug.LogError("rapporto 2 quasi finale " + rapporto2);
        rapporto1 = rapporto1 + (int)casorapporto;
        rapporto2 = rapporto2 + (int)casorapporto2;
        //  Debug.LogError("rapporto 1 finale " + rapporto1);
        //  Debug.LogError("rapporto 2 finale " + rapporto2);
        if (rapporto1 >= rapporto2)
        {
            if (rapporto1 >= (rapporto2 + (rapporto2 / 2)))
            {
                fine = 4;
            }
            else
            {
                fine = 3;
            }
        }
        else
        {
            if (rapporto2 >= (rapporto1 + (rapporto1 / 2)))
            {
                fine = 1;
            }
            else
            {
                fine = 2;
            }
        }
        // Debug.LogError("numero vittoria " + fine);
        return fine;
    }





}
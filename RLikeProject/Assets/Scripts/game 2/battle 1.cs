using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//riguardo i bonus territoriali : 1 mura citta, 2 fuori citta, 3 terre lontane, 4 terre demoniache
// riguardo la fine, : 1 sconfitta grave, 2 sconfitta, 3 vittoria, 4 vittoria decisiva


public class battle1 : MonoBehaviour
{



    public int battaglia(Captain1 capitano1, Captain2 capitano2, Soldiers.Swordsmen swordman, Soldiers.Archers archer, Soldiers.Riders rider, Enemy.ESwordsmen eswordman, Enemy.EArchers earcher, Enemy.ERiders erider, float terri, float bonusTerri, float bonusETerri, float bonusSoldier, float bonusEnemy)
    {
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


        while (turno < 6)
        {
            //----------------------------------calcoli iniziali del ciclo----------------------------------------
            ATK = (swordman.getAtk() * swordman.getTotal()) + (archer.getAtk() * archer.getTotal()) + (rider.getAtk() * rider.getTotal());
            DEF = (swordman.getDef() * swordman.getTotal()) + (archer.getDef() * archer.getTotal()) + (rider.getDef() * rider.getTotal());
            EATK = (eswordman.getAtk() * eswordman.getTotal()) + (earcher.getAtk() * earcher.getTotal()) + (erider.getAtk() * erider.getTotal());
            EDEF = (eswordman.getDef() * eswordman.getTotal()) + (earcher.getDef() * earcher.getTotal()) + (erider.getDef() * erider.getTotal());
            percswordman = (100 * (swordman.getDef() * swordman.getTotal())) / DEF;
            percarcher = (100 * (archer.getDef() * archer.getTotal())) / DEF;
            percrider = (100 * (rider.getDef() * rider.getTotal())) / DEF;
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
            //  Debug.LogError("y1 " + y1);
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
            totalsoldiers = swordman.getTotal() + archer.getTotal() + rider.getTotal();
            totalEsoldiers = eswordman.getTotal() + earcher.getTotal() + erider.getTotal();

            deadsoldier = (int)((totalsoldiers / 100) * z2);
            //Debug.LogError("deadsoldier " + deadsoldier );
            deadEsoldier = (int)((totalEsoldiers / 100) * z1);
            // Debug.LogError("deadEsoldier " + deadEsoldier);
            deadswordman = (int)((deadsoldier / 100) * percswordman);
            //  Debug.LogError("deadswordman " + deadswordman);
            deadarcher = (int)((deadsoldier / 100) * percarcher);
            //   Debug.LogError("deadarcher " + deadarcher);
            deadrider = (int)((deadsoldier / 100) * percrider);
            //   Debug.LogError("deadrider " + deadrider);
            deadeswordman = (int)((deadEsoldier / 100) * percEswordman);
            //  Debug.LogError("deadEswordman " + deadeswordman);
            deadearcher = (int)((deadEsoldier / 100) * percEarcher);
            //  Debug.LogError("deadEarcher " + deadearcher);
            deaderider = (int)((deadEsoldier / 100) * percErider);
            //  Debug.LogError("deadErider " + deaderider);

            swordman.setRapidTotal((int)-deadswordman);
            if (swordman.getTotal() < 0)
            {
                swordman.setRapidTotal(-swordman.getTotal());
            }
            archer.setRapidTotal((int)-deadarcher);
            if (archer.getTotal() < 0)
            {
                archer.setRapidTotal(-archer.getTotal());
            }
            rider.setRapidTotal((int)-deadrider);
            if (rider.getTotal() < 0)
            {
                rider.setRapidTotal(-rider.getTotal());
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
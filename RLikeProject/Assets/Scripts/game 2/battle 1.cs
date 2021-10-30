using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//riguardo i bonus territoriali : 1 mura citta, 2 fuori citta, 3 terre lontane, 4 terre demoniache
// riguardo la fine, : 1 sconfitta grave, 2 sconfitta, 3 vittoria, 4 vittoria decisiva


public class battle1 : MonoBehaviour
{
    int fine = 0;
    int rapporto1 = 0;
    int rapporto2 = 0;



    public int battaglia(Captain1 capitano1, Captain2 capitano2, Soldiers.Swordsmen swordman, Soldiers.Archers archer, Soldiers.Riders rider, Enemy.ESwordsmen eswordman, Enemy.EArchers earcher, Enemy.ERiders erider, float terri, float bonusTerri, float bonusETerri, float bonusSoldier, float bonusEnemy)
    {
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
        //------------------------------------------------------------------------------------------------------

        while (turno < 4)
        {
            //----------------------------------calcoli iniziali del ciclo----------------------------------------
            float ATK = (swordman.getAtk() * swordman.getTotal()) + (archer.getAtk() * archer.getTotal()) + (rider.getAtk() * rider.getTotal());
            float DEF = (swordman.getDef() * swordman.getTotal()) + (archer.getDef() * archer.getTotal()) + (rider.getDef() * rider.getTotal());
            float EATK = (eswordman.getAtk() * eswordman.getTotal()) + (earcher.getAtk() * earcher.getTotal()) + (erider.getAtk() * erider.getTotal());
            float EDEF = (eswordman.getDef() * eswordman.getTotal()) + (earcher.getDef() * earcher.getTotal()) + (erider.getDef() * erider.getTotal());

            float percswordman = (DEF / 100) * (swordman.getDef() * swordman.getTotal());
            float percarcher = (DEF / 100) * (archer.getDef() * archer.getTotal());
            float percrider = (DEF / 100) * (rider.getDef() * archer.getTotal());
            float percEswordman = (DEF / 100) * (eswordman.getDef() * eswordman.getTotal());
            float percEarcher = (DEF / 100) * (earcher.getDef() * earcher.getTotal());
            float percErider = (DEF / 100) * (erider.getDef() * erider.getTotal());
            ATK = ATK + capitano1.getAtk();
            DEF = DEF + capitano1.getDef();
            EATK = EATK + capitano2.getAtk();
            EDEF = EDEF + capitano2.getDef();


            ATK = ATK + ((ATK / 100) * bonustot);
            DEF = DEF + ((DEF / 100) * bonustot);
            EATK = EATK + ((EATK / 100) * bonusEtot);
            EDEF = EDEF + ((EDEF / 100) * bonusEtot);

            //-----------------------------passaggio 1 ===> x, y, z -----------------------------------------------------------
            float x1 = 0;
            float x2 = 0;
            float y1 = 0;
            float y2 = 0;
            float z1 = 0;
            float z2 = 0;
            x1 = ATK - EDEF;
            rapporto1 = (int)(rapporto1 + x1);
            x2 = EATK - DEF;
            rapporto2 = (int)(rapporto2 + x2);
            y1 = EDEF / x1;
            y2 = DEF / x2;
            z1 = (int)Random.Range(1f, 15f);
            z1 = z1 + ((z1 / 100) * y1);
            z2 = (int)Random.Range(1f, 15f);
            z2 = z2 + ((z2 / 100) * y2);


            //-----------------------------passaggio 2 ===>  morte soldati -----------------------------------------------------------
            int totalsoldiers = swordman.getTotal() + archer.getTotal() + rider.getTotal();
            int totalEsoldiers = eswordman.getTotal() + earcher.getTotal() + erider.getTotal();

            int deadsoldier = (int)((totalsoldiers / 100) * z1);
            int deadEsoldier = (int)((totalEsoldiers / 100) * z2);

            int deadswordman = (int)((deadsoldier / 100) * percswordman);
            int deadarcher = (int)((deadsoldier / 100) * percarcher);
            int deadrider = (int)((deadsoldier / 100) * percrider);

            int deadeswordman = (int)((deadEsoldier / 100) * percEswordman);
            int deadearcher = (int)((deadEsoldier / 100) * percEarcher);
            int deaderider = (int)((deadEsoldier / 100) * percErider);

            swordman.setRapidTotal(-deadswordman);
            archer.setRapidTotal(-deadarcher);
            rider.setRapidTotal(-deadrider);
            eswordman.setRapidTotal(-deadeswordman);
            earcher.setRapidTotal(-deadearcher);
            erider.setRapidTotal(-deaderider);

            if (totalEsoldiers == 0 || totalsoldiers == 0)
            {
                turno = 4;
            }


            turno++;
        }



        int random1 = (int)Random.Range(1f, 5f);
        int random2 = (int)Random.Range(1f, 5f);

        rapporto1 = rapporto1 + ((rapporto1 / 100) * random1);
        rapporto2 = rapporto2 + ((rapporto2 / 100) * random2);

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

        return fine;
    }





}

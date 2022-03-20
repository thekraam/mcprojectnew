using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldSoldiersManager : MonoBehaviour
{
    int terriFirstBattle = 0;
    int terriSecondBattle = 0;
    int terriThirdBattle = 0;
    int terriFourthBattle = 0;
    int terriFifthBattle = 0;
    int terriSixthBattle = 0;
    int terriSeventhBattle = 0;
    int terriEighthBattle = 0;
    int terriNinthBattle = 0;


    int turnsToWaitFirst = -1;
    int turnsToWaitSecond = -1;
    int turnsToWaitThird = -1;
    int turnsToWaitFourth = -1;
    int turnsToWaitFifth = -1;
    int turnsToWaitSixth = -1;
    int turnsToWaitSeventh = -1;
    int turnsToWaitEighth = -1;
    int turnsToWaitNinth = -1;


    bool firstBattleChecker = false;
    bool secondBattleChecker = false;
    bool thirdBattleChecker = false;
    bool fourthBattleChecker = false;
    bool fifthBattleChecker = false;
    bool sixthBattleChecker = false;
    bool seventhBattleChecker = false;
    bool eighthBattleChecker = false;
    bool ninthBattleChecker = false;

    int backSoldiersSwordsmenFirst;
    int backSoldiersArchersFirst;
    int backSoldiersRidersFirst;

    int backSoldiersSwordsmenSecond;
    int backSoldiersArchersSecond;
    int backSoldiersRidersSecond;

    int backSoldiersSwordsmenThird;
    int backSoldiersArchersThird;
    int backSoldiersRidersThird;

    int backSoldiersSwordsmenFourth;
    int backSoldiersArchersFourth;
    int backSoldiersRidersFourth;

    int backSoldiersSwordsmenFifth;
    int backSoldiersArchersFifth;
    int backSoldiersRidersFifth;

    int backSoldiersSwordsmenSixth;
    int backSoldiersArchersSixth;
    int backSoldiersRidersSixth;

    int backSoldiersSwordsmenSeventh;
    int backSoldiersArchersSeventh;
    int backSoldiersRidersSeventh;

    int backSoldiersSwordsmenEighth;
    int backSoldiersArchersEighth;
    int backSoldiersRidersEighth;

    int backSoldiersSwordsmenNinth;
    int backSoldiersArchersNinth;
    int backSoldiersRidersNinth;
    public void SoldiersCalcByTurn(bool isGuildBattle, Player player, Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders, int terri)
    {
        terriFirstBattle = terri;
        terriSecondBattle = terri;
        terriThirdBattle = terri;
        terriFourthBattle = terri;
        terriFifthBattle = terri;
        terriSixthBattle = terri;
        terriSeventhBattle = terri;
        terriEighthBattle = terri;
        terriNinthBattle = terri;

        backSoldiersSwordsmenFirst = swordsmen.getMomentSwordman() - swordsmen.getMomentDeadSwordman();
        backSoldiersArchersFirst = archers.getMomentArcher() - archers.getMomentDeadArcher();
        backSoldiersRidersFirst = riders.getMomentRider() - riders.getMomentDeadRider();

        backSoldiersSwordsmenSecond = swordsmen.getMomentSwordman() - swordsmen.getMomentDeadSwordman();
        backSoldiersArchersSecond = archers.getMomentArcher() - archers.getMomentDeadArcher();
        backSoldiersRidersSecond = riders.getMomentRider() - riders.getMomentDeadRider();

        backSoldiersSwordsmenThird = swordsmen.getMomentSwordman() - swordsmen.getMomentDeadSwordman();
        backSoldiersArchersThird = archers.getMomentArcher() - archers.getMomentDeadArcher();
        backSoldiersRidersThird = riders.getMomentRider() - riders.getMomentDeadRider();

        backSoldiersSwordsmenFourth = swordsmen.getMomentSwordman() - swordsmen.getMomentDeadSwordman();
        backSoldiersArchersFourth = archers.getMomentArcher() - archers.getMomentDeadArcher();
        backSoldiersRidersFourth = riders.getMomentRider() - riders.getMomentDeadRider();

        backSoldiersSwordsmenFifth = swordsmen.getMomentSwordman() - swordsmen.getMomentDeadSwordman();
        backSoldiersArchersFifth = archers.getMomentArcher() - archers.getMomentDeadArcher();
        backSoldiersRidersFifth = riders.getMomentRider() - riders.getMomentDeadRider();

        backSoldiersSwordsmenSixth = swordsmen.getMomentSwordman() - swordsmen.getMomentDeadSwordman();
        backSoldiersArchersSixth = archers.getMomentArcher() - archers.getMomentDeadArcher();
        backSoldiersRidersSixth = riders.getMomentRider() - riders.getMomentDeadRider();

        backSoldiersSwordsmenSeventh = swordsmen.getMomentSwordman() - swordsmen.getMomentDeadSwordman();
        backSoldiersArchersSeventh = archers.getMomentArcher() - archers.getMomentDeadArcher();
        backSoldiersRidersSeventh = riders.getMomentRider() - riders.getMomentDeadRider();

        backSoldiersSwordsmenEighth = swordsmen.getMomentSwordman() - swordsmen.getMomentDeadSwordman();
        backSoldiersArchersEighth = archers.getMomentArcher() - archers.getMomentDeadArcher();
        backSoldiersRidersEighth = riders.getMomentRider() - riders.getMomentDeadRider();

        backSoldiersSwordsmenNinth = swordsmen.getMomentSwordman() - swordsmen.getMomentDeadSwordman();
        backSoldiersArchersNinth = archers.getMomentArcher() - archers.getMomentDeadArcher();
        backSoldiersRidersNinth = riders.getMomentRider() - riders.getMomentDeadRider();

        /* blocco terri 2 */

        if (firstBattleChecker && terriFirstBattle == 2 && turnsToWaitFirst < 0) turnsToWaitFirst = 1;
        else if (turnsToWaitFirst > 0) turnsToWaitFirst--;

        if (secondBattleChecker && terriSecondBattle == 2 && turnsToWaitSecond < 0) turnsToWaitSecond = 1;
        else if (turnsToWaitSecond > 0) turnsToWaitSecond--;

        if (thirdBattleChecker && terriThirdBattle == 2 && turnsToWaitThird < 0) turnsToWaitThird = 1;
        else if (turnsToWaitThird > 0) turnsToWaitThird--;

        if (fourthBattleChecker && terriFourthBattle == 2 && turnsToWaitFourth < 0) turnsToWaitFourth = 1;
        else if (turnsToWaitFourth > 0) turnsToWaitFourth--;

        if (fifthBattleChecker && terriFifthBattle == 2 && turnsToWaitFifth < 0) turnsToWaitFifth = 1;
        else if (turnsToWaitFifth > 0) turnsToWaitFifth--;

        if (sixthBattleChecker && terriSixthBattle == 2 && turnsToWaitSixth < 0) turnsToWaitSixth = 1;
        else if (turnsToWaitSixth > 0) turnsToWaitSixth--;

        if (seventhBattleChecker && terriSeventhBattle == 2 && turnsToWaitSeventh < 0) turnsToWaitSeventh = 1;
        else if (turnsToWaitSeventh > 0) turnsToWaitSeventh--;

        if (eighthBattleChecker && terriEighthBattle == 2 && turnsToWaitEighth < 0) turnsToWaitEighth = 1;
        else if (turnsToWaitEighth > 0) turnsToWaitEighth--;

        if (ninthBattleChecker && terriNinthBattle == 2 && turnsToWaitNinth < 0) turnsToWaitNinth = 1;
        else if (turnsToWaitNinth > 0) turnsToWaitNinth--;

        /* blocco terri 3 */

        if (firstBattleChecker && terriFirstBattle == 3 && turnsToWaitFirst < 0) turnsToWaitFirst = 1;
        else if (turnsToWaitFirst > 0) turnsToWaitFirst--;

        if (secondBattleChecker && terriSecondBattle == 3 && turnsToWaitSecond < 0) turnsToWaitSecond = 1;
        else if (turnsToWaitSecond > 0) turnsToWaitSecond--;

        if (thirdBattleChecker && terriThirdBattle == 3 && turnsToWaitThird < 0) turnsToWaitThird = 1;
        else if (turnsToWaitThird > 0) turnsToWaitThird--;

        if (fourthBattleChecker && terriFourthBattle == 3 && turnsToWaitFourth < 0) turnsToWaitFourth = 1;
        else if (turnsToWaitFourth > 0) turnsToWaitFourth--;

        if (fifthBattleChecker && terriFifthBattle == 3 && turnsToWaitFifth < 0) turnsToWaitFifth = 1;
        else if (turnsToWaitFifth > 0) turnsToWaitFifth--;

        if (sixthBattleChecker && terriSixthBattle == 3 && turnsToWaitSixth < 0) turnsToWaitSixth = 1;
        else if (turnsToWaitSixth > 0) turnsToWaitSixth--;

        if (seventhBattleChecker && terriSeventhBattle == 3 && turnsToWaitSeventh < 0) turnsToWaitSeventh = 1;
        else if (turnsToWaitSeventh > 0) turnsToWaitSeventh--;

        if (eighthBattleChecker && terriEighthBattle == 3 && turnsToWaitEighth < 0) turnsToWaitEighth = 1;
        else if (turnsToWaitEighth > 0) turnsToWaitEighth--;

        if (ninthBattleChecker && terriNinthBattle == 3 && turnsToWaitNinth < 0) turnsToWaitNinth = 1;
        else if (turnsToWaitNinth > 0) turnsToWaitNinth--;

        /* blocco terri 4 */

        if (firstBattleChecker && terriFirstBattle == 4 && turnsToWaitFirst < 0) turnsToWaitFirst = 1;
        else if (turnsToWaitFirst > 0) turnsToWaitFirst--;

        if (secondBattleChecker && terriSecondBattle == 4 && turnsToWaitSecond < 0) turnsToWaitSecond = 1;
        else if (turnsToWaitSecond > 0) turnsToWaitSecond--;

        if (thirdBattleChecker && terriThirdBattle == 4 && turnsToWaitThird < 0) turnsToWaitThird = 1;
        else if (turnsToWaitThird > 0) turnsToWaitThird--;

        if (fourthBattleChecker && terriFourthBattle == 4 && turnsToWaitFourth < 0) turnsToWaitFourth = 1;
        else if (turnsToWaitFourth > 0) turnsToWaitFourth--;

        if (fifthBattleChecker && terriFifthBattle == 4 && turnsToWaitFifth < 0) turnsToWaitFifth = 1;
        else if (turnsToWaitFifth > 0) turnsToWaitFifth--;

        if (sixthBattleChecker && terriSixthBattle == 4 && turnsToWaitSixth < 0) turnsToWaitSixth = 1;
        else if (turnsToWaitSixth > 0) turnsToWaitSixth--;

        if (seventhBattleChecker && terriSeventhBattle == 4 && turnsToWaitSeventh < 0) turnsToWaitSeventh = 1;
        else if (turnsToWaitSeventh > 0) turnsToWaitSeventh--;

        if (eighthBattleChecker && terriEighthBattle == 4 && turnsToWaitEighth < 0) turnsToWaitEighth = 1;
        else if (turnsToWaitEighth > 0) turnsToWaitEighth--;

        if (ninthBattleChecker && terriNinthBattle == 4 && turnsToWaitNinth < 0) turnsToWaitNinth = 1;
        else if (turnsToWaitNinth > 0) turnsToWaitNinth--;


        if (turnsToWaitFirst == 0)
        {
            swordsmen.setRapidTotal(backSoldiersSwordsmenFirst);
            archers.setRapidTotal(backSoldiersArchersFirst);
            riders.setRapidTotal(backSoldiersRidersFirst);

            turnsToWaitFirst = -1;
            firstBattleChecker = false;
        }

        if (turnsToWaitSecond == 0)
        {
            swordsmen.setRapidTotal(backSoldiersSwordsmenSecond);
            archers.setRapidTotal(backSoldiersArchersSecond);
            riders.setRapidTotal(backSoldiersRidersSecond);

            turnsToWaitSecond = -1;
            secondBattleChecker = false;
        }

        if (turnsToWaitThird == 0)
        {
            swordsmen.setRapidTotal(backSoldiersSwordsmenThird);
            archers.setRapidTotal(backSoldiersArchersThird);
            riders.setRapidTotal(backSoldiersRidersThird);

            turnsToWaitThird = -1;
            thirdBattleChecker = false;
        }

        if (turnsToWaitFourth == 0)
        {
            swordsmen.setRapidTotal(backSoldiersSwordsmenFourth);
            archers.setRapidTotal(backSoldiersArchersFourth);
            riders.setRapidTotal(backSoldiersRidersFourth);

            turnsToWaitFourth = -1;
            fourthBattleChecker = false;
        }

        if (turnsToWaitFifth == 0)
        {
            swordsmen.setRapidTotal(backSoldiersSwordsmenFifth);
            archers.setRapidTotal(backSoldiersArchersFifth);
            riders.setRapidTotal(backSoldiersRidersFifth);

            turnsToWaitFifth = -1;
            fifthBattleChecker = false;
        }

        if (turnsToWaitSixth == 0)
        {
            swordsmen.setRapidTotal(backSoldiersSwordsmenSixth);
            archers.setRapidTotal(backSoldiersArchersSixth);
            riders.setRapidTotal(backSoldiersRidersSixth);

            turnsToWaitSixth = -1;
            sixthBattleChecker = false;
        }

        if (turnsToWaitSeventh == 0)
        {
            swordsmen.setRapidTotal(backSoldiersSwordsmenSeventh);
            archers.setRapidTotal(backSoldiersArchersSeventh);
            riders.setRapidTotal(backSoldiersRidersSeventh);

            turnsToWaitSeventh = -1;
            seventhBattleChecker = false;
        }

        if (turnsToWaitEighth == 0)
        {
            swordsmen.setRapidTotal(backSoldiersSwordsmenEighth);
            archers.setRapidTotal(backSoldiersArchersEighth);
            riders.setRapidTotal(backSoldiersRidersEighth);

            turnsToWaitEighth = -1;
            eighthBattleChecker = false;
        }

        if (turnsToWaitNinth == 0)
        {
            swordsmen.setRapidTotal(backSoldiersSwordsmenNinth);
            archers.setRapidTotal(backSoldiersArchersNinth);
            riders.setRapidTotal(backSoldiersRidersNinth);

            turnsToWaitNinth = -1;
            ninthBattleChecker = false;
        }
    }

    public void CheckBattleStatus(bool isGuildBattle, Player player, Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders, int terri)
    {
        if ((swordsmen.getMomentSwordman() > 0 || archers.getMomentArcher() > 0 || riders.getMomentRider() > 0) && !firstBattleChecker)
        {
            firstBattleChecker = true;
        }
        else if ((swordsmen.getMomentSwordman() > 0 || archers.getMomentArcher() > 0 || riders.getMomentRider() > 0) && !secondBattleChecker && firstBattleChecker)
        {
            secondBattleChecker = true;
        }
        else if ((swordsmen.getMomentSwordman() > 0 || archers.getMomentArcher() > 0 || riders.getMomentRider() > 0) && !thirdBattleChecker && seventhBattleChecker)
        {
            thirdBattleChecker = true;
        }
        else if ((swordsmen.getMomentSwordman() > 0 || archers.getMomentArcher() > 0 || riders.getMomentRider() > 0) && !fourthBattleChecker && thirdBattleChecker)
        {
            fourthBattleChecker = true;
        }
        else if ((swordsmen.getMomentSwordman() > 0 || archers.getMomentArcher() > 0 || riders.getMomentRider() > 0) && !fifthBattleChecker && fourthBattleChecker)
        {
            fifthBattleChecker = true;
        }
        else if ((swordsmen.getMomentSwordman() > 0 || archers.getMomentArcher() > 0 || riders.getMomentRider() > 0) && !sixthBattleChecker && fifthBattleChecker)
        {
            sixthBattleChecker = true;
        }
        else if ((swordsmen.getMomentSwordman() > 0 || archers.getMomentArcher() > 0 || riders.getMomentRider() > 0) && !seventhBattleChecker && sixthBattleChecker)
        {
            seventhBattleChecker = true;
        }
        else if ((swordsmen.getMomentSwordman() > 0 || archers.getMomentArcher() > 0 || riders.getMomentRider() > 0) && !eighthBattleChecker && seventhBattleChecker)
        {
            eighthBattleChecker = true;
        }
        else if ((swordsmen.getMomentSwordman() > 0 || archers.getMomentArcher() > 0 || riders.getMomentRider() > 0) && !ninthBattleChecker && eighthBattleChecker)
        {
            ninthBattleChecker = true;
        }

        SoldiersCalcByTurn(isGuildBattle, player, swordsmen, archers, riders, terri);
    }












    // -----------------------------------------------------------------------------------new--------------------------------------------------------------------

    int sword1 = 0;
    int arc1 = 0;
    int rid1 = 0;
    int turn1 = 0;

    int sword2 = 0;
    int arc2 = 0;
    int rid2 = 0;
    int turn2 = 0;

    int sword3 = 0;
    int arc3 = 0;
    int rid3 = 0;
    int turn3 = 0;

    int sword4 = 0;
    int arc4 = 0;
    int rid4 = 0;
    int turn4 = 0;

    int sword5 = 0;
    int arc5 = 0;
    int rid5 = 0;
    int turn5 = 0;


    public void salvasoldati(Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders, int terri)
    {
        Debug.LogError("son dentro salvasoldati");
        int controllo = 0;
        if (sword1 == 0 && arc1 == 0 && rid1 == 0 && controllo == 0)
        {
            Debug.LogError("son dentro la prima condizione (giusta)");
            sword1 = swordsmen.getMomentSwordman() - swordsmen.getMomentDeadSwordman();
            arc1 = archers.getMomentArcher() - archers.getMomentDeadArcher();
            rid1 = riders.getMomentRider() - riders.getMomentDeadRider();
            turn1 = terri;
            controllo = 1;
            Debug.LogError("sword1 " + sword1);
            Debug.LogError("arc1 " + arc1);
            Debug.LogError("rid1 " + rid1);
            Debug.LogError("turn1 " + turn1);

        }

        else if (sword2 == 0 && arc2 == 0 && rid2 == 0 && controllo == 0)
        {
            Debug.LogError("error");
            sword2 = swordsmen.getMomentSwordman() - swordsmen.getMomentDeadSwordman();
            arc2 = archers.getMomentArcher() - archers.getMomentDeadArcher();
            rid2 = riders.getMomentRider() - riders.getMomentDeadRider();
            turn2 = terri;
            controllo = 1;
        }

        else if (sword3 == 0 && arc3 == 0 && rid3 == 0 && controllo == 0)
        {
            Debug.LogError("error");
            sword3 = swordsmen.getMomentSwordman() - swordsmen.getMomentDeadSwordman();
            arc3 = archers.getMomentArcher() - archers.getMomentDeadArcher();
            rid3 = riders.getMomentRider() - riders.getMomentDeadRider();
            turn3 = terri;
            controllo = 1;
        }

        else if (sword4 == 0 && arc4 == 0 && rid4 == 0 && controllo == 0)
        {
            Debug.LogError("error");
            sword4 = swordsmen.getMomentSwordman() - swordsmen.getMomentDeadSwordman();
            arc4 = archers.getMomentArcher() - archers.getMomentDeadArcher();
            rid4 = riders.getMomentRider() - riders.getMomentDeadRider();
            turn4 = terri;
            controllo = 1;
        }

        else if (sword5 == 0 && arc5 == 0 && rid5 == 0 && controllo == 0)
        {
            Debug.LogError("error");
            sword5 = swordsmen.getMomentSwordman() - swordsmen.getMomentDeadSwordman();
            arc5 = archers.getMomentArcher() - archers.getMomentDeadArcher();
            rid5 = riders.getMomentRider() - riders.getMomentDeadRider();
            turn5 = terri;
            controllo = 1;
        }
        Debug.LogError("chiudo salvataggio dati");
    }

    public void riassegnaSoldati(Player player, Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders)
    {
        int c1 = 0;
        int c2 = 0;
        int c3 = 0;
        int c4 = 0;
        int c5 = 0;
        if (turn1 != 0)
        {
            turn1--;
            c1 = 1;
        }
        if (turn2 != 0)
        {
            turn2--;
            c2 = 1;
        }
        if (turn3 != 0)
        {
            turn3--;
            c3 = 1;
        }
        if (turn4 != 0)
        {
            turn4--;
            c4 = 1;
        }
        if (turn5 != 0)
        {
            turn5--;
            c5 = 1;
        }

        if (turn1 == 0 && c1 == 1)
        {
            swordsmen.setRapidTotal(sword1);
            archers.setRapidTotal(arc1);
            riders.setRapidTotal(rid1);
            sword1 = 0;
            arc1 = 0;
            rid1 = 0;
        }
        if (turn2 == 0 && c2 == 1)
        {
            swordsmen.setRapidTotal(sword2);
            archers.setRapidTotal(arc2);
            riders.setRapidTotal(rid2);
            sword2 = 0;
            arc2 = 0;
            rid2 = 0;
        }
        if (turn3 == 0 && c3 == 1)
        {
            swordsmen.setRapidTotal(sword3);
            archers.setRapidTotal(arc3);
            riders.setRapidTotal(rid3);
            sword3 = 0;
            arc3 = 0;
            rid3 = 0;
        }
        if (turn4 == 0 && c4 == 1)
        {
            swordsmen.setRapidTotal(sword4);
            archers.setRapidTotal(arc4);
            riders.setRapidTotal(rid4);
            sword4 = 0;
            arc4 = 0;
            rid4 = 0;
        }
        if (turn5 == 0 && c5 == 1)
        {
            swordsmen.setRapidTotal(sword5);
            archers.setRapidTotal(arc5);
            riders.setRapidTotal(rid5);
            sword5 = 0;
            arc5 = 0;
            rid5 = 0;
        }
    }

    //--------------------------------variabili per la risposta di tutti i tipi di messaggi da parte della gilda-------------------------------------

    int g1 = 0; int s1 = 0; int a1 = 0; int r1 = 0;
    int g2 = 0; int s2 = 0; int a2 = 0; int r2 = 0;
    int g3 = 0; int s3 = 0; int a3 = 0; int r3 = 0;
    int g4 = 0; int s4 = 0; int a4 = 0; int r4 = 0;
    int g5 = 0; int s5 = 0; int a5 = 0; int r5 = 0;
    int g6 = 0; int s6 = 0; int a6 = 0; int r6 = 0;
    int g7 = 0; int s7 = 0; int a7 = 0; int r7 = 0;
    int g8 = 0; int s8 = 0; int a8 = 0; int r8 = 0;
    int g9 = 0; int s9 = 0; int a9 = 0; int r9 = 0;
    int g10 = 0; int s10 = 0; int a10 = 0; int r10 = 0;
    int g11 = 0; int s11 = 0; int a11 = 0; int r11 = 0;
    int g12 = 0; int s12 = 0; int a12 = 0; int r12 = 0;
    int g13 = 0; int s13 = 0; int a13 = 0; int r13 = 0;
    int g14 = 0; int s14 = 0; int a14 = 0; int r14 = 0;
    int g15 = 0; int s15 = 0; int a15 = 0; int r15 = 0;
    int g16 = 0; int s16 = 0; int a16 = 0; int r16 = 0;
    int g17 = 0; int s17 = 0; int a17 = 0; int r17 = 0;
    int g18 = 0; int s18 = 0; int a18 = 0; int r18 = 0;
    int g19 = 0; int s19 = 0; int a19 = 0; int r19 = 0;
    int g20 = 0; int s20 = 0; int a20 = 0; int r20 = 0;




    public void gildaimpostamex(int x, int s, int a, int r)
    {
        Debug.LogError("Son dentro gildaimpostamex ");
        if (x == 1) { g1 = 1; s1 = s; a1 = a; r1 = r; Debug.LogError("prima con g1 = " +g1 + "s1 = " + s1 + " a1 = " + a1 + " r1 = " + r1); }
        if (x == 2) { g2 = 1; s2 = s; a2 = a; r2 = r; Debug.LogError("seconda con g2 = " + g2 + "s2 = " + s2 + " a2 = " + a2 + " r2 = " + r2); }
        if (x == 3) { g3 = 1; s3 = s; a3 = a; r3 = r; Debug.LogError("terza con g3 = " + g3 + "s3 = " + s3 + " a3 = " + a3 + " r3 = " + r3);}
        if (x == 4) { g4 = 1; s4 = s; a4 = a; r4 = r; Debug.LogError("quarta con g4 = " + g4 + "s4 = " + s4 + " a4 = " + a4 + " r4 = " + r4);}
        if (x == 5) { g5 = 2; s5 = s; a5 = a; r5 = r; }
        if (x == 6) { g6 = 2; s6 = s; a6 = a; r6 = r; }
        if (x == 7) { g7 = 2; s7 = s; a7 = a; r7 = r; }
        if (x == 8) { g8 = 2; s8 = s; a8 = a; r8 = r; }
        if (x == 9) { g9 = 2; s9 = s; a9 = a; r9 = r; }
        if (x == 10) { g10 = 2; s10 = s; a10 = a; r10 = r; }
        if (x == 11) { g11 = 2; s11 = s; a11 = a; r11 = r; }
        if (x == 12) { g12 = 2; s12 = s; a12 = a; r12 = r; }
        if (x == 13) { g13 = 3; s13 = s; a13 = a; r13 = r; }
        if (x == 14) { g14 = 3; s14 = s; a14 = a; r14 = r; }
        if (x == 15) { g15 = 3; s15 = s; a15 = a; r15 = r; }
        if (x == 16) { g16 = 3; s16 = s; a16 = a; r16 = r; }
        if (x == 17) { g17 = 4; s17 = s; a17 = a; r17 = r; }
        if (x == 18) { g18 = 4; s18 = s; a18 = a; r18 = r; }
        if (x == 19) { g19 = 4; s19 = s; a19 = a; r19 = r; }
        if (x == 20) { g20 = 4; s20 = s; a20 = a; r20 = r; }

        Debug.LogError("esco da gildaimpostamex");
    }


    public void gildamexritorno(Player player, Gilda gilda)
    {
        Debug.Log("entro dentro gildamexritorno");
        int co1 = 0; int co2 = 0; int co3 = 0; int co4 = 0; int co5 = 0; int co6 = 0; int co7 = 0; int co8 = 0; int co9 = 0; int co10 = 0;
        int co11 = 0; int co12 = 0; int co13 = 0; int co14 = 0; int co15 = 0; int co16 = 0; int co17 = 0; int co18 = 0; int co19 = 0; int co20 = 0;

        if (g1 != 0) { g1--; co1 = 1; Debug.Log("lavoro g1"); }
        if (g2 != 0) { g2--; co2 = 1; Debug.Log("lavoro g2"); }
        if (g3 != 0) { g3--; co3 = 1; Debug.Log("lavoro g3"); }
        if (g4 != 0) { g4--; co4 = 1; Debug.Log("lavoro g4"); }
        if (g5 != 0) { g5--; co5 = 1; }
        if (g6 != 0) { g6--; co6 = 1; }
        if (g7 != 0) { g7--; co7 = 1; }
        if (g8 != 0) { g8--; co8 = 1; }
        if (g9 != 0) { g9--; co9 = 1; }
        if (g10 != 0) { g10--; co10 = 1; }
        if (g11 != 0) { g11--; co11 = 1; }
        if (g12 != 0) { g12--; co12 = 1; }
        if (g13 != 0) { g13--; co13 = 1; }
        if (g14 != 0) { g14--; co14 = 1; }
        if (g15 != 0) { g15--; co15 = 1; }
        if (g16 != 0) { g16--; co16 = 1; }
        if (g17 != 0) { g17--; co17 = 1; }
        if (g18 != 0) { g18--; co18 = 1; }
        if (g19 != 0) { g19--; co19 = 1; }
        if (g20 != 0) { g20--; co20 = 1; }
        Debug.Log("quanto vale g1 : " + g1 + " e co1 : " + co1);
        Debug.Log("quanto vale g2 : " + g2 + " e co2 : " + co2);
        Debug.Log("quanto vale g3 : " + g3 + " e co3 : " + co3);
        Debug.Log("quanto vale g4 : " + g4 + " e co4 : " + co4);

        if ((g1 == 0) && (co1 == 1))
        {
            if(gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(200);
            Debug.LogError("Ho fatto il mio dovere 1");

            Debug.LogError("controllo1 = " + gilda.getcontrollosped1());
            Debug.LogError("controllo2 = " + gilda.getcontrollosped2());
            //dialogo 1
        }
        if ((g2 == 0) && (co2 == 1))
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(200);
            Debug.LogError("Ho fatto il mio dovere 2");

            Debug.LogError("controllo1 = " + gilda.getcontrollosped1());
            Debug.LogError("controllo2 = " + gilda.getcontrollosped2());
            //dialogo 2
        }
        if ((g3 == 0) && (co3 == 1))
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(200);
            Debug.LogError("Ho fatto il mio dovere 3");
            Debug.LogError("controllo1 = " + gilda.getcontrollosped1());
            Debug.LogError("controllo2 = " + gilda.getcontrollosped2());
            //dialogo 3
        }
        if ((g4 == 0) && (co4 == 1))
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(200);
            Debug.LogError("Ho fatto il mio dovere 4");

            Debug.LogError("controllo1 = " + gilda.getcontrollosped1());
            Debug.LogError("controllo2 = " + gilda.getcontrollosped2());
            //dialogo 4
        }
        if ((g5 == 0) && (co5 == 1))
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(200);
            //dialogo 5
        }
        if ((g6 == 0) && (co6 == 1))
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(200);
            //dialogo 6
        }
        if ((g7 == 0) && (co7 == 1))
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(200);
            //dialogo 7
        }
        if ((g8 == 0) && (co8 == 1))
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(200);
            //dialogo 8
        }
        if ((g9 == 0) && (co9 == 1))
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(200);
            //dialogo 9
        }
        if ((g10 == 0) && (co10 == 1))
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(200);
            //dialogo 10
        }
        if ((g11 == 0) && (co11 == 1))
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(200);
            //dialogo 11
        }
        if ((g12 == 0) && (co12 == 1))
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(200);
            //dialogo 12
        }
        if ((g13 == 0) && (co13 == 1))
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(200);
            //dialogo 13
        }
        if ((g14 == 0) && (co14 == 1))
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(200);
            //dialogo 14
        }
        if ((g15 == 0) && (co15 == 1))
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(200);
            //dialogo 15
        }
        if ((g16 == 0) && (co16 == 1))
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(200);
            //dialogo 16
        }
        if ((g17 == 0) && (co17 == 1))
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(200);
            //dialogo 17
        }
        if ((g18 == 0) && (co18 == 1))
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(200);
            //dialogo 18
        }
        if ((g19 == 0) && (co19 == 1))
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(200);
            //dialogo 19
        }
        if ((g20 == 0) && (co20 == 1))
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(200);
            //dialogo 20
        }

    }












































}

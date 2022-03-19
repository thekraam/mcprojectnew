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

    int backSoldiersSwordsmenFirst ;
    int backSoldiersArchersFirst;
    int backSoldiersRidersFirst ;

    int backSoldiersSwordsmenSecond ;
    int backSoldiersArchersSecond ;
    int backSoldiersRidersSecond ;

    int backSoldiersSwordsmenThird;
    int backSoldiersArchersThird ;
    int backSoldiersRidersThird ;

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
        if((swordsmen.getMomentSwordman() > 0 || archers.getMomentArcher() > 0 || riders.getMomentRider() > 0) && !firstBattleChecker)
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

}

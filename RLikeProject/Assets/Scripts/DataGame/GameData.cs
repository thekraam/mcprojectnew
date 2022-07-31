using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public string cityName;

    public int player_turn;

    public int player_population;
    public int temp_player_citizens;
    public int player_money;
    public int player_citizens;
    public int player_citizensMAX;
    public int temp_player_citizensMAX;

    public float bonusBattle;
    public float bonusWall;
    public float bonusCity;
    public float bonusFar;
    public float bonusDemoniac;
    public int lvlwall;
    public int lvlfield;
    public int soldiersaway;

    /*tutorial*/
    public bool welcomeTutorial;
    public bool villageTutorial;
    public bool farmTutorial;
    public bool barracksTutorial;
    public bool blacksmithTutorial;
    public bool guildTutorial;
    public bool mineTutorial;
    public bool bonusTutorial;

    /*events*/
    public int aqueduct;
    public int response;
    public int citydefenseproject;
    public int aqueductSecondary;
    public int aqueductTurnsLeft;
    public int aqueductMalusTurnsLeft;
    public bool attendingSecondaryEvent;
    public bool aqueductMalus;

    //DA AGGIUNGERE
    public int terri;
    public int bonusETerri;
    public int bonusEnemy;

    public int aemisFaith;
    public int aemisKnightsHostility;
    public int aemisRebel;

    public int elvesEnemy;
    public int forestDiplomacy;

    public int ancientGreenJewel;
    public int blackCrystal;


    public int event2;
    public int event2MalusTurnsLeft;
    public int event4;
    public int event4BonusTurnsLeft;
    public int secondaryEvent2;
    public int secondaryEvent2TurnsLeft;
    public int event5;
    public int event6;
    public int event7;
    public int event7MalusTurnsLeft;
    public int event8;
    public int secondaryEvent3;
    public int secondaryEvent3TurnsLeft;
    public int secondaryEvent3MalusEffectGoldTurnsLeft;
    public int secondaryEvent3MalusEffectCitizensTurnsLeft;
    public int secondaryEvent3MalusEffectGoldTurnsLeftMINE;
    public int event9;
    public int event9BonusTurnsLeft;
    public int event10;
    public int event11;
    public int event12;
    public int event12Malus;
    public int event12MalusTurnsLeft;
    public int event13;
    public int event14;
    public int event15;
    public int event15MalusTurnsLeft;
    public int event16;
    public int secondaryEvent4;
    public int secondaryEvent4TurnsLeft;
    public int event17;
    public int event17MalusTurnsLeft;
    public int event18;
    public int event19;
    public int event20;
    public int event21;
    public int event21MalusTurnsLeft;
    public int event22;
    public int event23;
    public int event24;
    public int event25;
    public int event26;
    public int event27;
    public int event27MalusTurnsLeft;
    public int event28;
    public int event29;
    public int event30;
    public int event30MalusTurnsLeft;




    /*farm*/
    public int farmLvl;
    public int abitantiMax;
    public int crescitaAbitanti;
    public int farmGold;
    public int farmLvlUpCost;
    /*mine*/
    public int minelvl;
    public int minegold;
    public bool carboneHigh;
    public int minecosto;
    /*barracks*/
    public int casermalvl;
    public int reclutamentoMAX;
    public float bonusBarrack;
    public int reclutamentoMaxMoment;
    public int casermaLvlUpCost;

    /*soldiers*/
    /*swordsmen*/
    public int total_swordsmen;
    public int temp_total_swordsmen;
    public int atk_swordsmen;
    public int temp_atk_swordsmen;
    public int def_swordsmen;
    public int temp_def_swordsmen;
    public float bonus_swordsmen;
    public int momentswordman;
    public int momentDeadswordman ;
    /*archers*/
    public int total_archers;
    public int temp_total_archers;
    public int atk_archers;
    public int temp_atk_archers;
    public int def_archers;
    public int temp_def_archers;
    public float bonus_archers;
    public int momentarcher;
    public int momentDeadArcher;
    /*riders*/
    public int total_riders;
    public int temp_total_riders;
    public int atk_riders;
    public int temp_atk_riders;
    public int def_riders;
    public int temp_def_riders;
    public float bonus_riders;
    public int momentrider;
    public int momentDeadRider;

    /*Enemy*/

    public int totalSoldierE;
    public int lvlE;

    public int total_swordsmenE;
    public int atk_swordsmenE;
    public int def_swordsmenE;
    public float bonus_swordsmenE;

    public int deadEswordmanE;

    public int total_archersE;
    public int atk_archersE;
    public int def_archersE;
    public float bonus_archersE;

    public int deadEArchersE;

    public int total_ridersE;
    public int atk_ridersE;
    public int def_ridersE;
    public float bonus_ridersE;

    public int deadERidersE;


    /*fabbro*/
    public int fablvl;
    public int fabcosto;
    public int armi;
    public int armature;
    public int zappa;
    public int goldzappa;
    public int piccone;
    public int goldpiccone;

    /*gilda*/
    public int gildalvl;
    public int gildacosto;
    public int sped1;
    public int sped2;
    public int sped3;
    public int sped4;
    public int sped5;
    public int controllosped1;
    public int controllosped2;

    /*OldSoldiers*/
    public int sword1;
    public int arc1;
    public int rid1;
    public int turn1;

    public int sword2;
    public int arc2;
    public int rid2;
    public int turn2;

    public int sword3;
    public int arc3;
    public int rid3;
    public int turn3;

    public int sword4;
    public int arc4;
    public int rid4;
    public int turn4;

    public int sword5;
    public int arc5;
    public int rid5;
    public int turn5;

    public int swordgilda1;
    public int arcgilda1;
    public int ridgilda1;
    public int tipologia1;
    public int moltiplicatore1;
    public int turngilda1;

    public int swordgilda2;
    public int arcgilda2;
    public int ridgilda2;
    public int tipologia2;
    public int moltiplicatore2;
    public int turngilda2;





    public GameData (string cityname, Player player , Events events , Fattoria fattoria , Caserma caserma,
        Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders, 
        Miniera miniera, Fabbro fabbro, Gilda gilda, Tutorial tutorial,
        OldSoldiersManager oldSoldiers, Enemy enemy,
        Enemy.ESwordsmen eSwordsmen, Enemy.EArchers eArchers, Enemy.ERiders eRiders
        )
    {

        cityName = cityname;

        player_turn = player.getTurn();
        player_population = player.getPopulation();
        player_money = player.getMoney();
        player_citizens = player.getCitizens();
        player_citizensMAX = player.getCitizensMax();
        temp_player_citizens = player.getTempCitizens();
        temp_player_citizensMAX = player.temp_player_citizensMAX;

        bonusBattle = player.bonusBattle;
        bonusWall= player.bonusWall;
        bonusCity = player.bonusCity;
        bonusFar = player.bonusFar;
        bonusDemoniac = player.bonusDemoniac;
        lvlwall = player.lvlwall;
        lvlfield = player.lvlfield;
        soldiersaway = player.soldiersaway;

        /*tutorial*/
        welcomeTutorial = tutorial.welcomeTutorial;
        //Debug.LogError("welcomeTutorial " + tutorial.welcomeTutorial);
        villageTutorial = tutorial.villageTutorial;
        farmTutorial = tutorial.farmTutorial;
        barracksTutorial = tutorial.barracksTutorial;
        blacksmithTutorial = tutorial.blacksmithTutorial;
        guildTutorial = tutorial.guildTutorial;
        mineTutorial = tutorial.mineTutorial;
        bonusTutorial = tutorial.bonusTutorial;

        /*events*/
        attendingSecondaryEvent = events.attendingSecondaryEvent;

        aqueduct = events.event1;
        response = events.response[0];
        citydefenseproject = events.event3;
        aqueductSecondary = events.secondaryEvent1;
        aqueductTurnsLeft = events.secondaryEvent1TurnsLeft;
        aqueductMalusTurnsLeft = events.secondaryEvent1MalusTurnsLeft;
        aqueductMalus = events.secondaryEvent1Malus == 1 ? true : false;



        terri = events.terri;
        bonusETerri = events.bonusETerri;
        bonusEnemy = events.bonusEnemy;

        aemisFaith = events.aemisFaith;
        aemisKnightsHostility = events.aemisKnightsHostility;
        aemisRebel = events.aemisRebel;

        elvesEnemy = events.elvesEnemy;
        forestDiplomacy = events.forestDiplomacy;

        ancientGreenJewel = events.ancientGreenJewel;
        blackCrystal = events.blackCrystal;


        event2 = events.event2;
        event2MalusTurnsLeft = events.event2MalusTurnsLeft;
        event4 = events.event4;
        event4BonusTurnsLeft = events.event4BonusTurnsLeft;
        secondaryEvent2 = events.secondaryEvent2;
        secondaryEvent2TurnsLeft = events.secondaryEvent2TurnsLeft;
        event5 = events.event5;
        event6 = events.event6;
        event7 = events.event7;
        event7MalusTurnsLeft = events.event7MalusTurnsLeft;
        event8 = events.event8;
        secondaryEvent3 = events.secondaryEvent3;
        secondaryEvent3TurnsLeft = events.secondaryEvent3TurnsLeft;
        secondaryEvent3MalusEffectGoldTurnsLeft = events.secondaryEvent3MalusEffectGoldTurnsLeft;
        secondaryEvent3MalusEffectCitizensTurnsLeft = events.secondaryEvent3MalusEffectCitizensTurnsLeft;
        secondaryEvent3MalusEffectGoldTurnsLeftMINE = events.secondaryEvent3MalusEffectGoldTurnsLeftMINE;
        event9 = events.event9;
        event9BonusTurnsLeft = events.event9BonusTurnsLeft;
        event10 = events.event10;
        event11 = events.event11;
        event12 = events.event12;
        event12Malus = events.event12Malus;
        event12MalusTurnsLeft = events.event12MalusTurnsLeft;
        event13 = events.event13;
        event14 = events.event14;
        event15 = events.event15;
        event15MalusTurnsLeft = events.event15MalusTurnsLeft;
        event16 = events.event16;
        secondaryEvent4 = events.secondaryEvent4;
        secondaryEvent4TurnsLeft = events.secondaryEvent4TurnsLeft;
        event17 = events.event17;
        event17MalusTurnsLeft = events.event17MalusTurnsLeft;
        event18 = events.event18;
        event19 = events.event19;
        event20 = events.event20;
        event21 = events.event21;
        event21MalusTurnsLeft = events.event21MalusTurnsLeft;
        event22 = events.event22;
        event23 = events.event23;
        //event24 = events.e24;
        //event25 = events.e25;
        //event26 = events.e26;
        event27 = events.event27;
        event27MalusTurnsLeft = events.event27MalusTurnsLeft;
        //event28 = events.e28;
        //event29 = events.e29;
        event30 = events.event30;
        event30MalusTurnsLeft = events.event30MalusTurnsLeft;





        /*farm*/
        farmLvl = fattoria.getLvlFattoria();
        abitantiMax = fattoria.getAbitantiMax();
        crescitaAbitanti = fattoria.getCrescitaAbitanti();
        farmGold = fattoria.getGoldFattoria();
        farmLvlUpCost = fattoria.getLvlUpCost();
        /*mine*/
        minelvl = miniera.lvl;
        minegold = miniera.gold;
        carboneHigh = miniera.carboneHigh;
        minecosto = miniera.costo;
        /*barracks*/
        casermalvl = caserma.getLvl();
        reclutamentoMAX = caserma.getReclutamentoMax();
        bonusBarrack = caserma.getBonusBarrack();
        reclutamentoMaxMoment = caserma.getReclutamentoMaxMoment();
        casermaLvlUpCost = caserma.getcosto();

        /*soldiers*/
        /*swordsmen*/
        total_swordsmen = swordsmen.getTotal();
        temp_total_swordsmen = swordsmen.getTempTotal();
        atk_swordsmen = swordsmen.getAtk();
        temp_atk_swordsmen = swordsmen.getTempAtk();
        def_swordsmen = swordsmen.getDef();
        temp_def_swordsmen = swordsmen.getTempDef();
        bonus_swordsmen = swordsmen.getBonus();
        momentswordman = swordsmen.getMomentSwordman();
        momentDeadswordman = swordsmen.getMomentDeadSwordman();
        /*archers*/
        total_archers = archers.getTotal();
        temp_total_archers = archers.getTempTotal();
        atk_archers = archers.getAtk();
        temp_atk_archers = archers.getTempAtk();
        def_archers = archers.getDef();
        temp_def_archers = archers.getTempDef();
        bonus_archers = archers.getBonus();
        momentarcher = archers.getMomentArcher();
        momentDeadArcher = archers.getMomentDeadArcher();
        /*riders*/
        total_riders = riders.getTotal();
        temp_total_riders = riders.getTempTotal();
        atk_riders = riders.getAtk();
        temp_atk_riders = riders.getTempAtk();
        def_riders = riders.getDef();
        temp_def_riders = riders.getTempDef();
        bonus_riders = riders.getBonus();
        momentrider = riders.getMomentRider();
        momentDeadRider = riders.getMomentDeadRider();

        /*Enemy*/

        totalSoldierE = enemy.getTotalsoldier();
        lvlE = enemy.getLvl();

        total_swordsmenE = eSwordsmen.getTotal();
        atk_swordsmenE = eSwordsmen.getAtk();
        def_swordsmenE = eSwordsmen.getDef();
        bonus_swordsmenE = eSwordsmen.getBonus();
        deadEswordmanE = eSwordsmen.getDeadESwordman();

        total_archersE = eArchers.getTotal();
        atk_archersE = eArchers.getAtk();
        def_archersE = eArchers.getDef();
        bonus_archersE = eArchers.getBonus();
        deadEArchersE = eArchers.getDeadEArchers();

        total_ridersE = eRiders.getTotal();
        atk_ridersE = eRiders.getAtk();
        def_ridersE = eRiders.getDef();
        bonus_ridersE = eRiders.getBonus();
        deadERidersE = eRiders.getDeadERiders();

        /*fabbro*/
        fablvl = fabbro.lvl;
        fabcosto = fabbro.costo;
        armi = fabbro.armi;
        armature = fabbro.armature;
        zappa = fabbro.zappa;
        goldzappa = fabbro.goldzappa;
        piccone = fabbro.piccone;
        goldpiccone = fabbro.goldpiccone;

        /*gilda*/
        gildalvl = gilda.lvl;
        gildacosto = gilda.costo;
        sped1 = gilda.sped1;
        sped2 = gilda.sped2;
        sped3 = gilda.sped3;
        sped4 = gilda.sped4;
        sped5 = gilda.sped5;
        controllosped1 = gilda.controllosped1;
        controllosped2 = gilda.controllosped2;

        /*OldSoldiers*/
        sword1 = oldSoldiers.sword1;
        arc1 = oldSoldiers.arc1;
        rid1 = oldSoldiers.rid1;
        turn1 = oldSoldiers.turn1;

        sword2 = oldSoldiers.sword2;
        arc2 = oldSoldiers.arc2;
        rid2 = oldSoldiers.rid2;
        turn2 = oldSoldiers.turn2;

        sword3 = oldSoldiers.sword3;
        arc3 = oldSoldiers.arc3;
        rid3 = oldSoldiers.rid3;
        turn3 = oldSoldiers.turn3;

        sword4 = oldSoldiers.sword4;
        arc4 = oldSoldiers.arc4;
        rid4 = oldSoldiers.rid4;
        turn4 = oldSoldiers.turn4;

        sword5 = oldSoldiers.sword5;
        arc5 = oldSoldiers.arc5;
        rid5 = oldSoldiers.rid5;
        turn5 = oldSoldiers.turn5;

        swordgilda1 = oldSoldiers.swordgilda1;
        arcgilda1 = oldSoldiers.arcgilda1;
        ridgilda1 = oldSoldiers.ridgilda1;
        tipologia1 = oldSoldiers.tipologia1;
        moltiplicatore1 = oldSoldiers.moltiplicatore1;
        turngilda1 = oldSoldiers.turngilda1;

        swordgilda2 = oldSoldiers.swordgilda2;
        arcgilda2 = oldSoldiers.arcgilda2;
        ridgilda2 = oldSoldiers.ridgilda2;
        tipologia2 = oldSoldiers.tipologia2;
        moltiplicatore2 = oldSoldiers.moltiplicatore2;
        turngilda2 = oldSoldiers.turngilda2;

    }

}

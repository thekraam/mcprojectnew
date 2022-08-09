using UnityEngine;

public class LoadGameData : MonoBehaviour
{
    public void LoadTutorial()
    {
        GameData data = SaveSystem.LoadGame();

        /*tutorial*/
        FindObjectOfType<Tutorial>().welcomeTutorial = data.welcomeTutorial;
        FindObjectOfType<Game>().tutorialW = data.welcomeTutorial;
        FindObjectOfType<Tutorial>().villageTutorial = data.villageTutorial;
        FindObjectOfType<Tutorial>().farmTutorial = data.farmTutorial;
        FindObjectOfType<Tutorial>().barracksTutorial = data.barracksTutorial;
        FindObjectOfType<Tutorial>().blacksmithTutorial = data.blacksmithTutorial;
        FindObjectOfType<Tutorial>().guildTutorial = data.guildTutorial;
        FindObjectOfType<Tutorial>().mineTutorial = data.mineTutorial;
        FindObjectOfType<Tutorial>().bonusTutorial = data.bonusTutorial;
    }

    public void loadnullgame(Player player, Fattoria fattoria, Miniera miniera, Caserma caserma, Enemy enemy, Fabbro fabbro, Gilda gilda)
    {
        GameData data = SaveSystem.LoadNullData();

        FindObjectOfType<Game>().CityNameUI.text = data.cityName;

        player.player_turn = data.player_turn;
        player.setPopulation(data.player_population);
        player.player_citizens = data.player_citizens;
        player.setCitizensMax(data.player_citizensMAX);
        player.setCitizens();

        player.temp_player_citizens = data.temp_player_citizens;
        //player.setTempCitizens(data.temp_player_citizens);
        player.player_money = data.player_money;

        player.bonusBattle = data.bonusBattle;
        player.bonusWall = data.bonusWall;
        player.bonusCity = data.bonusCity;
        player.bonusFar = data.bonusFar;
        player.bonusDemoniac = data.bonusDemoniac;
        player.lvlwall = data.lvlwall;
        player.lvlfield = data.lvlfield;
        player.soldiersaway = data.soldiersaway;

        ///*tutorial*/
        //FindObjectOfType<Tutorial>().welcomeTutorial = data.welcomeTutorial;
        //tutorialW = data.welcomeTutorial;
        //FindObjectOfType<Tutorial>().villageTutorial = data.villageTutorial;
        //FindObjectOfType<Tutorial>().farmTutorial = data.farmTutorial;
        //FindObjectOfType<Tutorial>().barracksTutorial = data.barracksTutorial;
        //FindObjectOfType<Tutorial>().blacksmithTutorial = data.blacksmithTutorial;
        //FindObjectOfType<Tutorial>().guildTutorial = data.guildTutorial;
        //FindObjectOfType<Tutorial>().mineTutorial = data.mineTutorial;
        //FindObjectOfType<Tutorial>().bonusTutorial = data.bonusTutorial;

        /*events*/
        FindObjectOfType<Events>().response[0] = data.response;
        FindObjectOfType<Events>().attendingSecondaryEvent = data.attendingSecondaryEvent;


        FindObjectOfType<Events>().terri = data.terri;
        FindObjectOfType<Events>().bonusETerri = data.bonusETerri;
        FindObjectOfType<Events>().bonusEnemy = data.bonusEnemy;

        FindObjectOfType<Events>().aemisFaith = data.aemisFaith;
        FindObjectOfType<Events>().aemisKnightsHostility = data.aemisKnightsHostility;
        FindObjectOfType<Events>().aemisRebel = data.aemisRebel;

        FindObjectOfType<Events>().elvesEnemy = data.elvesEnemy;
        FindObjectOfType<Events>().forestDiplomacy = data.forestDiplomacy;

        FindObjectOfType<Events>().ancientGreenJewel = data.ancientGreenJewel;
        FindObjectOfType<Events>().blackCrystal = data.blackCrystal;
        FindObjectOfType<Events>().aqueduct = data.aqueduct;
        FindObjectOfType<Events>().uominiErranti = data.uominiErranti;

        FindObjectOfType<Events>().event1 = data.event1;
        FindObjectOfType<Events>().secondaryEvent1MalusTurnsLeft = data.secondaryEvent1MalusTurnsLeft;
        FindObjectOfType<Events>().secondaryEvent1Malus = data.secondaryEvent1Malus ? 1 : 0;
        FindObjectOfType<Events>().secondaryEvent1 = data.secondaryEvent1;
        FindObjectOfType<Events>().secondaryEvent1TurnsLeft = data.secondaryEvent1TurnsLeft;
        FindObjectOfType<Events>().event2 = data.event2;
        FindObjectOfType<Events>().event2MalusTurnsLeft = data.event2MalusTurnsLeft;
        FindObjectOfType<Events>().event3 = data.event3;
        FindObjectOfType<Events>().event4 = data.event4;
        FindObjectOfType<Events>().event4BonusTurnsLeft = data.event4BonusTurnsLeft;
        FindObjectOfType<Events>().secondaryEvent2 = data.secondaryEvent2;
        FindObjectOfType<Events>().secondaryEvent2TurnsLeft = data.secondaryEvent2TurnsLeft;
        FindObjectOfType<Events>().event5 = data.event5;
        FindObjectOfType<Events>().event6 = data.event6;
        FindObjectOfType<Events>().event7 = data.event7;
        FindObjectOfType<Events>().event7MalusTurnsLeft = data.event7MalusTurnsLeft;
        FindObjectOfType<Events>().event8 = data.event8;
        FindObjectOfType<Events>().secondaryEvent3 = data.secondaryEvent3;
        FindObjectOfType<Events>().secondaryEvent3TurnsLeft = data.secondaryEvent3TurnsLeft;
        FindObjectOfType<Events>().secondaryEvent3MalusEffectGoldTurnsLeft = data.secondaryEvent3MalusEffectGoldTurnsLeft;
        FindObjectOfType<Events>().secondaryEvent3MalusEffectCitizensTurnsLeft = data.secondaryEvent3MalusEffectCitizensTurnsLeft;
        FindObjectOfType<Events>().secondaryEvent3MalusEffectGoldTurnsLeftMINE = data.secondaryEvent3MalusEffectGoldTurnsLeftMINE;
        FindObjectOfType<Events>().event9 = data.event9;
        FindObjectOfType<Events>().event9BonusTurnsLeft = data.event9BonusTurnsLeft;
        FindObjectOfType<Events>().event10 = data.event10;
        FindObjectOfType<Events>().event11 = data.event11;
        FindObjectOfType<Events>().event12 = data.event12;
        FindObjectOfType<Events>().event12Malus = data.event12Malus;
        FindObjectOfType<Events>().event12MalusTurnsLeft = data.event12MalusTurnsLeft;
        FindObjectOfType<Events>().event13 = data.event13;
        FindObjectOfType<Events>().event14 = data.event14;
        FindObjectOfType<Events>().event15 = data.event15;
        FindObjectOfType<Events>().event15MalusTurnsLeft = data.event15MalusTurnsLeft;
        FindObjectOfType<Events>().event16 = data.event16;
        FindObjectOfType<Events>().secondaryEvent4 = data.secondaryEvent4;
        FindObjectOfType<Events>().secondaryEvent4TurnsLeft = data.secondaryEvent4TurnsLeft;
        FindObjectOfType<Events>().event17 = data.event17;
        FindObjectOfType<Events>().event17MalusTurnsLeft = data.event17MalusTurnsLeft;
        FindObjectOfType<Events>().event18 = data.event18;
        FindObjectOfType<Events>().event19 = data.event19;
        FindObjectOfType<Events>().event20 = data.event20;
        FindObjectOfType<Events>().event21 = data.event21;
        FindObjectOfType<Events>().event21MalusTurnsLeft = data.event21MalusTurnsLeft;
        FindObjectOfType<Events>().event22 = data.event22;
        FindObjectOfType<Events>().event23 = data.event23;
        FindObjectOfType<Events>().event24 = data.event24;
        FindObjectOfType<Events>().secondaryEvent5 = data.secondaryEvent5;
        FindObjectOfType<Events>().secondaryEvent5TurnsLeft = data.secondaryEvent5TurnsLeft;
        FindObjectOfType<Events>().secondaryEvent5Malus40 = data.secondaryEvent5Malus40;
        FindObjectOfType<Events>().secondaryEvent5Malus100 = data.secondaryEvent5Malus100;
        FindObjectOfType<Events>().event25 = data.event25;
        FindObjectOfType<Events>().event25BonusTurnsLeft = data.event25BonusTurnsLeft;
        FindObjectOfType<Events>().secondaryEvent6 = data.secondaryEvent6;
        FindObjectOfType<Events>().secondaryEvent6TurnsLeft = data.secondaryEvent6TurnsLeft;
        FindObjectOfType<Events>().event26 = data.event26;
        FindObjectOfType<Events>().event27 = data.event27;
        FindObjectOfType<Events>().event27MalusTurnsLeft = data.event27MalusTurnsLeft;
        FindObjectOfType<Events>().event28 = data.event28;
        FindObjectOfType<Events>().event29 = data.event29;
        FindObjectOfType<Events>().event30 = data.event30;
        FindObjectOfType<Events>().event30MalusTurnsLeft = data.event30MalusTurnsLeft;

        FindObjectOfType<Events>().prologueFinalEvent = data.prologueFinalEvent;

        /*
        FindObjectOfType<Events>().setPlayer(data.player1);
        FindObjectOfType<Events>().setSwordsmen(data.swordsmen1);
        FindObjectOfType<Events>().setArchers(data.archers1);
        FindObjectOfType<Events>().setRiders(data.riders1);
        FindObjectOfType<Events>().setFattoria(data.fattoria1);
        FindObjectOfType<Events>().setMiniera(data.miniera1);
        FindObjectOfType<Events>().setCaserma(data.caserma1);
        FindObjectOfType<Events>().setFabbro(data.fabbro1);
        FindObjectOfType<Events>().setGilda(data.gilda1);
        */

        /*farm*/
        fattoria.setLvlFattoria(data.farmLvl);
        fattoria.setAbitantiMax(data.abitantiMax);
        fattoria.setCrescitaAbitanti(data.crescitaAbitanti);
        fattoria.setGoldFattoria(data.farmGold);
        fattoria.setLvlUpCost(data.farmLvlUpCost);
        /*mine*/
        miniera.lvl = data.minelvl;
        miniera.gold = data.minegold;
        miniera.carboneHigh = data.carboneHigh;
        miniera.costo = data.minecosto;
        /*barracks*/
        caserma.lvl = data.casermalvl;
        caserma.reclutamentoMAX = data.reclutamentoMAX;
        caserma.bonusBarrack = data.bonusBarrack;
        caserma.reclutamentoMaxMoment = data.reclutamentoMaxMoment;
        caserma.costo = data.casermaLvlUpCost;

        /*soldiers*/
        /*swordsmen*/
        FindObjectOfType<Game>().swordsmen.total_swordsmen = data.total_swordsmen;
        FindObjectOfType<Game>().swordsmen.setTempTotal(data.temp_total_swordsmen);
        FindObjectOfType<Game>().swordsmen.setTotal();
        FindObjectOfType<Game>().swordsmen.atk_swordsmen = data.atk_swordsmen;
        FindObjectOfType<Game>().swordsmen.temp_atk_swordsmen = data.temp_atk_swordsmen;
        FindObjectOfType<Game>().swordsmen.def_swordsmen = data.def_swordsmen;
        FindObjectOfType<Game>().swordsmen.temp_def_swordsmen = data.temp_def_swordsmen;
        FindObjectOfType<Game>().swordsmen.bonus_swordsmen = data.bonus_swordsmen;
        FindObjectOfType<Game>().swordsmen.momentswordman = data.momentswordman;
        FindObjectOfType<Game>().swordsmen.momentDeadswordman = data.momentDeadswordman;
        /*archers*/
        FindObjectOfType<Game>().archers.total_archers = data.total_archers;
        FindObjectOfType<Game>().archers.setTempTotal(data.temp_total_archers);
        FindObjectOfType<Game>().archers.setTotal();
        FindObjectOfType<Game>().archers.atk_archers = data.atk_archers;
        FindObjectOfType<Game>().archers.temp_atk_archers = data.temp_atk_archers;
        FindObjectOfType<Game>().archers.def_archers = data.def_archers;
        FindObjectOfType<Game>().archers.temp_def_archers = data.temp_def_archers;
        FindObjectOfType<Game>().archers.bonus_archers = data.bonus_archers;
        FindObjectOfType<Game>().archers.momentarcher = data.momentarcher;
        FindObjectOfType<Game>().archers.momentDeadArcher = data.momentDeadArcher;
        /*riders*/
        FindObjectOfType<Game>().riders.total_riders = data.total_riders;
        FindObjectOfType<Game>().riders.setTempTotal(data.temp_total_riders);
        FindObjectOfType<Game>().riders.setTotal();
        FindObjectOfType<Game>().riders.atk_riders = data.atk_riders;
        FindObjectOfType<Game>().riders.temp_atk_riders = data.temp_atk_riders;
        FindObjectOfType<Game>().riders.def_riders = data.def_riders;
        FindObjectOfType<Game>().riders.temp_def_riders = data.temp_def_riders;
        FindObjectOfType<Game>().riders.bonus_riders = data.bonus_riders;
        FindObjectOfType<Game>().riders.momentrider = data.momentrider;
        FindObjectOfType<Game>().riders.momentDeadRider = data.momentDeadRider;

        /*Enemy*/

        enemy.totalSoldier = data.totalSoldierE;
        enemy.lvl = data.lvlE;

        FindObjectOfType<Game>().eswordsmen.total_swordsmen = data.total_swordsmenE;
        FindObjectOfType<Game>().eswordsmen.atk_swordsmen = data.atk_swordsmenE;
        FindObjectOfType<Game>().eswordsmen.def_swordsmen = data.def_swordsmenE;
        FindObjectOfType<Game>().eswordsmen.bonus_swordsmen = data.bonus_swordsmenE;
        FindObjectOfType<Game>().eswordsmen.deadEswordman = data.deadEswordmanE;

        FindObjectOfType<Game>().earchers.total_archers = data.total_archersE;
        FindObjectOfType<Game>().earchers.atk_archers = data.atk_archersE;
        FindObjectOfType<Game>().earchers.def_archers = data.def_archersE;
        FindObjectOfType<Game>().earchers.bonus_archers = data.bonus_archersE;
        FindObjectOfType<Game>().earchers.deadEArchers = data.deadEArchersE;

        FindObjectOfType<Game>().eriders.total_riders = data.total_ridersE;
        FindObjectOfType<Game>().eriders.atk_riders = data.atk_ridersE;
        FindObjectOfType<Game>().eriders.def_riders = data.def_ridersE;
        FindObjectOfType<Game>().eriders.bonus_riders = data.bonus_ridersE;
        FindObjectOfType<Game>().eriders.deadERiders = data.deadERidersE;

        /*fabbro*/
        fabbro.lvl = data.fablvl;
        fabbro.costo = data.fabcosto;
        fabbro.armi = data.armi;
        fabbro.armature = data.armature;
        fabbro.zappa = data.zappa;
        fabbro.goldzappa = data.goldzappa;
        fabbro.piccone = data.piccone;
        fabbro.goldpiccone = data.goldpiccone;

        /*gilda*/
        gilda.lvl = data.gildalvl;
        gilda.costo = data.gildacosto;
        gilda.sped1 = data.sped1;
        gilda.sped2 = data.sped2;
        gilda.sped3 = data.sped3;
        gilda.sped4 = data.sped4;
        gilda.sped5 = data.sped5;
        gilda.controllosped1 = data.controllosped1;
        gilda.controllosped2 = data.controllosped2;

        /*OldSoldiers*/
        FindObjectOfType<OldSoldiersManager>().sword1 = data.sword1;
        FindObjectOfType<OldSoldiersManager>().arc1 = data.arc1;
        FindObjectOfType<OldSoldiersManager>().rid1 = data.rid1;
        FindObjectOfType<OldSoldiersManager>().turn1 = data.turn1;

        FindObjectOfType<OldSoldiersManager>().sword2 = data.sword2;
        FindObjectOfType<OldSoldiersManager>().arc2 = data.arc2;
        FindObjectOfType<OldSoldiersManager>().rid2 = data.rid2;
        FindObjectOfType<OldSoldiersManager>().turn2 = data.turn2;

        FindObjectOfType<OldSoldiersManager>().sword3 = data.sword3;
        FindObjectOfType<OldSoldiersManager>().arc3 = data.arc3;
        FindObjectOfType<OldSoldiersManager>().rid3 = data.rid3;
        FindObjectOfType<OldSoldiersManager>().turn3 = data.turn3;

        FindObjectOfType<OldSoldiersManager>().sword4 = data.sword4;
        FindObjectOfType<OldSoldiersManager>().arc4 = data.arc4;
        FindObjectOfType<OldSoldiersManager>().rid4 = data.rid4;
        FindObjectOfType<OldSoldiersManager>().turn4 = data.turn4;

        FindObjectOfType<OldSoldiersManager>().sword5 = data.sword5;
        FindObjectOfType<OldSoldiersManager>().arc5 = data.arc5;
        FindObjectOfType<OldSoldiersManager>().rid5 = data.rid5;
        FindObjectOfType<OldSoldiersManager>().turn5 = data.turn5;

        FindObjectOfType<OldSoldiersManager>().swordgilda1 = data.swordgilda1;
        FindObjectOfType<OldSoldiersManager>().arcgilda1 = data.arcgilda1;
        FindObjectOfType<OldSoldiersManager>().ridgilda1 = data.ridgilda1;
        FindObjectOfType<OldSoldiersManager>().tipologia1 = data.tipologia1;
        FindObjectOfType<OldSoldiersManager>().moltiplicatore1 = data.moltiplicatore1;
        FindObjectOfType<OldSoldiersManager>().turngilda1 = data.turngilda1;

        FindObjectOfType<OldSoldiersManager>().swordgilda2 = data.swordgilda2;
        FindObjectOfType<OldSoldiersManager>().arcgilda2 = data.arcgilda2;
        FindObjectOfType<OldSoldiersManager>().ridgilda2 = data.ridgilda2;
        FindObjectOfType<OldSoldiersManager>().tipologia2 = data.tipologia2;
        FindObjectOfType<OldSoldiersManager>().moltiplicatore2 = data.moltiplicatore2;
        FindObjectOfType<OldSoldiersManager>().turngilda2 = data.turngilda2;

        //Capitano 1

        FindObjectOfType<Game>().getCapitano().creato = data.creatoC;

        FindObjectOfType<Game>().getCapitano().lvl = data.lvlC;
        FindObjectOfType<Game>().getCapitano().atk = data.atkC;
        FindObjectOfType<Game>().getCapitano().def = data.defC;

        FindObjectOfType<Game>().getCapitano().bonusBattle = data.bonusBattleC;

        FindObjectOfType<Game>().getCapitano().bonusWall = data.bonusWallC;
        FindObjectOfType<Game>().getCapitano().bonusCity = data.bonusCityC;
        FindObjectOfType<Game>().getCapitano().bonusFar = data.bonusFarC;
        FindObjectOfType<Game>().getCapitano().bonusDemoniac = data.bonusDemoniacC;

        FindObjectOfType<Game>().getCapitano().nome = data.nomeC;

        //lista perk
        FindObjectOfType<Game>().getCapitano().xcont = data.xcont;
        FindObjectOfType<Game>().getCapitano().x1 = data.x1;
        FindObjectOfType<Game>().getCapitano().x2 = data.x2;
        FindObjectOfType<Game>().getCapitano().x3 = data.x3;
        FindObjectOfType<Game>().getCapitano().x4 = data.x4;
        FindObjectOfType<Game>().getCapitano().x5 = data.x5;
        FindObjectOfType<Game>().getCapitano().x6 = data.x6;
        FindObjectOfType<Game>().getCapitano().x7 = data.x7;
        FindObjectOfType<Game>().getCapitano().x8 = data.x8;
        FindObjectOfType<Game>().getCapitano().x9 = data.x9;
        FindObjectOfType<Game>().getCapitano().x10 = data.x10;

        //--------------------------------perks-----------------------------------
        FindObjectOfType<Game>().getCapitano().perk1 = data.perk1;
        FindObjectOfType<Game>().getCapitano().perk1comment = data.perk1comment;

        FindObjectOfType<Game>().getCapitano().perk2 = data.perk2;
        FindObjectOfType<Game>().getCapitano().perk2comment = data.perk2comment;

        FindObjectOfType<Game>().getCapitano().perk3 = data.perk3;
        FindObjectOfType<Game>().getCapitano().perk3comment = data.perk3comment;
        //-------------------------------------------------------------------------

        FindObjectOfType<Game>().getCapitano().finalcomment = data.finalcomment;
        FindObjectOfType<Game>().getCapitano().boolfinalcomment = data.boolfinalcomment;
    }

    public void loadgame(Player player, Fattoria fattoria, Miniera miniera, Caserma caserma, Enemy enemy, Fabbro fabbro, Gilda gilda)
    {
        GameData data = SaveSystem.LoadGame();

        FindObjectOfType<Game>().CityNameUI.text = data.cityName;

        player.player_turn = data.player_turn;
        player.setPopulation(data.player_population);
        player.player_citizens = data.player_citizens;
        player.setCitizensMax(data.player_citizensMAX);
        player.setCitizens();

        player.temp_player_citizens = data.temp_player_citizens;
        //player.setTempCitizens(data.temp_player_citizens);
        player.player_money = data.player_money;

        player.bonusBattle = data.bonusBattle;
        player.bonusWall = data.bonusWall;
        player.bonusCity = data.bonusCity;
        player.bonusFar = data.bonusFar;
        player.bonusDemoniac = data.bonusDemoniac;
        player.lvlwall = data.lvlwall;
        player.lvlfield = data.lvlfield;
        player.soldiersaway = data.soldiersaway;

        ///*tutorial*/
        //FindObjectOfType<Tutorial>().welcomeTutorial = data.welcomeTutorial;
        //tutorialW = data.welcomeTutorial;
        //FindObjectOfType<Tutorial>().villageTutorial = data.villageTutorial;
        //FindObjectOfType<Tutorial>().farmTutorial = data.farmTutorial;
        //FindObjectOfType<Tutorial>().barracksTutorial = data.barracksTutorial;
        //FindObjectOfType<Tutorial>().blacksmithTutorial = data.blacksmithTutorial;
        //FindObjectOfType<Tutorial>().guildTutorial = data.guildTutorial;
        //FindObjectOfType<Tutorial>().mineTutorial = data.mineTutorial;
        //FindObjectOfType<Tutorial>().bonusTutorial = data.bonusTutorial;

        /*events*/
        FindObjectOfType<Events>().response[0] = data.response;
        FindObjectOfType<Events>().attendingSecondaryEvent = data.attendingSecondaryEvent;


        FindObjectOfType<Events>().terri = data.terri;
        FindObjectOfType<Events>().bonusETerri = data.bonusETerri;
        FindObjectOfType<Events>().bonusEnemy = data.bonusEnemy;

        FindObjectOfType<Events>().aemisFaith = data.aemisFaith;
        FindObjectOfType<Events>().aemisKnightsHostility = data.aemisKnightsHostility;
        FindObjectOfType<Events>().aemisRebel = data.aemisRebel;

        FindObjectOfType<Events>().elvesEnemy = data.elvesEnemy;
        FindObjectOfType<Events>().forestDiplomacy = data.forestDiplomacy;

        FindObjectOfType<Events>().ancientGreenJewel = data.ancientGreenJewel;
        FindObjectOfType<Events>().blackCrystal = data.blackCrystal;
        FindObjectOfType<Events>().aqueduct = data.aqueduct;
        FindObjectOfType<Events>().uominiErranti = data.uominiErranti;

        FindObjectOfType<Events>().event1 = data.event1;
        FindObjectOfType<Events>().secondaryEvent1MalusTurnsLeft = data.secondaryEvent1MalusTurnsLeft;
        FindObjectOfType<Events>().secondaryEvent1Malus = data.secondaryEvent1Malus ? 1 : 0;
        FindObjectOfType<Events>().secondaryEvent1 = data.secondaryEvent1;
        FindObjectOfType<Events>().secondaryEvent1TurnsLeft = data.secondaryEvent1TurnsLeft;
        FindObjectOfType<Events>().event2 = data.event2;
        FindObjectOfType<Events>().event2MalusTurnsLeft = data.event2MalusTurnsLeft;
        FindObjectOfType<Events>().event3 = data.event3;
        FindObjectOfType<Events>().event4 = data.event4;
        FindObjectOfType<Events>().event4BonusTurnsLeft = data.event4BonusTurnsLeft;
        FindObjectOfType<Events>().secondaryEvent2 = data.secondaryEvent2;
        FindObjectOfType<Events>().secondaryEvent2TurnsLeft = data.secondaryEvent2TurnsLeft;
        FindObjectOfType<Events>().event5 = data.event5;
        FindObjectOfType<Events>().event6 = data.event6;
        FindObjectOfType<Events>().event7 = data.event7;
        FindObjectOfType<Events>().event7MalusTurnsLeft = data.event7MalusTurnsLeft;
        FindObjectOfType<Events>().event8 = data.event8;
        FindObjectOfType<Events>().secondaryEvent3 = data.secondaryEvent3;
        FindObjectOfType<Events>().secondaryEvent3TurnsLeft = data.secondaryEvent3TurnsLeft;
        FindObjectOfType<Events>().secondaryEvent3MalusEffectGoldTurnsLeft = data.secondaryEvent3MalusEffectGoldTurnsLeft;
        FindObjectOfType<Events>().secondaryEvent3MalusEffectCitizensTurnsLeft = data.secondaryEvent3MalusEffectCitizensTurnsLeft;
        FindObjectOfType<Events>().secondaryEvent3MalusEffectGoldTurnsLeftMINE = data.secondaryEvent3MalusEffectGoldTurnsLeftMINE;
        FindObjectOfType<Events>().event9 = data.event9;
        FindObjectOfType<Events>().event9BonusTurnsLeft = data.event9BonusTurnsLeft;
        FindObjectOfType<Events>().event10 = data.event10;
        FindObjectOfType<Events>().event11 = data.event11;
        FindObjectOfType<Events>().event12 = data.event12;
        FindObjectOfType<Events>().event12Malus = data.event12Malus;
        FindObjectOfType<Events>().event12MalusTurnsLeft = data.event12MalusTurnsLeft;
        FindObjectOfType<Events>().event13 = data.event13;
        FindObjectOfType<Events>().event14 = data.event14;
        FindObjectOfType<Events>().event15 = data.event15;
        FindObjectOfType<Events>().event15MalusTurnsLeft = data.event15MalusTurnsLeft;
        FindObjectOfType<Events>().event16 = data.event16;
        FindObjectOfType<Events>().secondaryEvent4 = data.secondaryEvent4;
        FindObjectOfType<Events>().secondaryEvent4TurnsLeft = data.secondaryEvent4TurnsLeft;
        FindObjectOfType<Events>().event17 = data.event17;
        FindObjectOfType<Events>().event17MalusTurnsLeft = data.event17MalusTurnsLeft;
        FindObjectOfType<Events>().event18 = data.event18;
        FindObjectOfType<Events>().event19 = data.event19;
        FindObjectOfType<Events>().event20 = data.event20;
        FindObjectOfType<Events>().event21 = data.event21;
        FindObjectOfType<Events>().event21MalusTurnsLeft = data.event21MalusTurnsLeft;
        FindObjectOfType<Events>().event22 = data.event22;
        FindObjectOfType<Events>().event23 = data.event23;
        FindObjectOfType<Events>().event24 = data.event24;
        FindObjectOfType<Events>().secondaryEvent5 = data.secondaryEvent5;
        FindObjectOfType<Events>().secondaryEvent5TurnsLeft = data.secondaryEvent5TurnsLeft;
        FindObjectOfType<Events>().secondaryEvent5Malus40 = data.secondaryEvent5Malus40;
        FindObjectOfType<Events>().secondaryEvent5Malus100 = data.secondaryEvent5Malus100;
        FindObjectOfType<Events>().event25 = data.event25;
        FindObjectOfType<Events>().event25BonusTurnsLeft = data.event25BonusTurnsLeft;
        FindObjectOfType<Events>().secondaryEvent6 = data.secondaryEvent6;
        FindObjectOfType<Events>().secondaryEvent6TurnsLeft = data.secondaryEvent6TurnsLeft;
        FindObjectOfType<Events>().event26 = data.event26;
        FindObjectOfType<Events>().event27 = data.event27;
        FindObjectOfType<Events>().event27MalusTurnsLeft = data.event27MalusTurnsLeft;
        FindObjectOfType<Events>().event28 = data.event28;
        FindObjectOfType<Events>().event29 = data.event29;
        FindObjectOfType<Events>().event30 = data.event30;
        FindObjectOfType<Events>().event30MalusTurnsLeft = data.event30MalusTurnsLeft;

        FindObjectOfType<Events>().prologueFinalEvent = data.prologueFinalEvent;

        /*
        FindObjectOfType<Events>().setPlayer(data.player1);
        FindObjectOfType<Events>().setSwordsmen(data.swordsmen1);
        FindObjectOfType<Events>().setArchers(data.archers1);
        FindObjectOfType<Events>().setRiders(data.riders1);
        FindObjectOfType<Events>().setFattoria(data.fattoria1);
        FindObjectOfType<Events>().setMiniera(data.miniera1);
        FindObjectOfType<Events>().setCaserma(data.caserma1);
        FindObjectOfType<Events>().setFabbro(data.fabbro1);
        FindObjectOfType<Events>().setGilda(data.gilda1);
        */

        /*farm*/
        fattoria.setLvlFattoria(data.farmLvl);
        fattoria.setAbitantiMax(data.abitantiMax);
        fattoria.setCrescitaAbitanti(data.crescitaAbitanti);
        fattoria.setGoldFattoria(data.farmGold);
        fattoria.setLvlUpCost(data.farmLvlUpCost);
        /*mine*/
        miniera.lvl = data.minelvl;
        miniera.gold = data.minegold;
        miniera.carboneHigh = data.carboneHigh;
        miniera.costo = data.minecosto;
        /*barracks*/
        caserma.lvl = data.casermalvl;
        caserma.reclutamentoMAX = data.reclutamentoMAX;
        caserma.bonusBarrack = data.bonusBarrack;
        caserma.reclutamentoMaxMoment = data.reclutamentoMaxMoment;
        caserma.costo = data.casermaLvlUpCost;

        /*soldiers*/
        /*swordsmen*/
        FindObjectOfType<Game>().swordsmen.total_swordsmen = data.total_swordsmen;
        FindObjectOfType<Game>().swordsmen.setTempTotal(data.temp_total_swordsmen);
        FindObjectOfType<Game>().swordsmen.setTotal();
        FindObjectOfType<Game>().swordsmen.atk_swordsmen = data.atk_swordsmen;
        FindObjectOfType<Game>().swordsmen.temp_atk_swordsmen = data.temp_atk_swordsmen;
        FindObjectOfType<Game>().swordsmen.def_swordsmen = data.def_swordsmen;
        FindObjectOfType<Game>().swordsmen.temp_def_swordsmen = data.temp_def_swordsmen;
        FindObjectOfType<Game>().swordsmen.bonus_swordsmen = data.bonus_swordsmen;
        FindObjectOfType<Game>().swordsmen.momentswordman = data.momentswordman;
        FindObjectOfType<Game>().swordsmen.momentDeadswordman = data.momentDeadswordman;
        /*archers*/
        FindObjectOfType<Game>().archers.total_archers = data.total_archers;
        FindObjectOfType<Game>().archers.setTempTotal(data.temp_total_archers);
        FindObjectOfType<Game>().archers.setTotal();
        FindObjectOfType<Game>().archers.atk_archers = data.atk_archers;
        FindObjectOfType<Game>().archers.temp_atk_archers = data.temp_atk_archers;
        FindObjectOfType<Game>().archers.def_archers = data.def_archers;
        FindObjectOfType<Game>().archers.temp_def_archers = data.temp_def_archers;
        FindObjectOfType<Game>().archers.bonus_archers = data.bonus_archers;
        FindObjectOfType<Game>().archers.momentarcher = data.momentarcher;
        FindObjectOfType<Game>().archers.momentDeadArcher = data.momentDeadArcher;
        /*riders*/
        FindObjectOfType<Game>().riders.total_riders = data.total_riders;
        FindObjectOfType<Game>().riders.setTempTotal(data.temp_total_riders);
        FindObjectOfType<Game>().riders.setTotal();
        FindObjectOfType<Game>().riders.atk_riders = data.atk_riders;
        FindObjectOfType<Game>().riders.temp_atk_riders = data.temp_atk_riders;
        FindObjectOfType<Game>().riders.def_riders = data.def_riders;
        FindObjectOfType<Game>().riders.temp_def_riders = data.temp_def_riders;
        FindObjectOfType<Game>().riders.bonus_riders = data.bonus_riders;
        FindObjectOfType<Game>().riders.momentrider = data.momentrider;
        FindObjectOfType<Game>().riders.momentDeadRider = data.momentDeadRider;

        /*Enemy*/

        enemy.totalSoldier = data.totalSoldierE;
        enemy.lvl = data.lvlE;

        FindObjectOfType<Game>().eswordsmen.total_swordsmen = data.total_swordsmenE;
        FindObjectOfType<Game>().eswordsmen.atk_swordsmen = data.atk_swordsmenE;
        FindObjectOfType<Game>().eswordsmen.def_swordsmen = data.def_swordsmenE;
        FindObjectOfType<Game>().eswordsmen.bonus_swordsmen = data.bonus_swordsmenE;
        FindObjectOfType<Game>().eswordsmen.deadEswordman = data.deadEswordmanE;

        FindObjectOfType<Game>().earchers.total_archers = data.total_archersE;
        FindObjectOfType<Game>().earchers.atk_archers = data.atk_archersE;
        FindObjectOfType<Game>().earchers.def_archers = data.def_archersE;
        FindObjectOfType<Game>().earchers.bonus_archers = data.bonus_archersE;
        FindObjectOfType<Game>().earchers.deadEArchers = data.deadEArchersE;

        FindObjectOfType<Game>().eriders.total_riders = data.total_ridersE;
        FindObjectOfType<Game>().eriders.atk_riders = data.atk_ridersE;
        FindObjectOfType<Game>().eriders.def_riders = data.def_ridersE;
        FindObjectOfType<Game>().eriders.bonus_riders = data.bonus_ridersE;
        FindObjectOfType<Game>().eriders.deadERiders = data.deadERidersE;

        /*fabbro*/
        fabbro.lvl = data.fablvl;
        fabbro.costo = data.fabcosto;
        fabbro.armi = data.armi;
        fabbro.armature = data.armature;
        fabbro.zappa = data.zappa;
        fabbro.goldzappa = data.goldzappa;
        fabbro.piccone = data.piccone;
        fabbro.goldpiccone = data.goldpiccone;

        /*gilda*/
        gilda.lvl = data.gildalvl;
        gilda.costo = data.gildacosto;
        gilda.sped1 = data.sped1;
        gilda.sped2 = data.sped2;
        gilda.sped3 = data.sped3;
        gilda.sped4 = data.sped4;
        gilda.sped5 = data.sped5;
        gilda.controllosped1 = data.controllosped1;
        gilda.controllosped2 = data.controllosped2;

        /*OldSoldiers*/
        FindObjectOfType<OldSoldiersManager>().sword1 = data.sword1;
        FindObjectOfType<OldSoldiersManager>().arc1 = data.arc1;
        FindObjectOfType<OldSoldiersManager>().rid1 = data.rid1;
        FindObjectOfType<OldSoldiersManager>().turn1 = data.turn1;

        FindObjectOfType<OldSoldiersManager>().sword2 = data.sword2;
        FindObjectOfType<OldSoldiersManager>().arc2 = data.arc2;
        FindObjectOfType<OldSoldiersManager>().rid2 = data.rid2;
        FindObjectOfType<OldSoldiersManager>().turn2 = data.turn2;

        FindObjectOfType<OldSoldiersManager>().sword3 = data.sword3;
        FindObjectOfType<OldSoldiersManager>().arc3 = data.arc3;
        FindObjectOfType<OldSoldiersManager>().rid3 = data.rid3;
        FindObjectOfType<OldSoldiersManager>().turn3 = data.turn3;

        FindObjectOfType<OldSoldiersManager>().sword4 = data.sword4;
        FindObjectOfType<OldSoldiersManager>().arc4 = data.arc4;
        FindObjectOfType<OldSoldiersManager>().rid4 = data.rid4;
        FindObjectOfType<OldSoldiersManager>().turn4 = data.turn4;

        FindObjectOfType<OldSoldiersManager>().sword5 = data.sword5;
        FindObjectOfType<OldSoldiersManager>().arc5 = data.arc5;
        FindObjectOfType<OldSoldiersManager>().rid5 = data.rid5;
        FindObjectOfType<OldSoldiersManager>().turn5 = data.turn5;

        FindObjectOfType<OldSoldiersManager>().swordgilda1 = data.swordgilda1;
        FindObjectOfType<OldSoldiersManager>().arcgilda1 = data.arcgilda1;
        FindObjectOfType<OldSoldiersManager>().ridgilda1 = data.ridgilda1;
        FindObjectOfType<OldSoldiersManager>().tipologia1 = data.tipologia1;
        FindObjectOfType<OldSoldiersManager>().moltiplicatore1 = data.moltiplicatore1;
        FindObjectOfType<OldSoldiersManager>().turngilda1 = data.turngilda1;

        FindObjectOfType<OldSoldiersManager>().swordgilda2 = data.swordgilda2;
        FindObjectOfType<OldSoldiersManager>().arcgilda2 = data.arcgilda2;
        FindObjectOfType<OldSoldiersManager>().ridgilda2 = data.ridgilda2;
        FindObjectOfType<OldSoldiersManager>().tipologia2 = data.tipologia2;
        FindObjectOfType<OldSoldiersManager>().moltiplicatore2 = data.moltiplicatore2;
        FindObjectOfType<OldSoldiersManager>().turngilda2 = data.turngilda2;


        //Capitano 1

        FindObjectOfType<Game>().getCapitano().creato = data.creatoC;

        FindObjectOfType<Game>().getCapitano().lvl = data.lvlC;
        FindObjectOfType<Game>().getCapitano().atk = data.atkC;
        FindObjectOfType<Game>().getCapitano().def = data.defC;

        FindObjectOfType<Game>().getCapitano().bonusBattle = data.bonusBattleC;

        FindObjectOfType<Game>().getCapitano().bonusWall = data.bonusWallC;
        FindObjectOfType<Game>().getCapitano().bonusCity = data.bonusCityC;
        FindObjectOfType<Game>().getCapitano().bonusFar = data.bonusFarC;
        FindObjectOfType<Game>().getCapitano().bonusDemoniac = data.bonusDemoniacC;

        FindObjectOfType<Game>().getCapitano().nome = data.nomeC;

        //lista perk
        FindObjectOfType<Game>().getCapitano().xcont = data.xcont;
        FindObjectOfType<Game>().getCapitano().x1 = data.x1;
        FindObjectOfType<Game>().getCapitano().x2 = data.x2;
        FindObjectOfType<Game>().getCapitano().x3 = data.x3;
        FindObjectOfType<Game>().getCapitano().x4 = data.x4;
        FindObjectOfType<Game>().getCapitano().x5 = data.x5;
        FindObjectOfType<Game>().getCapitano().x6 = data.x6;
        FindObjectOfType<Game>().getCapitano().x7 = data.x7;
        FindObjectOfType<Game>().getCapitano().x8 = data.x8;
        FindObjectOfType<Game>().getCapitano().x9 = data.x9;
        FindObjectOfType<Game>().getCapitano().x10 = data.x10;

        //--------------------------------perks-----------------------------------
        FindObjectOfType<Game>().getCapitano().perk1 = data.perk1;
        FindObjectOfType<Game>().getCapitano().perk1comment = data.perk1comment;

        FindObjectOfType<Game>().getCapitano().perk2 = data.perk2;
        FindObjectOfType<Game>().getCapitano().perk2comment = data.perk2comment;

        FindObjectOfType<Game>().getCapitano().perk3 = data.perk3;
        FindObjectOfType<Game>().getCapitano().perk3comment = data.perk3comment;
        //-------------------------------------------------------------------------

        FindObjectOfType<Game>().getCapitano().finalcomment = data.finalcomment;
        FindObjectOfType<Game>().getCapitano().boolfinalcomment = data.boolfinalcomment;
    }
}

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


    /*Tutorial*/
    public bool welcomeTutorial;
    public bool villageTutorial;
    public bool farmTutorial;
    public bool barracksTutorial;
    public bool blacksmithTutorial;
    public bool guildTutorial;
    public bool mineTutorial;
    public bool bonusTutorial;

    /*eventi*/
    public int aqueduct;
    public int response;
    public int citydefenseproject;
    public int aqueductSecondary;
    public int aqueductTurnsLeft;
    public int aqueductMalusTurnsLeft;
    public bool attendingSecondaryEvent;
    public bool aqueductEffectMalus;

    /*fattoria*/
    public int farmLvl;
    public int abitantiMax;
    public int crescitaAbitanti;
    public int farmGold;
    public int farmLvlUpCost;

    /*caserma*/
    public int casermalvl;
    public int reclutamentoMAX;
    public float bonusBarrack;
    public int reclutamentoMaxMoment;
    public int casermaLvlUpCost;

    /*soldati*/
    public int total_swordsmen;
    public int temp_total_swordsmen;
    public int total_archers;
    public int temp_total_archers;
    public int total_riders;
    public int temp_total_riders;

    /* mine */
    public int minelvl;
    public int minegold;
    public bool carboneHigh;
    public int minecosto;

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
    public int sped2;
    public int sped3;
    public int sped4;
    public int sped5;
    public int controllosped1;
    public int controllosped2;


    public GameData (string cityname, Player player , Events events , Fattoria fattoria , Caserma caserma,
        Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders, 
        Miniera miniera, Fabbro fabbro, Gilda gilda, Tutorial tutorial
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
        villageTutorial = tutorial.villageTutorial;
        farmTutorial = tutorial.farmTutorial;
        barracksTutorial = tutorial.barracksTutorial;
        blacksmithTutorial = tutorial.blacksmithTutorial;
        guildTutorial = tutorial.guildTutorial;
        mineTutorial = tutorial.mineTutorial;
        bonusTutorial = tutorial.bonusTutorial;

        /*eventi*/
        aqueduct = events.aqueduct;
        response = events.response[0];
        citydefenseproject = events.citydefenseproject;
        aqueductSecondary = events.aqueductSecondary;
        aqueductTurnsLeft = events.aqueductTurnsLeft;
        attendingSecondaryEvent = events.attendingSecondaryEvent;
        aqueductMalusTurnsLeft = events.aqueductMalusTurnsLeft;
        aqueductEffectMalus = events.aqueductEffectMalus;

        farmLvl = fattoria.getLvlFattoria();
        abitantiMax = fattoria.getAbitantiMax();
        crescitaAbitanti = fattoria.getCrescitaAbitanti();
        farmGold = fattoria.getGoldFattoria();
        farmLvlUpCost = fattoria.getLvlUpCost();

        casermalvl = caserma.getLvl();
        reclutamentoMAX = caserma.getReclutamentoMax();
        bonusBarrack = caserma.getBonusBarrack();
        reclutamentoMaxMoment = caserma.getReclutamentoMaxMoment();
        casermaLvlUpCost = caserma.getcosto();

        total_swordsmen = swordsmen.getTotal();
        temp_total_swordsmen = swordsmen.getTempTotal();
        total_archers = archers.getTotal();
        temp_total_archers = archers.getTempTotal();
        total_riders = riders.getTotal();
        temp_total_riders = riders.getTempTotal();

        minelvl = miniera.lvl;
        minegold = miniera.gold;
        carboneHigh = miniera.carboneHigh;
        minecosto = miniera.costo;

        fablvl = fabbro.lvl;
        fabcosto = fabbro.costo;
        armi = fabbro.armi;
        armature = fabbro.armature;
        zappa = fabbro.zappa;
        goldzappa = fabbro.goldzappa;
        piccone = fabbro.piccone;
        goldpiccone = fabbro.goldpiccone;


        gildalvl = gilda.lvl;
        gildacosto = gilda.costo;
        sped2 = gilda.sped2;
        sped3 = gilda.sped3;
        sped4 = gilda.sped4;
        sped5 = gilda.sped5;
        controllosped1 = gilda.controllosped1;
        controllosped2 = gilda.controllosped2;
    }

}

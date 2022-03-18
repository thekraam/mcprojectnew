using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{

    public int player_turn;
    public int player_population;
    public int player_money;
    public int player_citizens;
    public int player_citizensMAX;
    public int temp_player_citizens;

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


    public GameData (Player player , Events events , Fattoria fattoria , Caserma caserma,
        Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders)
    {
        player_turn = player.getTurn();
        player_population = player.getPopulation();
        player_money = player.getMoney();
        player_citizens = player.getCitizens();
        player_citizensMAX = player.getCitizensMax();
        temp_player_citizens = player.getTempCitizens();


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
    }

}

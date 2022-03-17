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

    public GameData (Player player , Events events , Fattoria fattoria)
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

    }

}

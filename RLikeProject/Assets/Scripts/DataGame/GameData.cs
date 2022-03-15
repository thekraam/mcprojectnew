using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{

    public int player_turn;
    public float player_population;
    public int player_money;
    public int skip_player_money;

    public int aqueduct;
    public int response;
    public int citydefenseproject;
    public int aqueductSecondary;
    public int aqueductTurnsLeft;
    public bool attendingSecondaryEvent;

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
        skip_player_money = player.getSkipMoney();



        aqueduct = events.getEventAqueduct();

        response = events.getEventResponse();

        citydefenseproject = events.getEventCitydefenseproject();

        aqueductSecondary = events.getEventAqueductSecondary();

        aqueductTurnsLeft = events.getEventAqueductTurnsLeft();

        attendingSecondaryEvent = events.getEventAttendingSecondaryEvent();

        farmLvl = fattoria.getLvlFattoria();
        abitantiMax = fattoria.getAbitantiMax();
        crescitaAbitanti = fattoria.getCrescitaAbitanti();
        farmGold = fattoria.getGoldFattoria();
        farmLvlUpCost = fattoria.getLvlUpCost();

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{

    public int player_turn;
    public int aqueduct;
    public int response;
    public int citydefenseproject;
    public int aqueductSecondary;
    public int aqueductTurnsLeft;
    public bool attendingSecondaryEvent;

    public GameData (Player player , Events events)
    {
        player_turn = player.getTurn();

        aqueduct = events.getEventAqueduct();

        response = events.getEventResponse();

        citydefenseproject = events.getEventCitydefenseproject();

        aqueductSecondary = events.getEventAqueductSecondary();

        aqueductTurnsLeft = events.getEventAqueductTurnsLeft();

        attendingSecondaryEvent = events.getEventAttendingSecondaryEvent();

    }

}

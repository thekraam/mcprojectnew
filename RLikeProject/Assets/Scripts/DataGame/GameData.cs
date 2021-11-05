using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{

    public int player_turn;

    public GameData (Player player)
    {
        player_turn = player.getTurn();

    }

}

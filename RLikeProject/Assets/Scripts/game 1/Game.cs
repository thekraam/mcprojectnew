using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    /* dichiarazione elementi di UI tramite oggetto Text in UnityEngine.UI */
    public Text soldiersUI;
    public Text citizensUI;
    public Text populationUI;
    public Text moneyUI;
    public Text turnsUI;
    Player player = new Player(); // oggetto player partita - non contiene soldati

    /* classi di tipo soldato.classesoldato */
    Soldiers.Swordsmen swordsmen = new Soldiers.Swordsmen();
    Soldiers.Archers archers = new Soldiers.Archers();
    Soldiers.Riders riders = new Soldiers.Riders();


    public List<Text> UIelements; 
    
    bool isFirstTurn = true;
    bool isLastTurn = false;

    public void Update()
    {
        // soldiersUI.text = "" + (player.countTotalCitizens(player, swordsmen, archers, riders) - player.getCitizens()); // mostra il nuovo totale dei soldati appena lo trovi

        // populationUI.text = "" + player.countTotalCitizens(player, swordsmen, archers, riders); // mostra il nuovo totale della popolazione totale come somma di soldati e civili appena la trovi

        moneyUI.text = "" + player.getMoney(); // mostra il nuovo totale dei soldi appena lo trovi

        turnsUI.text = "" + player.getTurn(); // mostra il nuovo turno appena lo trovi
    }

    public void onSkipTurn()
    {
        player.setMoney(); // cambia definitivamente i soldi, al resto ci pensa Update

        player.nextTurn(); // cambia il numero del turno attuale, al resto ci pensa Update

        player.setCitizens(); // cambia il numero di cittadini liberi, al resto ci pensa Update in funzione del numero di soldati riportato sotto

        swordsmen.setTotal(); // idem

        archers.setTotal(); // idem

        riders.setTotal(); // idem
    }

}
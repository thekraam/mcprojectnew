using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Text soldiersUI;
    public Text citizensUI;
    public Text moneyUI;
    public Text turnsUI;

    public List<Text> UIelements; 

    bool isFirstTurn = true;
    bool isLastTurn = false;
    int currentTurn = 1;

    void Start()
    {
        if (isFirstTurn)
        {
            // dichiarazioni oggetti utilizzati
            Player player = new Player(); // non contiene soldati
            Soldiers total = new Soldiers(); // classe soldiers da sola solo per il totale soldati, NON lavora con le sottoclassi, in quel caso si necessita nuovo oggetto

            // scrivo numero soldati di partenza
            soldiersUI.text = "" + 10; // total.totalSoldiers();

            // scrivo numero cittadini di partenza
            citizensUI.text = "" + 20;// player.getCitizens();

            // scrivo quantita di monete di partenza
            moneyUI.text = "" + 30; // player.getMoney();

            // scrivo turno attuale
            turnsUI.text = "" + 40; // currentTurn;

            isFirstTurn = false;
            currentTurn++;


        }
        else
        {

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Text soldiersUI;
    public Text citizensUI;
    public Text populationUI;
    public Text moneyUI;
    public Text turnsUI;
    Player player = new Player(); // non contiene soldati
    Soldiers.Swordsmen swordsmen = new Soldiers.Swordsmen(); // classe soldiers da sola solo per il totale soldati, NON lavora con le sottoclassi, in quel caso si necessita nuovo oggetto di tipo Soldiers.Swordsmen/Archers/Riders
    Soldiers.Archers archers = new Soldiers.Archers();
    Soldiers.Riders riders = new Soldiers.Riders();


    public List<Text> UIelements; 
    
    bool isFirstTurn = true;
    bool isLastTurn = false;

    public void functiontest()
    {
        changeSoldiersUIText();
    }

    public void Update()
    {
        void changeSoldiersUIText()
        {
            soldiersUI.text = "" + (player.countTotalCitizens(player, swordsmen, archers, riders) - player.getCitizens());
        }
        void changePopulationUIText()
        {
            populationUI.text = "" + player.countTotalCitizens(player, swordsmen, archers, riders);
        }
        void changeMoneyUIText()
        {
            moneyUI.text = "" + player.getMoney();
        }
        void changeTurnsUIText()
        {
            turnsUI.text = "" + player.getTurn();
        }
    }
}

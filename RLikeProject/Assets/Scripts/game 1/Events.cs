using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    /* variabile di controllo risposta avvenuta decisione giocatore, [0] contenente la risposta (0 o 1), [1] contenente l'avvenuto check (1 se si, 0 altrimenti) */
    public int[] response = new int[2];


    Dialogue dialogue = new Dialogue();

    /* stringa messaggi */
    string[] message = new string[10];

    /* variabile territorio attuale di battaglia */
    public int terri = -1;

    /* variabili malus cittadini */
    private int citizensMalus1 = 0;
    private int citizensMalus2 = 0;
    private int citizensMalus3 = 0;
    private int citizensMalus4 = 0;
    private int citizensMalus5 = 0;
    private int citizensMalus6 = 0;
    private int citizensMalus7 = 0;
    private int citizensMalus8 = 0;
    private int citizensMalus9 = 0;

    /* variabili malus gold */
    private int goldMalus1 = 0;
    private int goldMalus2 = 0;
    private int goldMalus3 = 0;
    private int goldMalus4 = 0;
    private int goldMalus5 = 0;
    private int goldMalus6 = 0;
    private int goldMalus7 = 0;
    private int goldMalus8 = 0;
    private int goldMalus9 = 0;


    /* booleane effetti */
    public bool aqueductEffectMalus = false;


    /* booleane eventi secondari */
    public bool attendingSecondaryEvent = false; // generico, stabilisce se si sta partecipando gia' ad un evento secondario

    public int aqueductSecondary = 0; // evento secondario acquedotto


    /* booleane di avvenuto evento, 0 di default */
    public int aqueduct = 0;
    public int citydefenseproject = 0;

    /* variabili countdown evento secondario, grande numero di default */
    public int aqueductTurnsLeft = 999999;

    /* variabili countdown EFFETTI TEMPORANEI evento secondario, grande numero di default */
    public int aqueductMalusTurnsLeft = 999999;

    /* getter e setter 
    public bool getEventAttendingSecondaryEvent()
    {
        return attendingSecondaryEvent;
    }
    public void setEventAttendingSecondaryEvent(bool modifier)
    {
        this.attendingSecondaryEvent = modifier;
    }
    //
    public int getEventAqueduct()
    {
        return aqueduct;
    }
    public void setEventAqueduct(int modifier)
    {
        this.aqueduct = modifier;
    }
    //
    public int getEventCitydefenseproject()
    {
        return citydefenseproject;
    }
    public void setEventCitydefenseproject(int modifier)
    {
        this.citydefenseproject = modifier;
    }
    //
    public int getEventResponse()
    {
        return response[0];
    }
    public void setEventResponse(int modifier)
    {
        this.response[0] = modifier;
    }

    //
    public int getEventAqueductSecondary()
    {
        return aqueductSecondary;
    }
    public void setEventAqueductSecondary(int modifier)
    {
        this.aqueductSecondary = modifier;
    }
    //
    public int getEventAqueductTurnsLeft()
    {
        return aqueductTurnsLeft;
    }
    public void setEventAqueductTurnsLeft(int modifier)
    {
        this.aqueductTurnsLeft = modifier;
    }
    */



    /* controllore di response (decisione giocatore) sull'oggetto dialoguemanager */
    IEnumerator ResponseUpdater()
    {
        response[1] = 0; // check deve essere 0 prima di controllarlo
        while (response[1] == 0)
        {
            response = FindObjectOfType<DialogueManager>().InvokedChecker();
            yield return new WaitForSeconds(0.5f);
        }
        yield return true;
    }

    /* decrementatore turni per il prossimo evento secondario */
    public void eventTurnsDecreaser()
    {
        if (aqueductTurnsLeft > 0) aqueductTurnsLeft--;
    }

    public void MaxCitizensEffects(Player player, Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders)
    {

    }
    public int GoldMalusEffects(Player player, Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders)
    {
        return goldMalus1 + goldMalus2 + goldMalus3 + goldMalus4 + goldMalus5 + goldMalus6 + goldMalus7 + goldMalus8 + goldMalus9;
    }
    public int CitizensMalusEffects(Player player, Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders, Fattoria fattoria)
    {
        if (aqueductEffectMalus && aqueductTurnsLeft == 0)
        {
            if (aqueductMalusTurnsLeft == 0)
            {
                citizensMalus1 = 0;
                aqueductEffectMalus = false;
                attendingSecondaryEvent = false;
            }
            else
            {
                citizensMalus1 = (int)(0.4 * (float)fattoria.getCrescitaAbitanti()); // -40% popolazione
                aqueductMalusTurnsLeft--;
            }
        }
        return citizensMalus1 + citizensMalus2 + citizensMalus3 + citizensMalus4 + citizensMalus5 + citizensMalus6 + citizensMalus7 + citizensMalus8 + citizensMalus9;
    }

    public void SecondaryEventStarter(Player player, Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders)
    {
        if (aqueductSecondary == 1 && attendingSecondaryEvent && aqueductTurnsLeft == 0)
        {
            aqueductEffectMalus = true;

            aqueductSecondary = 0;
            attendingSecondaryEvent = false;
            aqueductMalusTurnsLeft = 3;

            string eventString1 = "The lack of drinking water caused a reduction of newborns.\n[-40% New Citizens per turn, for 3 turns]";

            string[] message = { eventString1 };

            dialogue.TriggerDialogue(player, swordsmen, archers, riders, message);
        }
    }

    /* avviatore eventi, la funzione sceglie un evento casuale e non gia' avvenuto sulla base di alcuni criteri */
    public void EventStarter(Player player, Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders)
    {
        float eventChooser = 0;

        eventChooser = Random.Range(0f, 1f);
        if (eventChooser >= 0 && eventChooser < 1f)
        {
            if (aqueduct == 0 /*&& player.getMoney() >= 400*/) // evento non avviabile qualora il giocatore non abbia i fondi necessari
            {
                StartCoroutine(TriggerAqueductEvent(player, swordsmen, archers, riders));
            }
            else if (citydefenseproject == 0 /*&& player.getMoney() >= 1000*/) // evento non avviabile qualora il giocatore non abbia i fondi necessari
            {
                StartCoroutine(TriggerCityDefenseProjectEvent(player, swordsmen, archers, riders));
            }
        }
    }

    /* evento primario aquedotto */
    IEnumerator TriggerAqueductEvent(Player player, Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders)
    {
        aqueduct = 1;
        float aqueductValue = Random.Range(0f, 1f); // probabilita di verifica evento secondario
        aqueductValue = 0.5f;
        string eventString1 = "A certain group of citizens complains about the lack of drinking water.";
        string eventString2 = "They would like you to finance a new aqueduct in the city.";
        string eventString3 = "Are you accepting their request?\n[Cost: 400 Gold]";

        string[] message = { eventString1, eventString2, eventString3 };

        dialogue.TriggerInteractiveDialogue(player, swordsmen, archers, riders, message);

        StartCoroutine(ResponseUpdater());
        yield return new WaitUntil(() => response[1] == 1);


        Debug.LogError("il vero response è");
        Debug.LogError(response[0]);
        if (response[0] == 1)
        {
            player.setRapidMoney(-400);
            aqueductValue = 0;
        }
        else if (aqueductValue >= 0.5f)
        {
            attendingSecondaryEvent = true;
            aqueductSecondary = 1;
            aqueductTurnsLeft = 4;
        }
        else
            aqueductSecondary = 0; // conferma logica dell'algoritmo, inutile
    }

    /* evento primario aumento delle difese della citta' */
    IEnumerator TriggerCityDefenseProjectEvent(Player player, Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders)
    {
        citydefenseproject = 1;

        string eventString1 = "A local artisan proposes a city reinforcement project.";
        string eventString2 = "The project forsees an extra woodden palisade on the fields around the city, a ...";
        string eventString3 = "... bunch of woodden lookout turrets, and paid guards in every single road that gives access to the city.";
        string eventString4 = "Would you like to finance this project?\n[Cost: 1000 Gold]";

        string[] message = { eventString1, eventString2, eventString3, eventString4 };

        dialogue.TriggerInteractiveDialogue(player, swordsmen, archers, riders, message);

        StartCoroutine(ResponseUpdater());
        yield return new WaitUntil(() => response[1] == 1);

        if (response[0] == 1)
        {
            player.setRapidMoney(-1000);
            player.bonusWall = 1;
        }
    }
}

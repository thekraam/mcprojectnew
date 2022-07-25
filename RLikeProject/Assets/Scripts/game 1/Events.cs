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
    public int bonusETerri = 0;
    public int bonusEnemy = 0;

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

    /* last battle info */
    public int lastBattleInfo = 0;
    public bool finishedBattle = false;

    /* variabile fedeAemis */
    public int aemisFaith = 0;

    /* booleane eventi secondari */
    public bool attendingSecondaryEvent = false; // generico, stabilisce se si sta partecipando gia' ad un evento secondario
    public bool attendingMainEvent = true;


    public int aqueductSecondary = 0; // evento secondario acquedotto

    //////////////////////////////////////////////////////
    ////*            variabili eventi             */////
    //////////////////////////////////////////////////////

    /////* variabili evento acquedotto */////
    public int aqueduct = 0;
    //------------ turni mancanti fine acquedotto e       ------------//
    //------------ turni mancanti fine malus acquedotto   ------------//
    public int aqueductTurnsLeft = 999999;
    public int aqueductMalusTurnsLeft = 999999;

    public bool aqueductEffectMalus = false;

    /////* variabili evento progetto di costruzione difesa per la citta' */////
    public int citydefenseproject = 0;

    /////* variabili evento elfi dei boschi */////
    public int woodsElves = 0;
    public int elfsEnemy = 0;


    //////////////////////////////////////////////////////

    public void makeEnemyForEvent(int totale, int livello, int swordsmen, int archers, int riders, int lvlCapitano)
    {
        FindObjectOfType<Game>().makeEnemy(totale, livello, swordsmen, archers, riders, lvlCapitano);
    }

    // pulsante start battle di battle preparation
    public void onPressStartBattle()
    {
        FindObjectOfType<PrepBattaglia>().AssegnaSoldati(); // soldati selezionati con gli sliders = soldati assegnati ai moment

        lastBattleInfo = FindObjectOfType<Game>().newBattle(terri, bonusETerri, bonusEnemy);

        FindObjectOfType<PrepBattaglia>().AvvioBattaglia(); // avvio effetto per killist

        //FindObjectOfType<PrepBattaglia>().battleLive.SetActive(true);
    }

    public void onPressContinue()
    {
        FindObjectOfType<PrepBattaglia>().TerminaBattaglia();
        finishedBattle = true;
    }

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
        if (aqueductSecondary == 1 && aqueductTurnsLeft == 0)
        {
            aqueductEffectMalus = true;

            aqueductSecondary = 0;
            attendingSecondaryEvent = false;
            aqueductMalusTurnsLeft = 3;

            string eventString1 = "The lack of drinking water caused a reduction of newborns.\n[-40% New Citizens each turn turn, for 3 turns]";

            string[] message = { eventString1 };

            dialogue.TriggerDialogue(player, swordsmen, archers, riders, message);
        }
    }

    /* avviatore eventi, la funzione sceglie un evento casuale e non gia' avvenuto sulla base di alcuni criteri */
    public void EventStarter(Player player, Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders)
    {
        float eventChooser = 0;
        bool selected = false;

        while (!selected && !attendingSecondaryEvent)
        {
            eventChooser = Random.Range(0f, 1f);

            eventChooser = 1.4f; // debug evento testbattaglia

            if (eventChooser >= 0 && eventChooser < 1f)
            {
                if (aqueduct == 0 /*&& player.getMoney() >= 400*/) // evento non avviabile qualora il giocatore non abbia i fondi necessari
                {
                    StartCoroutine(TriggerAqueductEvent(player, swordsmen, archers, riders));
                    selected = true;
                }
                else if (citydefenseproject == 0 /*&& player.getMoney() >= 1000*/) // evento non avviabile qualora il giocatore non abbia i fondi necessari
                {
                    StartCoroutine(TriggerCityDefenseProjectEvent(player, swordsmen, archers, riders));
                    selected = true;
                }
            }
            if(eventChooser >= 1f && eventChooser < 2f)
            {
                StartCoroutine(TriggerBattleTestEvent(player, swordsmen, archers, riders));
                selected = true;
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
        yield return new WaitForSeconds(1.5f);
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
        yield return new WaitForSeconds(1.5f);
    }

    IEnumerator TriggerBattleTestEvent(Player player, Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders)
    {    
        string eventString1 = "A cojo' voi combatte? o sei 'na pussy";

        string[] message = { eventString1 };

        dialogue.TriggerInteractiveDialogue(player, swordsmen, archers, riders, message);

        StartCoroutine(ResponseUpdater());
        yield return new WaitUntil(() => response[1] == 1);

        if(response[0] == 1) // risponde si
        {
            terri = 2; // assegnazione territorio di battaglia 
            makeEnemyForEvent(20, 1, 5, 5, 10, 1); // creazione esercito nemico
            FindObjectOfType<PrepBattaglia>().AvvioPreparazione(terri);

            yield return new WaitUntil(() => finishedBattle == true);
        }
        yield return null;
    }

    int woodsElves = 0;
    int elfsEnemy = 0;
    int aemisFaith = 0;

    // evento 14
    IEnumerator TriggerWoodsElvesEvent(Player player, Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders)
    {
        woodsElves = 1;
        float woodsElvesValue = Random.Range(0f, 1f); // probabilita di verifica evento secondario
        woodsElvesValue = 0.1f;
        string eventString1 = "A man visits your city and asks to be helped.";
        string eventString2 = "He claims he has been mugged by a group of Elves of the Woods and asks for help in the name of Aemis.";
        string eventString3 = "He wants you to organize an expedition in the Far Lands.";
        string eventString4 = "Are you willing to help this man?\n[The expedition has no cost]";

        string[] message = { eventString1, eventString2, eventString3, eventString4 };

        dialogue.TriggerInteractiveDialogue(player, swordsmen, archers, riders, message);

        StartCoroutine(ResponseUpdater());
        yield return new WaitUntil(() => response[1] == 1);


        Debug.LogError("il vero response è");
        Debug.LogError(response[0]);
        if (response[0] == 1) // il giocatore risponde si
        {
            elfsEnemy = 1; // variabile 'nemicoElfi'
            aemisFaith++;
            if (woodsElvesValue <= 0.9f) // 90% di possibilita che si verifichi evento battaglia
            {
                terri = 3; // assegnazione territorio di battaglia 
                int EventEswordsmen = 5 * Random.Range(1, 4);
                int EventEarchers = 3 * Random.Range(1, 3);
                int EventEriders = 0;
                makeEnemyForEvent(EventEswordsmen + EventEarchers + EventEriders, 1, EventEswordsmen, EventEarchers, EventEriders, 1); // creazione esercito nemico
                FindObjectOfType<PrepBattaglia>().AvvioPreparazione(terri);

                yield return new WaitUntil(() => finishedBattle == true);

                if(lastBattleInfo > 2) // vittoria di qualsiasi tipo
                {
                    string eventString5 = "Your expedition comes back.";
                    string eventString6 = "The Captain explains that the Elves fought long and hard before dying.";
                    string eventString7 = "The man's belongings have been retrieved and returned.\nThe man wants to thank your kindness and help by donating part of his belongings.";
                    string eventString8 = "[You obtain 300 gold worth of goods]";

                    string[] message2 = { eventString5, eventString6, eventString7, eventString8 };

                    dialogue.TriggerInteractiveDialogue(player, swordsmen, archers, riders, message);

                    player.setRapidMoney(300);
                }
                else // sconfitta di qualsiasi tipo
                {
                    string eventString5 = "Your expedition comes back.";
                    string eventString6 = "The Captain explains that the Elves were numerous and fought harder than expected.";
                    string eventString7 = "The expedition had to retire back to "+ FindObjectOfType<Game>().CityNameUI.text +" to reduce losses.";
                    string eventString8 = "["+swordsmen.getMomentDeadSwordman() + " swordsmen, " + archers.getMomentDeadArcher() + " archers and " + riders.getMomentDeadRider() + " riders didn't came back]";

                    string[] message2 = { eventString5, eventString6, eventString7, eventString8 };

                    dialogue.TriggerInteractiveDialogue(player, swordsmen, archers, riders, message);
                }
            }
            else
            {
                string eventString5 = "Your expedition comes back earlier than expected.";
                string eventString6 = "The Captain explains that the Elves surrended the moment after he claimed to be there in the name of " + FindObjectOfType<Game>().CityNameUI.text + ".";
                string eventString7 = "The Elves returned the man's belongings.\nThe man wants to thank your kindness and help by donating part of his belongings.";
                string eventString8 = "[You obtain 300 gold worth of goods]";

                string[] message2 = { eventString5, eventString6, eventString7, eventString8 };

                dialogue.TriggerInteractiveDialogue(player, swordsmen, archers, riders, message);

                player.setRapidMoney(300);
            }

        }
        else
        {
            aemisFaith--;
        }
        yield return new WaitForSeconds(1.5f);
    }
}

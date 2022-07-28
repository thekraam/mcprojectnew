using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    /* riferimenti a variabili game */
    private Player player;
    private Soldiers.Swordsmen swordsmen;
    private Soldiers.Archers archers;
    private Soldiers.Riders riders;
    private Fattoria fattoria;
    private Miniera miniera;
    private Caserma caserma;
    private Fabbro fabbro;
    private Gilda gilda;

    /* variabile di controllo risposta avvenuta decisione giocatore, [0] contenente la risposta (0 o 1), [1] contenente l'avvenuto check (1 se si, 0 altrimenti) */
    public int[] response = new int[2];

    /* variabile controllo fine evento */
    public bool isEventDialogueClosed = true;

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
    private int citizensMalus10 = 0;

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
    private int goldMalus10 = 0;

    /* informazioni ultima battaglia */
    public int lastBattleInfo = 0;
    public bool finishedBattle = false;

    //////////////////////////////////////////////////////
    //////////////////////////////////////////////////////
    ////*                 variabili               *///////
    ////             per tutti gli eventi          ///////
    //////////////////////////////////////////////////////
    //////////////////////////////////////////////////////

    /* variabili Aemis */
    public int aemisFaith = 0;
    public int aemisKnightsHostility = 0;
    public int aemisRebel = 0;

    /* booleane eventi secondari */
    public bool attendingSecondaryEvent = false; // generico, stabilisce se si sta partecipando gia' ad un evento secondario
    public bool attendingMainEvent = true;


    public int aqueductSecondary = 0; // evento secondario acquedotto

    //////////////////////////////////////////////////////
    //////////////////////////////////////////////////////
    ////*                 variabili               *///////
    ////              eventi verificati            ///////
    //////////////////////////////////////////////////////
    //////////////////////////////////////////////////////

    //////////* variabili evento acquedotto *//////////////////
    ///////////////////////////////////////////////////////////
    public int aqueduct = 0;
    //------------ turni mancanti fine acquedotto e       ------------//
    //------------ turni mancanti fine malus acquedotto   ------------//
    public int aqueductTurnsLeft = 99;
    public int aqueductMalusTurnsLeft = 99;

    public int secondaryEventTurnsLeft = 99;

    public bool aqueductMalus = false;
    //////////////////////////////////////////////////////
    //////////////////////////////////////////////////////
    ///
    /////* variabili evento progetto di costruzione difesa per la citta' */////
    public int citydefenseproject = 0;

    /////* variabili evento elfi dei boschi */////
    public int woodsElves = 0;
    public int elfsEnemy = 0;

    /////* variabili evento celestiale e cavalieri */////
    public int theCelestialEvent = 0;
    public int theCelestialEventMalus = 0;
    public int theCelestialEventMalusTurnsLeft = 0;

    //////////////////////////////////////////////////////

    public void makeEnemyForEvent(int totale, int livello, int swordsmen, int archers, int riders, int lvlCapitano)
    {
        FindObjectOfType<Game>().makeEnemy(totale, livello, swordsmen, archers, riders, lvlCapitano);
    }

    public void onPressCloseVictoryDefeatPanel()
    {
        finishedBattle = true;
    }

    // pulsante start battle di battle preparation
    public void onPressStartBattle()
    {
        finishedBattle = false;

        FindObjectOfType<PrepBattaglia>().AssegnaSoldati(); // soldati selezionati con gli sliders = soldati assegnati ai moment

        lastBattleInfo = FindObjectOfType<Game>().newBattle(terri, bonusETerri, bonusEnemy);

        FindObjectOfType<PrepBattaglia>().AvvioBattaglia(); // avvio effetto per killist

        //FindObjectOfType<PrepBattaglia>().battleLive.SetActive(true);
    }

    public void onPressContinue()
    {
        FindObjectOfType<PrepBattaglia>().TerminaBattaglia();
    }

    /* controllore di response (decisione giocatore) sull'oggetto dialoguemanager */
    IEnumerator ResponseUpdater(bool isSmallDialogue)
    {
        response[1] = 0; // check deve essere 0 prima di controllarlo
        while (response[1] == 0)
        {
            response = isSmallDialogue ? FindObjectOfType<DialogueManagerMINI>().InvokedChecker() : FindObjectOfType<DialogueManager>().InvokedChecker();
            yield return new WaitForSeconds(0.5f);
        }
        yield return true;
    }

    /* decrementatore turni per il prossimo evento secondario */
    public void eventTurnsDecreaser()
    {
        if (aqueductTurnsLeft > 0) aqueductTurnsLeft--;
        if (secondaryEventTurnsLeft > 0) secondaryEventTurnsLeft--;
    }

    public void MaxCitizensEffects()
    {

    }
    public int GoldMalusEffects()
    {
        goldMalus1 = 0; goldMalus2 = 0; goldMalus3 = 0; goldMalus4 = 0; goldMalus5 = 0; 
        goldMalus6 = 0; goldMalus7 = 0; goldMalus8 = 0; goldMalus9 = 0; goldMalus10 = 0;

        if (theCelestialEventMalusTurnsLeft > 0 && theCelestialEventMalus == 1)
        {
            goldMalus1 = (int)(fattoria.getGoldFattoria() / 2) + (int)(miniera.getgoldMiniera() / 2);
            theCelestialEventMalusTurnsLeft--;
        }
        if (bonusTurns > 0 )
        {
            goldMalus2 = -((int)(fattoria.getGoldFattoria() / 2) + (int)(miniera.getgoldMiniera() / 2));
            bonusTurns--;
        }


        return goldMalus1 + goldMalus2 + goldMalus3 + goldMalus4 + goldMalus5 + goldMalus6 + goldMalus7 + goldMalus8 + goldMalus9 + goldMalus10;
    }
    public int CitizensMalusEffects()
    {
        citizensMalus1 = 0; citizensMalus2 = 0; citizensMalus3 = 0; citizensMalus4 = 0; citizensMalus5 = 0;
        citizensMalus6 = 0; citizensMalus7 = 0; citizensMalus8 = 0; citizensMalus9 = 0; citizensMalus10 = 0;

        if (aqueductMalus && aqueductTurnsLeft == 0 && aqueductMalusTurnsLeft > 0)
        {
            citizensMalus1 = (int)(0.4f * (float)fattoria.getCrescitaAbitanti()); // -40% popolazione
            aqueductMalusTurnsLeft--;
        }
        //if (aqueductMalusTurnsLeft == 0)
        //{
        //    citizensMalus1 = 0;
        //    aqueductEffectMalus = false;
        //    attendingSecondaryEvent = false;
        //}
        //if (aqueductMalusTurnsLeft > 0)
        //{
        //    citizensMalus1 = (int)(0.4f * (float)fattoria.getCrescitaAbitanti()); // -40% popolazione
        //    aqueductMalusTurnsLeft--;
        //}

        return citizensMalus1 + citizensMalus2 + citizensMalus3 + citizensMalus4 + citizensMalus5 + citizensMalus6 + citizensMalus7 + citizensMalus8 + citizensMalus9 + citizensMalus10;
    }

    public void SecondaryEventStarter()
    {
        bool aa = false;
        if (aqueductSecondary == 1 && aqueductTurnsLeft == 0 && !aa)
        {
            isEventDialogueClosed = false;
            aqueductMalus = true;

            aqueductSecondary = 0;
            attendingSecondaryEvent = false;
            aqueductMalusTurnsLeft = 3;

            string eventString1 = "The lack of drinking water caused a reduction of newborns.\n[-40% New Citizens each season, for 3 seasons]";

            string[] message = { eventString1 };

            dialogue.TriggerDialogue(message);
            isEventDialogueClosed = true;
            aa=true;
        }
        Debug.Log("mancanoMalus "+ aqueductMalusTurnsLeft);
        Debug.Log("mancano "+ secondaryEventTurnsLeft);
        if (eventSecondary2 == 1 && secondaryEventTurnsLeft == 0 && !aa)
        {

            StartCoroutine(SecondaryEvent2());
            aa=true;
        }
    }

    /* avviatore eventi, la funzione sceglie un evento casuale e non gia' avvenuto sulla base di alcuni criteri */
    public void EventStarter(Player player, Fattoria fattoria, Miniera miniera, Caserma caserma, Fabbro fabbro, Gilda gilda, Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders)
    {
        response[1] = 0;

        this.player = player;
        this.fattoria = fattoria;
        this.miniera = miniera;
        this.caserma = caserma;
        this.fabbro = fabbro;
        this.gilda = gilda;
        this.swordsmen = swordsmen;
        this.archers = archers;
        this.riders = riders;

        float eventChooser = 0;
        bool selected = false;

        while (!selected && !attendingSecondaryEvent)
        {
            eventChooser = Random.Range(0f, 1f);

            eventChooser = 1.4f; // debug evento testbattaglia

            if (eventChooser >= 0 && eventChooser < 1f) // classificazione eventi fondamentali o di poca importanza, per ordine di importanza
            {
                if (aqueduct == 0 /*&& player.getMoney() >= 400*/) // evento non avviabile qualora il giocatore non abbia i fondi necessari
                {
                    StartCoroutine(TriggerAqueductEvent());
                    selected = true;
                }
                else if (citydefenseproject == 0 /*&& player.getMoney() >= 1000*/) // evento non avviabile qualora il giocatore non abbia i fondi necessari
                {
                    StartCoroutine(TriggerCityDefenseProjectEvent());
                    selected = true;
                }
            }
            if (eventChooser >= 1f && eventChooser < 2f)
            {
                StartCoroutine(TriggerBattleTestEvent());
                selected = true;
            }
            if (eventChooser >= 2f && eventChooser < 3f)
            {
                StartCoroutine(TriggerWoodsElvesEvent());
                selected = true;
            }
            if (eventChooser >= 3f && eventChooser < 4f && aemisFaith <= 4 && aemisKnightsHostility == 1)
            {
                StartCoroutine(TriggerTheCelestialEvent());
                selected = true;
            }
            
            if (eventChooser >= 4f && eventChooser < 5f)
            {

                StartCoroutine(TriggerEvent4());
                selected = true;
                
            }
            
        }

    }
    
    /* evento primario aquedotto */
    IEnumerator TriggerAqueductEvent()
    {
        isEventDialogueClosed = false;
        aqueduct = 1;
        float aqueductValue = Random.Range(0f, 1f); // probabilita di verifica evento secondario
        aqueductValue = 0.5f;
        string eventString1 = "A certain group of citizens complains about the lack of drinking water.";
        string eventString2 = "They would like you to finance a new aqueduct in the city.";
        string eventString3 = "Are you accepting their request?\n[Cost: 400 Gold]";

        string[] message = { eventString1, eventString2, eventString3 };

        dialogue.TriggerSmallInteractiveDialogue(message);

        StartCoroutine(ResponseUpdater(true));
        yield return new WaitUntil(() => response[1] == 1);


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
        isEventDialogueClosed = true;
        yield return new WaitForSeconds(1.5f);
    }

    /* evento primario aumento delle difese della citta' */
    IEnumerator TriggerCityDefenseProjectEvent()
    {
        isEventDialogueClosed = false;
        citydefenseproject = 1;

        string eventString1 = "A local artisan proposes a city reinforcement project.";
        string eventString2 = "The project forsees an extra woodden palisade on the fields around the city, a ...";
        string eventString3 = "... bunch of woodden lookout turrets, and paid guards in every single road that gives access to the city.";
        string eventString4 = "Would you like to finance this project?\n[Cost: 1000 Gold]";

        string[] message = { eventString1, eventString2, eventString3, eventString4 };

        dialogue.TriggerSmallInteractiveDialogue(message);

        StartCoroutine(ResponseUpdater(true));
        yield return new WaitUntil(() => response[1] == 1);

        if (response[0] == 1)
        {
            player.setRapidMoney(-1000);
            player.bonusWall = 1;
        }
        isEventDialogueClosed = true;
        yield return new WaitForSeconds(1.5f);
    }

    IEnumerator TriggerBattleTestEvent()
    {
        isEventDialogueClosed = false;
        string eventString1 = "A cojo' voi combatte? o sei 'na pussy";

        string[] message = { eventString1 };

        dialogue.TriggerSmallInteractiveDialogue(message);

        StartCoroutine(ResponseUpdater(true));
        yield return new WaitUntil(() => response[1] == 1);

        if(response[0] == 1) // risponde si
        {
            terri = 2; // assegnazione territorio di battaglia 
            makeEnemyForEvent(20, 1, 5, 5, 10, 1); // creazione esercito nemico
            FindObjectOfType<PrepBattaglia>().AvvioPreparazione(terri);

            yield return new WaitUntil(() => finishedBattle == true);
        }
        isEventDialogueClosed = true;
        yield return new WaitForSeconds(1.5f);
    }


    // evento 14
    IEnumerator TriggerWoodsElvesEvent()
    {
        isEventDialogueClosed = false;
        woodsElves = 1;
        float woodsElvesValue = Random.Range(0f, 1f); // probabilita di verifica evento battaglia
        woodsElvesValue = 0.1f;
        string eventString1 = "A man visits your city and asks to be helped.";
        string eventString2 = "He claims he has been mugged by a group of Elves of the Woods and asks for help in the name of Aemis.";
        string eventString3 = "He wants you to organize an expedition in the Far Lands.";
        string eventString4 = "Are you willing to help this man?\n[The expedition has no cost]";

        string[] message = { eventString1, eventString2, eventString3, eventString4 };

        dialogue.TriggerSmallInteractiveDialogue(message);

        StartCoroutine(ResponseUpdater(true));
        yield return new WaitUntil(() => response[1] == 1);

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

                    dialogue.TriggerDialogue(message2);

                    player.setRapidMoney(300);
                }
                else // sconfitta di qualsiasi tipo
                {
                    string eventString5 = "Your expedition comes back.";
                    string eventString6 = "The Captain explains that the Elves were numerous and fought harder than expected.";
                    string eventString7 = "The expedition had to retire back to "+ FindObjectOfType<Game>().CityNameUI.text +" to reduce losses.";
                    //string eventString8 = "["+swordsmen.getMomentDeadSwordman() + " swordsmen, " + archers.getMomentDeadArcher() + " archers and " + riders.getMomentDeadRider() + " riders didn't came back]";

                    string[] message2 = { eventString5, eventString6, eventString7};

                    dialogue.TriggerDialogue(message2);
                }
            }
            else
            {
                string eventString5 = "Your expedition comes back earlier than expected.";
                string eventString6 = "The Captain explains that the Elves surrended the moment after he claimed to be there in the name of " + FindObjectOfType<Game>().CityNameUI.text + ".";
                string eventString7 = "The Elves returned the man's belongings.\nThe man wants to thank your kindness and help by donating part of his belongings.";
                string eventString8 = "[You obtain 300 gold worth of goods]";

                string[] message2 = { eventString5, eventString6, eventString7, eventString8 };

                dialogue.TriggerDialogue(message2);

                player.setRapidMoney(300);
            }

        }
        else
        {
            aemisFaith--;
        }
        isEventDialogueClosed = true;
        yield return new WaitForSeconds(1.5f);
    }

    IEnumerator TriggerTheCelestialEvent()
    {
        isEventDialogueClosed = false;
        theCelestialEvent = 1;

        string eventString1 = "A Celestial, along with a large group of knights, visits your city.";
        string eventString2 = "The Celestial asks your defenses to lower their weapons and you to give them gifts and golds in the name of the Aemis' cult.";
        string eventString3 = "They do not intend to accept a refusal.";
        string eventString4 = "Are you willing to proceed on behalf of the Aemis' cult?\n[You will give them half of your gold]";

        string[] message = { eventString1, eventString2, eventString3, eventString4 };

        dialogue.TriggerSmallInteractiveDialogue(message);

        StartCoroutine(ResponseUpdater(true));
        yield return new WaitUntil(() => response[1] == 1);

        if (response[0] == 1) // risponde si
        {
            player.setRapidMoney(-(int)((player.getMoney()) / 2));
            player.setPopulation((player.getPopulation()-40)<0 ? 0 : (player.getPopulation()-40));

            aemisFaith = 0;

            string eventString5 = "Whilist half of your possessions are being managed, a group of proud citizens rise up against the Celestial's army.";
            string eventString6 = "Your reassuring words are ignored as all of them are being slaughtered by the army.";
            string eventString7 = "Minutes later the Celestial and their army take leave.";
            string eventString8 = "[You lost 40 citizens]";

            string[] message2 = { eventString5, eventString6, eventString7, eventString8 };

            dialogue.TriggerDialogue(message2);
        }
        else
        {
            terri = 1;
            makeEnemyForEvent(70, 2, 40, 20, 10, 4);
            FindObjectOfType<PrepBattaglia>().AvvioPreparazione(terri);

            yield return new WaitUntil(() => finishedBattle == true);

            if(lastBattleInfo > 2) // qualsiasi vittoria
            {
                aemisFaith -= 10;
                aemisRebel = 1;

                string eventString5 = "" + FindObjectOfType<Game>().capitanonameUI.text + " slays the Celestial as your victory quickly approaches.";
                string eventString6 = "Shortly after a tree made of pure light rapidly grows in the point where the Celestial fell.";
                string eventString7 = "[The knights' belongings, worth 5000 gold, are now yours]";

                string[] message2 = { eventString5, eventString6, eventString7 };

                dialogue.TriggerDialogue(message2);
            }
            else
            {
                player.setRapidMoney(-player.getMoney());
                swordsmen.setRapidTotal(-swordsmen.getTotal());
                archers.setRapidTotal(-archers.getTotal());
                riders.setRapidTotal(-riders.getTotal());

                theCelestialEventMalus = 1;
                theCelestialEventMalusTurnsLeft = 3;

                string eventString5 = "Shortly after your loss, the Celestial and their fellows raid the city.";
                string eventString6 = "All of your possessions are lost and the remaining soldiers became slaves.";
                string eventString7 = "[Your gold stock has been emptied, your entire army is lost and for three seasons the gold income from the Farm and the Mine is halved]";

                string[] message2 = { eventString5, eventString6, eventString7 };

                dialogue.TriggerDialogue(message2);
            }
        }
        isEventDialogueClosed = true;
        yield return null;
    }


    // evento 4
    public int event4 = 0;
    public int eventSecondary2 = 0;
    public int bonusTurns = 0;
    

    IEnumerator TriggerEvent4()
    {
        isEventDialogueClosed = false;
        event4 = 1;

        string eventString1 = "a";
        string eventString2 = "b";
        string eventString3 = "c";
        string eventString4 = "d";

        string[] message = { eventString1, eventString2, eventString3, eventString4 };

        dialogue.TriggerInteractiveDialogue(message);
        
        StartCoroutine(ResponseUpdater(false));
        yield return new WaitUntil(() => response[1] == 1);
        
        if (response[0] == 1)
        {
            
            player.setRapidMoney(-500);
            bonusTurns = 5;
            aemisFaith++;
        }
        else
        {
            if (Random.Range(0f, 1f) <= 0.2f)
            { 
                attendingSecondaryEvent = true;
                aemisFaith--;
                eventSecondary2 = 1;
                secondaryEventTurnsLeft = 1;
            }
        }
        isEventDialogueClosed = true;
        yield return new WaitForSeconds(1.5f);
    }

    //eveto secondario 2
    IEnumerator SecondaryEvent2()
    {
        
        isEventDialogueClosed = false;
        eventSecondary2 = 0;

        string eventString1 = "a1";
        string eventString2 = "a2";
        string eventString3 = "a3";
        string eventString4 = "a4";

        string[] message = { eventString1, eventString2, eventString3, eventString4 };

        dialogue.TriggerInteractiveDialogue(message);

        StartCoroutine(ResponseUpdater(false));
        yield return new WaitUntil(() => response[1] == 1);

        if (response[0] == 1)
        {
           aemisFaith++;
        }
        else
        {
            aemisFaith -= 3;
        }

        
        isEventDialogueClosed = true;
        
    }
}

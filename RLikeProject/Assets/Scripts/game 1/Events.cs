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

    public void setPlayer(Player player) { this.player = player; }
    public Player getPlayer() { return this.player;  }
    public void setSwordsmen(Soldiers.Swordsmen swordsmen) { this.swordsmen = swordsmen; }
    public Soldiers.Swordsmen getSwordsmen() { return this.swordsmen; }
    public void setArchers (Soldiers.Archers archers) { this.archers = archers; }
    public Soldiers.Archers getArchers() { return this.archers; }
    public void setRiders(Soldiers.Riders riders) { this.riders = riders; }
    public Soldiers.Riders getRiders() { return this.riders; }
    public void setFattoria(Fattoria fattoria) { this.fattoria = fattoria; }
    public Fattoria getFattoria() { return this.fattoria; }
    public void setMiniera(Miniera miniera) { this.miniera = miniera; }
    public Miniera getMiniera() { return this.miniera; }
    public void setCaserma(Caserma caserma) { this.caserma = caserma; }
    public Caserma getCaserma() { return this.caserma; }
    public void setFabbro(Fabbro fabbro) { this.fabbro = fabbro; }
    public Fabbro getFabbro() { return this.fabbro; }
    public void setGilda(Gilda gilda) { this.gilda = gilda; }
    public Gilda getGilda() { return this.gilda; }



    /* oggetto per sostiuzione immagine */
    LoadImage LoadImage = new LoadImage();

    /* variabile di controllo risposta avvenuta decisione giocatore, [0] contenente la risposta (0 o 1), [1] contenente l'avvenuto check (1 se si, 0 altrimenti) */
    public int[] response = new int[2];

    /* variabile controllo fine evento */
    public bool isEventDialogueClosed = true;

    //Dialogue dialogue = new Dialogue();

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

    /* variabili generali */
    public int aqueduct = 0;

    public int elvesEnemy = 0;
    public int forestDiplomacy = 0;

    public int ancientGreenJewel = 0;
    public int blackCrystal = 0;

    public int uominiErranti = 0;


    public void makeEnemyForEvent(int livello, int swordsmen, string swordsmenAlias, string swordsmenAliasSingular, int archers, string archersAlias, string archersAliasSingular, int riders, string ridersAlias, string ridersAliasSingular, int lvlCapitano)
    {
        FindObjectOfType<Game>().makeEnemy(livello, swordsmen, swordsmenAlias, swordsmenAliasSingular, archers, archersAlias, archersAliasSingular, riders, ridersAlias, ridersAliasSingular, lvlCapitano);
    }

    public void makeEnemyForEvent(int livello, int swordsmen, int archers, int riders, int lvlCapitano)
    {
        FindObjectOfType<Game>().makeEnemy(livello, swordsmen, "swordsmen", "swordsman", archers, "archers", "archer", riders, "riders", "rider", lvlCapitano);
    }

    public void onPressCloseVictoryDefeatPanel()
    {
        finishedBattle = true;
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
    }

    public void InitializeEvents()
    {
        this.player = FindObjectOfType<Game>().getPlayer();
        this.fattoria = FindObjectOfType<Game>().getFattoria();
        this.miniera = FindObjectOfType<Game>().getMiniera();
        this.caserma = FindObjectOfType<Game>().getCaserma();
        this.fabbro = FindObjectOfType<Game>().getFabbro();
        this.gilda = FindObjectOfType<Game>().getGilda();
        this.swordsmen = FindObjectOfType<Game>().swordsmen;
        this.archers = FindObjectOfType<Game>().archers;
        this.riders = FindObjectOfType<Game>().riders;
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
        if (secondaryEvent1TurnsLeft > 0) secondaryEvent1TurnsLeft--;
        if (secondaryEvent2TurnsLeft > 0) secondaryEvent2TurnsLeft--;
        if (secondaryEvent3TurnsLeft > 0) secondaryEvent3TurnsLeft--;
        if (secondaryEvent4TurnsLeft > 0) secondaryEvent4TurnsLeft--;
    }

    public void MaxCitizensEffects()
    {

    }
    public int GoldMalusEffects()
    {
        goldMalus1 = 0; goldMalus2 = 0; goldMalus3 = 0; goldMalus4 = 0; goldMalus5 = 0; 
        goldMalus6 = 0; goldMalus7 = 0; goldMalus8 = 0; goldMalus9 = 0; goldMalus10 = 0;

        if (event12MalusTurnsLeft > 0 && event12Malus == 1)
        {
            goldMalus1 = (int)(fattoria.getGoldFattoria() / 2) + (int)(miniera.getgoldMiniera() / 2);
            event12MalusTurnsLeft--;
        }
        if (event4BonusTurnsLeft > 0)
        {
            goldMalus2 = -((int)(fattoria.getGoldFattoria() / 2) + (int)(miniera.getgoldMiniera() / 2));
            event4BonusTurnsLeft--;
        }
        if (event7MalusTurnsLeft > 0)
        {
            goldMalus3 = (int)(miniera.getgoldMiniera());
            event7MalusTurnsLeft--;
        }
        if (secondaryEvent3MalusEffectGoldTurnsLeft > 0)
        {
            goldMalus4 = (int)(fattoria.getGoldFattoria());
            secondaryEvent3MalusEffectGoldTurnsLeft--;
        }
        if (secondaryEvent3MalusEffectGoldTurnsLeftMINE > 0)
        {
            goldMalus5 = (int)(miniera.getgoldMiniera());
            secondaryEvent3MalusEffectGoldTurnsLeftMINE--;
        }
        if (event15MalusTurnsLeft > 0)
        {
            goldMalus6 = (int)(0.3f * (float)miniera.getgoldMiniera());
            event15MalusTurnsLeft--;
        }
        if (event9BonusTurnsLeft > 0)
        {
            goldMalus7 = -100;
        }
        if (event2MalusTurnsLeft > 0)
        {
            goldMalus8 = fattoria.getGoldFattoria();
            event2MalusTurnsLeft--;
        }
        if (event27MalusTurnsLeft > 0)
        {
            goldMalus9 = -(fattoria.getGoldFattoria() * 4);
            event27MalusTurnsLeft--;
        }
        if (event30MalusTurnsLeft > 0)
        {
            goldMalus10 = -(int)(0.4f * (float)fattoria.getGoldFattoria());
            event30MalusTurnsLeft--;
        }

        return goldMalus1 + goldMalus2 + goldMalus3 + goldMalus4 + goldMalus5 + goldMalus6 + goldMalus7 + goldMalus8 + goldMalus9 + goldMalus10;
    }
    public int CitizensMalusEffects()
    {
        citizensMalus1 = 0; citizensMalus2 = 0; citizensMalus3 = 0; citizensMalus4 = 0; citizensMalus5 = 0;
        citizensMalus6 = 0; citizensMalus7 = 0; citizensMalus8 = 0; citizensMalus9 = 0; citizensMalus10 = 0;

        if (secondaryEvent1MalusTurnsLeft > 0 && secondaryEvent1Malus == 1)
        {
            citizensMalus1 = (int)(0.4f * (float)fattoria.getCrescitaAbitanti()); // -40% popolazione
            secondaryEvent1MalusTurnsLeft--;
        }
        if (secondaryEvent3MalusEffectCitizensTurnsLeft > 0)
        {
            citizensMalus2 = fattoria.getCrescitaAbitanti();
            secondaryEvent3MalusEffectCitizensTurnsLeft--;
        }
        if (event17MalusTurnsLeft > 0 )
        {
            citizensMalus3 = (int)(0.5f * (float)fattoria.getCrescitaAbitanti()); // -50% crescita abitanti
            event17MalusTurnsLeft--;
        }
        if (event21MalusTurnsLeft > 0)
        {
            citizensMalus4 = fattoria.getCrescitaAbitanti(); // -100% crescita abitanti
            event21MalusTurnsLeft--;
        }
        //if (bonusCitizens)
        //{
        //    player.setTempCitizens(30*(Random.Range(1,5))); // +30 cittadini * random(1-4)

        //    bonusCitizens = false;
        //}
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

        response[1] = 0;
        bool skippingEventForOverlap = false;
        if (secondaryEvent1 == 1 && secondaryEvent1TurnsLeft == 0 && !skippingEventForOverlap)
        {
            secondaryEvent1Malus = 1;

            secondaryEvent1 = 0;
            attendingSecondaryEvent = false;
            secondaryEvent1MalusTurnsLeft = 3;

            string eventString1 = "The lack of drinking water caused a reduction of newborns.\n[-40% New Citizens each season, for 3 seasons]";

            string[] message = { eventString1 };

            Dialogue.TriggerDialogue(message);


            skippingEventForOverlap = true;
        }
        if (secondaryEvent2 == 1 && secondaryEvent2TurnsLeft == 0 && !skippingEventForOverlap)
        {
            StartCoroutine(SecondaryEvent2());
            skippingEventForOverlap = true;
        }
        if(secondaryEvent3 == 1 && secondaryEvent3TurnsLeft == 0 && !skippingEventForOverlap)
        {
            StartCoroutine(SecondaryEvent3());
            skippingEventForOverlap = true;
        }
        if(secondaryEvent4 == 1 && secondaryEvent4TurnsLeft == 0 && !skippingEventForOverlap)
        {
            StartCoroutine(SecondaryEvent4());
            skippingEventForOverlap = true;
        }
    }

    private bool hasEnoughSoldiers(int cap) // se il giocatore non ha abbastanza soldati a coppie di tipi, basato su un valore che va superato per ogni tipo
    {
        return ((swordsmen.getTotal() + archers.getTotal() >= cap)       // se cap = 10 ho bisogno di almeno 10 soldati tra swordsmen e archers
                || (swordsmen.getTotal() + riders.getTotal() >= cap)
                || (riders.getTotal() + archers.getTotal() >= cap));
    }
    /* avviatore eventi, la funzione sceglie un evento casuale e non gia' avvenuto sulla base di alcuni criteri */
    public void EventStarter()
    {
        finishedBattle = false;

        response[1] = 0;


        float eventChooser = 0;
        bool selected = false;

        while (!selected && !attendingSecondaryEvent)
        {
            isEventDialogueClosed = false;
            eventChooser = Random.Range(0f, 10f);

            eventChooser = 24f;
            blackCrystal = 1;

            //eventChooser = 0.4f; // debug evento testbattaglia

            if (eventChooser >= 0 && eventChooser < 1f) // classificazione eventi fondamentali o di poca importanza, per ordine di importanza
            {
                if (event1 == 0 && player.getMoney() >= 400) // evento non avviabile qualora il giocatore non abbia i fondi necessari
                {
                    StartCoroutine(TriggerEvent1());
                    selected = true;
                }
                else if (event3 == 0 && player.getMoney() >= 1000) // evento non avviabile qualora il giocatore non abbia i fondi necessari
                {
                    StartCoroutine(TriggerEvent3());
                    selected = true;
                }
            }
            if (eventChooser >= 1f && eventChooser < 2f)
            {
                StartCoroutine(TriggerBattleTestEvent());
                selected = true;
            }
            if (eventChooser >= 2f && eventChooser < 3f && hasEnoughSoldiers(7) && event14 == 0) // se non hai soldati...
            {
                StartCoroutine(TriggerEvent14());
                selected = true;
            }
            if (eventChooser >= 3f && eventChooser < 4f && aemisFaith <= 4 && aemisKnightsHostility == 1 && hasEnoughSoldiers(10) && event12 == 0) // il giocatore deve affrontare una grande battaglia, deve avere una minima chance
            {
                StartCoroutine(TriggerEvent12());
                selected = true;
            }
            if (eventChooser >= 4f && eventChooser < 5f && player.getMoney() >= 500 && event4 == 0) // almeno 500 gold per farlo
            {
                StartCoroutine(TriggerEvent4());
                selected = true;
            }
            if (eventChooser >= 5f && eventChooser < 6f && hasEnoughSoldiers(10) && event5 == 0) // una possibile grande battaglia attende il giocatore, deve avere una minima chance
            {
                StartCoroutine(TriggerEvent5());
                selected = true;
            }
            if (eventChooser >= 6f && eventChooser < 7f && event6 == 0)
            {
                StartCoroutine(TriggerEvent6());
                selected = true;
            }
            if(eventChooser >= 7f && eventChooser < 8f && player.getMoney() >= 300 && event7 == 0)
            {
                StartCoroutine(TriggerEvent7());
                selected = true;
            }
            if (eventChooser >= 8f && eventChooser < 9f && hasEnoughSoldiers(15) && event8 == 0) // una possibile grande battaglia attende il giocatore, deve avere una minima chance
            {
                StartCoroutine(TriggerEvent8());
                selected = true;
            }
            if (eventChooser >= 9f && eventChooser < 10f && player.getMoney() >= 100 && event11 == 0) 
            {
                StartCoroutine(TriggerEvent11());
                selected = true;
            }
            if (eventChooser >= 10f && eventChooser < 11f && player.getMoney() >= 1000 && event13 == 0) 
            {
                StartCoroutine(TriggerEvent13());
                selected = true;
            }
            if (eventChooser >= 11f && eventChooser < 12f && aemisFaith <= 2 && player.getMoney() >= 400 && event15 == 0) 
            {
                StartCoroutine(TriggerEvent15());
                selected = true;
            }
            if (eventChooser >= 12f && eventChooser < 13f && event16 == 0) 
            {
                StartCoroutine(TriggerEvent16());
                selected = true;
            }
            if (eventChooser >= 13f && eventChooser < 14f && player.bonusWall == 0 && player.getMoney() >= 500 && event17 == 0) 
            {
                StartCoroutine(TriggerEvent17());
                selected = true;
            }
            if (eventChooser >= 14f && eventChooser < 15f && player.getMoney() >= 1000 && event18 == 0) 
            {
                StartCoroutine(TriggerEvent18());
                selected = true;
            }
            if (eventChooser >= 15f && eventChooser < 16f && event2 == 0)
            {
                StartCoroutine(TriggerEvent2());
                selected = true;
            }
            if (eventChooser >= 16f && eventChooser < 17f && event9 == 0)
            {
                StartCoroutine(TriggerEvent9());
                selected = true;
            }
            if (eventChooser >= 17f && eventChooser < 18f && event10 == 0)
            {
                StartCoroutine(TriggerEvent10());
                selected = true;
            }
            if (eventChooser >= 18f && eventChooser < 19f && event19 == 0)
            {
                StartCoroutine(TriggerEvent19());
                selected = true;
            }
            if(eventChooser >= 19f && eventChooser < 20f && aemisFaith < 6 && event20 == 0)
            {
                StartCoroutine(TriggerEvent20());
                selected = true;
            }
            if (eventChooser >= 20f && eventChooser < 21f && player.getMoney() >= 400 && event1 == 1 && event21 == 0 && aqueduct == 0)
            {
                StartCoroutine(TriggerEvent21());
                selected = true;
            }
            if (eventChooser >= 21f && eventChooser < 22f && event23 == 0)
            {
                StartCoroutine(TriggerEvent23());
                selected = true;
            }
            if (eventChooser >= 22f && eventChooser < 23f && player.getMoney() >= 1000 && event27 == 0)
            {
                StartCoroutine(TriggerEvent27());
                selected = true;
            }
            if (eventChooser >= 23f && eventChooser < 24f && event30 == 0)
            {
                StartCoroutine(TriggerEvent30());
                selected = true;
            }
            if (eventChooser >= 24f && eventChooser < 25f && event22 == 0 && blackCrystal == 1)
            {
                StartCoroutine(TriggerEvent22());
                selected = true;
            }

            else
            {
                selected = true;
            }
            //selected = true; //per la forzatura dell'evento

        }

    }

    /////////////////////////////////////////* EVENTI *///////////////////////////////////////////////////
    /* evento primario aquedotto */
    public int event1 = 0; // 1 se verificato 0 altrimenti
    public int secondaryEvent1 = 0; // evento secondario annesso, 1 se verificato 0 altrimenti
    public int secondaryEvent1TurnsLeft = 99; // turni da attendere affinche si verifichi evento secondario annesso
    public int secondaryEvent1Malus = 0; // applicazione malus di evento secondario, 1 se applicato, 0 altrimenti
    public int secondaryEvent1MalusTurnsLeft = 99; // turni durata malus di evento secondario


    IEnumerator TriggerEvent1()
    {
        event1 = 1;
        float secondaryEventProbability = Random.Range(0f, 1f); // probabilita di verifica evento secondario
        secondaryEventProbability = 0.5f;
        string eventString1 = "A certain group of citizens complains about the lack of drinking water.";
        string eventString2 = "They would like you to finance a new aqueduct in the city.";
        string eventString3 = "Are you accepting their request?\n[Cost: 400 Gold]";

        string[] message = { eventString1, eventString2, eventString3 };

        Dialogue.TriggerSmallInteractiveDialogue(message);

        StartCoroutine(ResponseUpdater(true));
        yield return new WaitUntil(() => response[1] == 1);


        if (response[0] == 1)
        {
            player.setRapidMoney(-400);
            aqueduct = 1;
        }
        else if (secondaryEventProbability > 0.5f)
        {
            attendingSecondaryEvent = true;
            secondaryEvent1 = 1;
            secondaryEvent1TurnsLeft = 4;
            secondaryEvent1Malus = 1;
        }
        yield return new WaitForSeconds(1f);
        isEventDialogueClosed = true;
    }

    /* evento primario aumento delle difese della citta' */
    public int event3 = 0;
    IEnumerator TriggerEvent3()
    {
        event3 = 1;

        string eventString1 = "A local artisan proposes a city reinforcement project.";
        string eventString2 = "The project forsees an extra woodden palisade on the fields around the city, a ...";
        string eventString3 = "... bunch of woodden lookout turrets, and paid guards in every single road that gives access to the city.";
        string eventString4 = "Would you like to finance this project?\n[Cost: 1000 Gold]";

        string[] message = { eventString1, eventString2, eventString3, eventString4 };

        Dialogue.TriggerSmallInteractiveDialogue(message);

        StartCoroutine(ResponseUpdater(true));
        yield return new WaitUntil(() => response[1] == 1);

        if (response[0] == 1)
        {
            player.setRapidMoney(-1000);
            player.bonusWall += 0.2f;
        }
        
        yield return new WaitForSeconds(1f);
        isEventDialogueClosed = true;
    }

    IEnumerator TriggerBattleTestEvent()
    {
        string eventString1 = "A cojo' voi combatte? o sei 'na pussy";

        string[] message = { eventString1 };

        Dialogue.TriggerSmallInteractiveDialogue(message);

        StartCoroutine(ResponseUpdater(true));
        yield return new WaitUntil(() => response[1] == 1);

        if(response[0] == 1) // risponde si
        {
            terri = 2; // assegnazione territorio di battaglia 
            makeEnemyForEvent(1, 5, 5, 10, 1); // creazione esercito nemico
            FindObjectOfType<PrepBattaglia>().AvvioPreparazione(terri);

            yield return new WaitUntil(() => finishedBattle == true);
        }
        yield return new WaitForSeconds(1f);
        isEventDialogueClosed = true;
    }


    // evento furto degli elfi dei boschi
    public int event14 = 0;

    IEnumerator TriggerEvent14()
    {
        event14 = 1;
        float woodsElvesValue = Random.Range(0f, 1f); // probabilita di verifica evento battaglia
        woodsElvesValue = 0.1f;
        string eventString1 = "A man visits your city and asks to be helped.";
        string eventString2 = "He claims he has been mugged by a group of Elves of the Woods and asks for help in the name of Aemis.";
        string eventString3 = "He wants you to organize an expedition in the Far Lands.";
        string eventString4 = "Are you willing to help this man?\n[The expedition has no cost]";

        string[] message = { eventString1, eventString2, eventString3, eventString4 };

        Dialogue.TriggerSmallInteractiveDialogue(message);

        StartCoroutine(ResponseUpdater(true));
        yield return new WaitUntil(() => response[1] == 1);

        if (response[0] == 1) // il giocatore risponde si
        {
            elvesEnemy = 1; // variabile 'nemicoElfi'
            aemisFaith++;
            if (woodsElvesValue < 0.9f) // 90% di possibilita che si verifichi evento battaglia
            {
                terri = 3; // assegnazione territorio di battaglia 
                int EventEswordsmen = 5 * Random.Range(1, 4);
                int EventEarchers = 3 * Random.Range(1, 3);
                int EventEriders = 0;
                makeEnemyForEvent(1, EventEswordsmen, EventEarchers, EventEriders, 1); // creazione esercito nemico
                FindObjectOfType<PrepBattaglia>().AvvioPreparazione(terri);

                yield return new WaitUntil(() => finishedBattle == true); 

                if(lastBattleInfo > 2) // vittoria di qualsiasi tipo
                {
                    string eventString5 = "Your expedition comes back.";
                    string eventString6 = "The Captain explains that the Elves fought long and hard before dying.";
                    string eventString7 = "The man's belongings have been retrieved and returned.\nThe man wants to thank your kindness and help by donating part of his belongings.";
                    string eventString8 = "[You obtain 300 Gold worth of goods]";

                    string[] message2 = { eventString5, eventString6, eventString7, eventString8 };

                    Dialogue.TriggerDialogue(message2);

                    player.setRapidMoney(300);
                }
                else // sconfitta di qualsiasi tipo
                {
                    string eventString5 = "Your expedition comes back.";
                    string eventString6 = "The Captain explains that the Elves were numerous and fought harder than expected.";
                    string eventString7 = "The expedition had to retire back to "+ FindObjectOfType<Game>().CityNameUI.text +" to reduce losses.";
                    //string eventString8 = "["+swordsmen.getMomentDeadSwordman() + " swordsmen, " + archers.getMomentDeadArcher() + " archers and " + riders.getMomentDeadRider() + " riders didn't came back]";

                    string[] message2 = { eventString5, eventString6, eventString7};

                    Dialogue.TriggerDialogue(message2);
                }
            }
            else
            {
                string eventString5 = "Your expedition comes back earlier than expected.";
                string eventString6 = "The Captain explains that the Elves surrended the moment after he claimed to be there in the name of " + FindObjectOfType<Game>().CityNameUI.text + ".";
                string eventString7 = "The Elves returned the man's belongings.\nThe man wants to thank your kindness and help by donating part of his belongings.";
                string eventString8 = "[You obtain 300 Gold worth of goods]";

                string[] message2 = { eventString5, eventString6, eventString7, eventString8 };

                Dialogue.TriggerDialogue(message2);

                player.setRapidMoney(300);
            }

        }
        else
        {
            aemisFaith--;
        }
        isEventDialogueClosed = true;
        yield return new WaitForSeconds(1f);
    }

    /////* evento celestiale e cavalieri */////
    public int event12 = 0;
    public int event12Malus = 0;
    public int event12MalusTurnsLeft = 0;

    IEnumerator TriggerEvent12()
    {
        event12 = 1;

        string eventString1 = "A Celestial, along with a large group of knights, visits your city.";
        string eventString2 = "The Celestial asks your defenses to lower their weapons and you to give them gifts and golds in the name of the Aemis' cult.";
        string eventString3 = "They do not intend to accept a refusal.";
        string eventString4 = "Are you willing to proceed on behalf of the Aemis' cult?\n[You will give them half of your gold]";

        string[] message = { eventString1, eventString2, eventString3, eventString4 };

        Dialogue.TriggerSmallInteractiveDialogue(message);

        StartCoroutine(ResponseUpdater(true));
        yield return new WaitUntil(() => response[1] == 1);

        if (response[0] == 1) // risponde si
        {
            player.setRapidMoney(-(int)((player.getMoney()) / 2));
            player.setRapidCitizens(-40);

            aemisFaith = 0;

            string eventString5 = "Whilist half of your possessions are being managed, a group of proud citizens rise up against the Celestial's army.";
            string eventString6 = "Your reassuring words are ignored as all of them are being slaughtered by the army.";
            string eventString7 = "Minutes later the Celestial and their army take leave.";
            string eventString8 = "[You lost 40 citizens]";

            string[] message2 = { eventString5, eventString6, eventString7, eventString8 };

            Dialogue.TriggerDialogue(message2);
        }
        else
        {
            terri = 1;
            makeEnemyForEvent(2, 40, 20, 10, 4);
            FindObjectOfType<PrepBattaglia>().AvvioPreparazione(terri);

            yield return new WaitUntil(() => finishedBattle == true);

            if(lastBattleInfo > 2) // qualsiasi vittoria
            {
                aemisFaith -= 10;
                aemisRebel = 1;

                string eventString5 = "" + FindObjectOfType<Game>().capitanonameUI.text + " slays the Celestial as your victory quickly approaches.";
                string eventString6 = "Shortly after a tree made of pure light rapidly grows in the point where the Celestial fell.";
                string eventString7 = "[The knights' belongings, worth 5000 Gold, are now yours]";

                string[] message2 = { eventString5, eventString6, eventString7 };

                Dialogue.TriggerDialogue(message2);

                player.setRapidMoney(5000);
            }
            else
            {
                player.setRapidMoney(-player.getMoney());
                swordsmen.setRapidTotal(-swordsmen.getTotal());
                archers.setRapidTotal(-archers.getTotal());
                riders.setRapidTotal(-riders.getTotal());

                event12Malus = 1;
                event12MalusTurnsLeft = 3;

                string eventString5 = "Shortly after your loss, the Celestial and their fellows raid the city.";
                string eventString6 = "All of your possessions are lost and the remaining soldiers became slaves.";
                string eventString7 = "[Your gold stock has been emptied, your entire army is lost and for three seasons the gold income from the Farm and the Mine is halved]";

                string[] message2 = { eventString5, eventString6, eventString7 };

                Dialogue.TriggerDialogue(message2);
            }
        }
        isEventDialogueClosed = true;
        yield return new WaitForSeconds(1f);
    }


    // evento rito dell'accensione
    public int event4 = 0;
    public int event4BonusTurnsLeft = 0;
    public int secondaryEvent2 = 0;
    public int secondaryEvent2TurnsLeft = 99;
    

    IEnumerator TriggerEvent4()
    {
        event4 = 1;

        string eventString1 = "A local priest asks fundings for the organization of this year's 'Lighting Fest' due to their lack of donation to the temple.";
        string eventString2 = "Are you offering your help?\n[You will spend 500 Gold]";

        string[] message = { eventString1, eventString2 };

        Dialogue.TriggerInteractiveDialogue(message);
        
        StartCoroutine(ResponseUpdater(false));
        yield return new WaitUntil(() => response[1] == 1);
        
        if (response[0] == 1)
        {
            player.setRapidMoney(-500);
            event4BonusTurnsLeft = 5;
            aemisFaith++;
        }
        else
        {
            if (Random.Range(0f, 1f) <= 0.2f)
            { 
                attendingSecondaryEvent = true;
                aemisFaith--;
                secondaryEvent2 = 1;
                secondaryEvent2TurnsLeft = 1;
            }
        }
        yield return new WaitForSeconds(1f);
        isEventDialogueClosed = true;
    }

    //evento secondario 2 - senza la festa dell'accensione i sacerdoti predicano sventura 
    IEnumerator SecondaryEvent2()
    {
        secondaryEvent2 = 0;

        string eventString1 = "Without the 'Lighting Fest' happening, your citizen's faith lowers.";
        string eventString2 = "To achieve interest again, all the local priests are forced to preach misfortune to those who won't partecipate to their cult.";
        string eventString3 = "A group of citizens is seeing the problem as they ask you to do something about it.";
        string eventString4 = "Are you willing to help your population?";

        string[] message = { eventString1, eventString2, eventString3, eventString4 };

        Dialogue.TriggerInteractiveDialogue(message);

        StartCoroutine(ResponseUpdater(false));
        yield return new WaitUntil(() => response[1] == 1);

        if (response[0] == 1)
        {
            aemisFaith -= 3;
        }
        else
        {
            aemisFaith++;
        }
        yield return new WaitForSeconds(1f);
        isEventDialogueClosed = true;
    }


    //evento5 - evento fulmine che colpisce la citta'. Incendio e presagio di sventura se non si combatte con i demoni oscuri

    public int event5 = 0;


    IEnumerator TriggerEvent5()
    {
        event5 = 1;

        string eventString1 = "A lightning falls inside your city and a fire begins to burn plenty of buildings and houses.";
        string eventString2 = "Lots of citizens lost their houses and the Aemis cult treats the event as a sign of bad omen.";
        string eventString3 = "The cult suggests to take action against the demons towards the far lands.";
        string eventString4 = "Are you willing to organize an expedition towards the far lands?\n[The expedition has no cost]";

        string[] message = { eventString1, eventString2, eventString3, eventString4 };

        Dialogue.TriggerInteractiveDialogue(message);

        StartCoroutine(ResponseUpdater(false));
        yield return new WaitUntil(() => response[1] == 1);

        // riguardo la fine, : 1 sconfitta grave, 2 sconfitta, 3 vittoria, 4 vittoria decisiva

        if (response[0] == 1) // risponde si
        {
            if(Random.Range(0f,1f)<= 0.7f) 
            { 
                terri = 3; // assegnazione territorio di battaglia 
                makeEnemyForEvent(1, 10, 3, 0, 1); // creazione esercito nemico
                FindObjectOfType<PrepBattaglia>().AvvioPreparazione(terri);

                yield return new WaitUntil(() => finishedBattle == true);

                if(lastBattleInfo > 2)
                {
                    string eventString5 = "Days later the expedition comes back with good news.";
                    string eventString6 = "The demons have been killed and the Aemis cult gives reassuring words to the people of the city.";

                    string[] message2 = { eventString5, eventString6 };

                    Dialogue.TriggerDialogue(message2);

                    aemisFaith += 2;
                }
                else
                {
                    string eventString5 = "Days later the expedition comes back with bad news.";
                    string eventString6 = "The demons had the upper hand on your soldiers. They retired in fear back to the city.";
                    string eventString7 = "The Aemis cult, however, appreciated your attempt.";

                    string[] message2 = { eventString5, eventString6, eventString7 };

                    Dialogue.TriggerDialogue(message2);

                    aemisFaith++;
                }
            }
            else
            {
                terri = 4; // assegnazione territorio di battaglia 
                makeEnemyForEvent(1, (5*(player.getTurn()/2)), (3*(player.getTurn()/2)), 0, 1); // creazione esercito nemico
                FindObjectOfType<PrepBattaglia>().AvvioPreparazione(terri);

                yield return new WaitUntil(() => finishedBattle == true);

                if(lastBattleInfo > 2)
                {
                    string eventString5 = "Days later the expedition comes back with good news.";
                    string eventString6 = "Even if your soldiers had to move to the Demoniac Lands to fight the demons, they had the upper hand.";
                    string eventString7 = "The Aemis cult is thankful for your help and gives reassuring words to the people of your city.";

                    string[] message2 = { eventString5, eventString6, eventString7 };

                    Dialogue.TriggerDialogue(message2);

                    aemisFaith += 2;
                }
                else
                {
                    string eventString5 = "Days later the expedition comes back with bad news.";
                    string eventString6 = "Your expedition has been trapped inside the Demoniac Lands and only a few managed to escape.";
                    string eventString7 = "The Aemis cult, however, appreciates your attempt.";

                    string[] message2 = { eventString5, eventString6, eventString7 };

                    Dialogue.TriggerDialogue(message2);

                    aemisFaith++;
                }
            }
        }
        else
        {
            string eventString5 = "Voices around your disbelief on the Aemis cult began to spread around the city.";

            string[] message2 = { eventString5 };

            Dialogue.TriggerDialogue(message2);

            aemisFaith --;
        }
        
        yield return new WaitForSeconds(1f);
        isEventDialogueClosed = true;
    }


    // evento 6 - evento dei profughi, arrivano e pretendono il diritto di asilo - se accetti e hai fortuna +300 gold, altrimenti alcuni cittadini in piu


    public int event6 = 0;

    IEnumerator TriggerEvent6()
    {
        event6 = 1;

        string eventString1 = "A group of refugee from the far lands asks for shelter in your city.";
        string eventString2 = "Are you helping them?";

        string[] message = { eventString1, eventString2 };

        Dialogue.TriggerInteractiveDialogue(message);
        
        StartCoroutine(ResponseUpdater(false));
        yield return new WaitUntil(() => response[1] == 1);
        
        if (response[0] == 1)
        {
            int porc = 15 * (Random.Range(1, 5));
            player.setRapidCitizens(porc); // + 30 per random 1-4


            if (Random.Range(0f,1f)<= 0.2f)
            {
                string eventString3 = "One of the refugees holds a great amount of possessions.";
                string eventString4 = "He decides to donate part of it to your city.\n[You obtain 300 Gold]";

                string[] message2 = { eventString3, eventString4 };

                Dialogue.TriggerDialogue(message2);
                player.setRapidMoney(300);
            }
        }

        yield return new WaitForSeconds(1f);
        isEventDialogueClosed = true;
    }

    // evento 7 - una frana blocca il passaggio alla miniera se non paghi per 3 turni non ricevi gold dalla miniera


    public int event7 = 0;
    public int event7MalusTurnsLeft = 0;

    IEnumerator TriggerEvent7()
    {
        event7 = 1;

        string eventString1 = "A landslide caused the inaccessibility to the mine and requires immediate attention.";
        string eventString2 = "Are you willing to act in this regard?\n[You will spend 300 Gold]";

        string[] message = { eventString1, eventString2 };

        Dialogue.TriggerInteractiveDialogue(message);

        StartCoroutine(ResponseUpdater(false));
        yield return new WaitUntil(() => response[1] == 1);

        if (response[0] == 1)
        {
            player.setRapidMoney(-300);
        }
        else
        {
            string eventString3 = "The landslide interrupts the miners' job for three seasons.";

            string[] message2 = { eventString3 };

            Dialogue.TriggerDialogue(message2);
            event7MalusTurnsLeft = 3;
        }

        yield return new WaitForSeconds(1f);
        isEventDialogueClosed = true;
    }


    // evento 8 - dei banditi si sono impossessati di una rotta commerciale, intervieni o no?


    public int event8 = 0;
    public int secondaryEvent3 = 0;
    public int secondaryEvent3TurnsLeft = 99;

    IEnumerator TriggerEvent8()
    {
        event8 = 1;

        float secondaryEventProbability = Random.Range(0f, 1f);
        float floatingProbability = 0.6f;

        string eventString1 = "Some bandits have taken possess of one of your trade routes and threaten raids towards your city.";
        string eventString2 = "Are you willing to act in this regard and send an expedition to punish them?\n[The expedition has no cost]";

        string[] message = { eventString1, eventString2 };

        Dialogue.TriggerInteractiveDialogue(message);

        StartCoroutine(ResponseUpdater(false));
        yield return new WaitUntil(() => response[1] == 1);

        if (response[0] == 1)
        {
            int captainLVL = Random.Range(1, 5);
            int swordsmen = 5 * Random.Range(1, 7);
            int archers = 2 * Random.Range(1, 6);
            int riders = 1 * Random.Range(1, 5);
            terri = 3;
            makeEnemyForEvent(2, swordsmen, archers, riders, captainLVL);

            FindObjectOfType<PrepBattaglia>().AvvioPreparazione(terri);

            yield return new WaitUntil(() => finishedBattle  == true);

            if(lastBattleInfo > 3)
            {
                string eventString3 = "The expedition returns victorious and the roads are now free to use.";
                string eventString4 = "Your soldiers claim that the bandits fled as were leaving behind most of their possessions.\n[You obtain 3000 Gold worth of possessions]";

                string[] message2 = { eventString3, eventString4 };

                Dialogue.TriggerDialogue(message2);

                player.setRapidMoney(3000);
            }
            else if (lastBattleInfo == 3)
            {
                string eventString3 = "The expedition returns victorious and the roads are now free to use.";
                string eventString4 = "Your soldiers claim that the bandits fled as were leaving behind some of their provisions.\n[You obtain 1000 Gold worth of provisions]";

                string[] message2 = { eventString3, eventString4 };

                Dialogue.TriggerDialogue(message2);

                player.setRapidMoney(1000);
            }
            else if (lastBattleInfo == 2)
            {
                floatingProbability = 0.1f;
            }
            else if (lastBattleInfo == 1)
            {
                floatingProbability = 0.9f;
            }
        }
        if ((secondaryEventProbability < floatingProbability && response[0] == 0) || (secondaryEventProbability < floatingProbability && (floatingProbability==0.1f || floatingProbability==0.9f)))
        {
            secondaryEvent3 = 1;
            secondaryEvent3TurnsLeft = 2;
        }

        yield return new WaitForSeconds(1f);
        isEventDialogueClosed = true;
    }

    /* evento secondario 3 - i banditi ignorati si mettono a distruggere e saccheggiare le campagne attorno alla città, il giocatore deve prendere varie decisioni sulla situazione */

    public int secondaryEvent3MalusEffectGoldTurnsLeft = 0;
    public int secondaryEvent3MalusEffectCitizensTurnsLeft = 0;
    public int secondaryEvent3MalusEffectGoldTurnsLeftMINE = 0;

    IEnumerator SecondaryEvent3()
    {
        secondaryEvent3 = 0;
        isEventDialogueClosed = false;
        bool youHaveBeenDestroyed = false;

        string eventString1 = "A group of bandits is assaulting and raiding properties outside the city.";
        string eventString2 = "Your military advisor suggests to fight them and protect your citizens.";
        string eventString3 = "Are you following his advice?";

        string[] message = { eventString1, eventString2, eventString3 };

        Dialogue.TriggerInteractiveDialogue(message);
        StartCoroutine(ResponseUpdater(false));
        yield return new WaitUntil(() => response[1] == 1);


        if (response[0] == 1)
        {
            int captainLVL = Random.Range(1, 5);
            int swordsmen = 8 * Random.Range(1, 7);
            int archers = 4 * Random.Range(1, 6);
            int riders = 2 * Random.Range(1, 5);
            terri = 2;

            makeEnemyForEvent(2, swordsmen, archers, riders, captainLVL);

            FindObjectOfType<PrepBattaglia>().AvvioPreparazione(terri);
            yield return new WaitUntil(() => finishedBattle  == true);
            
            if(lastBattleInfo > 2)
            {
                string eventString4 = "Your soldiers return victorious and the roads are now free to use.";
                string eventString5 = "They soldiers claim that the bandits fled as were leaving behind some of their provisions.\n[You obtain 1000 Gold worth of provisions]";

                string[] message2 = { eventString4, eventString5 };

                Dialogue.TriggerDialogue(message2);

                player.setRapidMoney(1000);
            }
            else if (lastBattleInfo <= 2)
            {
                string eventString4 = "Your army retires as you witness the destruction of all the fields around the city.";
                string eventString5 = "You understand that your city will need time to recover.\n[Gold income and Population growth from the Farm are momentarily reduced to zero]";

                string[] message2 = { eventString4, eventString5 };

                Dialogue.TriggerDialogue(message2);

                secondaryEvent3MalusEffectGoldTurnsLeft = 2;
                secondaryEvent3MalusEffectCitizensTurnsLeft = 2;

                if (lastBattleInfo == 1) youHaveBeenDestroyed = true; 
            }
        }
        if (response[0]==0 || youHaveBeenDestroyed)
        {
            if (response[0] == 0)
            {
                secondaryEvent3MalusEffectGoldTurnsLeft = 2;
                secondaryEvent3MalusEffectCitizensTurnsLeft = 2;

                string eventString4 = "Your army retires back to the city as you witness the destruction of all the fields around the city.";
                string eventString5 = "You understand that your city will need time to recover.\n[Gold income and Population growth from the Farm are momentarily reduced to zero]";

                string[] message2 = { eventString4, eventString5 };

                Dialogue.TriggerDialogue(message2);

                int captainLVL = Random.Range(1, 5);
                int swordsmen = 8 * Random.Range(1, 7);
                int archers = 4 * Random.Range(1, 6);
                int riders = 2 * Random.Range(1, 5);
                terri = 2;

                makeEnemyForEvent(2, swordsmen, archers, riders, captainLVL);

                yield return new WaitUntil(() => FindObjectOfType<DialogueManager>().endingdialogue == 1);
                yield return new WaitForSeconds(0.5f);
            }

            if (Random.Range(0f, 1f) < 0.5)
            {
                string eventString6 = "The Bandits started an assault towards the city.";
                string eventString7 = "You have to fight for the sake of your city.";

                string[] message3 = { eventString6, eventString7 };

                Dialogue.TriggerDialogue(message3);
                yield return new WaitUntil(() => FindObjectOfType<DialogueManager>().endingdialogue == 1);


                yield return new WaitForSeconds(0.5f);
                terri = 1;
                FindObjectOfType<PrepBattaglia>().AvvioPreparazione(terri);

                yield return new WaitUntil(() => finishedBattle  == true);

                if (lastBattleInfo < 3)
                {
                    string eventString8 = "The city is being devastated as most of your citizens are being killed and houses burned down or destroyed.";
                    string eventString9 = "The treasury has been emptied along with most of the houses.";
                    string eventString10 = "[You lost " + (int)(player.getMoney() * 0.9) + " Gold and the Citizens has been halved. The population growth and your Mine income are momentarily nullified]";

                    string[] message4 = { eventString8, eventString9, eventString10 };

                    Dialogue.TriggerDialogue(message4);

                    player.setRapidMoney(-(int)(player.getMoney() * 0.9));
                    player.setRapidCitizens(-(int)(player.getCitizens() / 2));

                    secondaryEvent3MalusEffectGoldTurnsLeftMINE = 2;
                }
            }
        }

        yield return new WaitForSeconds(1f);
        isEventDialogueClosed = true;
    }

    /* --------------------------------------------------------------------------------- *
     * --------------------------------------------------------------------------------- */

    // evento 9 - richiesta di commercio dall'ambasciatore delle creature della foresta
    
    // DA FINIRE!!

    public int event9 = 0;
    public int event9BonusTurnsLeft = 0;

    IEnumerator TriggerEvent9()
    {
        event9 = 1;

        string eventString1 = "An ambassador from the forests of the far lands arrives in the city.";
        string eventString2 = "He claims that he wants to establish a common trade route between their people and you.";
        string eventString3 = "Are you accepting this request?";

        string[] message = { eventString1, eventString2, eventString3 };

        Dialogue.TriggerInteractiveDialogue(message);

        StartCoroutine(ResponseUpdater(false));
        yield return new WaitUntil(() => response[1] == 1);

        if (response[0] == 1)
        {
            
            event9BonusTurnsLeft = 99;
            forestDiplomacy = 1;
            aemisFaith--;
        }

        yield return new WaitForSeconds(1f);
        isEventDialogueClosed = true;
    }

    /* --------------------------------------------------------------------------------- *
     * --------------------------------------------------------------------------------- */

    // evento 10 - nella miniera sono state trovate delle pietre preziose
    
    // DA FINIRE!!

    public int event10 = 0;

    IEnumerator TriggerEvent10()
    {
        event10 = 1;

        string eventString1 = "A set of stones of great rarity has been found in the mine.";
        string eventString2 = "Their exact value is hard to tell, your specialists suggest you to sell them to the nanic merchants.";
        string eventString3 = "Are you willing to do so?\n[Gold value can't be estimated]";

        string[] message = { eventString1, eventString2, eventString3 };

        Dialogue.TriggerInteractiveDialogue(message);

        StartCoroutine(ResponseUpdater(false));
        yield return new WaitUntil(() => response[1] == 1);

        if (response[0] == 1)
        {
            player.setRapidMoney(1500);
        }
        else //altrimenti tieni la pietra
        {
            blackCrystal = 1;
        }

        yield return new WaitForSeconds(1f);
        isEventDialogueClosed = true;
    }

    /* --------------------------------------------------------------------------------- *
     * --------------------------------------------------------------------------------- */

    // evento 11 - un gruppo di cavalieri di Aemis si presenta in città
    
    // DA FINIRE!!

    public int event11 = 0;

    IEnumerator TriggerEvent11()
    {
        event11 = 1;

        string eventString1 = "A group of knights of Aemis enters the city after a long journey.";
        string eventString2 = "They ask you to give them provisions for them to continue their trip.";
        string eventString3 = "A man from your army, however, tells you the might won't need them, since it appears they already own some.";
        string eventString4 = "Are you willing to help the knights of Aemis?\n[Providing provisions has a cost of 100 Gold]";

        string[] message = { eventString1, eventString2, eventString3, eventString4 };

        Dialogue.TriggerInteractiveDialogue(message);

        StartCoroutine(ResponseUpdater(false));
        yield return new WaitUntil(() => response[1] == 1);

        if (response[0] == 1)
        {
            string eventString5 = "The knights of Aemis thank you for your help and leave the city.";


            string[] message1 = { eventString5 };

            Dialogue.TriggerDialogue(message1);

            player.setRapidMoney(-100);
            aemisFaith += 2;
        }
        else 
        {
            string eventString5 = "The knights of Aemis invoke the name of Aemis and their autority in this regard in order for them to get what they won't.";
            string eventString6 = "They threaten violence on your people if you don't give them the provisions asked.";
            string eventString7 = "Are you willing to help them this time?\n[Providing provisions has a cost of 100 Gold]";


            string[] message1 = { eventString5, eventString6, eventString7 };

            Dialogue.TriggerInteractiveDialogue(message1);

            StartCoroutine(ResponseUpdater(false));
            yield return new WaitUntil(() => response[1] == 1);
                
            if (response[0] == 1)
            {
                player.setRapidMoney(-100);
            }
            else
            {
                string eventString8 = "In the end, the knights leave the city without doing anything harmful.";
                string eventString9 = "However they claim vengeance on you and your people.";

                string[] message2 = { eventString8, eventString9 };

                Dialogue.TriggerDialogue(message2);

                aemisFaith += 3;

                aemisKnightsHostility = 1;
            }

        }

        yield return new WaitForSeconds(1f);
        isEventDialogueClosed = true;
    }

    /* --------------------------------------------------------------------------------- *
     * --------------------------------------------------------------------------------- */

    // evento 13 - i cittadini chiedono più finanziamenti per proteggere i campi
    
    // DA FINIRE!!

    public int event13 = 0;

    IEnumerator TriggerEvent13()
    {
        event13 = 1;

        string eventString1 = "After a long discussion, your people have to tell you something.";
        string eventString2 = "They ask you to provide them with more financing towards the protection of their fields from brigands and animals...";
        string eventString3 = "... along with a better defense of the walls around the city.";
        string eventString4 = "Are you offering this financing?\n[Financing this plan has a cost of 1000 Gold]";

        string[] message = { eventString1, eventString2, eventString3, eventString4 };

        Dialogue.TriggerInteractiveDialogue(message);

        StartCoroutine(ResponseUpdater(false));
        yield return new WaitUntil(() => response[1] == 1);

        if (response[0] == 1)
        {
            player.setRapidMoney(-1000);
            player.bonusCity += 0.3f;  // bonusCity + 30%
        }
        

        yield return new WaitForSeconds(1f);
        isEventDialogueClosed = true;
    }

    /* --------------------------------------------------------------------------------- *
     * ----------------------------- SOLO SE aemisFaith <= 2 --------------------------- *
     * --------------------------------------------------------------------------------- */

    // evento 15 ---- SOLO SE aemisFaith <= 2 --- un sacerdote chiede di offrire una parte del raccolto dei prossimi anni
    
    // DA FINIRE!!

    public int event15 = 0;

    public int event15MalusTurnsLeft = 0;

    IEnumerator TriggerEvent15()
    {
        event15 = 1;

        string eventString1 = "In order to restore the faith in Aemis, some priests presents themselves in front of you with a plan.";
        string eventString2 = "They would like you to offer to the Aemis' cult your next years' crops.";
        string eventString3 = "Also, they ask you to build a statue of Liam, commander of the Celestials.";
        string eventString4 = "Are you accepting this request?\n[It will cost 400 Gold upfront, along with a reduction of income from the Farm for 3 seasons]";

        string[] message = { eventString1, eventString2, eventString3, eventString4 };

        Dialogue.TriggerInteractiveDialogue(message);

        StartCoroutine(ResponseUpdater(false));
        yield return new WaitUntil(() => response[1] == 1);

        if (response[0] == 1)
        {
            player.setRapidMoney(-400);
            
            event15MalusTurnsLeft = 3;                    //-30% guadagno gold della fattoria per 3 turni
            aemisFaith += 2;
        }
        else
        {
            aemisFaith--;
        }
        

        yield return new WaitForSeconds(1f);
        isEventDialogueClosed = true;
    }


    /* --------------------------------------------------------------------------------- *
     * --------------------------------------------------------------------------------- */
    
    // evento secondario 4 -  il ricercatore ritorna dicendo di aver trovato i resti di un tempio
    
    // DA FINIRE!!

    public int secondaryEvent4 = 0;
    public int secondaryEvent4TurnsLeft = 99;

    IEnumerator SecondaryEvent4()
    {
        secondaryEvent4 = 0;

        string eventString1 = "The researcher has returned with informations.";
        string eventString2 = "He claims that he found ancient ruins of a Temple devoted to the Eternal of the Elves of the woods.";
        string eventString3 = "The news quickly spread in the city and people are starting to think that the old legends are actually true.";
        string eventString4 = "The local priests of Aemis ask you to intervene and stop these rumors.";
        string eventString5 = "Are you willing to do so?";

        string[] message = { eventString1, eventString2, eventString3, eventString4, eventString5 };

        Dialogue.TriggerInteractiveDialogue(message);

        StartCoroutine(ResponseUpdater(false));
        yield return new WaitUntil(() => response[1] == 1);

        if (response[0] == 0)
        {
            string eventString6 = "A group of Elves are interested in this regard and would like to buy the research.";
            string eventString7 = "You sell them the research because you feel it's the right choice.\n[You gain 3000 Gold]";

            string[] message2 = { eventString6, eventString7 };

            Dialogue.TriggerDialogue(message2);

            aemisFaith -= 2;
            player.setRapidMoney(3000);

        }
        else
        {
            aemisFaith++;
        }
        yield return new WaitForSeconds(1f);
        isEventDialogueClosed = true;
    }

    /* --------------------------------------------------------------------------------- *
     * --------------------------------------------------------------------------------- */

    // evento 16 -  un ricercatore ha trovato in un bosco uno strano altare 
    
    // DA FINIRE!!

    public int event16 = 0;

    IEnumerator TriggerEvent16()
    {
        event16 = 1;

        string eventString1 = "A local researcher presents themselves in front of you claiming that he found a weird altar in the woods.";
        string eventString2 = "Incomprehensible and indecipherable writtens have been found on it, but he's sure they are from ancient times.";
        string eventString3 = "He also tells you that, along with those inscriptions, a strange, pulsating green light was present.";
        string eventString4 = "The researcher suspects that it might represent an ancient Eternal of a race that no longer exists.";
        string eventString5 = "In the end, he asks for financing in order for him to research more about this matter.";
        string eventString6 = "Are you willing to finance this research?\n[The research has 1000 Gold cost]";

        string[] message = { eventString1, eventString2, eventString3, eventString4, eventString5, eventString6 };

        Dialogue.TriggerInteractiveDialogue(message);

        StartCoroutine(ResponseUpdater(false));
        yield return new WaitUntil(() => response[1] == 1);

        if (response[0] == 1)
        {
            string eventString7 = "The local priests of Aemis ask you to stop this madness.";
            string eventString8 = "Are you stopping the research?\n[300 Gold will be refunded]";

            string[] message1 = { eventString7, eventString8 };

            Dialogue.TriggerInteractiveDialogue(message1);

            player.setRapidMoney(-1000);

            StartCoroutine(ResponseUpdater(false));
            yield return new WaitUntil(() => response[1] == 1);

            if (response[0] == 0) //se rifiuta
            {
                aemisFaith--;
                secondaryEvent4 = 1;
                secondaryEvent4TurnsLeft = 2;
            }
            else player.setRapidMoney(300); // rimborso spese
        }
        else
        {
            aemisFaith++;
        }
        

        yield return new WaitForSeconds(1f);
        isEventDialogueClosed = true;
    }


    /* --------------------------------------------------------------------------------- *
     * ----------------------------- SOLO SE bonusWall == 0 ---------------------------- *
     * --------------------------------------------------------------------------------- */

    // evento 17 ---- SOLO SE bonusWall == 0 --- il guildmaster è preocupato per le difese delle mura
    
    // DA FINIRE!!

    public int event17 = 0;

    public int event17MalusTurnsLeft = 0;

    IEnumerator TriggerEvent17()
    {
        event17 = 1;

        string eventString1 = "The Guild Master is worried about the walls' defense.";
        string eventString2 = "He suggests a project of renewal that would provide new palisades.";
        string eventString3 = "Are you financing this idea?\n[It has a cost of 500 Gold but you gain a .2% of wall bonus]";

        string[] message = { eventString1, eventString2, eventString3 };

        Dialogue.TriggerInteractiveDialogue(message);

        StartCoroutine(ResponseUpdater(false));
        yield return new WaitUntil(() => response[1] == 1);

        if (response[0] == 1)
        {
            player.setRapidMoney(-500);
            
            player.bonusWall += 0.2f;   //+20% bonusWall
        }
        else
        {
            string eventString5 = "The citizens are starting to feel less and less protected in your city.";
            string eventString6 = "A great discontent spreads around the city, causing a reduction in growth.\n[Citizens growth is reduced for some seasons]";

            string[] message2 = { eventString5, eventString6 };

            Dialogue.TriggerDialogue(message2);

            event17MalusTurnsLeft = 4;             //-50% crescita abitanti per 4 turni
        }
        

        yield return new WaitForSeconds(1f);
        isEventDialogueClosed = true;
    }


    /* --------------------------------------------------------------------------------- *
     * --------------------------------------------------------------------------------- */

    // evento 18 - il guildmaster è preocupato per le difese delle mura
    
    // DA FINIRE!!

    public int event18 = 0;

    IEnumerator TriggerEvent18()
    {
        event18 = 1;

        string eventString1 = "A forest in the distance burns up and the nearest villages are being quickly abandoned.";
        string eventString2 = "Lots of refugees of these villages come to your city and ask for shelter.";
        string eventString3 = "Local priests suggest to do so and more in the name of the Aemis' cult.";
        string eventString4 = "Are you willing to help them in the name of Aemis?\n[Shelter, food and provisions have a cost of 1000 Gold]";

        string[] message = { eventString1, eventString2, eventString3, eventString4 };

        Dialogue.TriggerInteractiveDialogue(message);

        StartCoroutine(ResponseUpdater(false));
        yield return new WaitUntil(() => response[1] == 1);

        if (response[0] == 1)
        {
            string eventString5 = "The refugees are being welcomed by the Aemis' cult.";
            string eventString6 = "Their presence caused a growth of Aemis' followers.";

            string[] message2 = { eventString5, eventString6 };

            Dialogue.TriggerDialogue(message2);

            aemisFaith += 3;
            player.setRapidMoney(-1000);
        }
        else
        {
            string eventString7 = "It is now your own Captain that suggests to help them, but this time in the name of your own city.";
            string eventString8 = "It asks you to do so so that the city gains influence and power.";
            string eventString9 = "Are you willing to help the refugees in the name of " + FindObjectOfType<Game>().CityNameUI.text + "?\n[Shelter, food and provisions have a cost of 1000 Gold]";

            string[] message3 = { eventString7, eventString8, eventString9};

            Dialogue.TriggerInteractiveDialogue(message3);

            StartCoroutine(ResponseUpdater(false));
            yield return new WaitUntil(() => response[1] == 1);

            if (response[0] == 1)
            {
                player.setRapidMoney(-1000);
                player.player_citizensMAX += 100;   // da rivedere
                player.setRapidCitizens(30); // +30
                swordsmen.setRapidTotal(10); // +10 swordman   da rivedere

            }
        }
        

        yield return new WaitForSeconds(1f);
        isEventDialogueClosed = true;
    }

    /* --------------------------------------------------------------------------------- *
     * --------------------------------------------------------------------------------- */

    // evento 2 - dei lupi rompono il cazzo 

    public int event2 = 0;
    public int event2MalusTurnsLeft = 0;


    IEnumerator TriggerEvent2()
    {
        event2 = 1;

        string eventString1 = "A group of wolves has been seen wandering around the city.";
        string eventString2 = "During the night people complain the howls and the farmers about their sheeps disappearing.";
        string eventString3 = "Your men suggests you to take care of the situation by sending an expedition outside the city.";
        string eventString4 = "Are you willing to do so?\n[The expedition has no cost]";

        string[] message = { eventString1, eventString2, eventString3, eventString4 };

        Dialogue.TriggerInteractiveDialogue(message);

        StartCoroutine(ResponseUpdater(false));
        yield return new WaitUntil(() => response[1] == 1);

        if (response[0] == 1)
        {
            terri = 2;
            makeEnemyForEvent(1, 0, "nul", "nul", (4 * player.getTurn()), "wolves", "wolf", 0, "nul", "nul", 2);

            FindObjectOfType<PrepBattaglia>().AvvioPreparazione(terri);

            yield return new WaitUntil(() => finishedBattle == true);

            if (lastBattleInfo > 2)
            {
                string eventString5 = "The expedition comes back with good news.";
                string eventString6 = "Your soldiers took down the wolves and came back with their cloth.";
                string eventString7 = "The cloth is worth 800 Gold.\n[You obtain 800 Gold]";

                string[] message2 = { eventString5, eventString6, eventString7 };

                Dialogue.TriggerDialogue(message2);

                player.setRapidMoney(800);
            }
            else if (lastBattleInfo == 2)
            {
                string eventString5 = "The expedition comes back with good news.";
                string eventString6 = "Your soldiers fought against the wolves as long as they could, but they didn't took down all of them.";
                string eventString7 = "They reassure you that they won't come back soon.";

                string[] message2 = { eventString5, eventString6, eventString7 };

                Dialogue.TriggerDialogue(message2);
            }

        }
        else
        {
            string eventString7 = "The wolves destroy the local fields around the Farm.";
            string eventString8 = "Your Farm won't be usable for a while.\n[Gold income from the Farm is reduced to zero for 4 seasons]";

            string[] message3 = { eventString7, eventString8 };

            Dialogue.TriggerDialogue(message3);

            event2MalusTurnsLeft = 4;
        }


        yield return new WaitForSeconds(1f);
        isEventDialogueClosed = true;
    }


    /* --------------------------------------------------------------------------------- *
     * --------------------------------------------------------------------------------- */

    // evento 19 - un uomo misterioso appare in città

    // DA FINIRE!!

    public int event19 = 0;

    IEnumerator TriggerEvent19()
    {
        event19 = 1;

        string eventString1 = "A mysterious man enters the city.";
        string eventString2 = "He claims to be a ghost from the past, a soldier who died in battle centuries ago.";
        string eventString3 = "He also claims to have seen numerous battles being fought around these lands, but none of those were different in any way from that in which he died.";
        string eventString4 = "His presence alerts the local priests of Aemis and condamn the entity. They ask you to take action against it.";
        string eventString5 = "Are you willing to proceed on behalf of the Aemis' cult?";

        string[] message = { eventString1, eventString2, eventString3, eventString4, eventString5 };

        Dialogue.TriggerInteractiveDialogue(message);

        StartCoroutine(ResponseUpdater(false));
        yield return new WaitUntil(() => response[1] == 1);

        if (response[0] == 0) //accoglienza
        {
            aemisFaith -= 2;

            string eventString6 = "You invite the ghost to your presence and ask him to continue his story.";
            string eventString7 = "The ghost goes on and tells about a demoniac army that fought his comrades and lost.";
            string eventString8 = "But with that victory came a great loss: his own life. He died while taking down the Great Demon at the command of the demoniac army.";
            string eventString9 = "It is in the exact place of the Great Demon's death that a black tree has grown. Noone, to this day, has never even thought of getting close to it.";
            string eventString10 = "The ghost stops his tale as he asks you to destroy that tree. This way, his soul will be set free. Slowly after his presence fades away.";
            string eventString11 = "Are you willing to accept this task?\n[Sending the expedition has no cost]";

            string[] message3 = { eventString6, eventString7, eventString8, eventString9, eventString10, eventString11 };

            Dialogue.TriggerInteractiveDialogue(message3);

            StartCoroutine(ResponseUpdater(false));
            yield return new WaitUntil(() => response[1] == 1);

            if (response[0] == 1)
            {
                string eventString12 = "Your men are sent for an expedition to find that tree and take it down.";
                string eventString13 = "They are soon back with good news, it looks like the tree was very close to the city.";
                string eventString14 = "Taking the tree down was no easy task, but they managed to do it.";
                string eventString15 = "Your soldiers hand you a green jewel as they claim it has been found right under the tree's roots.";
                string eventString16 = "The ghost appears again and thanks you. He then vanishes, leaving no trace behind.";

                string[] message2 = { eventString12, eventString13, eventString14, eventString15, eventString16 };

                Dialogue.TriggerDialogue(message2);

                ancientGreenJewel = 1;

            }
            else
            {
                string eventString14 = "The ghost says that his destiny will be shared by your soldiers.";
                string eventString15 = "He then leaves the city as he enters a thick fog.";

                string[] message2 = { eventString14, eventString15 };

                Dialogue.TriggerDialogue(message2);
            }

        }
        else //condanna
        {
            string eventString6 = "You follow the Aemis' cult suggestion and you exile the ghost out of the city.";
            string eventString7 = "The ghost disappears as he enters a thick fog.";

            string[] message2 = { eventString6, eventString7 };

            Dialogue.TriggerDialogue(message2);

            aemisFaith += 2;
            
        }


        yield return new WaitForSeconds(1f);
        isEventDialogueClosed = true;
    }

    /* --------------------------------------------------------------------------------- *
     * ----------------------------- SOLO SE aemisFaith < 6 ---------------------------- *
     * --------------------------------------------------------------------------------- */

    // evento 20 ---- SOLO SE aemisFaith < 6 --- una risa tra i fedeli di Aemis e un gruppo non fedele ha provocato gravi disagi

    // DA FINIRE!!

    public int event20 = 0;

    IEnumerator TriggerEvent20()
    {
        event20 = 1;

        string eventString1 = "A brawl happened between a group of faithful and non-faithful of the Aemis' cult, spreading discomfort around the city.";
        string eventString2 = "The local Aemis' priests pretend a refund for the damages caused, while your men tell you that the Aemis' followers are responsible.";
        string eventString3 = "The Guild Master confirms your men's version and other farmers claim that those unfaithul are the real culprit.";
        string eventString4 = "There are no compromises possible, you have to take a decision.";
        string eventString5 = "Are you willing to exile out of the city the local priests and his followers of Aemis?";

        string[] message = { eventString1, eventString2, eventString3, eventString4, eventString5 };

        Dialogue.TriggerInteractiveDialogue(message);

        StartCoroutine(ResponseUpdater(false));
        yield return new WaitUntil(() => response[1] == 1);

        if (response[0] == 1)
        {
            string eventString6 = "The followers of Aemis' and the priests damn your city as they leave.";

            string[] message2 = { eventString6 };

            Dialogue.TriggerSmallDialogue(message2);

            aemisFaith -= 10;
            aemisRebel = 1;
        }
        else
        {
            aemisFaith += 1;

            string eventString7 = "Since you took the decision of leaving the priests and the followers of Aemis' in their place, you have to pay for the damages.";
            string eventString8 = "[You pay 300 Gold for the damages caused by the situation]";

            string[] message2 = { eventString7, eventString8 };

            Dialogue.TriggerDialogue(message2);

            player.setRapidMoney(-300);
        }

        yield return new WaitForSeconds(1f);
        isEventDialogueClosed = true;
    }


    /* --------------------------------------------------------------------------------- *
     * ----------------------------- SOLO SE event1 == 0 ---------------------------- *
     * --------------------------------------------------------------------------------- */

    // evento 21 ---- SOLO SE event1 == 0 --- le acque della città son diventate torbide dopo una tempesta

    // DA FINIRE!!

    public int event21 = 0;
    public int event21MalusTurnsLeft = 0;

    IEnumerator TriggerEvent21()
    {
        event21 = 1;

        string eventString1 = "The city's waters became murky after a great storm and your citizens complain about the lack of drinkable water.";
        string eventString2 = "Your men suggest the construction of new wells around the city.";
        string eventString3 = "Are you willing to do so?\n[Building the necessary wells has a cost of 400 Gold]";

        string[] message = { eventString1, eventString2, eventString3 };

        Dialogue.TriggerInteractiveDialogue(message);

        StartCoroutine(ResponseUpdater(false));
        yield return new WaitUntil(() => response[1] == 1);

        if (response[0] == 1)
        {
            player.setRapidMoney(-400);
        }
        else
        {
            string eventString7 = "The city take a downturn due to the lack of water.";
            string eventString8 = "[The lack of water causes a reduction of Citizens growth per season to zero]";

            string[] message2 = { eventString7, eventString8 };

            Dialogue.TriggerDialogue(message2);

            event21MalusTurnsLeft = 3;
        }

        yield return new WaitForSeconds(1f);
        isEventDialogueClosed = true;
    }

    /* --------------------------------------------------------------------------------- *
     * ----------------------------- SOLO SE blackCrystal == 1 ---------------------------- *
     * --------------------------------------------------------------------------------- */

    // evento 22 ---- SOLO SE blackCrystal == 1 --- un strano rumore durante la notte

    // DA FINIRE!!

    public int event22 = 0;
    

    IEnumerator TriggerEvent22()
    {
        event22 = 1;

        string eventString1 = "During the night, a man heard noises from the room where the black crystal has been stored.";
        string eventString2 = "Some men ask you to keep it away from the city, fearing it could cause trouble or worse.";
        string eventString3 = "";
        if (event16 == 1)
            eventString3 = "The same researcher of the ancient ruins tells you that the Crystal might actually be worth keeping and that he could eventually control its powers.";
        else
            eventString3 = "A researcher tells you that the Crystal might actually be worth keeping and that he could eventually control its powers.";
        string eventString4 = "Are you willing to investigate the powers of the black Crystal?\n[If you don't, the Crystal will be sold]";

        string[] message = { eventString1, eventString2, eventString3, eventString4 };

        Dialogue.TriggerInteractiveDialogue(message);

        StartCoroutine(ResponseUpdater(false));
        yield return new WaitUntil(() => response[1] == 1);

        if (response[0] == 1)   //indagare
        {
            string eventString6 = "The researcher unleashes the powers of the black Crystal and uses it to enchant a great sword.";
            string eventString7 = "This sword has been gifted to your Captain.\n[" + FindObjectOfType<Game>().getCapitano().getName() + "'s attack and defenses have increased]";

            string[] message2 = { eventString6, eventString7 };

            Dialogue.TriggerDialogue(message2);


            FindObjectOfType<Game>().getCapitano().aumentaAtk(10);// atk capitano +10
            FindObjectOfType<Game>().getCapitano().aumentaDef(10);// def capitano +10


        }
        else //liberartene
        {
            string eventString7 = "You decide to sell the Crystal for as low as possible to keep it away from the city.";
            string eventString8 = "A merchant decides to buy it for as low as 500 Gold.\n[You gain 500 Gold]";

            string[] message2 = { eventString7, eventString8 };

            Dialogue.TriggerDialogue(message2);

            player.setRapidMoney(500);

            blackCrystal = 0;
        }

        yield return new WaitForSeconds(1f);
        isEventDialogueClosed = true;
    }

    /* --------------------------------------------------------------------------------- *
     * --------------------------------------------------------------------------------- */

    // evento 23 - un gruppo di bambini ha trovato vicino alle miniere una strana pergamena

    // DA FINIRE!!

    public int event23 = 0;

    IEnumerator TriggerEvent23()
    {
        event23 = 1;

        string eventString1 = "Some children have been seen playing around with a scroll on which a Demonic figure is drawn.";
        string eventString2 = "As soon as they saw it the scroll has been confiscated and presented to you.";
        string eventString3 = "Local priests of Aemis ask you the possibility to investigate further on their own. According to them there may be a traitor of Aemis.";
        string eventString4 = "Are you proceeding this way?\n[Investigation has no cost]";

        string[] message = { eventString1, eventString2, eventString3, eventString4 };

        Dialogue.TriggerInteractiveDialogue(message);

        StartCoroutine(ResponseUpdater(false));
        yield return new WaitUntil(() => response[1] == 1);

        if (response[0] == 1)
        {
            aemisFaith++;

            string eventString6 = "The priests find a man guilty of spreading false rumors about the Aemis' cult and ask you for its exile.";
            string eventString7 = "Are you willing to exile this man?";

            string[] message3 = { eventString6, eventString7 };

            Dialogue.TriggerInteractiveDialogue(message3);

            StartCoroutine(ResponseUpdater(false));
            yield return new WaitUntil(() => response[1] == 1);

            if (response[0] == 1)
            {
                aemisFaith++;
                string eventString10 = "The man is exiled as the local priests thank you for the cooperation.";

                string[] message2 = { eventString10 };

                Dialogue.TriggerDialogue(message2);
            }
            else
            {
                string eventString12 = "The man accuses the Aemis' cult of threats and violence against him.";
                string eventString13 = "The man then flees from the city as he claims to do so to keep himself alive.";

                string[] message2 = { eventString12, eventString13 };

                Dialogue.TriggerDialogue(message2);
            }
        }
        else
        {
            aemisFaith--;

            string eventString6 = "Days later, as you walk around the city with your guards, a man desperately approaches you.";
            string eventString7 = "He claims to be persecuted by the Aemis' cult, but as followers of the cult are getting closer, he flees.";
            string eventString8 = "Later that day you hear that the man has fled out of the city.";

            string[] message2 = { eventString6, eventString7, eventString8 };

            Dialogue.TriggerDialogue(message2);
        }

        yield return new WaitForSeconds(1f);
        isEventDialogueClosed = true;
    }

    /* --------------------------------------------------------------------------------- *
     * --------------------------------------------------------------------------------- */

    // evento 27 - 

    // DA FINIRE!!

    public int event27 = 0;
    public int event27MalusTurnsLeft = 0;

    IEnumerator TriggerEvent27()
    {
        event27 = 1;

        string eventString1 = "You hear that a group of elven merchants has entered the city.";
        string eventString2 = "They brought a great variety of plants and fruits from the far lands.";
        string eventString3 = "Local farmers reunited to ask you to buy them so that the city gain more the next year.\n[The affair has a cost of 1000 Gold]";

        string[] message = { eventString1, eventString2, eventString3 };

        Dialogue.TriggerInteractiveDialogue(message);

        StartCoroutine(ResponseUpdater(false));
        yield return new WaitUntil(() => response[1] == 1);

        if (response[0] == 1)
        {
            string eventString4 = "The fruits and plants brought a great increase of income for the next seasons.";

            string[] message2 = { eventString4 };

            Dialogue.TriggerSmallDialogue(message2);

            player.setRapidMoney(-1000);
            event27MalusTurnsLeft = 10; //goldFattoria * 4 per 10 turni
        }


        yield return new WaitForSeconds(1f);
        isEventDialogueClosed = true;
    }

    /* --------------------------------------------------------------------------------- *
     * --------------------------------------------------------------------------------- */

    // evento 30 - un grande cinghiale è stato avvistato intorno alla città

    // DA FINIRE!!

    public int event30 = 0;
    public int event30MalusTurnsLeft = 0;

    IEnumerator TriggerEvent30()
    {
        event30 = 1;

        string eventString1 = "A big wild boar has been seen wandering around the city. Hunters tried to capture him but didn't succeed.";
        string eventString2 = "Local guards also tried to handle the situation but nothing has changed, the boar always manages to escape.";
        string eventString3 = "Shortly after you hear voices about the boar being a magical creature e lots of citizens ask to leave him alone.";
        string eventString4 = "Other hunters, however, still want help to hunt the boar down once and for all.";
        string eventString5 = "Are you willing to help the hunters and do something about the boar?\n[Helping the hunters has no cost]";

        string[] message = { eventString1, eventString2, eventString3, eventString4, eventString5 };

        Dialogue.TriggerInteractiveDialogue(message);

        StartCoroutine(ResponseUpdater(false));
        yield return new WaitUntil(() => response[1] == 1);

        if (response[0] == 1)
        {
            string eventString6 = "You decide to help the hunters by asking your own army to help them.";
            string eventString7 = "Soon you hear how the situation evolved: the boar has been quickly cornered by your army, however something weird happened.";
            string eventString8 = "The wild boar started talking human language. It claimed to be an ancient creature and that instead of fighting him, humans should be fighting time.";
            string eventString9 = "The speechless army decided to leave the boar alone, thinking that with its death damnation and misfortune would've affected the city.";

            string[] message2 = { eventString6, eventString7, eventString8, eventString9 };

            Dialogue.TriggerDialogue(message2);

            event30MalusTurnsLeft = 3; // goldFattoria +40% per 3 turni
        }
        else
        {
            string eventString10 = "Soon after you hear the wild boar disappeared after some days without leaving trace.";

            string[] message2 = { eventString10 };

            Dialogue.TriggerDialogue(message2);
        }

        yield return new WaitForSeconds(1f);
        isEventDialogueClosed = true;
    }



    /* --------------------------------------------------------------------------------- *
     * --------------------------------------------------------------------------------- */

    // evento 26 - 

    public int event26 = 0;

    IEnumerator TriggerEvent26()
    {
        event26 = 1;

        string eventString1 = "";
        string eventString2 = "";
        string eventString3 = "";
        string eventString4 = "";

        string[] message = { eventString1, eventString2, eventString3, eventString4 };

        Dialogue.TriggerInteractiveDialogue(message);

        StartCoroutine(ResponseUpdater(false));
        yield return new WaitUntil(() => response[1] == 1);

        if (response[0] == 1)
        {
            
            if (lastBattleInfo > 0) //vittoria del capitano // VARIABILE NEL IF DA CAMBIARE
            {
                string eventString5 = "";
                string eventString6 = "";
                string eventString7 = "";

                string[] message2 = { eventString5, eventString6, eventString7 };

                Dialogue.TriggerDialogue(message2);

                FindObjectOfType<Game>().getCapitano().aumentaDef(6);// def capitano +10


            }
            else //sconfitta del capitano
            {
                string eventString6 = "";
                string eventString7 = "";
                string eventString8 = "";

                string[] message2 = { eventString6, eventString7, eventString8 };

                Dialogue.TriggerDialogue(message2);

                FindObjectOfType<Game>().getCapitano().resetCaptain();// reset capitano
            }

        }
        else
        {
            string eventString7 = "";
            string eventString8 = "";

            string[] message3 = { eventString7, eventString8 };

            Dialogue.TriggerDialogue(message3);

        }


        yield return new WaitForSeconds(1f);
        isEventDialogueClosed = true;
    }

    /* --------------------------------------------------------------------------------- *
 * --------------------------------------------------------------------------------- */

    // evento 28 - dei lupi rompono il cazzo 

    public int event28 = 0;
    


    IEnumerator TriggerEvent28()
    {
        event28 = 1;

        string eventString1 = "";
        string eventString2 = "";
        string eventString3 = "";
        string eventString4 = "";

        string[] message = { eventString1, eventString2, eventString3, eventString4 };

        Dialogue.TriggerInteractiveDialogue(message);

        StartCoroutine(ResponseUpdater(false));
        yield return new WaitUntil(() => response[1] == 1);

        if (response[0] == 1)
        {
            terri = 2;
            makeEnemyForEvent(2, 1, 1, 1, 1); //DA CAMBIARE 

            FindObjectOfType<PrepBattaglia>().AvvioPreparazione(terri);

            yield return new WaitUntil(() => finishedBattle == true);

            if (lastBattleInfo > 0)
            {
                string eventString5 = "The expedition comes back with good news.";
                string eventString6 = "Your soldiers took down the wolves and came back with their cloth.";
                string eventString7 = "The cloth is worth 800 Gold.\n[You obtain 800 Gold]";

                string[] message2 = { eventString5, eventString6, eventString7 };

                Dialogue.TriggerDialogue(message2);

                uominiErranti = 1;
            }
            

        }
        


        yield return new WaitForSeconds(1f);
        isEventDialogueClosed = true;
    }


    /* --------------------------------------------------------------------------------- *
     * --------------------------------------------------------------------------------- */

    // evento 29 - 

    // DA FINIRE!!

    public int event29 = 0;

    IEnumerator TriggerEvent29()
    {
        event29 = 1;

        string eventString1 = "";
        string eventString2 = "";
        string eventString3 = "";
        string eventString4 = "";
        string eventString5 = "";

        string[] message = { eventString1, eventString2, eventString3, eventString4, eventString5 };

        Dialogue.TriggerInteractiveDialogue(message);

        StartCoroutine(ResponseUpdater(false));
        yield return new WaitUntil(() => response[1] == 1);

        if (response[0] == 1)
        {
            
            string eventString6 = "";
            string eventString7 = "";

            string[] message3 = { eventString6, eventString7 };

            Dialogue.TriggerInteractiveDialogue(message3);

            StartCoroutine(ResponseUpdater(false));
            yield return new WaitUntil(() => response[1] == 1);

            if (response[0] == 1)
            {
                terri = 2;
                makeEnemyForEvent(2, 1, 1, 1, 1); //DA CAMBIARE 

                FindObjectOfType<PrepBattaglia>().AvvioPreparazione(terri);

                yield return new WaitUntil(() => finishedBattle == true);

                aemisKnightsHostility = 1;
                
                if (lastBattleInfo > 2)
                {
                    
                    string eventString8 = "";
                    string eventString9 = "";

                    string[] message2 = { eventString8, eventString9 };

                    Dialogue.TriggerDialogue(message2);

                    player.setRapidMoney(4000);
                }
                else 
                {
                    
                    string eventString8 = "";
                    string eventString9 = "";

                    string[] message2 = { eventString8, eventString9 };

                    Dialogue.TriggerDialogue(message2);
                }
            }
            else
            {
                string eventString8 = "";
                string eventString9 = "";

                string[] message2 = { eventString8, eventString9 };

                Dialogue.TriggerDialogue(message2);
            }
        }
        else
        {
            aemisFaith++;

            string eventString6 = "";
            string eventString7 = "";
            string eventString8 = "";

            string[] message2 = { eventString6, eventString7, eventString8 };

            Dialogue.TriggerDialogue(message2);
        }

        yield return new WaitForSeconds(1f);
        isEventDialogueClosed = true;
    }

}

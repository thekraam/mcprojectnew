using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Game : MonoBehaviour
{
    /* variabili di controllo tempo di aggiornamento allo skipturn */
    private float startTime = 0;
    private float startTimeController = 0;
    private bool isTurnDone = false;

    /* dichiarazione contatore eventi casuali non progressivi e booleana eventi speciali*/
    private int eventCounter = 0;
    private bool attendingSpecialEvent = false;
    private bool attendingGuildEvent = false;

    /* Dichiarazione dialogue */
    public Dialogue dialogue = new Dialogue();
    
    /* Dichiarazione object di controllo visibilita pannelli */
    public GameObject gamePanel; // pannello all'avvio partita
    public GameObject farmPanel;
    public GameObject fabbroPanel;
    public GameObject casermaPanel;
    public GameObject guildPanel;

    /* dichiarazione elementi di UI tramite oggetto Text in UnityEngine.UI */
    // FARM
    public Text farmlvlUI;
    public Text farmnextlvlUI;
    public Text farmmaxpopulationUI;
    public Text farmnextmaxpopulationUI;
    public Text farmcitizensperturnUI;
    public Text farmnextcitizensperturnUI;
    public Text farmgoldperturnUI;
    public Text farmnextgoldperturnUI;
    public Text farmupgradecostUI;
    // GENERAL
    public Text soldiersUI;
    public Text citizensUI;
    public Text populationUI;
    public Text moneyUI;
    public Text maxRecruitableUI;
    public TextMeshProUGUI turnsUI;
    Player player = new Player(); // oggetto player partita - non contiene soldati

    /* classi di tipo soldato.classesoldato */
    Soldiers.Swordsmen swordsmen = new Soldiers.Swordsmen();
    Soldiers.Archers archers = new Soldiers.Archers();
    Soldiers.Riders riders = new Soldiers.Riders();

    Fattoria fattoria = new Fattoria();
    Miniera miniera = new Miniera();
    Caserma caserma = new Caserma();
    Fabbro fabbro = new Fabbro();

    public List<Text> UIelements; 

    public void Start()
    {
        // disattivo pannelli non di game, 'nse sa mai
        gamePanel.SetActive(true); //
        farmPanel.SetActive(false);
        casermaPanel.SetActive(false);
        guildPanel.SetActive(false);
        casermaPanel.SetActive(false);
    }

    // ---------------------------- aggiornamento in real time texts ----------------------------
    public void Update()
    {
        // --------------------------- controller tempo per aggiornamento sync ---------------------------
        startTime = startTime + Time.deltaTime;
        startTimeController = startTimeController + Time.deltaTime;

        if(startTimeController > 2 && !isTurnDone)
        {
            startTime = 0;
            startTimeController = 0;
        }

        if (startTime > 2 && isTurnDone)
        {
            isTurnDone = false;
            onSkipTurn();
            startTimeController = 0;
            startTime = 0;
        }

        // --------------------------- updater generale ---------------------------

        // soldiersUI.text = "" + (player.countTotalCitizens(player, swordsmen, archers, riders) - player.getCitizens()); // mostra il nuovo totale dei soldati appena lo trovi

        // populationUI.text = "" + player.getPopulation(); // mostra il nuovo totale della popolazione totale come somma di soldati e civili appena la trovi

        // moneyUI.text = "" + player.getMoney(); // mostra il nuovo totale dei soldi appena lo trovi

        // maxRecruitableUI.text = "" + caserma.getMaxRecruitable();

        turnsUI.text = "" + player.getTurn(); // mostra il nuovo turno appena lo trovi

        // --------------------------- updater dati fattoria - tempo reale ---------------------------

        farmlvlUI.text = "" + fattoria.getLvlFattoria();
        farmnextlvlUI.text = "" + fattoria.getNextLvlFattoria();

        farmmaxpopulationUI.text = "" + fattoria.getAbitantiMax();
        farmnextmaxpopulationUI.text = "" + fattoria.getNextAbitantiMax();

        farmcitizensperturnUI.text = "+" + fattoria.getCrescitaAbitanti();
        farmnextcitizensperturnUI.text = "+" + fattoria.getNextCrescitaAbitanti();

        farmgoldperturnUI.text = "+" + fattoria.getGoldFattoria();
        farmnextgoldperturnUI.text = "+" + fattoria.getNextGoldFattoria();

        // farmupgradecostUI.text = "" + fattoria.getCostoLvlUp();


    }

    public void onTapNextSeason()
    {
        isTurnDone = true;
    }

    public void onSkipTurn()
    {
        player.setSkipMoney(fattoria.getGoldFattoria() + miniera.getgoldMiniera() + 2 * player.getCitizens() + 20 * fabbro.zappa * fattoria.getLvlFattoria() + 20 * fabbro.zappa2 * fattoria.getLvlFattoria());
        player.setMoney(); // cambia definitivamente i soldi, al resto ci pensa Update   
       
        player.setCitizens(); // cambia il numero di cittadini liberi, al resto ci pensa Update in funzione del numero di soldati riportato sotto
        player.setTempCitizens(fattoria.getCrescitaAbitanti());

        player.setCitizensMax(fattoria.getAbitantiMax());

        swordsmen.setTotal(); // ricalcolo tot spadaccini
        archers.setTotal(); // ricalcolo tot arcieri
        riders.setTotal(); // ricalcolo tot cavalieri

        player.setPopulation(player.getCitizens() + swordsmen.getTotal() + archers.getTotal() + riders.getTotal()); // ricalcolo popolazione attuale

        player.nextTurn(); // cambia il numero del turno attuale, al resto ci pensa Update

        this.attendingGuildEvent = false;
        //eventStarter(player.getTurn(), false);
    }



    // ---------------------------- avviatore eventi ----------------------------
    /*public void eventStarter(int turn, bool selectingGuildEvent)
    {
        if (!selectingGuildEvent && turn > 1)
        { 
            float isEventHappening = Random.Range(0f, 1f);
            if (attendingSpecialEvent)
            {
                dialogue.TriggerInteractiveDialogue(player, swordsmen, archers, riders); // avvia evento conseguenza
                attendingSpecialEvent = false;
            }
            else if (isEventHappening >= 0f  &&
                     isEventHappening < 0.2f &&
                     this.eventCounter < 10    )
            {
                dialogue.TriggerDialogue(player, swordsmen, archers, riders); // avvia evento passivo, senza scelta
                this.eventCounter++;
            }
            else if (isEventHappening >= 0.2f &&
                     isEventHappening < 0.3f    )
            {
                dialogue.TriggerInteractiveDialogue(player, swordsmen, archers, riders); // avvia evento che scatena conseguenza, con scelta
                attendingSpecialEvent = true;
            } 
        }
        else
        {
            if (!this.attendingGuildEvent)
            {
                dialogue.TriggerGuildDialogue(player, swordsmen, archers, riders);
                attendingGuildEvent = true;
            }
            else
            {
                dialogue.TriggerGuildErrorDialogue(player, swordsmen, archers, riders);
            }
        }
    }
    */
    // ----------------------------metodi per nascondere o visualizzare i pannelli di gioco----------------------------
    public void onTapVillage()
    {
        gamePanel.SetActive(true); // sempre true
        farmPanel.SetActive(false);
        casermaPanel.SetActive(false);
        guildPanel.SetActive(false);
        fabbroPanel.SetActive(false);
    }

    public void onTapFarm()
    {
        gamePanel.SetActive(true); // sempre true
        farmPanel.SetActive(true); // 
        casermaPanel.SetActive(false);
        guildPanel.SetActive(false);
        fabbroPanel.SetActive(false);
    }
    public void onTapCaserma()
    {
        gamePanel.SetActive(true); // sempre true
        farmPanel.SetActive(false); 
        casermaPanel.SetActive(true); //
        guildPanel.SetActive(false);
        fabbroPanel.SetActive(false);
    }

    public void onTapGuild()
    {
        gamePanel.SetActive(true); // sempre true
        farmPanel.SetActive(false); 
        casermaPanel.SetActive(false);
        guildPanel.SetActive(true); //
        fabbroPanel.SetActive(false);
    }

    public void onTapFabbro()
    {
        gamePanel.SetActive(true); // sempre true
        farmPanel.SetActive(false);
        casermaPanel.SetActive(false);
        guildPanel.SetActive(false);
        fabbroPanel.SetActive(true); //
    }






    //----------------------------pulsanti reclutamento------------------------

     public void onRecruitSwordsmen (int x)
    {
        caserma.reclutaSwordman(swordsmen, x);
        player.setRapidMoney(-20);
    }
    public void onRecruitArchers(int x)
    {
        caserma.reclutaArchers(archers, x);
        player.setRapidMoney(-20);
    }
    public void onRecruitRiders(int x)
    {
        caserma.reclutaRiders(riders, x);
        player.setRapidMoney(-30);
    }

    //-------------------------------aggiunta capitani (beta testing)-----------------------
    Captain1 capitano = new Captain1();
    Captain2 enemyCapitano = new Captain2();

}
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

    /* Dichiarazione EventList */
    public Events events = new Events();

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
        gamePanel.SetActive(false); //
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
            //da aggiungere controllo presenza capitano
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
        Debug.LogError(player.getTurn());

        



    }
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


    /*----------------save------load------------------*/

    public void SaveGame()
    {
        SaveSystem.SaveGame(player);
    }

    public void LoadGame()
    {
        GameData data = SaveSystem.LoadGame();
        player.player_turn = data.player_turn;

    }


    //------------------------------------------ sistema di battaglia (beta testing)-----------------------
    Captain1 capitano = new Captain1();
    Captain2 enemyCapitano = new Captain2();
    Enemy enemy = new Enemy();
    battle1 battle = new battle1();
    Enemy.ESwordsmen eswordsmen = new Enemy.ESwordsmen();
    Enemy.EArchers earchers = new Enemy.EArchers();
    Enemy.ERiders eriders = new Enemy.ERiders();

    public void makeEnemy(int totale, int livello, int swordmen, int archers, int riders, int lvlcapitano)
    {
        enemy.creazione(totale, livello, swordmen, archers, riders, lvlcapitano, enemyCapitano, eswordsmen, earchers, eriders);
    }
    public void makeCaptain(int lvl)
    {
        capitano.resetCaptain();
        capitano.lvlUpRapid(lvl);

    }

    public int newBattle(float terri, float bonusETerri, float bonusEnemy)
    {
        int esito = 0;
        float bonusTerri = 0;
        if (terri == 1)
        {
            bonusTerri = player.getBonusWall();
        }
        if (terri == 2)
        {
            bonusTerri = player.getBonusCity();
        }
        if (terri == 3)
        {
            bonusTerri = player.getBonusFar();
        }
        if (terri == 4)
        {
            bonusTerri = player.getBonusDemoniac();
        }
        float bonusSoldier = player.getBonusBattle() + caserma.getBonusBarrack();

        esito = battle.battaglia(capitano, enemyCapitano, swordsmen, archers, riders, eswordsmen, earchers, eriders, terri, bonusTerri, bonusETerri, bonusSoldier, bonusEnemy); ;

        return esito;
    }



    /* Variabili di */


}
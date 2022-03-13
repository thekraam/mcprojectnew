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

    /* Dichiarazione Musica di gioco */
    //public AudioClip[] GameMusic;
    public AudioClip newTurnSound;
    public AudioClip village_mapUnfold;
    public AudioClip farm_cowbells;
    public AudioClip blacksmith_Anvil;
    public AudioClip guild_paperwork;
    public AudioClip guild_expeditionCompleted;
    public AudioClip barracks_swordFight;
    public AudioClip cave_mining;

    /* Dichiarazione object di controllo visibilita pannelli */
    public GameObject mainMenuPanel;
    public GameObject gamePanel; // pannello all'avvio partita
    public GameObject cityPanel;
    public GameObject farmPanel;
    public GameObject fabbroPanel;
    public GameObject casermaPanel;
    public GameObject guildPanel;

    /* pannelli blocker */
    public GameObject skipTurnBlocker;
    public GameObject dialogueInterfaceBlocker;

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
    public Text SwordsmenUI;
    public Text ArchersUI;
    public Text RidersUI;
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
        // musica on
        //FindObjectOfType<AudioManager>().RandomMusic(GameMusic);

        // disattivo pannelli non di game, 'nse sa mai
        mainMenuPanel.SetActive(true);
        skipTurnBlocker.SetActive(false);
        dialogueInterfaceBlocker.SetActive(false);
        cityPanel.SetActive(true);
        gamePanel.SetActive(false); 
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

        if (!isTurnDone)
        {
            startTime = 0;
        }

        if (startTimeController > 1.5f) skipTurnBlocker.SetActive(false);

        if (startTime > 0.5f + FindObjectOfType<SceneLoader>().waitTime && isTurnDone)
        {
            //da aggiungere controllo presenza capitano
            isTurnDone = false;
            onSkipTurn();
            skipTurnBlocker.SetActive(true);
            startTimeController = 0;
            startTime = 0;
        }

        if (FindObjectOfType<DialogueManager>().animator.GetBool("IsOpen")) dialogueInterfaceBlocker.SetActive(true);

        // --------------------------- updater generale ---------------------------

        SwordsmenUI.text = "" + swordsmen.getTotal();
        ArchersUI.text = "" + archers.getTotal();
        RidersUI.text = "" + riders.getTotal();

        populationUI.text = "" + player.getPopulation() + "/" + player.getCitizensMax(); // mostra il nuovo totale della popolazione totale appena la trovi
    
        moneyUI.text = "" + player.getMoney(); // mostra il nuovo totale dei soldi appena lo trovi

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

        if (fattoria.getLvlFattoria() < 5)
            farmupgradecostUI.text = "Costo: " + fattoria.getLvlUpCost();
        else
        {
            Color32 darkred = new Color32(92, 0, 0, 255);
            farmupgradecostUI.text = "Max level reached";
            farmupgradecostUI.color = darkred;
        }

    }

    public void onTapNextSeason()
    {
        isTurnDone = true;
        FindObjectOfType<AudioManager>().PlayEffectFaded(newTurnSound);
    }
    
    public void onSkipTurn()
    {


        player.setSkipMoney(fattoria.getGoldFattoria() + miniera.getgoldMiniera() + 2 * player.getCitizens() + 20 * fabbro.zappa * fattoria.getLvlFattoria() + 20 * fabbro.zappa2 * fattoria.getLvlFattoria() - FindObjectOfType<Events>().GoldMalusEffects(player, swordsmen, archers, riders));
        player.setMoney(); // cambia definitivamente i soldi, al resto ci pensa Update   

        player.setCitizens(); // cambia il numero di cittadini liberi, al resto ci pensa Update in funzione del numero di soldati riportato sotto
        player.setTempCitizens(fattoria.getCrescitaAbitanti() - FindObjectOfType<Events>().CitizensMalusEffects(player, swordsmen, archers, riders));

        player.setCitizensMax(fattoria.getAbitantiMax());



        swordsmen.setTotal(); // ricalcolo tot spadaccini
        archers.setTotal(); // ricalcolo tot arcieri
        riders.setTotal(); // ricalcolo tot cavalieri

        player.setPopulation(player.getCitizens() + swordsmen.getTotal() + archers.getTotal() + riders.getTotal()); // ricalcolo popolazione attuale

        player.nextTurn(); // cambia il numero del turno attuale, al resto ci pensa Update
        Debug.LogError(player.getTurn());

        FindObjectOfType<Events>().eventTurnsDecreaser();
        FindObjectOfType<Events>().SecondaryEventStarter(player, swordsmen, archers, riders); // avvio evento secondario, fa controlli sugli status attuali dell'oggetto events ed eventualmente inizializza un evento secondario
        FindObjectOfType<Events>().EventStarter(player, swordsmen, archers, riders); // avvio evento primario, non si avvia se e' in corso uno secondario

    }
    // ----------------------------metodi per nascondere o visualizzare i pannelli di gioco----------------------------
    public void onTapVillage()
    {
        FindObjectOfType<AudioManager>().PlayEffectFaded(village_mapUnfold);

        gamePanel.SetActive(true); // sempre true
        cityPanel.SetActive(true); //
        farmPanel.SetActive(false);
        casermaPanel.SetActive(false);
        guildPanel.SetActive(false);
        fabbroPanel.SetActive(false);
    }

    public void onTapFarm()
    {
        FindObjectOfType<AudioManager>().PlayEffectFaded(farm_cowbells);

        gamePanel.SetActive(true); // sempre true
        cityPanel.SetActive(false); //
        farmPanel.SetActive(true); // 
        casermaPanel.SetActive(false);
        guildPanel.SetActive(false);
        fabbroPanel.SetActive(false);
    }
    public void onTapCaserma()
    {
        FindObjectOfType<AudioManager>().PlayEffectFaded(barracks_swordFight);

        gamePanel.SetActive(true); // sempre true
        cityPanel.SetActive(false); //
        farmPanel.SetActive(false);
        casermaPanel.SetActive(true); //
        guildPanel.SetActive(false);
        fabbroPanel.SetActive(false);
    }

    public void onTapGuild()
    {
        FindObjectOfType<AudioManager>().PlayEffectFaded(guild_paperwork);

        gamePanel.SetActive(true); // sempre true
        cityPanel.SetActive(false); //
        farmPanel.SetActive(false);
        casermaPanel.SetActive(false);
        guildPanel.SetActive(true); //
        fabbroPanel.SetActive(false);
    }

    public void onTapFabbro()
    {
        FindObjectOfType<AudioManager>().PlayEffectFaded(blacksmith_Anvil);

        gamePanel.SetActive(true); // sempre true
        cityPanel.SetActive(false); //
        farmPanel.SetActive(false);
        casermaPanel.SetActive(false);
        guildPanel.SetActive(false);
        fabbroPanel.SetActive(true); //
    }
    // tasti fattoria

    public void onUpgradeFarm()
    {
        if(fattoria.getLvlFattoria() < 5)
            fattoria.lvlUpFattoria();
    }

    /*----------------save------load------------------*/

    public void SaveGame()
    {
        SaveSystem.SaveGame(player,FindObjectOfType<Events>());
    }

    public void LoadGame()
    {
        GameData data = SaveSystem.LoadGame();
        player.player_turn = data.player_turn;
        FindObjectOfType<Events>().setEventAqueduct(data.aqueduct);
        FindObjectOfType<Events>().setEventResponse(data.response);
        FindObjectOfType<Events>().setEventCitydefenseproject(data.citydefenseproject);
        FindObjectOfType<Events>().setEventAqueductSecondary(data.aqueductSecondary);
        FindObjectOfType<Events>().setEventAqueductTurnsLeft(data.aqueductTurnsLeft);
        FindObjectOfType<Events>().setEventAttendingSecondaryEvent(data.attendingSecondaryEvent);

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

}

    /* Variabili di */








    //-------------------------------- betatesting e debugging --------------------------------
    /*
    public Text nomeECap;
    public void creaECapitano ()
    {
        makeEnemy(10, 1, 7, 3, 0, 1);
        enemyCapitano.lvlUpRapid(6);

    }
}

    */
//nomeECap.text = "nome = " + enemyCapitano.getName() + " perk 1 " + enemyCapitano.getPerk1() + " commento : " + enemyCapitano.getPerk1comment() + "\n perk 2 : " + enemyCapitano.getPerk2() + " commento : " + enemyCapitano.getPerk2comment() + "\n perk 3 : " + enemyCapitano.getPerk3() + " commento : " + enemyCapitano.getPerk3comment();
// nomeECap.text = "attacco : " + enemyCapitano.getAtk() + " difesa : " + enemyCapitano.getDef() + " bonus : " + enemyCapitano.getBonusBattle();     
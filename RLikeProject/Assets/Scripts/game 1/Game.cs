using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class Game : MonoBehaviour
{
    [Header("City and symbol UI")]
    public Text CityNameUI;

    public GameObject logoUI_1;
    public GameObject logoUI_2;
    public GameObject logoUI_3;
    public GameObject logoUI_4;

    [Header("Sync Variables")]
    /* variabili di controllo tempo di aggiornamento allo skipturn */
    private float startTime = 0;
    private float startTimeController = 0;
    private bool isTurnDone = false;

    [Header("Game Status")]
    public GameObject resumeGameText;

    [Header("Music")]
    /* Dichiarazione Musica di gioco */
    public AudioClip[] GameMusic;
    public AudioClip newTurnSound;
    public AudioClip village_mapUnfold;
    public AudioClip farm_cowbells;
    public AudioClip blacksmith_Anvil;
    public AudioClip guild_paperwork;
    public AudioClip guild_expeditionCompleted;
    public AudioClip barracks_swordFight;
    public AudioClip mine_pickaxe;

    [Header("Main Panels")]
    /* Dichiarazione object di controllo visibilita pannelli */
    public GameObject mainMenuPanel;
    public GameObject gamePanel; // pannello all'avvio partita
    public GameObject cityPanel;
    public GameObject farmPanel;
    public GameObject fabbroPanel;
    public GameObject casermaPanel;
    public GameObject guildPanel;
    public GameObject minePanel;

    [Header("Panel Blockers")]
    /* pannelli blocker */
    public GameObject skipTurnBlocker;
    public GameObject dialogueInterfaceBlocker;

    [Header("UI Section")]
    /* dichiarazione elementi di UI tramite oggetto Text in UnityEngine.UI */

    [Header("Farm UI")]
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

    [Header("Blacksmith UI")]
    //FABBRO
    public Text fabbrolvlUI;
    public Text fabbroupgradecostUI;
    public Text fabbroAtkUI;
    public Text fabbroNextAtkUI;
    public Text fabbroDefUI;
    public Text fabbroNextDefUI;
    public Text fabbroZappaUI;
    public Text fabbroNextZappaUI;
    public Text fabbroPicconeUI;
    public Text fabbroNextPicconeUI;
    public Text fabbrocostoAtk;
    public Text fabbrocostoDef;
    public Text fabbrocostoZappa;
    public Text fabbrocostoPiccone;

    [Header("Barracks UI")]
    //CASERMA
    public Text casermalvUI;
    public Text casermaupgradecostUI;
    public Text casermanextlvlUI;
    public Text casermareclutamentoMAXUI;
    public Text casermanextreclutamentoMAXUI;
    public Text casermaBattleBonusUI;
    public Text casermaNextBattleBonusUI;

    [Header("Mine UI")]
    //MINIERA
    public Text minieralvUI;
    public Text minieranextlvlUI;
    public Text minieracostoUI;
    public Text minieragoldUI;
    public Text minieragolnextUI;

    [Header("Guild UI")]
    //GILDA
    public Text gildalvUI;
    public Text gildacostoUI;

    [Header("Miscellaneous UI")]
    // GENERAL
    public Text SwordsmenUI;
    public Text SwordsmenNextUI;
    public Text ArchersUI;
    public Text ArchersNextUI;
    public Text RidersUI;
    public Text RidersNextUI;
    public Text citizensUI;
    public Text citizensNextUI;
    public Text populationUI_1;
    public Text populationUI_2; 
    public Text moneyUI;
    public Text moneyNextUI;
    public Text moneyfarmUI;
    public Text moneymineUI;
    public Text moneytaxUI;
    public TextMeshProUGUI turnsUI;

    // colori
    public Color32 darkred = new Color32(92, 0, 0, 255);
    public Color32 blacknormal = new Color32(55 , 55, 55, 255);


    Player player = new Player(); // oggetto player partita - non contiene soldati

    /* classi di tipo soldato.classesoldato */
    Soldiers.Swordsmen swordsmen = new Soldiers.Swordsmen();
    Soldiers.Archers archers = new Soldiers.Archers();
    Soldiers.Riders riders = new Soldiers.Riders();

    Fattoria fattoria = new Fattoria();
    Miniera miniera = new Miniera();
    Caserma caserma = new Caserma();
    Fabbro fabbro = new Fabbro();
    Gilda gilda = new Gilda();
    OldSoldiersManager manager = new OldSoldiersManager();

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
        gamePanel.SetActive(true); 
        farmPanel.SetActive(false);
        casermaPanel.SetActive(false);
        guildPanel.SetActive(false);
        casermaPanel.SetActive(false);
    }

    public void SAVEDELETETEST()
    {
        SaveSystem.DeleteSave();
    }

    public void onQuitGame()
    {
        SceneManager.UnloadSceneAsync(0);
        SceneManager.LoadScene(0);
    }

    // ---------------------------- aggiornamento in real time texts ----------------------------

    private void SyncTurnAndBlockers()
    {
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
    }

    private void UpdateVillageUI()
    {
        CityNameUI.text = FindObjectOfType<FontDecreaser>().Cityname.text.ToString().ToUpper();
        CityNameUI.fontSize = FindObjectOfType<FontDecreaser>().Cityname.fontSize;

        FindObjectOfType<SliderController>().RealTimeSliders(player, swordsmen, archers, riders, caserma); // va in Caserma
        SwordsmenUI.text = "" + swordsmen.getTotal();
        SwordsmenNextUI.text = swordsmen.getscrittaswordman();
        ArchersUI.text = "" + archers.getTotal();
        ArchersNextUI.text = archers.getscrittaarcher();
        RidersUI.text = "" + riders.getTotal();
        RidersNextUI.text = riders.getscrittarider();
        citizensUI.text = "" + player.getCitizens();
        citizensNextUI.text = "(+" + (fattoria.getCrescitaAbitanti() - FindObjectOfType<Events>().CitizensMalusEffects(player, swordsmen, archers, riders, fattoria)) + ")";
        populationUI_1.text = "" + player.getPopulation();
        populationUI_2.text = "" + player.getCitizensMax();
        moneyfarmUI.text = "(+" + (fattoria.getGoldFattoria() + fabbro.getSoldiZappa()) + ")";
        moneymineUI.text = "(+" + (miniera.getgoldMiniera() + fabbro.getSoldiPiccone()) + ")";
        moneytaxUI.text = "(+" + (player.getCitizens() * 2) + ")";
        moneyUI.text = "" + player.getMoney();
        moneyNextUI.text = "(+" + (fattoria.getGoldFattoria() + fabbro.getSoldiZappa() + miniera.getgoldMiniera() + fabbro.getSoldiPiccone()+ (player.getCitizens() * 2))  +")";   

        turnsUI.text = "" + player.getTurn(); // mostra il nuovo turno appena lo trovi
    }
    
    private void UpdateFarmUI()
    {
        farmlvlUI.text = "" + fattoria.getLvlFattoria();
        farmnextlvlUI.text = "" + fattoria.getNextLvlFattoria();

        farmmaxpopulationUI.text = "" + fattoria.getAbitantiMax();
        farmnextmaxpopulationUI.text = fattoria.getNextAbitantiMax();

        farmcitizensperturnUI.text = "+" + fattoria.getCrescitaAbitanti();
        farmnextcitizensperturnUI.text = fattoria.getNextCrescitaAbitanti();

        farmgoldperturnUI.text = "+" + fattoria.getGoldFattoria();
        farmnextgoldperturnUI.text = fattoria.getNextGoldFattoria();

        if (fattoria.getLvlFattoria() < 5)
        {
            farmupgradecostUI.text = "Costo: " + fattoria.getLvlUpCost();
            if (player.getMoney() < fattoria.getLvlUpCost())
            {
                farmupgradecostUI.color = darkred;
            }
            else
            {
                farmupgradecostUI.color = blacknormal;
            }
        }
        else
        {
            farmupgradecostUI.text = "Max level reached";
            farmupgradecostUI.color = darkred;
        }
    }

    private void UpdateBlacksmithUI()
    {
        fabbrolvlUI.text = "" + fabbro.getlvl();
        // fabbroupgradecostUI.text = "Costo: " + fabbro.getcosto();
        if (fabbro.getlvl() < 5)
        {
            fabbroupgradecostUI.text = "Costo: " + fabbro.getcosto();
            if (player.getMoney() < fabbro.getcosto())
            {
                fabbroupgradecostUI.color = darkred;
            }
            else
            {
                fabbroupgradecostUI.color = blacknormal;
            }
        }
        else
        {
            fabbroupgradecostUI.text = "Max level reached";
            fabbroupgradecostUI.color = darkred;
        }

        fabbroAtkUI.text = "+" + fabbro.getArmi();
        fabbroDefUI.text = "+" + fabbro.getArmature();
        fabbroZappaUI.text = "+" + fabbro.getZappa();
        fabbroPicconeUI.text = "+" + fabbro.getPiccone();


        fabbroNextAtkUI.text = fabbro.getnextpotenziamento(1);
        fabbroNextDefUI.text = fabbro.getnextpotenziamento(2);
        fabbroNextZappaUI.text = fabbro.getnextpotenziamento(3);
        fabbroNextPicconeUI.text = fabbro.getnextpotenziamento(4);

        if (fabbro.getArmi() == fabbro.getlvl() && fabbro.getlvl() != 5)
        {
            fabbrocostoAtk.text = "Next lvl needed";
            fabbrocostoAtk.color = darkred;
        }
        else if (fabbro.getCostoNumPotenziamenti(1) > player.getMoney())
        {
            fabbrocostoAtk.text = fabbro.getCostoPotenziamenti(1);
            fabbrocostoAtk.color = darkred;
        }
        else
        {
            fabbrocostoAtk.text = fabbro.getCostoPotenziamenti(1);
            fabbrocostoAtk.color = blacknormal;
        }
        if (fabbro.getArmature() == fabbro.getlvl() && fabbro.getlvl() != 5)
        {
            fabbrocostoDef.text = "Next lvl needed";
            fabbrocostoDef.color = darkred;
        }
        else if (fabbro.getCostoNumPotenziamenti(2) > player.getMoney())
        {
            fabbrocostoDef.text = fabbro.getCostoPotenziamenti(2);
            fabbrocostoDef.color = darkred;
        }
        else
        {
            fabbrocostoDef.text = fabbro.getCostoPotenziamenti(2);
            fabbrocostoDef.color = blacknormal;
        }
        if (fabbro.getZappa() == fabbro.getlvl() && fabbro.getlvl() != 5)
        {
            fabbrocostoZappa.text = "Next lvl needed";
            fabbrocostoZappa.color = darkred;
        }
        else if (fabbro.getCostoNumPotenziamenti(3) > player.getMoney())
        {
            fabbrocostoZappa.text = fabbro.getCostoPotenziamenti(3);
            fabbrocostoZappa.color = darkred;
        }
        else
        {
            fabbrocostoZappa.text = fabbro.getCostoPotenziamenti(3);
            fabbrocostoZappa.color = blacknormal;
        }
        if (fabbro.getPiccone() == fabbro.getlvl() && fabbro.getlvl() != 5)
        {
            fabbrocostoPiccone.text = "Next lvl needed";
            fabbrocostoPiccone.color = darkred;
        }
        else if (fabbro.getCostoNumPotenziamenti(4) > player.getMoney())
        {

            fabbrocostoPiccone.text = fabbro.getCostoPotenziamenti(4);
            fabbrocostoPiccone.color = darkred;
        }
        else
        {
            fabbrocostoPiccone.text = fabbro.getCostoPotenziamenti(4);
            fabbrocostoPiccone.color = blacknormal;
        }
    }

    private void UpdateBarracksUI()
    {
        /*
            public Text casermaNextBattleBonusUI;

        */
        casermalvUI.text = "" + caserma.getLvl();
        if (caserma.getLvl() < 5)
        {
            casermaupgradecostUI.text = "Costo: " + caserma.getcosto();
            if (player.getMoney() < caserma.getcosto())
            {
                casermaupgradecostUI.color = darkred;
            }
            else
            {
                casermaupgradecostUI.color = blacknormal;
            }
        }
        else
        {
            casermaupgradecostUI.text = "Max level reached";
            casermaupgradecostUI.color = darkred;
        }

        casermanextlvlUI.text = caserma.getNextlvlBarrack();
        casermareclutamentoMAXUI.text = "" + caserma.getReclutamentoMax();
        casermanextreclutamentoMAXUI.text = caserma.getNextlvlReclutamentoMax();
        casermaBattleBonusUI.text = "" + caserma.getBonusBarrack();
        casermaNextBattleBonusUI.text = caserma.getNextLvlBonusBarrack();
    }


    private void UpdateMineUI()
    {
        minieralvUI.text = "" + miniera.getLvlMiniera();
        minieranextlvlUI.text = miniera.getNextlvl();
        if (miniera.getLvlMiniera() < 5)
        {
            minieracostoUI.text = "Costo: " + miniera.getcosto();
            if (player.getMoney() < miniera.getcosto())
            {
                minieracostoUI.color = darkred;
            }
            else
            {
                minieracostoUI.color = blacknormal;
            }
        }
        else
        {
            minieracostoUI.text = "Max level reached";
            minieracostoUI.color = darkred;
        }
        minieragoldUI.text = "+" + miniera.getgoldMiniera();
        minieragolnextUI.text = miniera.getgoldnext();


    }
    private void UpdateGuildUI()
    {

        gildalvUI.text = "" + gilda.getlvl();
        if (gilda.getlvl() < 5)
        {
            gildacostoUI.text = "Costo: " + gilda.getcosto();
            if (player.getMoney() < gilda.getcosto())
            {
                gildacostoUI.color = darkred;
            }
            else
            {
                gildacostoUI.color = blacknormal;
            }
        }
        else
        {
            gildacostoUI.text = "Max level reached";
            gildacostoUI.color = darkred;
        }

    }




    public void Update()
    {
        // ---------------------------   Controllo Presenza Salvataggio --------------------------
        SaveSystem.DataStatus(resumeGameText);

        // ---------------------------                 BG Music                ---------------------------

        if (FindObjectOfType<FontDecreaser>().introClosed)
            FindObjectOfType<AudioManager>().RandomMusic(GameMusic);
        // --------------------------- controller tempo per aggiornamento sync ---------------------------
        SyncTurnAndBlockers();

        // --------------------------- updater generale ---------------------------

        UpdateVillageUI();

        // --------------------------- updater dati fattoria - tempo reale ---------------------------

        player.setCitizensMax(fattoria.getAbitantiMax());
        UpdateFarmUI();

        // --------------------------- updater dati fabbro - tempo reale ---------------------------

        UpdateBlacksmithUI();

        // --------------------------- updater dati caserma - tempo reale ---------------------------

        UpdateBarracksUI();
        // --------------------------- updater dati Miniera - tempo reale ---------------------------

        UpdateMineUI();
        // --------------------------- updater dati Gilda - tempo reale ---------------------------
        UpdateGuildUI();
    }



    public void onTapNextSeason()
    { 
        isTurnDone = true;
        FindObjectOfType<AudioManager>().PlayEffectFaded(newTurnSound);
    }
    
    public void onSkipTurn()
    {

        player.setSkipMoney(fattoria.getGoldFattoria() + miniera.getgoldMiniera() + 2 * player.getCitizens() + fabbro.getSoldiPiccone() + fabbro.getSoldiZappa() - FindObjectOfType<Events>().GoldMalusEffects(player, swordsmen, archers, riders));
        player.setMoney(); // cambia definitivamente i soldi, al resto ci pensa Update   

        player.setTempCitizens(fattoria.getCrescitaAbitanti() - FindObjectOfType<Events>().CitizensMalusEffects(player, swordsmen, archers, riders, fattoria));
        player.setCitizens(); // cambia il numero di cittadini liberi, al resto ci pensa Update in funzione del numero di soldati riportato sotto


        //player.setCitizensMax(fattoria.getAbitantiMax());


        caserma.aggiornaMax(); //aggiornamento soldati reclutabili nel turno

        swordsmen.setTotal(); // ricalcolo tot spadaccini
        archers.setTotal(); // ricalcolo tot arcieri
        riders.setTotal(); // ricalcolo tot cavalieri

        player.setPopulation(player.getCitizens() + swordsmen.getTotal() + archers.getTotal() + riders.getTotal()); // ricalcolo popolazione attuale

        player.nextTurn(); // cambia il numero del turno attuale, al resto ci pensa Update
        Debug.LogError(player.getTurn());

        manager.riassegnaSoldati(player, swordsmen, archers, riders); // riassegna i soldati che tornano dalle battaglie (betatesting)
        manager.gildamexritorno(player, gilda);  //betatesting

        FindObjectOfType<Events>().eventTurnsDecreaser();
        FindObjectOfType<Events>().SecondaryEventStarter(player, swordsmen, archers, riders); // avvio evento secondario, fa controlli sugli status attuali dell'oggetto events ed eventualmente inizializza un evento secondario
        FindObjectOfType<Events>().EventStarter(player, swordsmen, archers, riders); // avvio evento primario, non si avvia se e' in corso uno secondario
        SaveGame();
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
        minePanel.SetActive(false);
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
        minePanel.SetActive(false);
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
        minePanel.SetActive(false);

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
        minePanel.SetActive(false);
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
        minePanel.SetActive(false);
    }

    public void onTapMine()
    {
        FindObjectOfType<AudioManager>().PlayEffectFaded(mine_pickaxe);

        gamePanel.SetActive(true); // sempre true
        cityPanel.SetActive(false); //
        farmPanel.SetActive(false);
        casermaPanel.SetActive(false);
        guildPanel.SetActive(false);
        fabbroPanel.SetActive(false); //
        minePanel.SetActive(true);
    }

    // tasti fattoria

    public void onUpgradeFarm()
    {
        if(fattoria.getLvlFattoria() < 5 && (player.getMoney() >= fattoria.getLvlUpCost()) ){
            player.setRapidMoney(-fattoria.getLvlUpCost());
            fattoria.lvlUpFattoria();
        }

    }

    // tasti fabbro

    public void onUpgradeFabbro()
    {
        if (fabbro.getlvl() < 5 && (player.getMoney() >= fabbro.getcosto()))
        {
            player.setRapidMoney(-fabbro.getcosto());
            fabbro.lvlup();
        }
    }


    public void upgradeArmi()
    {
        if ((fabbro.getArmi()+1) <= fabbro.getlvl() && fabbro.getCostoNumPotenziamenti(1) <= player.getMoney())
        {
            player.setRapidMoney(-fabbro.getCostoNumPotenziamenti(1));
            fabbro.powerUPArmi(swordsmen, archers, riders);
        }
    }
    public void upgradeArmature()
    {
        if ((fabbro.getArmature()+1) <= fabbro.getlvl() && fabbro.getCostoNumPotenziamenti(2) <= player.getMoney())
        {
            player.setRapidMoney(-fabbro.getCostoNumPotenziamenti(2));
            fabbro.powerUPArmature(swordsmen, archers, riders);
        }
    }
    public void upgradeZappa()
    {
        if ((fabbro.getZappa()+1) <= fabbro.getlvl() && fabbro.getCostoNumPotenziamenti(3) <= player.getMoney())
        {
            player.setRapidMoney(-fabbro.getCostoNumPotenziamenti(3));
            fabbro.powerUPZappa(fattoria);
        }
    }
    public void upgradePiccone()
    {
        if ((fabbro.getPiccone()+1) <= fabbro.getlvl() && fabbro.getCostoNumPotenziamenti(4) <= player.getMoney())
        {
            player.setRapidMoney(-fabbro.getCostoNumPotenziamenti(4));
            fabbro.powerUPPiccone(miniera);
        }
    }











    // tasti caserma

    public void onUpgradeCaserma()
    {
        if (caserma.getLvl() < 5 && (player.getMoney() >= caserma.getcosto()))
        {
            player.setRapidMoney(-caserma.getcosto());
            caserma.lvlUpBarrack();
            caserma.setReclutamentoMaxMoment(-10);
        }
    }
    public void onRecruitSwordsmen()
    {
        FindObjectOfType<SliderController>().onPressStartTraining(1, player, caserma, swordsmen, archers, riders);
    }

    public void onRecruitArchers()
    {
        FindObjectOfType<SliderController>().onPressStartTraining(2, player, caserma, swordsmen, archers, riders);
    }

    public void onRecruitRiders()
    {
        FindObjectOfType<SliderController>().onPressStartTraining(3, player, caserma, swordsmen, archers, riders);
    }

    public void onDisbandTroops()
    {
        FindObjectOfType<SliderController>().onPressDisbandTroops(player, swordsmen, archers, riders);
    }
 



    // tasti miniera
    public void onUpgradeMiniera()
    {
        if (miniera.getLvlMiniera() < 5 && (player.getMoney() >= miniera.getcosto()))
        {
            player.setRapidMoney(-miniera.getcosto());
            miniera.lvlUpMiniera();
        }
    }



    //tasti gilda
    public void onUpgradeGilda()
    {
        if (gilda.getlvl() < 5 && (player.getMoney() >= gilda.getcosto()))
        {
            player.setRapidMoney(-gilda.getcosto());
            gilda.lvlup();
        }
    }
    //--------------------------------------------------------------spedizione

    public void onSpedizione1() // prima tipologia di spedizione
    {
        if (gilda.getcontrollosped1() == 0)
        {
            gilda.spedizione(player, swordsmen, archers, riders, 1, manager);
            gilda.setcontrollosped1(1);
        }
        else if (gilda.getcontrollosped2() == 0)
        {
            gilda.spedizione(player, swordsmen, archers, riders, 1, manager);
            gilda.setcontrollosped2(1);
        }

    }

    public void onSpedizione2() // prima tipologia di spedizione
    {
        if (gilda.getcontrollosped1() == 0)
        {
            gilda.spedizione(player, swordsmen, archers, riders, 2, manager);
            gilda.setcontrollosped1(1);
        }
        else if (gilda.getcontrollosped2() == 0)
        {
            gilda.spedizione(player, swordsmen, archers, riders, 2, manager);
            gilda.setcontrollosped2(1);
        }

    }
    public void onSpedizione3() // prima tipologia di spedizione
    {
        if (gilda.getcontrollosped1() == 0)
        {
            gilda.spedizione(player, swordsmen, archers, riders, 3, manager);
            gilda.setcontrollosped1(1);
        }
        else if (gilda.getcontrollosped2() == 0)
        {
            gilda.spedizione(player, swordsmen, archers, riders, 3, manager);
            gilda.setcontrollosped2(1);
        }

    }
    public void onSpedizione4() // prima tipologia di spedizione
    {
        if (gilda.getcontrollosped1() == 0)
        {
            gilda.spedizione(player, swordsmen, archers, riders, 4, manager);
            gilda.setcontrollosped1(1);
        }
        else if (gilda.getcontrollosped2() == 0)
        {
            gilda.spedizione(player, swordsmen, archers, riders, 4, manager);
            gilda.setcontrollosped2(1);
        }

    }

    public void onSpedizione5() // prima tipologia di spedizione
    {
        if (gilda.getcontrollosped1() == 0)
        {
            gilda.spedizione(player, swordsmen, archers, riders, 5, manager);
            gilda.setcontrollosped1(1);
        }
        else if (gilda.getcontrollosped2() == 0)
        {
            gilda.spedizione(player, swordsmen, archers, riders, 5, manager);
            gilda.setcontrollosped2(1);
        }

    }





    /*----------------save------load------------------*/

    public void SaveGame()
    {
        SaveSystem.SaveGame(CityNameUI.text,player,FindObjectOfType<Events>(),fattoria,caserma,swordsmen,archers,riders,miniera,fabbro,gilda);
    }

    public void LoadGame()
    {
        GameData data = SaveSystem.LoadGame();

        CityNameUI.text = data.cityName;

        player.player_turn = data.player_turn;
        player.setPopulation(data.player_population);
        player.player_citizens = data.player_citizens;
        player.setCitizensMax(data.player_citizensMAX);
        player.setCitizens();
        
        player.temp_player_citizens = data.temp_player_citizens;
        //player.setTempCitizens(data.temp_player_citizens);
        player.player_money = data.player_money;


        FindObjectOfType<Events>().aqueduct = data.aqueduct;
        FindObjectOfType<Events>().response[0] = data.response;
        FindObjectOfType<Events>().aqueductMalusTurnsLeft = data.aqueductMalusTurnsLeft;
        FindObjectOfType<Events>().aqueductEffectMalus = data.aqueductEffectMalus;
        FindObjectOfType<Events>().citydefenseproject = data.citydefenseproject;
        FindObjectOfType<Events>().aqueductSecondary = data.aqueductSecondary;
        FindObjectOfType<Events>().aqueductTurnsLeft = data.aqueductTurnsLeft;
        
        FindObjectOfType<Events>().attendingSecondaryEvent = data.attendingSecondaryEvent;


        fattoria.setLvlFattoria(data.farmLvl);
        fattoria.setAbitantiMax(data.abitantiMax);
        fattoria.setCrescitaAbitanti(data.crescitaAbitanti);
        fattoria.setGoldFattoria(data.farmGold);
        fattoria.setLvlUpCost(data.farmLvlUpCost);

        miniera.lvl = data.minelvl;
        miniera.gold = data.minegold;
        miniera.carboneHigh = data.carboneHigh;
        miniera.costo = data.minecosto;

        caserma.lvl = data.casermalvl;
        caserma.reclutamentoMAX = data.reclutamentoMAX;
        caserma.bonusBarrack = data.bonusBarrack;
        caserma.reclutamentoMaxMoment = data.reclutamentoMaxMoment;
        caserma.costo = data.casermaLvlUpCost;

        swordsmen.total_swordsmen = data.total_swordsmen;
        swordsmen.setTempTotal(data.temp_total_swordsmen);
        swordsmen.setTotal();
        archers.total_archers = data.total_archers;
        archers.setTempTotal(data.temp_total_archers);
        archers.setTotal();
        riders.total_riders = data.total_riders;
        riders.setTempTotal(data.temp_total_riders);
        riders.setTotal();

        fabbro.lvl = data.fablvl;
        fabbro.costo = data.fabcosto;
        fabbro.armi  = data.armi;
        fabbro.armature = data.armature;
        fabbro.zappa = data.zappa;
        fabbro.goldzappa = data.goldzappa;
        fabbro.piccone = data.piccone;
        fabbro.goldpiccone = data.goldpiccone;

        
        gilda.lvl = data.gildalvl;
        gilda.costo = data.gildacosto;
        gilda.sped2 = data.sped2;
        gilda.sped3 = data.sped3;
        gilda.sped4 = data.sped4;
        gilda.sped5 = data.sped5;
        gilda.controllosped1 = data.controllosped1;
        gilda.controllosped2 = data.controllosped2;


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
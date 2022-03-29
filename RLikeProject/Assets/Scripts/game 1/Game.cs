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

    public bool tutorialW;
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
    public Text infoswordmanQTYUI;
    public Text infoarcherQTYUI;
    public Text inforiderQTYUI;
    public Text infoswordmanATKUI;
    public Text infoarcherATKUI;
    public Text inforiderATKUI;
    public Text infoswordmanDEFUI;
    public Text infoarcherDEFUI;
    public Text inforiderDEFUI;
    public Text infoswordmanTATKUI;
    public Text infoarcherTATKUI;
    public Text inforiderTATKUI;
    public Text infoswordmanTDEFUI;
    public Text infoarcherTDEFUI;
    public Text inforiderTDEFUI;





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
    public Text gildanumspedUI;
    public Button Exped1;
    public Button Exped2;
    public Button Exped3;
    public Button Exped4;
    public Button Exped5;

    public Text gildabonus1;
    public Text gildabonus2;
    public Text gildabonus3;
    public Text gildabonus4;
    public Text gildalvlwall;
    public Text gildalvlfields;
    public Text gildacostowall;
    public Text gildacostofields;


    public Text capitanonameUI;
    public Text capitanolvlUI;
    public Text capitanoATKUI;
    public Text capitanoDEFUI;
    public Text capitanoBonusUI;
    public Text capitanoTalent1UI;
    public Text capitanoTalent2UI;
    public Text capitanoTalent3UI;
    public Text capitanoDescriptionUI;

    public Text gsped1UI;
    public Text gsped11UI;
    public Text gsped12UI;
    public Text gsped2UI;
    public Text gsped21UI;
    public Text gsped22UI;
    public Text gsped3UI;
    public Text gsped31UI;
    public Text gsped32UI;
    public Text gsped33UI;
    public Text gsped4UI;
    public Text gsped41UI;
    public Text gsped42UI;
    public Text gsped43UI;
    public Text gsped5UI;
    public Text gsped51UI;
    public Text gsped52UI;
    public Text gsped53UI;




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
    public Color32 yellowgood = new Color32(149, 74, 8, 255);

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
        if (capitano.getcreato() == false) { capitano.setcreato(); }
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
        fabbroZappaUI.text = "+" + (fabbro.getZappa() * 10) + "%";
        fabbroPicconeUI.text = "+" + (fabbro.getPiccone()*5) + "%";


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

          infoswordmanQTYUI.text = "" + swordsmen.getTotal();
          infoarcherQTYUI.text = "" + archers.getTotal();
          inforiderQTYUI.text = "" + riders.getTotal();
          infoswordmanATKUI.text = "" + swordsmen.getAtk();
          infoarcherATKUI.text = "" + archers.getAtk();
          inforiderATKUI.text = "" + riders.getAtk();
          infoswordmanDEFUI.text = "" + swordsmen.getDef() ;
          infoarcherDEFUI.text = "" + archers.getDef();
          inforiderDEFUI.text = "" + riders.getDef();
          infoswordmanTATKUI.text =  "" + (swordsmen.getAtk() * swordsmen.getTotal()) ;
          infoarcherTATKUI.text = "" + (archers.getTotal() * archers.getAtk());
          inforiderTATKUI.text = "" + (riders.getAtk() * riders.getTotal());
          infoswordmanTDEFUI.text = "" + ( swordsmen.getTotal() * swordsmen.getDef());
          infoarcherTDEFUI.text = "" + (archers.getDef() * archers.getTotal());
          inforiderTDEFUI.text = "" + (riders.getTotal() * riders.getDef());




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

        if (gilda.getsped1() == 1)
        {
            Exped1.interactable = true;
         
        }
        else
        {
            Exped1.interactable = false;
          
        }
        if (gilda.getsped2() == 1)
        {
            Exped2.interactable = true;

        }
        else
        {
            Exped2.interactable = false;
        }
        if (gilda.getsped3() == 1)
        {
            Exped3.interactable = true;
        }
        else
        {
            Exped3.interactable = false;
        }
        if (gilda.getsped4() == 1)
        {
            Exped4.interactable = true;
        }
        else
        {
            Exped4.interactable = false;
        }
        if (gilda.getsped5() == 1)
        {
            Exped5.interactable = true;
        }
        else
        {
            Exped5.interactable = false;
        }


        gildanumspedUI.text = gilda.segnalanumsped();
        if (gildanumspedUI.text == "0/2")
        {
            gildanumspedUI.color = blacknormal;
        }
        if (gildanumspedUI.text == "1/2")
        {
            gildanumspedUI.color = yellowgood;
        }
        if (gildanumspedUI.text == "2/2")
        {
            gildanumspedUI.color = darkred;
        }



        gildabonus1.text = "" + player.getBonusWall() + "%";
            gildabonus2.text = "" + player.getBonusCity() + "%";
            gildabonus3.text = "" + player.getBonusFar() + "%";
            gildabonus4.text = "" + player.getBonusDemoniac() + "%";
            gildalvlwall.text = "lvl " + (player.getlvlwall() +1);
            gildalvlfields.text = "lvl " + (player.getlvlfield()+1);


        gildacostowall.text = player.getcostowallmex();
        if (player.getMoney() < player.getcostowall() || player.getlvlwall() == 4)
        {
            gildacostowall.color = darkred;
        }
        else
        {
            gildacostowall.color = blacknormal;
        }

        gildacostofields.text = player.getcostofieldmex();

        if (player.getMoney() < player.getcostofield() || player.getlvlfield() == 4)
        {
            gildacostofields.color = darkred;
        }
        else
        {
            gildacostofields.color = blacknormal;
        }


        capitanonameUI.text = "Captain " + capitano.getName();
        capitanolvlUI.text = "lvl " + capitano.getLvl();
        capitanoATKUI.text = "" + capitano.getAtk();
        capitanoDEFUI.text = "" + capitano.getDef();
        capitanoBonusUI.text = "+" + capitano.getBonusBattle() + "%";
                     

             capitanoTalent1UI.text = capitano.getPerk1();
            if (capitano.getLvl() >= 3) { capitanoTalent2UI.text = capitano.getPerk2(); }
            else { capitanoTalent2UI.text = ""; }
            if (capitano.getLvl() == 6) { capitanoTalent3UI.text = capitano.getPerk3(); }
            else { capitanoTalent3UI.text = ""; }

            capitanoDescriptionUI.text = capitano.getFinalComment();



        if ((swordsmen.getTotal() < 5 || archers.getTotal() < 5) && Exped1.interactable) { gsped1UI.color = darkred; gsped11UI.color = darkred; gsped12UI.color = darkred; }
        else { gsped1UI.color = blacknormal; gsped11UI.color = blacknormal; gsped12UI.color = blacknormal; }
        if ((swordsmen.getTotal() < 10 || archers.getTotal() < 10) && Exped2.interactable) { gsped2UI.color = darkred; gsped21UI.color = darkred; gsped22UI.color = darkred; }
        else { gsped2UI.color = blacknormal; gsped21UI.color = blacknormal; gsped22UI.color = blacknormal; }
        if ((swordsmen.getTotal() < 10 || archers.getTotal() < 10 || riders.getTotal() < 10) && Exped3.interactable) { gsped3UI.color = darkred; gsped31UI.color = darkred; gsped32UI.color = darkred; gsped33UI.color = darkred; }
        else { gsped3UI.color = blacknormal; gsped31UI.color = blacknormal; gsped32UI.color = blacknormal; gsped33UI.color = blacknormal; }
        if ((swordsmen.getTotal() < 15 || archers.getTotal() < 15 || riders.getTotal() < 10) && Exped4.interactable) { gsped4UI.color = darkred; gsped41UI.color = darkred; gsped42UI.color = darkred; gsped43UI.color = darkred; }
        else { gsped4UI.color = blacknormal; gsped41UI.color = blacknormal; gsped42UI.color = blacknormal; gsped43UI.color = blacknormal; }
        if ((swordsmen.getTotal() < 20 || archers.getTotal() < 20 || riders.getTotal() < 10) && Exped5.interactable) { gsped5UI.color = darkred; gsped51UI.color = darkred; gsped52UI.color = darkred; gsped53UI.color = darkred; }
        else { gsped5UI.color = blacknormal; gsped51UI.color = blacknormal; gsped52UI.color = blacknormal; gsped53UI.color = blacknormal; }





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
        FindObjectOfType<Events>().attendingMainEvent = true; // si da per scontato che stia partecipando ad un evento, qualora non dovesse scattare Events.EventStarter settera a false a fine tentativo scelta evento

        player.setSkipMoney(fattoria.getGoldFattoria() + miniera.getgoldMiniera() + 2 * player.getCitizens() + fabbro.getSoldiPiccone() + fabbro.getSoldiZappa() - FindObjectOfType<Events>().GoldMalusEffects(player, swordsmen, archers, riders));
        player.setMoney(); // cambia definitivamente i soldi, al resto ci pensa Update   
        player.setPopulation(player.getCitizens() + swordsmen.getTotal() + archers.getTotal() + riders.getTotal()); // prima volta necessaria
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
        // audio effect
        FindObjectOfType<AudioManager>().PlayEffectFaded(village_mapUnfold);

        gamePanel.SetActive(true); // sempre true
        cityPanel.SetActive(true); //
        farmPanel.SetActive(false);
        casermaPanel.SetActive(false);
        guildPanel.SetActive(false);
        fabbroPanel.SetActive(false);
        minePanel.SetActive(false);

        FindObjectOfType<Tutorial>().OnFirstTapVillage();
    }

    public void onTapFarm()
    {
        // audio effect
        FindObjectOfType<AudioManager>().PlayEffectFaded(farm_cowbells);

        gamePanel.SetActive(true); // sempre true
        cityPanel.SetActive(false); //
        farmPanel.SetActive(true); // 
        casermaPanel.SetActive(false);
        guildPanel.SetActive(false);
        fabbroPanel.SetActive(false);
        minePanel.SetActive(false);

        FindObjectOfType<Tutorial>().OnFirstTapFarm();
    }
    public void onTapCaserma()
    {
        // audio effect
        FindObjectOfType<AudioManager>().PlayEffectFaded(barracks_swordFight);

        gamePanel.SetActive(true); // sempre true
        cityPanel.SetActive(false); //
        farmPanel.SetActive(false);
        casermaPanel.SetActive(true); //
        guildPanel.SetActive(false);
        fabbroPanel.SetActive(false);
        minePanel.SetActive(false);

        FindObjectOfType<Tutorial>().OnFirstTapBarracks();
    }

    public void onTapGuild()
    {
        // audio effect
        FindObjectOfType<AudioManager>().PlayEffectFaded(guild_paperwork);

        gamePanel.SetActive(true); // sempre true
        cityPanel.SetActive(false); //
        farmPanel.SetActive(false);
        casermaPanel.SetActive(false);
        guildPanel.SetActive(true); //
        fabbroPanel.SetActive(false);
        minePanel.SetActive(false);

        FindObjectOfType<Tutorial>().OnFirstTapGuild();
    }

    public void onTapFabbro()
    {
        // audio effect
        FindObjectOfType<AudioManager>().PlayEffectFaded(blacksmith_Anvil);

        gamePanel.SetActive(true); // sempre true
        cityPanel.SetActive(false); //
        farmPanel.SetActive(false);
        casermaPanel.SetActive(false);
        guildPanel.SetActive(false);
        fabbroPanel.SetActive(true); //
        minePanel.SetActive(false);

        FindObjectOfType<Tutorial>().OnFirstTapBlacksmith();
    }

    public void onTapMine()
    {
        // audio effect
        FindObjectOfType<AudioManager>().PlayEffectFaded(mine_pickaxe);

        gamePanel.SetActive(true); // sempre true
        cityPanel.SetActive(false); //
        farmPanel.SetActive(false);
        casermaPanel.SetActive(false);
        guildPanel.SetActive(false);
        fabbroPanel.SetActive(false); //
        minePanel.SetActive(true);

        FindObjectOfType<Tutorial>().OnFirstTapMine();
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

    public void onUpgradeWall()
    {
        if (player.getlvlwall() < 4 && (player.getMoney() >= player.getcostowall()))
        {
            player.setRapidMoney(-player.getcostowall());
            player.lvlupWall();
        }
    }

    public void onUpgradeField()
    {
        if (player.getlvlfield() < 4 && (player.getMoney() >= player.getcostofield()))
        {
            player.setRapidMoney(-player.getcostofield());
            player.lvlupfield();
        }
    }






    //--------------------------------------------------------------spedizione

    public void onSpedizione1() // prima tipologia di spedizione
    {
        Debug.LogError("spedizione1 = " + gilda.getcontrollosped1());
        Debug.LogError("spedizione2 = " + gilda.getcontrollosped2());
        if (gilda.getcontrollosped1() == 0 && swordsmen.getTotal() >= 5 && archers.getTotal() >= 5)
        {
            Debug.LogError("La spedizione parte");
            gilda.spedizione(player, swordsmen, archers, riders, 1, manager);
            gilda.setcontrollosped1(1);
        }
        else if (gilda.getcontrollosped2() == 0 && swordsmen.getTotal() >= 5 && archers.getTotal() >= 5)
        {
            gilda.spedizione(player, swordsmen, archers, riders, 1, manager);
            gilda.setcontrollosped2(1);
        }

    }

    public void onSpedizione2() // prima tipologia di spedizione
    {
        if (gilda.getcontrollosped1() == 0 && swordsmen.getTotal() >= 10 && archers.getTotal() >= 10)
        {
            gilda.spedizione(player, swordsmen, archers, riders, 2, manager);
            gilda.setcontrollosped1(1);
        }
        else if (gilda.getcontrollosped2() == 0 && swordsmen.getTotal() >= 10 && archers.getTotal() >= 10)
        {
            gilda.spedizione(player, swordsmen, archers, riders, 2, manager);
            gilda.setcontrollosped2(1);
        }

    }
    public void onSpedizione3() // prima tipologia di spedizione
    {
        if (gilda.getcontrollosped1() == 0 && swordsmen.getTotal() >= 10 && archers.getTotal() >= 10 && riders.getTotal() >= 10 )
        {
            gilda.spedizione(player, swordsmen, archers, riders, 3, manager);
            gilda.setcontrollosped1(1);
        }
        else if (gilda.getcontrollosped2() == 0 && swordsmen.getTotal() >= 10 && archers.getTotal() >= 10 && riders.getTotal() >= 10)
        {
            gilda.spedizione(player, swordsmen, archers, riders, 3, manager);
            gilda.setcontrollosped2(1);
        }

    }
    public void onSpedizione4() // prima tipologia di spedizione
    {
        if (gilda.getcontrollosped1() == 0 && swordsmen.getTotal() >= 15 && archers.getTotal() >= 15 && riders.getTotal() >= 10)
        {
            gilda.spedizione(player, swordsmen, archers, riders, 4, manager);
            gilda.setcontrollosped1(1);
        }
        else if (gilda.getcontrollosped2() == 0 && swordsmen.getTotal() >= 15 && archers.getTotal() >= 15 && riders.getTotal() >= 10)
        {
            gilda.spedizione(player, swordsmen, archers, riders, 4, manager);
            gilda.setcontrollosped2(1);
        }

    }

    public void onSpedizione5() // prima tipologia di spedizione
    {
        if (gilda.getcontrollosped1() == 0 && swordsmen.getTotal() >= 20 && archers.getTotal() >= 20 && riders.getTotal() >= 10)
        {
            gilda.spedizione(player, swordsmen, archers, riders, 5, manager);
            gilda.setcontrollosped1(1);
        }
        else if (gilda.getcontrollosped2() == 0 && swordsmen.getTotal() >= 20 && archers.getTotal() >= 20 && riders.getTotal() >= 10)
        {
            gilda.spedizione(player, swordsmen, archers, riders, 5, manager);
            gilda.setcontrollosped2(1);
        }

    }





    /*----------------save------load------------------*/

    public void SaveGame()
    {
        SaveSystem.SaveGame(CityNameUI.text,player,
            FindObjectOfType<Events>(),fattoria,
            caserma,swordsmen,archers,riders,miniera,
            fabbro,gilda, FindObjectOfType<Tutorial>(),
            FindObjectOfType<OldSoldiersManager>());
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

        player.bonusBattle = data.bonusBattle;
        player.bonusWall = data.bonusWall;
        player.bonusCity = data.bonusCity;
        player.bonusFar = data.bonusFar;
        player.bonusDemoniac = data.bonusDemoniac;
        player.lvlwall = data.lvlwall;
        player.lvlfield = data.lvlfield;
        player.soldiersaway = data.soldiersaway;

        /*tutorial*/
        FindObjectOfType<Tutorial>().welcomeTutorial = data.welcomeTutorial;
        tutorialW = data.welcomeTutorial;
        FindObjectOfType<Tutorial>().villageTutorial = data.villageTutorial;
        FindObjectOfType<Tutorial>().farmTutorial = data.farmTutorial;
        FindObjectOfType<Tutorial>().barracksTutorial = data.barracksTutorial;
        FindObjectOfType<Tutorial>().blacksmithTutorial = data.blacksmithTutorial;
        FindObjectOfType<Tutorial>().guildTutorial = data.guildTutorial;
        FindObjectOfType<Tutorial>().mineTutorial = data.mineTutorial;
        FindObjectOfType<Tutorial>().bonusTutorial = data.bonusTutorial;

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

        /*soldati*/
        swordsmen.total_swordsmen = data.total_swordsmen;
        swordsmen.setTempTotal(data.temp_total_swordsmen);
        swordsmen.setTotal();
        swordsmen.atk_swordsmen = data.atk_swordsmen;
        swordsmen.temp_atk_swordsmen = data.temp_atk_swordsmen;
        swordsmen.def_swordsmen = data.def_swordsmen;
        swordsmen.temp_def_swordsmen = data.temp_def_swordsmen;
        swordsmen.bonus_swordsmen = data.bonus_swordsmen;
        swordsmen.momentswordman = data.momentswordman;
        swordsmen.momentDeadswordman = data.momentDeadswordman;

        archers.total_archers = data.total_archers;
        archers.setTempTotal(data.temp_total_archers);
        archers.setTotal();
        archers.atk_archers = data.atk_archers;
        archers.temp_atk_archers = data.temp_atk_archers;
        archers.def_archers = data.def_archers;
        archers.temp_def_archers = data.temp_def_archers;
        archers.bonus_archers = data.bonus_archers;
        archers.momentarcher = data.momentarcher;
        archers.momentDeadArcher = data.momentDeadArcher;


        riders.total_riders = data.total_riders;
        riders.setTempTotal(data.temp_total_riders);
        riders.setTotal();
        riders.atk_riders = data.atk_riders;
        riders.temp_atk_riders = data.temp_atk_riders;
        riders.def_riders = data.def_riders;
        riders.temp_def_riders = data.temp_def_riders;
        riders.bonus_riders = data.bonus_riders;
        riders.momentrider = data.momentrider;
        riders.momentDeadRider = data.momentDeadRider;


        fabbro.lvl = data.fablvl;
        fabbro.costo = data.fabcosto;
        fabbro.armi  = data.armi;
        fabbro.armature = data.armature;
        fabbro.zappa = data.zappa;
        fabbro.goldzappa = data.goldzappa;
        fabbro.piccone = data.piccone;
        fabbro.goldpiccone = data.goldpiccone;

        /*gilda*/

        gilda.lvl = data.gildalvl;
        gilda.costo = data.gildacosto;
        gilda.sped1 = data.sped1;
        gilda.sped2 = data.sped2;
        gilda.sped3 = data.sped3;
        gilda.sped4 = data.sped4;
        gilda.sped5 = data.sped5;
        gilda.controllosped1 = data.controllosped1;
        gilda.controllosped2 = data.controllosped2;

        /*OldSoldiers*/

        FindObjectOfType<OldSoldiersManager>().sword1 = data.sword1;
        FindObjectOfType<OldSoldiersManager>().arc1 = data.arc1;
        FindObjectOfType<OldSoldiersManager>().rid1 = data.rid1;
        FindObjectOfType<OldSoldiersManager>().turn1 = data.turn1;

        FindObjectOfType<OldSoldiersManager>().sword2 = data.sword2;
        FindObjectOfType<OldSoldiersManager>().arc2 = data.arc2;
        FindObjectOfType<OldSoldiersManager>().rid2 = data.rid2;
        FindObjectOfType<OldSoldiersManager>().turn2 = data.turn2;

        FindObjectOfType<OldSoldiersManager>().sword3 = data.sword3;
        FindObjectOfType<OldSoldiersManager>().arc3 = data.arc3;
        FindObjectOfType<OldSoldiersManager>().rid3 = data.rid3;
        FindObjectOfType<OldSoldiersManager>().turn3 = data.turn3;

        FindObjectOfType<OldSoldiersManager>().sword4 = data.sword4;
        FindObjectOfType<OldSoldiersManager>().arc4 = data.arc4;
        FindObjectOfType<OldSoldiersManager>().rid4 = data.rid4;
        FindObjectOfType<OldSoldiersManager>().turn4 = data.turn4;

        FindObjectOfType<OldSoldiersManager>().sword5 = data.sword5;
        FindObjectOfType<OldSoldiersManager>().arc5 = data.arc5;
        FindObjectOfType<OldSoldiersManager>().rid5 = data.rid5;
        FindObjectOfType<OldSoldiersManager>().turn5 = data.turn5;

        FindObjectOfType<OldSoldiersManager>().swordgilda1 = data.swordgilda1;
        FindObjectOfType<OldSoldiersManager>().arcgilda1 = data.arcgilda1;
        FindObjectOfType<OldSoldiersManager>().ridgilda1 = data.ridgilda1;
        FindObjectOfType<OldSoldiersManager>().tipologia1 = data.tipologia1;
        FindObjectOfType<OldSoldiersManager>().moltiplicatore1 = data.moltiplicatore1;
        FindObjectOfType<OldSoldiersManager>().turngilda1 = data.turngilda1;

        FindObjectOfType<OldSoldiersManager>().swordgilda2 = data.swordgilda2;
        FindObjectOfType<OldSoldiersManager>().arcgilda2 = data.arcgilda2;
        FindObjectOfType<OldSoldiersManager>().ridgilda2 = data.ridgilda2;
        FindObjectOfType<OldSoldiersManager>().tipologia2 = data.tipologia2;
        FindObjectOfType<OldSoldiersManager>().moltiplicatore2 = data.moltiplicatore2;
        FindObjectOfType<OldSoldiersManager>().turngilda2 = data.turngilda2;
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
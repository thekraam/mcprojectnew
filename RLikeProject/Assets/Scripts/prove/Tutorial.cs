using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [Header("Welcome Tutorial and Continue")]
    public Button continueButton;
    public GameObject parentContinueButton;
    public GameObject welcomePanel1;
    public GameObject welcomePanel2;

    [Header("Village Tutorial")]
    public GameObject villagePanel1;
    public GameObject villagePanel2;

    [Header("Farm Tutorial")]
    public GameObject farmPanel;

    [Header("Barracks Tutorial")]
    public GameObject barracksPanel1;
    public GameObject barracksPanel2;

    [Header("Blacksmith Tutorial")]
    public GameObject blacksmithPanel;

    [Header("Mine Tutorial")]
    public GameObject minePanel;

    [Header("Guild Tutorial")]
    public GameObject guildPanel1;
    public GameObject guildPanel2;
    public GameObject bonusPanel;

    [Header("Misc")]
    public GameObject bgPanel;


    bool welcomeTutorial = true;
    bool villageTutorial = true;
    bool farmTutorial = true;
    bool barracksTutorial = true;
    bool blacksmithTutorial = true;
    bool guildTutorial = true;
    bool mineTutorial = true;
    bool bonusTutorial = true;


    ///////////////////////// TUTORIAL BENVENUTO //////////////////////////////////////
    void Start()
    {
        if (welcomeTutorial)
        {
            welcomeTutorial = false;
            bgPanel.gameObject.SetActive(true);
            parentContinueButton.gameObject.SetActive(true);
            welcomePanel1.SetActive(true);
            continueButton.onClick.AddListener(WelcomePanel1Disabler); // aggiungi funzionalitą bottone
        }
    }

    private void WelcomePanel1Disabler()
    {
        // disabilita primo panel
        welcomePanel1.SetActive(false);
        continueButton.onClick.RemoveAllListeners();

        // abilita secondo panel
        welcomePanel2.SetActive(true);
        continueButton.onClick.AddListener(WelcomePanel2Disabler);
    }
    private void WelcomePanel2Disabler()
    {
        welcomePanel2.SetActive(false);
        continueButton.onClick.RemoveAllListeners();
        parentContinueButton.gameObject.SetActive(false);
        bgPanel.gameObject.SetActive(false);
    }


    ///////////////////////// TUTORIAL GILDA //////////////////////////////////////
    public void OnFirstTapGuild()
    {
        if (guildTutorial)
        {
            guildTutorial = false;
            bgPanel.gameObject.SetActive(true);
            parentContinueButton.gameObject.SetActive(true);
            guildPanel1.SetActive(true);
            continueButton.onClick.AddListener(GuildPanel1Disabler);
        }
    }

    private void GuildPanel1Disabler()
    {
        guildPanel1.SetActive(false);
        continueButton.onClick.RemoveAllListeners();

        guildPanel2.SetActive(true);
        continueButton.onClick.AddListener(GuildPanel2Disabler);
    }

    private void GuildPanel2Disabler()
    {
        guildPanel2.SetActive(false);
        continueButton.onClick.RemoveAllListeners();
        parentContinueButton.gameObject.SetActive(false);
        bgPanel.gameObject.SetActive(false);
    }
    ///////////////////////// TUTORIAL BONUS GILDA //////////////////////////////////////
    
    public void OnFirstTapBonusButton()
    {
        if (bonusTutorial)
        {
            bonusTutorial = false;
            parentContinueButton.gameObject.SetActive(true);
            bonusPanel.SetActive(true);
            continueButton.onClick.AddListener(BonusPanelDisabler);
        }
    }

    private void BonusPanelDisabler()
    {
        bonusPanel.SetActive(false);
        continueButton.onClick.RemoveAllListeners();
        parentContinueButton.gameObject.SetActive(false);
    }

    ///////////////////////// TUTORIAL VILLAGGIO //////////////////////////////////////
    public void OnFirstTapVillage()
    {
        if (villageTutorial)
        {
            villageTutorial = false;
            bgPanel.gameObject.SetActive(true);
            parentContinueButton.gameObject.SetActive(true);
            villagePanel1.SetActive(true);
            continueButton.onClick.AddListener(VillagePanel1Disabler);
        }
    }

    private void VillagePanel1Disabler()
    {
        villagePanel1.SetActive(false);
        continueButton.onClick.RemoveAllListeners();

        villagePanel2.SetActive(true);
        continueButton.onClick.AddListener(VillagePanel2Disabler);
    }

    private void VillagePanel2Disabler()
    {
        villagePanel2.SetActive(false);
        continueButton.onClick.RemoveAllListeners();
        parentContinueButton.gameObject.SetActive(false);
        bgPanel.gameObject.SetActive(false);
    }

    ///////////////////////// TUTORIAL CASERMA //////////////////////////////////////
    
    public void OnFirstTapBarracks()
    {
        if (barracksTutorial)
        {
            barracksTutorial = false;
            bgPanel.gameObject.SetActive(true);
            parentContinueButton.gameObject.SetActive(true);
            barracksPanel1.SetActive(true);
            continueButton.onClick.AddListener(BarracksPanel1Disabler);
        }
    }

    private void BarracksPanel1Disabler()
    {
        barracksPanel1.SetActive(false);
        continueButton.onClick.RemoveAllListeners();

        barracksPanel2.SetActive(true);
        continueButton.onClick.AddListener(BarracksPanel2Disabler);
    }

    private void BarracksPanel2Disabler()
    {
        barracksPanel2.SetActive(false);
        continueButton.onClick.RemoveAllListeners();
        parentContinueButton.gameObject.SetActive(false);
        bgPanel.gameObject.SetActive(false);
    }

    ///////////////////////// TUTORIAL FARM //////////////////////////////////////
    
    public void OnFirstTapFarm()
    {
        if (farmTutorial)
        {
            farmTutorial = false;
            bgPanel.gameObject.SetActive(true);
            parentContinueButton.gameObject.SetActive(true);
            farmPanel.SetActive(true);
            continueButton.onClick.AddListener(FarmPanelDisabler);
        }
    }

    private void FarmPanelDisabler()
    {
        farmPanel.SetActive(false);
        continueButton.onClick.RemoveAllListeners();
        parentContinueButton.gameObject.SetActive(false);
        bgPanel.gameObject.SetActive(false);
    }

    ///////////////////////// TUTORIAL MINE //////////////////////////////////////
    
    public void OnFirstTapMine()
    {
        if (mineTutorial)
        {
            mineTutorial = false;
            bgPanel.gameObject.SetActive(true);
            parentContinueButton.gameObject.SetActive(true);
            minePanel.SetActive(true);
            continueButton.onClick.AddListener(MinePanelDisabler);
        }
    }

    private void MinePanelDisabler()
    {
        minePanel.SetActive(false);
        continueButton.onClick.RemoveAllListeners();
        parentContinueButton.gameObject.SetActive(false);
        bgPanel.gameObject.SetActive(false);
    }

    ///////////////////////// TUTORIAL MINE //////////////////////////////////////
    ///
    public void OnFirstTapBlacksmith()
    {
        if (blacksmithTutorial)
        {
            blacksmithTutorial = false;
            bgPanel.gameObject.SetActive(true);
            parentContinueButton.gameObject.SetActive(true);
            blacksmithPanel.SetActive(true);
            continueButton.onClick.AddListener(BlacksmithPanelDisabler);
        }
    }

    private void BlacksmithPanelDisabler()
    {
        blacksmithPanel.SetActive(false);
        continueButton.onClick.RemoveAllListeners();
        parentContinueButton.gameObject.SetActive(false);
        bgPanel.gameObject.SetActive(false);
    }
}

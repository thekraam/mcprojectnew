using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrepBattaglia : MonoBehaviour
{

    public Slider swordsmenSlider;
    public Slider archersSlider;
    public Slider ridersSlider;


    public Text selectedSwordsmenUI;
    public Text minSwordsmenUI;
    public Text maxSwordsmenUI;


    public Text selectedArchersUI;
    public Text minArchersUI;
    public Text maxArchersUI;

    public Text selectedRidersUI;
    public Text minRidersUI;
    public Text maxRidersUI;

    public GameObject resocontoBattagliaPanel;

    public Text nomeCap;
    public Text atkCap;
    public Text defCap;
    public Text bonusCap;
    public Text bonusTerry;
    public Text bonusTroops;
    public Text bonusTotal;
    public Text totalSelected;
    public Text totalAtk;
    public Text totalDef;

    public CanvasGroup battlePreparation;
    public CanvasGroup battleTransition;
    //public GameObject battleLive;

    private Captain1 capitanocorrente;
    private Caserma casermacorrente;
    private Player playercorrente;
    Soldiers.Swordsmen swordmencorrenti;
    Soldiers.Archers archercorrenti;
    Soldiers.Riders ridercorrenti;
    
    int x = 0;
    float capBonus = 0;
    float terriBonus = 0;
    float troopsBonus = 0;


    //pannello di vittoria

    public Text decisive;
    public Text Victory;
    public Text soldatigiocatore;
    public Text soldatiEnemy;
    public GameObject Alloro;
    public GameObject Spada;







    public IEnumerator effettoFadeOut(CanvasGroup currentCanvasGroup)
    {
        float choiceTime = 0f;
        while (choiceTime < 0.8f)
        {
            choiceTime += Time.deltaTime;
            currentCanvasGroup.alpha = Mathf.Lerp(1f, 0f, choiceTime / 0.8f); // da 0f a 1f si accende, da 1f a 0f si spegne
            yield return new WaitForSeconds(0.001f);
        }
        yield return new WaitForSeconds(0.001f);
        currentCanvasGroup.gameObject.SetActive(false);
    }

    public IEnumerator effettoFadeIn(CanvasGroup currentCanvasGroup)
    {
        currentCanvasGroup.gameObject.SetActive(true);
        float choiceTime = 0f;
        while (choiceTime < 0.8f)
        {
            choiceTime += Time.deltaTime;
            currentCanvasGroup.alpha = Mathf.Lerp(0f, 1f, choiceTime / 0.8f); // da 0f a 1f si accende, da 1f a 0f si spegne
            yield return new WaitForSeconds(0.001f);
        }
        yield return new WaitForSeconds(0.001f);
    }

    private IEnumerator AvvioEffettiTermineBattaglia()
    {
        battlePreparation.gameObject.SetActive(false);
        StartCoroutine(effettoFadeOut(battleTransition));
        StartCoroutine(effettoFadeOut(FindObjectOfType<KillList>().canvasContinue));
        yield return new WaitForSeconds(0.8f);
        FindObjectOfType<KillList>().battleConcluded = true;

        preparazioneVittoriapan();
        resocontoBattagliaPanel.SetActive(true);
        //Debug.LogError("dopo l'attivazione del pannello");
        FindObjectOfType<OldSoldiersManager>().salvasoldati(swordmencorrenti, archercorrenti, ridercorrenti, FindObjectOfType<Events>().terri);
    }

    private IEnumerator AvvioEffettiTermineBattagliaFinale ()
    {
        battlePreparation.gameObject.SetActive(false);
        StartCoroutine(effettoFadeOut(battleTransition));
        StartCoroutine(effettoFadeOut(FindObjectOfType<KillList>().canvasContinue));
        yield return new WaitForSeconds(0.8f);
        FindObjectOfType<KillList>().battleConcluded = true;

        preparazioneVittoriapan();
        resocontoBattagliaPanel.SetActive(true);
        //Debug.LogError("dopo l'attivazione del pannello");
        FindObjectOfType<OldSoldiersManager>().salvasoldati(swordmencorrenti, archercorrenti, ridercorrenti, FindObjectOfType<Events>().terri);
    }

    private IEnumerator AvvioEffettiBattaglia()
    {
        StartCoroutine(effettoFadeIn(battleTransition));
        yield return new WaitForSeconds(0.1f);

        FindObjectOfType<PrepBattaglia>().SincronizzaSoldati(); // sincronizzo i soldati veri del giocatore

        StartCoroutine(FindObjectOfType<KillList>().PushLines());
        yield return null;
    }

    public void TerminaBattaglia()
    {
        StartCoroutine(AvvioEffettiTermineBattaglia());
    }

    public void AvvioBattaglia()
    {
        StartCoroutine(AvvioEffettiBattaglia());
    }

    // evento individualmente chiama ...
    public void AvvioPreparazione(int terri)
    {
        preparazione(terri);
        StartCoroutine(effettoFadeIn(battlePreparation));
    }


    public void RealTimeSliders(Player player, Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders, Caserma caserma, Captain1 Capitano)
    {


        if (swordsmen.getTotal() == 0)
        {
            minSwordsmenUI.text = "0";
            maxSwordsmenUI.text = "0";
            swordsmenSlider.minValue = 0;
            swordsmenSlider.maxValue = 0;
        }
        if (swordsmen.getTotal() == 1)
        {
            minSwordsmenUI.text = "0";
            maxSwordsmenUI.text = "1";
            swordsmenSlider.minValue = 0;
            swordsmenSlider.maxValue = 1;
        }
        if (swordsmen.getTotal() > 1)
        {
            minSwordsmenUI.text = "0";
            maxSwordsmenUI.text = "" + swordsmen.getTotal();
            swordsmenSlider.minValue = 0;
            swordsmenSlider.maxValue = swordsmen.getTotal();
        }
        if (archers.getTotal() == 0)
        {
            minArchersUI.text = "0";
            maxArchersUI.text = "0";
            archersSlider.minValue = 0;
            archersSlider.maxValue = 0;
        }
        if (archers.getTotal() == 1)
        {
            minArchersUI.text = "0";
            maxArchersUI.text = "1";
            archersSlider.minValue = 0;
            archersSlider.maxValue = 1;
        }
        if (archers.getTotal() > 1)
        {
            minArchersUI.text = "0";
            maxArchersUI.text = "" + archers.getTotal();
            archersSlider.minValue = 0;
            archersSlider.maxValue = archers.getTotal();
        }
        if (riders.getTotal() == 0)
        {
            minRidersUI.text = "0";
            maxRidersUI.text = "0";
            ridersSlider.minValue = 0;
            ridersSlider.maxValue = 0;
        }
        if (riders.getTotal() == 1)
        {
            minRidersUI.text = "0";
            maxRidersUI.text = "1";
            ridersSlider.minValue = 0;
            ridersSlider.maxValue = 1;
        }
        if (riders.getTotal() > 1)
        {
            minRidersUI.text = "0";
            maxRidersUI.text = "" + riders.getTotal();
            ridersSlider.minValue = 0;
            ridersSlider.maxValue = riders.getTotal();
        }
        selectedSwordsmenUI.text = "" + (int)swordsmenSlider.value;
        selectedArchersUI.text = "" + (int)archersSlider.value;
        selectedRidersUI.text = "" + (int)ridersSlider.value;

        nomeCap.text = "Captain: " + Capitano.getName();
        atkCap.text = "ATK: " + Capitano.getAtk();
        defCap.text = "DEF: " + Capitano.getDef();

        if (x == 0)
        {
            capitanocorrente = Capitano;
            casermacorrente = caserma;
            playercorrente = player;
            swordmencorrenti = swordsmen;
            archercorrenti = archers;
            ridercorrenti = riders;
            x = 1;
        }

        bonusCap.text = "" + capBonus + "%";
        bonusTerry.text = "" + terriBonus + "%";
        bonusTroops.text = "" + troopsBonus + "%";
        float totalb = capBonus + terriBonus + troopsBonus;
        bonusTotal.text = "" + totalb + "%";

        int totalS = (int)swordsmenSlider.value + (int)archersSlider.value + (int)ridersSlider.value;
        totalSelected.text = "Total selected: " + totalS;

        int totalA = (swordsmen.getAtk() * (int)swordsmenSlider.value + archers.getAtk() * (int)archersSlider.value + riders.getAtk() * (int)ridersSlider.value);
        totalAtk.text = "ATK: " + totalA;

        int totalD = (swordsmen.getDef() * (int)swordsmenSlider.value + archers.getDef() * (int)archersSlider.value + riders.getDef() * (int)ridersSlider.value);
        totalDef.text = "DEF: " + totalD;

    }


    //la creazione dell'esercito nemico si trova in game.cs, pertanto vanno richiamate prima quelle funzioni


    public void preparazione(int terri)
    {
        if (terri == 1)
        {
            terriBonus = terriBonus + playercorrente.getBonusWall();
            capBonus = capBonus + capitanocorrente.getBonusWall();
        }
        if (terri == 2)
        {
            terriBonus = terriBonus + playercorrente.getBonusCity();
            capBonus = capBonus + capitanocorrente.getBonusCity();
        }
        if (terri == 3)
        {
            terriBonus = terriBonus + playercorrente.getBonusFar();
            capBonus = capBonus + capitanocorrente.getBonusFar();
        }
        if (terri == 4)
        {
            terriBonus = terriBonus + playercorrente.getBonusDemoniac();
            capBonus = capBonus + capitanocorrente.getBonusDemoniac();
        }

        capBonus = capBonus + capitanocorrente.getBonusBattle();
        terriBonus = terriBonus + playercorrente.getBonusBattle();
        troopsBonus = casermacorrente.getBonusBarrack();
    }




    public void AssegnaSoldati()
    {
        FindObjectOfType<Game>().swordsmen.setMomentSwordman((int)swordsmenSlider.value);
        //FindObjectOfType<Game>().swordsmen.setRapidTotal(-(int)swordsmenSlider.value);
        FindObjectOfType<Game>().archers.setMomentArcher((int)archersSlider.value);
        //FindObjectOfType<Game>().archers.setRapidTotal(-(int)archersSlider.value);
        FindObjectOfType<Game>().riders.setMomentRider((int)ridersSlider.value);
        //FindObjectOfType<Game>().riders.setRapidTotal(-(int)ridersSlider.value);


        // reset sliders
    }

    public void SincronizzaSoldati()
    {
        FindObjectOfType<Game>().swordsmen.setRapidTotal(-(int)swordsmenSlider.value);
        FindObjectOfType<Game>().archers.setRapidTotal(-(int)archersSlider.value);
        FindObjectOfType<Game>().riders.setRapidTotal(-(int)ridersSlider.value);
    }





 
    public void preparazioneVittoriapan()
    {
       // Debug.LogError("dentro prepVitpan");
        int controllo = FindObjectOfType<Events>().lastBattleInfo;
        if (controllo == 1)
        {
            decisive.text = "DECISIVE";
            Victory.text = "DEFEAT!";
           Alloro.SetActive(false);
            Spada.SetActive(true);
        }
        if (controllo == 2)
        {
            Alloro.SetActive(false);
            Spada.SetActive(true);
            decisive.text = "";
            Victory.text = "DEFEAT!";
        }
        if (controllo == 3)
        {
            Alloro.SetActive(true);
            Spada.SetActive(false);
            decisive.text = "";
            Victory.text = "VICTORY!";
        }
        if (controllo == 4)
        {
            Alloro.SetActive(true);
           Spada.SetActive(false);
            decisive.text = "DECISIVE";
            Victory.text = "VICTORY!";
        }

        int s = FindObjectOfType<Game>().swordsmen.getMomentDeadSwordman();
        int a = FindObjectOfType<Game>().archers.getMomentDeadArcher();
        int r = FindObjectOfType<Game>().riders.getMomentDeadRider();
        int es = FindObjectOfType<Game>().eswordsmen.getDeadESwordman();
        int ea = FindObjectOfType<Game>().earchers.getDeadEArchers();
        int er = FindObjectOfType<Game>().eriders.getDeadERiders();




        string soldati1 = "";
        string soldati2 = "";
        string soldati3 = "";


        if (s == 1)
        {
            soldati1 = "" + s + " swordsman\n";
        }
        if (s == 0 || s > 1)
        {
            soldati1 = "" + s + " swordsmen\n";
        }
        if (a == 1)
        {
            soldati2 = "" + a + " archer\n";
        }
        if (a == 0 || a > 1)
        {
            soldati2 = "" + a + " archers\n";
        }

        if (r == 1)
        {
            soldati3 = "" + r + " rider";
        }
        if (r == 0 || r > 1)
        {
            soldati3 = "" + r + " riders";
        }

        soldatigiocatore.text = "" + soldati1 + soldati2 + soldati3;

        string esoldati1 = "";
        string esoldati2 = "";
        string esoldati3 = "";

        if ((es == 1) && FindObjectOfType<Game>().eswordsmen.aliasSingular != "nul")
        {
            esoldati1 = "" + es +" " + FindObjectOfType<Game>().eswordsmen.aliasSingular + "\n";
        }
        if ((es > 1 || es == 0) && FindObjectOfType<Game>().eswordsmen.aliasSingular != "nul")
        {
            esoldati1 = "" + es + " " + FindObjectOfType<Game>().eswordsmen.alias + "\n";
        }

        if (( ea == 1) && FindObjectOfType<Game>().earchers.aliasSingular != "nul")
        {
            esoldati2 = "" + ea + " " + FindObjectOfType<Game>().earchers.aliasSingular + "\n";
        }
        if ((ea > 1 || ea == 0) && FindObjectOfType<Game>().earchers.aliasSingular != "nul")
        {
            esoldati2 = "" + ea + " " + FindObjectOfType<Game>().earchers.alias + "\n";
        }

        if ((er == 1) && FindObjectOfType<Game>().eriders.aliasSingular != "nul")
        {
            esoldati3 = "" + er + " " + FindObjectOfType<Game>().eriders.aliasSingular;
        }
        if ((er == 0 || er > 1) && FindObjectOfType<Game>().eriders.aliasSingular != "nul")
        {
            esoldati3 = "" + er + " " + FindObjectOfType<Game>().eriders.alias;
        }

        soldatiEnemy.text = "" + esoldati1 + esoldati2 + esoldati3;


      //  Debug.LogError("Finito prepVitpan");
    }




}
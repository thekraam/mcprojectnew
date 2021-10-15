using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    
    
    
    /* Dichiarazione object di controllo visibilita pannelli */
    public GameObject gamePanel; // pannello all'avvio partita
    public GameObject farmPanel;
    public GameObject fabbroPanel;
    public GameObject casermaPanel;
    public GameObject guildPanel;

    /* dichiarazione elementi di UI tramite oggetto Text in UnityEngine.UI */
    public Text soldiersUI;
    public Text citizensUI;
    public Text populationUI;
    public Text moneyUI;
    public Text turnsUI;
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
    
    bool isFirstTurn = true;
    bool isLastTurn = false;

    public void Start()
    {
        // disattivo pannelli non di game, 'nse sa mai
        gamePanel.SetActive(true); //
        farmPanel.SetActive(false);
        casermaPanel.SetActive(false);
        guildPanel.SetActive(false);
        casermaPanel.SetActive(false);
    }


    public void Update()
    {
        // soldiersUI.text = "" + (player.countTotalCitizens(player, swordsmen, archers, riders) - player.getCitizens()); // mostra il nuovo totale dei soldati appena lo trovi

        // populationUI.text = "" + player.countTotalCitizens(player, swordsmen, archers, riders); // mostra il nuovo totale della popolazione totale come somma di soldati e civili appena la trovi

        moneyUI.text = "" + player.getMoney(); // mostra il nuovo totale dei soldi appena lo trovi

        turnsUI.text = "" + player.getTurn(); // mostra il nuovo turno appena lo trovi
    }

    public void onSkipTurn()
    {
        player.setMoney(); // cambia definitivamente i soldi, al resto ci pensa Update
        player.setSkipMoney(fattoria.getGoldFattoria() + miniera.getgoldMiniera() + 2*fattoria.getLvlFattoria()+20*fabbro.zappa*fattoria.getLvlFattoria() + 20*fabbro.zappa2*fattoria.getLvlFattoria());
        player.nextTurn(); // cambia il numero del turno attuale, al resto ci pensa Update

        player.setCitizens(); // cambia il numero di cittadini liberi, al resto ci pensa Update in funzione del numero di soldati riportato sotto
        player.setTempCitizens(fattoria.getCrescitaAbitanti());

        player.setCitizensMax();
        player.setTempCitizensMax(fattoria.getAbitantiMax());

        swordsmen.setTotal(); // idem

        archers.setTotal(); // idem

        riders.setTotal(); // idem
    }

    // metodi per nascondere o visualizzare i pannelli di gioco
    public void onTapVillage()
    {
        gamePanel.SetActive(true); //
        farmPanel.SetActive(false);
        casermaPanel.SetActive(false);
        guildPanel.SetActive(false);
        fabbroPanel.SetActive(false);
    }

    public void onTapFarm()
    {
        gamePanel.SetActive(true);
        farmPanel.SetActive(true); // 
        casermaPanel.SetActive(false);
        guildPanel.SetActive(false);
        fabbroPanel.SetActive(false);
    }
    public void onTapCaserma()
    {
        gamePanel.SetActive(false);
        farmPanel.SetActive(false); 
        casermaPanel.SetActive(true); //
        guildPanel.SetActive(false);
        fabbroPanel.SetActive(false);
    }

    public void onTapGuild()
    {
        gamePanel.SetActive(false);
        farmPanel.SetActive(false); 
        casermaPanel.SetActive(false);
        guildPanel.SetActive(true); //
        fabbroPanel.SetActive(false);
    }

    public void onTapFabbro()
    {
        gamePanel.SetActive(false);
        farmPanel.SetActive(false);
        casermaPanel.SetActive(false);
        guildPanel.SetActive(false);
        fabbroPanel.SetActive(true); //
    }

}
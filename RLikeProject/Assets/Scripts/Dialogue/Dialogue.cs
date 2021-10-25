﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dialogue : MonoBehaviour
{

    public string a = "a";


    // funzione per far apparire il dialogue, va su un tasto o una situazione
    public void TriggerDialogue(Player player, Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(a, pickRandomEvent(player, swordsmen, archers, riders));
    }


    // seleziona un evento casuale tra i seguenti (e' facilmente modificabile: e' possibile aggiungere booleane per indicare che un evento e' gia avvenuto e aggiungerlo ai controlli in if)
    public string[] pickRandomEvent(Player player, Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders)
    {

        float eventChooser = Random.Range(0f, 1f);

        if (eventChooser >= 0 && eventChooser < 0.1f)
        {
            string eventString1 = "ciao";
            string eventString2 = "questa";
            string eventString3 = "è";
            string eventString4 = "una prova";

            string[] stringsEvent = new string[] { eventString1, eventString2, eventString3, eventString4};
            return stringsEvent;
        }
        if(eventChooser >=0.1f && eventChooser < 0.2f)
        {
            string eventString1 = "ciao";
            string eventString2 = "questa";
            string eventString3 = "è";
            string eventString4 = "un'altra";
            string eventString5 = "prova";
            string eventString6 = "piu lunga";

            string[] stringsEvent = new string[] { eventString1, eventString2, eventString3, eventString4, eventString5, eventString6};
            return stringsEvent;
        }
        else
            return null; // MAI usare null qui nella versione finale, sta qui solo per far compilare
    }
}

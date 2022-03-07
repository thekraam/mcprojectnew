using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Dialogue : MonoBehaviour
{

    private string a = "Guild Master";



    // FUNZIONE DA USARE SOLO PER NEXT IN MAIN PER I DIALOGHI
    public void TriggerSPECIALDialogue()
    {
        string[] alreadyAttendingMessage = { "Apologize sir, you can't send two adventurer groups at the same time." , "coglione", "funziono, forse"};
        FindObjectOfType<DialogueManager>().StartDialogue(true, a, alreadyAttendingMessage);
    }
    //////////////////////////////////////////////////////////////////////////////////////

    // funzione per far apparire il dialogue, va su un tasto o una situazione
    public void TriggerDialogue(Player player, Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders, string [] message)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(false, a, message);
    }

    // funzione per far apparire un dialogue con scelta finale (si/no)
    public void TriggerInteractiveDialogue(Player player, Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders, string[] message)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(true, a, message);
    }


    // funzione per far apparire il dialogue, va su un tasto o una situazione
    public void TriggerGuildDialogue(Player player, Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders)
    {
        FindObjectOfType<DialogueManager>().StartDialogue(false, a, pickGuildEvent(player, swordsmen, archers, riders));
    }

    // dialogo di popup in caso si tenti di fare due eventi gilda nello stesso turno
    public void TriggerGuildErrorDialogue(Player player, Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders)
    {
        string[] alreadyAttendingMessage = {"Apologize sir, you can't send two adventurer groups at the same time."};
        FindObjectOfType<DialogueManager>().StartDialogue(false, "Guild Master", alreadyAttendingMessage);
    }


    // funzione che viene chiamata solo se l'evento parte dalla gila
    public string[] pickGuildEvent(Player player, Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders)
    {
        return null; // MAI usare null qui nella versione finale, sta qui solo per far compilare
    }
    


    // funzione che, tenendo conto delle booleane, seleziona un evento casuale con scelta finale e conseguenze
    public string[] pickProgressiveEvent(Player player, Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders)
    {
        return null; // MAI usare null qui nella versione finale, sta qui solo per far compilare
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

            string[] stringsEvent = new string[] {eventString1, eventString2, eventString3, eventString4};
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

            string[] stringsEvent = new string[] {eventString1, eventString2, eventString3, eventString4, eventString5, eventString6};
            return stringsEvent;
        }
        else
            return null; // MAI usare null qui nella versione finale, sta qui solo per far compilare
    }
}

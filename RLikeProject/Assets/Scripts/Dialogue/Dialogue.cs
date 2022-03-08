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
}

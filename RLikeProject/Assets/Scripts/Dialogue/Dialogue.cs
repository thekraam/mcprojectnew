using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class Dialogue
{

    static readonly string a = "Guild Master";

    static DialogueManager MidDialogue = GameObject.FindObjectOfType<DialogueManager>();
    static DialogueManagerMINI SmallDialogue = GameObject.FindObjectOfType<DialogueManagerMINI>();

    // FUNZIONE DA USARE SOLO PER NEXT IN MAIN PER I DIALOGHI
    public static void TriggerSPECIALDialogue()
    {
        string[] alreadyAttendingMessage = { "Apologize sir, you can't send two adventurer groups at the same time." , "coglione", "funziono, forse"};
        MidDialogue.StartDialogue(true, a, alreadyAttendingMessage);
    }
    //////////////////////////////////////////////////////////////////////////////////////

    // funzione per far apparire il dialogue, va su un tasto o una situazione
    public static void TriggerDialogue(string [] message)
    {
        MidDialogue.StartDialogue(false, a, message);
    }

    // funzione per far apparire il dialogue piccolo, va su un tasto o una situazione
    public static void TriggerSmallDialogue(string[] message)
    {
        SmallDialogue.StartDialogue(false, a, message);
    }

    // funzione per far apparire un dialogue con scelta finale (si/no)
    public static void TriggerInteractiveDialogue( string[] message)
    {
       MidDialogue.StartDialogue(true, a, message);
    }


    // funzione per far apparire il dialogue, va su un tasto o una situazione
    public static void TriggerSmallInteractiveDialogue(string[] message)
    {
        SmallDialogue.StartDialogue(true, "Guild Master", message);
    }

    // dialogo di popup in caso si tenti di fare due eventi gilda nello stesso turno
    public static void TriggerGuildErrorDialogue(Player player, Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders)
    {
        string[] alreadyAttendingMessage = {"Apologize sir, you can't send two adventurer groups at the same time."};
        MidDialogue.StartDialogue(false, "Guild Master", alreadyAttendingMessage);
    }


    // funzione che viene chiamata solo se l'evento parte dalla gila
    public static string[] pickGuildEvent(Player player, Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders)
    {
        return null; // MAI usare null qui nella versione finale, sta qui solo per far compilare
    }
    


    // funzione che, tenendo conto delle booleane, seleziona un evento casuale con scelta finale e conseguenze
    public static string[] pickProgressiveEvent(Player player, Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders)
    {
        return null; // MAI usare null qui nella versione finale, sta qui solo per far compilare
    }
}

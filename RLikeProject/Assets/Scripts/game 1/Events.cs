using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{

    private Dialogue dialogue = new Dialogue();
    private int[] eventResults = { 0, 0, 0 };

    public int[] pickRandomEvent(Player player, Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders)
    {

        float eventChooser = Random.Range(0f, 1f);

        if (eventChooser >= 0 && eventChooser < 0.1f)
        {
            eventResults[0] = triggerAqueductEvent(player, swordsmen, archers, riders);
            return null;
        }
        /*if (eventChooser >= 0.1f && eventChooser < 0.2f)
        {
            string eventString1 = "ciao";
            string eventString2 = "questa";
            string eventString3 = "è";
            string eventString4 = "un'altra";
            string eventString5 = "prova";
            string eventString6 = "piu lunga";

            string[] stringsEvent = new string[] { eventString1, eventString2, eventString3, eventString4, eventString5, eventString6 };
            return stringsEvent;
        }*/
        else
            return null; // MAI usare null qui nella versione finale, sta qui solo per far compilare
    }

    private int triggerAqueductEvent(Player player, Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders)
    {
        float aqueductValue = Random.Range(0f, 1f);

        string eventString1 = "ciao";
        string eventString2 = "questa";
        string eventString3 = "è";
        string eventString4 = "una prova";

        string[] message = new string[] { eventString1, eventString2, eventString3, eventString4 };


        bool aqueduct = dialogue.TriggerInteractiveDialogue(player, swordsmen, archers, riders, message);
        if (aqueduct) aqueductValue = 0;
        if (aqueductValue >= 0.5f)
        {
            return 1;
        }
        else return 0;
    
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    private Dialogue dialogue = new Dialogue();

    /* booleane effetti */
    bool aqueductEffectMalus = false;


    /* booleane eventi secondari */
    bool attendingSecondaryEvent = false; // generico

    int aqueductSecondary = 0;


    /* booleane di avvenuto evento, 0 di default */
    int aqueduct = 0;


    /* variabili countdown evento secondario, grande numero di default */
    int aqueductTurnsLeft = 999999;


    public void MaxCitizensEffects(Player player, Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders)
    {

    }



    public void UpdateEffects(Player player, Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders)
    {
        if (aqueductEffectMalus)
        {  
            aqueductEffectMalus = false;
        }
    }

    public void secondaryEventStarter(Player player, Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders)
    {
        if (aqueductSecondary == 1 && attendingSecondaryEvent) aqueductEffectMalus = true;
    }

    public void turnsForEventDecreaser(Player player, Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders)
    {
        if (aqueductTurnsLeft > 0) aqueductTurnsLeft--;
    }

    public void eventStarter(Player player, Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders)
    {
        bool eventPicked = false;

        float eventChooser = Random.Range(0f, 1f);
        while (!eventPicked && !attendingSecondaryEvent)
        {
            if (eventChooser >= 0 && eventChooser < 0.1f)
            {
                if (aqueduct == 0)
                {
                    triggerAqueductEvent(player, swordsmen, archers, riders);
                    eventPicked = true;
                }
            }
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
    }

    private void triggerAqueductEvent(Player player, Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders)
    {
        aqueduct = 1;
        float aqueductValue = Random.Range(0f, 1f); // probabilita di verifica evento secondario

        string eventString1 = "ciao";
        string eventString2 = "questa";
        string eventString3 = "è";
        string eventString4 = "una prova";

        string[] message = new string[] { eventString1, eventString2, eventString3, eventString4 };

        int response = dialogue.TriggerInteractiveDialogue(player, swordsmen, archers, riders, message);

        if (response == 1)
        {
            aqueductValue = 0;
        }
        else if (aqueductValue >= 0.5f)
        {
            attendingSecondaryEvent = true;
            aqueductSecondary = 1;
            aqueductTurnsLeft = 4;
        }
        else
            aqueductSecondary = 0; // conferma logica dell'algoritmo, inutile
    }
}

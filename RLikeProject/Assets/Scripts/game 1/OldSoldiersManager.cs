using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldSoldiersManager : MonoBehaviour
{
    public int sword1 = 0;
    public int arc1 = 0;
    public int rid1 = 0;
    public int turn1 = 0;

    public int sword2 = 0;
    public int arc2 = 0;
    public int rid2 = 0;
    public int turn2 = 0;

    public int sword3 = 0;
    public int arc3 = 0;
    public int rid3 = 0;
    public int turn3 = 0;

    public int sword4 = 0;
    public int arc4 = 0;
    public int rid4 = 0;
    public int turn4 = 0;

    public int sword5 = 0;
    public int arc5 = 0;
    public int rid5 = 0;
    public int turn5 = 0;

    Dialogue dialogo = new Dialogue();

    public void salvasoldati(Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders, int terri)
    {
       // Debug.LogError("son dentro salvasoldati");
        int controllo = 0;
        if (sword1 == 0 && arc1 == 0 && rid1 == 0 && controllo == 0)
        {
            //    Debug.LogError("son dentro la prima condizione (giusta)");
            sword1 = swordsmen.getMomentSwordman();
            arc1 = archers.getMomentArcher();
            rid1 = riders.getMomentRider();
            turn1 = terri;
            controllo = 1;
            // Debug.LogError("sword1 " + sword1);
            // Debug.LogError("arc1 " + arc1);
            // Debug.LogError("rid1 " + rid1);
            // Debug.LogError("turn1 " + turn1);

        }

        else if (sword2 == 0 && arc2 == 0 && rid2 == 0 && controllo == 0)
        {
            //    Debug.LogError("error");
            sword2 = swordsmen.getMomentSwordman();
            arc2 = archers.getMomentArcher();
            rid2 = riders.getMomentRider();
            turn2 = terri;
            controllo = 1;
        }

        else if (sword3 == 0 && arc3 == 0 && rid3 == 0 && controllo == 0)
        {
            //   Debug.LogError("error");
            sword3 = swordsmen.getMomentSwordman();
            arc3 = archers.getMomentArcher();
            rid3 = riders.getMomentRider();
            turn3 = terri;
            controllo = 1;
        }

        else if (sword4 == 0 && arc4 == 0 && rid4 == 0 && controllo == 0)
        {
            //    Debug.LogError("error");
            sword4 = swordsmen.getMomentSwordman();
            arc4 = archers.getMomentArcher();
            rid4 = riders.getMomentRider();
            turn4 = terri;
            controllo = 1;
        }

        else if (sword5 == 0 && arc5 == 0 && rid5 == 0 && controllo == 0)
        {
            //   Debug.LogError("error");
            sword5 = swordsmen.getMomentSwordman();
            arc5 = archers.getMomentArcher();
            rid5 = riders.getMomentRider();
            turn5 = terri;
            controllo = 1;
        }
        //  Debug.LogError("chiudo salvataggio dati");
    }

    public void riassegnaSoldati(Player player, Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders)
    {
        int c1 = 0;
        int c2 = 0;
        int c3 = 0;
        int c4 = 0;
        int c5 = 0;
        if (turn1 != 0)
        {
            turn1--;
            c1 = 1;
        }
        if (turn2 != 0)
        {
            turn2--;
            c2 = 1;
        }
        if (turn3 != 0)
        {
            turn3--;
            c3 = 1;
        }
        if (turn4 != 0)
        {
            turn4--;
            c4 = 1;
        }
        if (turn5 != 0)
        {
            turn5--;
            c5 = 1;
        }

        if (turn1 == 0 && c1 == 1)
        {
            swordsmen.setRapidTotal(sword1);
            archers.setRapidTotal(arc1);
            riders.setRapidTotal(rid1);
            sword1 = 0;
            arc1 = 0;
            rid1 = 0;
        }
        if (turn2 == 0 && c2 == 1)
        {
            swordsmen.setRapidTotal(sword2);
            archers.setRapidTotal(arc2);
            riders.setRapidTotal(rid2);
            sword2 = 0;
            arc2 = 0;
            rid2 = 0;
        }
        if (turn3 == 0 && c3 == 1)
        {
            swordsmen.setRapidTotal(sword3);
            archers.setRapidTotal(arc3);
            riders.setRapidTotal(rid3);
            sword3 = 0;
            arc3 = 0;
            rid3 = 0;
        }
        if (turn4 == 0 && c4 == 1)
        {
            swordsmen.setRapidTotal(sword4);
            archers.setRapidTotal(arc4);
            riders.setRapidTotal(rid4);
            sword4 = 0;
            arc4 = 0;
            rid4 = 0;
        }
        if (turn5 == 0 && c5 == 1)
        {
            swordsmen.setRapidTotal(sword5);
            archers.setRapidTotal(arc5);
            riders.setRapidTotal(rid5);
            sword5 = 0;
            arc5 = 0;
            rid5 = 0;
        }
    }





    public int getSoldatiSpediti ()
    {
        int numerototale = 0;
        if (sword1 != 0 || arc1 != 0 || rid1 != 0)
        {
            numerototale = numerototale + sword1 + arc1 + rid1;

        }
        if (sword2 != 0 || arc2 != 0 || rid2 != 0)
        {
            numerototale = numerototale + sword2 + arc2 + rid2;

        }
        if (sword3 != 0 || arc3 != 0 || rid3 != 0)
        {
            numerototale = numerototale + sword3 + arc3 + rid3;

        }
        if (sword4 != 0 || arc4 != 0 || rid4 != 0)
        {
            numerototale = numerototale + sword4 + arc4 + rid4;

        }
        return numerototale;
    }


















    //--------------------------------variabili per la risposta di tutti i tipi di messaggi da parte della gilda-------------------------------------

    public int swordgilda1;
    public int arcgilda1;
    public int ridgilda1;
    public int tipologia1;
    public int moltiplicatore1;
    public int turngilda1;

    public int swordgilda2;
    public int arcgilda2;
    public int ridgilda2;
    public int tipologia2;
    public int moltiplicatore2;
    public int turngilda2;




    public void gildaimpostamex(int x, int y, int s, int a, int r)
    {
        int cont = 0;
        if (swordgilda1 == 0 && arcgilda1 == 0 && ridgilda1 == 0)
        {
            swordgilda1 = s;
            arcgilda1 = a;
            ridgilda1 = r;
            tipologia1 = x;
            moltiplicatore1 = y;
            cont = 1;
         }

        else
        {
            swordgilda2 = s;
            arcgilda2 = a;
            ridgilda2 = r;
            tipologia2 = x;
            moltiplicatore2 = y;
        }
        if (cont == 1)
        {
            if (x < 5)
            {
                turngilda1 = 1;
            }
            if (5 <= (x) && (x) < 13)
            {
                turngilda1 = 2;
            }
            if (13 <= (x ) && (x ) < 17)
            {
                turngilda1 = 3;
            }
            if (17 <= (x ) && (x ) <= 20)
            {
                turngilda1 = 4;
            }
        }
        else
        {
            if (x < 5)
            {
                turngilda2 = 1;
            }
            if (5 <= (x ) && (x ) < 13)
            {
                turngilda2 = 2;
            }
            if (13 <= (x) && (x ) < 17)
            {
                turngilda2 = 3;
            }
            if (17 <= (x ) && (x) <= 20)
            {
                turngilda2 = 4;
            }
        }
    }



    private IEnumerator dialogoDiRitorno(bool isDialogoPiccolo, string[] messaggi)
    {
        if (isDialogoPiccolo)
        {
            yield return new WaitUntil(() => FindObjectOfType<DialogueManagerMINI>().endingdialogue == 1 && FindObjectOfType<Events>().isEventDialogueClosed);
            dialogo.TriggerSmallDialogue(messaggi);
        }
        else
        {
            yield return new WaitUntil(() => FindObjectOfType<DialogueManager>().endingdialogue == 1 && FindObjectOfType<Events>().isEventDialogueClosed);
            dialogo.TriggerDialogue(messaggi);
        }
        FindObjectOfType<AudioManager>().PlayEffectFaded(FindObjectOfType<Game>().guild_cameBack);
        yield return null;
    }


    public void gildamexritorno(Player player, Gilda gilda)
    {
        //    Debug.Log("entro dentro gildamexritorno");


        turngilda1--;
        turngilda2--;
        //    Debug.LogError("tipologia1 = " + tipologia1 + " e moltiplicatore " + moltiplicatore1 );
        //   Debug.LogError("tipologia2 = " + tipologia2 + " e moltiplicatore " + moltiplicatore2);
        //   Debug.LogError("turngilda1 = " + turngilda1);
        //   Debug.LogError("turngilda2 = " + turngilda2);

        if (((tipologia1 == 1) && turngilda1 == 0) || ((tipologia2 == 1) && turngilda2 == 0))
        {
            //     Debug.LogError("caso 1 ");
            if (gilda.getcontrollosped1() == 1) { gilda.setcontrollosped1(0); }
            else if (gilda.getcontrollosped2() == 1) { gilda.setcontrollosped2(0); }
            player.setRapidMoney(200);
            gilda.setsped1(1);
            player.setsoldiersaway(-10);
            string eventString1 = "Your soldiers are back from the expedition.";
            string eventString2 = "In the woods they've found some elves's lost treasures";
            string eventString3 = "(You obtain 200 gold)";

            string[] message = { eventString1, eventString2, eventString3};
            StartCoroutine(dialogoDiRitorno(true, message));

            //        Debug.LogError("sped1 = " + gilda.getsped1());
        }
        if (((tipologia1 == 2) && turngilda1 == 0 )||( (tipologia2 == 2) && turngilda2 == 0))
        {
            if (gilda.getcontrollosped1() == 1) { gilda.setcontrollosped1(0); }
            else if (gilda.getcontrollosped2() == 1) { gilda.setcontrollosped2(0); }
            gilda.setsped1(1);
            player.setsoldiersaway(-10);
            string eventString1 = "Your soldiers are back from the expedition.";
            string eventString2 = "During the search they were attacked by brigands and only a few managed to escape";
            string[] message1 = { eventString1, eventString2,};
            StartCoroutine(dialogoDiRitorno(true, message1));

            //       Debug.LogError("caso 2 ");

            //       Debug.LogError("sped1 = " + gilda.getsped1());
        }
        if (((tipologia1 == 3) && turngilda1 == 0) || ((tipologia2 == 3) && turngilda2 == 0))
        {
            if (gilda.getcontrollosped1() == 1) { gilda.setcontrollosped1(0); }
            else if (gilda.getcontrollosped2() == 1) {gilda.setcontrollosped2(0); }
            player.setRapidMoney(200);
            gilda.setsped1(1);
            player.setsoldiersaway(-10);
            string eventString1 = "Your soldiers are back from the expedition.";
            string eventString2 = "During the search they were attacked by brigands but your soldiers fought and chased them away";
            string eventString3 = "You've lost some soldiers but at least they've found some treasures to bring back";
            string eventString4 = "(You obtain 200 gold)";
            string[] message1 = { eventString1, eventString2, eventString3, eventString4 };
            StartCoroutine(dialogoDiRitorno(true, message1));
            //dialogo 3 - la chiamata va fatta del tipo 'StartCoroutine(dialogoDiRitorno(true, messagge));'
            //        Debug.LogError("caso 3 ");

            //       Debug.LogError("sped1 = " + gilda.getsped1());
        }
        if (((tipologia1 == 4) && turngilda1 == 0) || ((tipologia2 == 4) && turngilda2 == 0))
        {
            if (gilda.getcontrollosped1() == 1) { gilda.setcontrollosped1(0); }
            else if (gilda.getcontrollosped2() == 1)  {gilda.setcontrollosped2(0); }
            player.setRapidMoney(200);
            gilda.setsped1(1);
            player.setsoldiersaway(-10);
            string eventString1 = "Your soldiers are back from the expedition.";
            string eventString2 = "In the woods they've found some elves's lost treasures of great value";
            string eventString3 = "(You obtain 900 gold)";
            string[] message1 = { eventString1, eventString2, eventString3};
            StartCoroutine(dialogoDiRitorno(true, message1));
            //dialogo 4 - la chiamata va fatta del tipo 'StartCoroutine(dialogoDiRitorno(true, messagge));'
            //       Debug.LogError("caso 4 ");

            //      Debug.LogError("sped1 = " + gilda.getsped1());
        }
        if (((tipologia1 == 5) && turngilda1 == 0 )|| ((tipologia2 == 5) && turngilda2 == 0))
        {
            //      Debug.Log("Son dentro tipologia 5");
            if (gilda.getcontrollosped1() == 1) { gilda.setcontrollosped1(0); }
            else if (gilda.getcontrollosped2() == 1) { gilda.setcontrollosped2(0); }
            player.setRapidMoney(800);
            gilda.setsped2(1);
            player.setsoldiersaway(-20);
            //dialogo 5 - la chiamata va fatta del tipo 'StartCoroutine(dialogoDiRitorno(true, messagge));'
            string eventString1 = "Your soldiers are back from the expedition.";
            string eventString2 = "Inside a cave they found an ancient chest full of golden coins";
            string eventString3 = "(You obtain 800 golds)";
            string[] message1 = { eventString1, eventString2, eventString3};
            StartCoroutine(dialogoDiRitorno(true, message1));

        }
        if (((tipologia1 == 6) && turngilda1 == 0) || ((tipologia2 == 6) && turngilda2 == 0))
        {
            //       Debug.Log("Son dentro tipologia 6");
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            gilda.setsped2(1);
            player.setsoldiersaway(-20);
            //dialogo 6 - la chiamata va fatta del tipo 'StartCoroutine(dialogoDiRitorno(true, messagge));'
            string eventString1 = "Your soldiers are back from the expedition.";
            string eventString2 = "In a cave they've been attacked by a giant spider and your soldiers ran away";
            string[] message1 = { eventString1, eventString2};
            StartCoroutine(dialogoDiRitorno(true, message1));

        }
        if (((tipologia1 == 7) && turngilda1 == 0 )||( (tipologia2 == 7) && turngilda2 == 0))
        {
            //       Debug.Log("Son dentro tipologia 7");
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(800);
            gilda.setsped2(1);
            player.setsoldiersaway(-20);
            //dialogo 7 - la chiamata va fatta del tipo 'StartCoroutine(dialogoDiRitorno(true, messagge));'
            string eventString1 = "Your soldiers are back from the expedition.";
            string eventString2 = "In a cave they've been attacked by a giant spider but your soldiers killed it";
            string eventString3 = "Inside the cave they found an ancient chest full of gold coins";
            string eventString4 = "(You obtain 800 golds)";
            string[] message1 = { eventString1, eventString2, eventString3, eventString4 };
            StartCoroutine(dialogoDiRitorno(true, message1));
        }
        if (((tipologia1 == 8) && turngilda1 == 0) || ((tipologia2 == 8) && turngilda2 == 0))
        {
            //       Debug.Log("Son dentro tipologia 8");
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(1600);
            gilda.setsped2(1);
            player.setsoldiersaway(-20);
            //dialogo 8 - la chiamata va fatta del tipo 'StartCoroutine(dialogoDiRitorno(true, messagge));'
            string eventString1 = "Your soldiers are back from the expedition.";
            string eventString2 = "Inside a cave they found an ancient chest full of golden coins";
            string eventString3 = "(You obtain 1600 golds)";
            string[] message1 = { eventString1, eventString2, eventString3};
            StartCoroutine(dialogoDiRitorno(true, message1));
        }
        if ((tipologia1  == 9) && turngilda1 == 0 || (tipologia2 == 9) && turngilda2 == 0)
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(1500);
            gilda.setsped3(1);
            player.setsoldiersaway(-30);
            //dialogo 9 - la chiamata va fatta del tipo 'StartCoroutine(dialogoDiRitorno(true, messagge));'
            string eventString1 = "Your soldiers are back from the expedition.";
            string eventString2 = "In the ancient ruins they found the tomb of an ancient king with a jewel of great value";
            string eventString3 = "(You obtain 1500 golds)";
            string[] message1 = { eventString1, eventString2, eventString3,};
            StartCoroutine(dialogoDiRitorno(true, message1));

        }
        if ((tipologia1 == 10) && turngilda1 == 0 || (tipologia2 == 10) && turngilda2 == 0)
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(1500);
            gilda.setsped3(1);
            player.setsoldiersaway(-30);
            //dialogo 10 - la chiamata va fatta del tipo 'StartCoroutine(dialogoDiRitorno(true, messagge));'
            string eventString1 = "Your soldiers are back from the expedition.";
            string eventString2 = "In the ancient ruins they found the tomb of an ancient king";
            string eventString3 = "Guardian spirits have appeared and attacked your men; some of them managed to escape";
            string[] message1 = { eventString1, eventString2, eventString3};
            StartCoroutine(dialogoDiRitorno(true, message1));

        }
        if ((tipologia1 == 11) && turngilda1 == 0 || (tipologia2 == 11) && turngilda2 == 0)
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(1500);
            gilda.setsped3(1);
            player.setsoldiersaway(-30);
            //dialogo 11 - la chiamata va fatta del tipo 'StartCoroutine(dialogoDiRitorno(true, messagge));'
            string eventString1 = "Your soldiers are back from the expedition.";
            string eventString2 = "In the ancient ruins they found the tomb of an ancient king";
            string eventString3 = "Guardian spirits have appeared and attacked your men; some of them managed to escape";
            string eventString4 = "one of them took a jewel of great value with him";
            string eventString5 = "(You obtain 1500 golds)";
            string[] message1 = { eventString1, eventString2, eventString3, eventString4,eventString5 };
            StartCoroutine(dialogoDiRitorno(true, message1));

        }
        if ((tipologia1 == 12) && turngilda1 == 0 || (tipologia2 == 12) && turngilda2 == 0)
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(3000);
            gilda.setsped3(1);
            player.setsoldiersaway(-30);
            //dialogo 12 - la chiamata va fatta del tipo 'StartCoroutine(dialogoDiRitorno(true, messagge));'
            string eventString1 = "Your soldiers are back from the expedition.";
            string eventString2 = "In the ancient ruins they found the tomb of an ancient king";
            string eventString3 = "they found a golden sword of great value near the sarcophagus";
            string eventString4 = "(you obtain 3000 golds";
            string[] message1 = { eventString1, eventString2, eventString3, eventString4 };
            StartCoroutine(dialogoDiRitorno(true, message1));

        }
        if ((tipologia1 == 13) && turngilda1 == 0 || (tipologia2 == 13) && turngilda2 == 0)
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(2500);
            gilda.setsped4(1);
            player.setsoldiersaway(-40);
            //dialogo 13 - la chiamata va fatta del tipo 'StartCoroutine(dialogoDiRitorno(true, messagge));'
            string eventString1 = "Your soldiers are back from the expedition.";
            string eventString2 = "Across the demonic lands near a dead log they found a skeletron";
            string eventString3 = "Next to the skeletron there was a bag with a huge amount of jewels";
            string eventString4 = "(You obtain 2500 golds)";
            string[] message1 = { eventString1, eventString2, eventString3, eventString4 };
            StartCoroutine(dialogoDiRitorno(true, message1));

        }
        if ((tipologia1 == 14) && turngilda1 == 0 || (tipologia2 == 14) && turngilda2 == 0)
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(2500);
            gilda.setsped4(1);
            player.setsoldiersaway(-40);
            //dialogo 14 - la chiamata va fatta del tipo 'StartCoroutine(dialogoDiRitorno(true, messagge));'
            string eventString1 = "Your soldiers are back from the expedition.";
            string eventString2 = "Across the demonic lands they have been attacked by a group of lesser demons";
            string eventString3 = "After the fight they managed to escape before the enemy reinforcements arrives";
            string[] message1 = { eventString1, eventString2, eventString3};
            StartCoroutine(dialogoDiRitorno(true, message1));

        }
        if ((tipologia1 == 15) && turngilda1 == 0 || (tipologia2  == 15) && turngilda2 == 0)
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(2500);
            gilda.setsped4(1);
            player.setsoldiersaway(-40);
            //dialogo 15 - la chiamata va fatta del tipo 'StartCoroutine(dialogoDiRitorno(true, messagge));'
            string eventString1 = "Your soldiers are back from the expedition.";
            string eventString2 = "Across the demonic lands they have been attacked by a group of lesser demons";
            string eventString3 = "After the fight, they looted lots of inexpected treasures from their bodies";
            string eventString4 = "(You obtain 2500 golds)";
            string[] message1 = { eventString1, eventString2, eventString3, eventString4 };
            StartCoroutine(dialogoDiRitorno(true, message1));

        }
        if ((tipologia1 == 16) && turngilda1 == 0 || (tipologia2 == 16) && turngilda2 == 0)
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(5000);
            gilda.setsped4(1);
            player.setsoldiersaway(-40);
            //dialogo 16 - la chiamata va fatta del tipo 'StartCoroutine(dialogoDiRitorno(true, messagge));'
            string eventString1 = "Your soldiers are back from the expedition.";
            string eventString2 = "Across the demonic lands they found an abandoned manor.";
            string eventString3 = "Inside a treasure chest of very precious diamonds was hidden";
            string eventString4 = "(You obtain 5000 golds";
            string[] message1 = { eventString1, eventString2, eventString3, eventString4 };
            StartCoroutine(dialogoDiRitorno(true, message1));

        }
        if ((tipologia1 == 17) && turngilda1 == 0 || (tipologia2 == 17) && turngilda2 == 0)
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(4000);
            gilda.setsped5(1);
            player.setsoldiersaway(-50);
            //dialogo 17 - la chiamata va fatta del tipo 'StartCoroutine(dialogoDiRitorno(true, messagge));'
            string eventString1 = "Your soldiers are back from the expedition to the Abyss.";
            string eventString2 = "None of your men want to talk about what they saw there.";
            string eventString3 = "Just one of them had a strange mistical jewel of great value";
            string eventString4 = "(You obtain 4000 golds)";
            string[] message1 = { eventString1, eventString2, eventString3, eventString4 };
            StartCoroutine(dialogoDiRitorno(true, message1));

        }
        if ((tipologia1 == 18) && turngilda1 == 0 || (tipologia2 == 18) && turngilda2 == 0)
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            gilda.setsped5(1);
            player.setsoldiersaway(-50);
            //dialogo 18 - la chiamata va fatta del tipo 'StartCoroutine(dialogoDiRitorno(true, messagge));'
            string eventString1 = "Your soldiers are back from the expedition to the Abyss.";
            string eventString2 = "None of your men want to talk about what they saw there.";
            string eventString3 = "few men have returned compared to those who left";
            string[] message1 = { eventString1, eventString2, eventString3, };
            StartCoroutine(dialogoDiRitorno(true, message1));

        }
        if ((tipologia1 == 19) && turngilda1 == 0 || (tipologia2 == 19) && turngilda2 == 0)
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(4000);
            gilda.setsped5(1);
            player.setsoldiersaway(-50);
            //dialogo 19 - la chiamata va fatta del tipo 'StartCoroutine(dialogoDiRitorno(true, messagge));'
            string eventString1 = "Your soldiers are back from the expedition.";
            string eventString2 = "None of your men want to talk about what they saw there.";
            string eventString3 = "few men have returned compared to those who left";
            string eventString4 = "Just one of them had a strange mistical jewel of great value";
            string eventString5 = "(You obtain 4000 golds)";
            string[] message1 = { eventString1, eventString2, eventString3, eventString4, eventString5 };
            StartCoroutine(dialogoDiRitorno(true, message1));

        }
        if ((tipologia1 == 20) && turngilda1 == 0 || (tipologia2 == 20) && turngilda2 == 0)
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(7500);
            gilda.setsped5(1);
            player.setsoldiersaway(-50);
            //dialogo 20 - la chiamata va fatta del tipo 'StartCoroutine(dialogoDiRitorno(true, messagge));'
            string eventString1 = "Your soldiers are back from the expedition.";
            string eventString2 = "None of your men want to talk about what they saw there.";
            string eventString3 = "one of them had with him a large silver hammer of great value";
            string eventString4 = "(You obtain 7500 golds)";
            string[] message1 = { eventString1, eventString2, eventString3, eventString4 };
            StartCoroutine(dialogoDiRitorno(true, message1));

        }

        if (turngilda1 == 0)
        {
            swordgilda1 = 0;
            arcgilda1 = 0;
            ridgilda1 = 0;
            tipologia1 = 0;
            moltiplicatore1 = 0;
        }
        if (turngilda2 == 0)
        {
            swordgilda2 = 0;
            arcgilda2 = 0;
            ridgilda2 = 0;
            tipologia2 = 0;
            moltiplicatore2 = 0;
        }




        if (true)
        {
            //         Debug.Log("CONFERMA");
        }
    }
}









        /*
        if ((g2 == 0) && (co2 == 1))
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(200);
            Debug.LogError("Ho fatto il mio dovere 2");

            Debug.LogError("controllo1 = " + gilda.getcontrollosped1());
            Debug.LogError("controllo2 = " + gilda.getcontrollosped2());
            //dialogo 2
        }
        if ((g3 == 0) && (co3 == 1))
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(200);
            Debug.LogError("Ho fatto il mio dovere 3");
            Debug.LogError("controllo1 = " + gilda.getcontrollosped1());
            Debug.LogError("controllo2 = " + gilda.getcontrollosped2());
            //dialogo 3
        }
        if ((g4 == 0) && (co4 == 1))
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(200);
            Debug.LogError("Ho fatto il mio dovere 4");

            Debug.LogError("controllo1 = " + gilda.getcontrollosped1());
            Debug.LogError("controllo2 = " + gilda.getcontrollosped2());
            //dialogo 4
        }
        if ((g5 == 0) && (co5 == 1))
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(200);
            //dialogo 5
        }
        if ((g6 == 0) && (co6 == 1))
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(200);
            //dialogo 6
        }
        if ((g7 == 0) && (co7 == 1))
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(200);
            //dialogo 7
        }
        if ((g8 == 0) && (co8 == 1))
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(200);
            //dialogo 8
        }
        if ((g9 == 0) && (co9 == 1))
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(200);
            //dialogo 9
        }
        if ((g10 == 0) && (co10 == 1))
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(200);
            //dialogo 10
        }
        if ((g11 == 0) && (co11 == 1))
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(200);
            //dialogo 11
        }
        if ((g12 == 0) && (co12 == 1))
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(200);
            //dialogo 12
        }
        if ((g13 == 0) && (co13 == 1))
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(200);
            //dialogo 13
        }
        if ((g14 == 0) && (co14 == 1))
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(200);
            //dialogo 14
        }
        if ((g15 == 0) && (co15 == 1))
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(200);
            //dialogo 15
        }
        if ((g16 == 0) && (co16 == 1))
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(200);
            //dialogo 16
        }
        if ((g17 == 0) && (co17 == 1))
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(200);
            //dialogo 17
        }
        if ((g18 == 0) && (co18 == 1))
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(200);
            //dialogo 18
        }
        if ((g19 == 0) && (co19 == 1))
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(200);
            //dialogo 19
        }
        if ((g20 == 0) && (co20 == 1))
        {
            if (gilda.getcontrollosped1() == 1) gilda.setcontrollosped1(0);
            else if (gilda.getcontrollosped2() == 1) gilda.setcontrollosped2(0);
            player.setRapidMoney(200);
            //dialogo 20
        }

    }


*/









































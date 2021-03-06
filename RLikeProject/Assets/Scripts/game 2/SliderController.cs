using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public AudioClip RecruitmentSound;

    public Slider swordsmenSlider;
    public Slider archersSlider;
    public Slider ridersSlider;

    public Text selectedSwordsmenUI;
    public Text minSwordsmenUI;
    public Text maxSwordsmenUI;
    public GameObject noCitizensAvailableSwordsmen;

    public Text selectedArchersUI;
    public Text minArchersUI;
    public Text maxArchersUI;
    public GameObject noCitizensAvailableArchers;

    public Text selectedRidersUI;
    public Text minRidersUI;
    public Text maxRidersUI;
    public GameObject noCitizensAvailableRiders;


    public Text swordmanTotalcostUI;
    public Text archersTotalcostUI;
    public Text ridersTotalcostUI;
    public Text swordmanRemaingSlotUI;
    public Text archersRemaingSlotUI;
    public Text ridersRemaingSlotUI;

    [Header("Disband")]
    public Slider swordsmenDisbandSlider;
    public Slider archersDisbandSlider;
    public Slider ridersDisbandSlider;
    public GameObject noCitizensAvailableSwordsmenDisband;

    public Text selectedDisbandSwordsmenUI;
    public Text minDisbandSwordsmenUI;
    public Text maxDisbandSwordsmenUI;
    public GameObject noCitizensAvailableArchersDisband;

    public Text selectedDisbandArchersUI;
    public Text minDisbandArchersUI;
    public Text maxDisbandArchersUI;
    public GameObject noCitizensAvailableRidersDisband;

    public Text selectedDisbandRidersUI;
    public Text minDisbandRidersUI;
    public Text maxDisbandRidersUI;





    public void RealTimeSliders(Player player, Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders, Caserma caserma)
    {
        if(calcoloMax(player, swordsmen, archers, riders, caserma, 1) != 0)
        {
            minSwordsmenUI.text = "1";
            maxSwordsmenUI.text = "" + calcoloMax(player, swordsmen, archers, riders, caserma, 1);
            swordsmenSlider.minValue = 1;
            swordsmenSlider.maxValue = calcoloMax(player, swordsmen, archers, riders, caserma, 1);
            swordmanTotalcostUI.text = "Cost : " + ((int)swordsmenSlider.value) * 20;

            minArchersUI.text = "1";
            maxArchersUI.text = "" + calcoloMax(player, swordsmen, archers, riders, caserma, 1);
            archersSlider.minValue = 1;
            archersSlider.maxValue = calcoloMax(player, swordsmen, archers, riders, caserma, 1);
            archersTotalcostUI.text = "Cost : " + ((int)archersSlider.value) * 20;

            minRidersUI.text = "1";
            maxRidersUI.text = "" + calcoloMax(player, swordsmen, archers, riders, caserma, 2);
            ridersSlider.minValue = 1;
            ridersSlider.maxValue = calcoloMax(player, swordsmen, archers, riders, caserma, 2);
            ridersTotalcostUI.text = "Cost : " + ((int)ridersSlider.value) * 20;
            noCitizensAvailableSwordsmen.SetActive(false);
            noCitizensAvailableArchers.SetActive(false);
            noCitizensAvailableRiders.SetActive(false);
        }
        else
        {
            minSwordsmenUI.text = "";
            maxSwordsmenUI.text = "";
            minArchersUI.text = "";
            maxArchersUI.text = "";
            minRidersUI.text = "";
            maxRidersUI.text = "";

            swordsmenSlider.minValue = 0;
            swordsmenSlider.maxValue = 0;

            archersSlider.minValue = 0;
            archersSlider.maxValue = 0;

            ridersSlider.minValue = 0;
            ridersSlider.maxValue = 0;


            noCitizensAvailableSwordsmen.SetActive(true);
            noCitizensAvailableArchers.SetActive(true);
            noCitizensAvailableRiders.SetActive(true);
        }
        selectedSwordsmenUI.text = "" + (int)swordsmenSlider.value;
        selectedArchersUI.text = "" + (int)archersSlider.value;
        selectedRidersUI.text = "" + (int)ridersSlider.value;
        swordmanRemaingSlotUI.text = "Remaining slot : " + caserma.getReclutamentoMaxMoment();
        archersRemaingSlotUI.text = "Remaining slot : " + caserma.getReclutamentoMaxMoment();
        ridersRemaingSlotUI.text = "Remaining slot : " + caserma.getReclutamentoMaxMoment();

        
        
        /*------------------------Disband Troops---------------------*/

        if (swordsmen.getTotal() != 0) { 
            minDisbandSwordsmenUI.text = "0";
            maxDisbandSwordsmenUI.text = "" + swordsmen.getTotal();
            swordsmenDisbandSlider.minValue = 0;
            swordsmenDisbandSlider.maxValue = swordsmen.getTotal();
            noCitizensAvailableSwordsmenDisband.SetActive(false);            
        }
        else
        {
            minDisbandSwordsmenUI.text = "";
            maxDisbandSwordsmenUI.text = "";           
            swordsmenDisbandSlider.minValue = 0;
            swordsmenDisbandSlider.maxValue = 0;
            noCitizensAvailableSwordsmenDisband.SetActive(true);
        }
        //
        if (archers.getTotal() != 0) { 
            minDisbandArchersUI.text = "0";
            maxDisbandArchersUI.text = "" + archers.getTotal();
            archersDisbandSlider.minValue = 0;
            archersDisbandSlider.maxValue = archers.getTotal();
            noCitizensAvailableArchersDisband.SetActive(false);            
        }
        else
        {
            minDisbandArchersUI.text = "";
            maxDisbandArchersUI.text = "";            
            archersDisbandSlider.minValue = 0;
            archersDisbandSlider.maxValue = 0;
            noCitizensAvailableArchersDisband.SetActive(true);            
        }
        //
        if (riders.getTotal() != 0) { 
            minDisbandRidersUI.text = "0";
            maxDisbandRidersUI.text = "" + riders.getTotal();
            ridersDisbandSlider.minValue = 0;
            ridersDisbandSlider.maxValue = riders.getTotal();
            noCitizensAvailableRidersDisband.SetActive(false);            
        }
        else
        {
            minDisbandRidersUI.text = "";
            maxDisbandRidersUI.text = "";            
            ridersDisbandSlider.minValue = 0;
            ridersDisbandSlider.maxValue = 0;
            noCitizensAvailableRidersDisband.SetActive(true);
        }  
        //
        selectedDisbandSwordsmenUI.text = "" + (int)swordsmenDisbandSlider.value;
        selectedDisbandArchersUI.text = "" + (int)archersDisbandSlider.value;
        selectedDisbandRidersUI.text = "" + (int)ridersDisbandSlider.value;
        /*------------------------------------------------------------------------*/
    }

    public void onPressStartTraining(int type, Player player, Caserma barracks, Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders)
    {
        if ((int)swordsmenSlider.value != 0 && type == 1)
        {
            player.setRapidMoney((-20)*((int)swordsmenSlider.value));
            player.player_citizens -= (int)swordsmenSlider.value;
            swordsmen.setTempTotal((int)swordsmenSlider.value);
            barracks.setReclutamentoMaxMoment((int)swordsmenSlider.value);
        }
        else if ((int)archersSlider.value != 0 && type == 2)
        {
            player.setRapidMoney((-20) * ((int)archersSlider.value));
            player.player_citizens -= (int)archersSlider.value;
            archers.setTempTotal((int)archersSlider.value);
            barracks.setReclutamentoMaxMoment((int)archersSlider.value);
        }
        else if ((int)ridersSlider.value != 0 && type == 3)
        {
            player.setRapidMoney((-30) * ((int)ridersSlider.value));
            player.player_citizens -= (int)ridersSlider.value;
            riders.setTempTotal((int)ridersSlider.value);
            barracks.setReclutamentoMaxMoment((int)ridersSlider.value);
        }
        FindObjectOfType<AudioManager>().PlayEffect(RecruitmentSound);
    }

    //DisbandTroops
    public void onPressDisbandTroops( Player player,Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders)
    {
        if ((int)swordsmenDisbandSlider.value != 0 || (int)archersDisbandSlider.value != 0 || (int)ridersDisbandSlider.value != 0)
        { 
            
            player.player_citizens += (int)swordsmenDisbandSlider.value;
            swordsmen.setRapidTotal(-(int)swordsmenDisbandSlider.value);
 
            player.player_citizens += (int)archersDisbandSlider.value;
            archers.setRapidTotal(-(int)archersDisbandSlider.value);
            
            player.player_citizens += (int)ridersDisbandSlider.value;
            riders.setRapidTotal(-(int)ridersDisbandSlider.value);
        }    
        
        //FindObjectOfType<AudioManager>().PlayEffect(RecruitmentSound);
    }
    public void ClosingPanels()
    {
        swordsmenSlider.value = swordsmenSlider.minValue;
        archersSlider.value = archersSlider.minValue;
        ridersSlider.value = ridersSlider.minValue;
    }




    public int calcoloMax (Player player, Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders, Caserma caserma, int x)
    {
        int y = player.getCitizens();
        int z = caserma.getReclutamentoMaxMoment();
        if (x == 1)
        {
            while ((20*y) > player.getMoney())
            {
                y = y - 1;
            }
        }
        if (x == 2)
        {
            while ((30 * y) > player.getMoney())
            {
                y = y - 1;
            }
        }
        if (z < y)
        {
            return z;
        }
        else
        {
            return y;
        }

    }
}

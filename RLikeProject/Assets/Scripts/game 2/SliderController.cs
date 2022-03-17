using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
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

    public void RealTimeSliders(Player player, Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders)
    {
        if(player.getCitizens() != 0)
        {
            minSwordsmenUI.text = "1";
            maxSwordsmenUI.text = "" + player.getCitizens();
            swordsmenSlider.minValue = 1;
            swordsmenSlider.maxValue = player.getCitizens();

            minArchersUI.text = "1";
            maxArchersUI.text = "" + player.getCitizens();
            archersSlider.minValue = 1;
            archersSlider.maxValue = player.getCitizens();

            minRidersUI.text = "1";
            maxRidersUI.text = "" + player.getCitizens();
            ridersSlider.minValue = 1;
            ridersSlider.maxValue = player.getCitizens();
        }
        else
        {
            minSwordsmenUI.text = "";
            maxSwordsmenUI.text = "";
            minArchersUI.text = "";
            maxArchersUI.text = "";
            minRidersUI.text = "";
            maxRidersUI.text = "";

            noCitizensAvailableSwordsmen.SetActive(true);
            noCitizensAvailableArchers.SetActive(true);
            noCitizensAvailableRiders.SetActive(true);
        }
        selectedSwordsmenUI.text = "" + (int)swordsmenSlider.value;
        selectedArchersUI.text = "" + (int)archersSlider.value;
        selectedRidersUI.text = "" + (int)ridersSlider.value;
    }

    public void onPressStartTraining(int type, Player player, Caserma barracks, Soldiers.Swordsmen swordsmen, Soldiers.Archers archers, Soldiers.Riders riders)
    {
        if ((int)swordsmenSlider.value != 0 && type == 1)
        {
            player.setRapidMoney((-15)*((int)swordsmenSlider.value));
            player.setTempCitizens((int)swordsmenSlider.value);
            player.player_citizens -= (int)swordsmenSlider.value;
            swordsmen.setTempTotal((int)swordsmenSlider.value);
        }
        else if ((int)archersSlider.value != 0 && type == 2)
        {
            player.setRapidMoney((-15) * ((int)archersSlider.value));
            player.setTempCitizens((int)archersSlider.value);
            player.player_citizens -= (int)archersSlider.value;
            archers.setTempTotal((int)archersSlider.value);
        }
        else if ((int)ridersSlider.value != 0 && type == 3)
        {
            player.setRapidMoney((-15) * ((int)ridersSlider.value));
            player.setTempCitizens((int)ridersSlider.value);
            player.player_citizens -= (int)ridersSlider.value;
            riders.setTempTotal((int)ridersSlider.value);
        }
    }

    public void ClosingPanels()
    {
        swordsmenSlider.value = swordsmenSlider.minValue;
        archersSlider.value = archersSlider.minValue;
        ridersSlider.value = ridersSlider.minValue;
    }
}

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
    public Text selectedArchersUI;
    public Text selectedRidersUI;

    public void onSwordsmenSliderInteraction()
    {
        selectedSwordsmenUI.text = "" + (int)swordsmenSlider.value;
    }
    public void onArchersSliderInteraction()
    {
        selectedArchersUI.text = "" + (int)archersSlider.value;
    }
    public void onRidersSliderInteraction()
    {
        selectedRidersUI.text = "" + (int)ridersSlider.value;
    }
}

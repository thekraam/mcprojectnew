using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreElement : MonoBehaviour
{

    public Text usernameText;
    public Text citynameText;
    public Text goldText;
    public Text seasonText;

    public void NewScoreElement(string _username, string _cityname, string _gold, string _season)
    {
        usernameText.text = _username;
        citynameText.text = _cityname;
        goldText.text = _gold;
        seasonText.text = _season;
    }

}
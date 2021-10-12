using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 public class Prova : MonoBehaviour
 {
    /*int cittadini = 50;
    public int getCittadini()
    {
        return cittadini;
    }

    public void setCittadiniPlusOne()
    {
        cittadini = cittadini + 1;
    }

    public void ChangeCittadiniText()
    {
        public Text citizens;
        citizens.text = "" + 2;

    }*/


    public float cambiacittadini(float cittadini, int modificatore)
    {
        
        cittadini = cittadini + modificatore;
        Debug.Log("Prova: " + cittadini);
        
        return cittadini;
    }
 }

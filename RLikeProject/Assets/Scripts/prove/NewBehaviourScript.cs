using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public Text myText;
   
    public void incremento() {

        
        Prova prova = new Prova();
        

        myText.text = "cambiato: " + (prova.cambiacittadini(5, 2) + 1);
        Debug.Log(prova.cambiacittadini(5, 2) + 1);

    }
}

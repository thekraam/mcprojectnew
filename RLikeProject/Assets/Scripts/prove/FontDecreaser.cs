using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FontDecreaser : MonoBehaviour
{
    public Text Cityname;
    int i=0;


    public void Update()
    {
        if (Cityname.text.Length < 8) Cityname.fontSize = 150;
        if (Cityname.text.Length > 8 && Cityname.text.Length > i)
        {
            Cityname.fontSize -= 4;
            i++;
        }
    }


    public void Decreaser()
    {
        while(Cityname.text.Length > 8 && Cityname.text.Length > i)
        {
            Cityname.fontSize -= 4;
            i++;
        }
    }

}
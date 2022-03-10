using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FontDecreaser : MonoBehaviour
{
    public Text prova;

    public void test()
    {
        if(prova.text.Length > 10)
            prova.fontSize -= 5;
    }
}

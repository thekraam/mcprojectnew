using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public GameObject PanelO;

    public void OpenPanel()
    {
        if(PanelO != null)
        {
            PanelO.SetActive(true);
        }
    }
}

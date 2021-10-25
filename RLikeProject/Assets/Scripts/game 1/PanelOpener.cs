using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    public GameObject panel;

    public void OpenPanel()
    {

        if(panel != null)
        {
            panel.SetActive(true);
        }
    }
    public void OpenPanelAnimator()
    {

        if (panel != null)
        {
            panel.SetActive(true);
            Animator animator = panel.GetComponent<Animator>();
            if(animator != null)
            {
                bool isOpen = animator.GetBool("open");
                
                animator.SetBool("open", !isOpen);
            }
        }
    }

    public void ClosePanel()
    {
        if (panel != null)
        {
            panel.SetActive(false);
        }
    }
}

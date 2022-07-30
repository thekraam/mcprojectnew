using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 public class LoadImage : MonoBehaviour
 {
    public void load(string file_name_in_resources)
    {
        this.gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>(file_name_in_resources);
    }
}

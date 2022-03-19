using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FontDecreaser : MonoBehaviour
{
    public Text Cityname;

	public static FontDecreaser Instance = null;

	int i=0;
    public bool CityInputRequest = false;
	public bool introClosed = false;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy(gameObject);
		}

		DontDestroyOnLoad(gameObject);
	}


	public void Update()
    {
        if (Cityname.text.Length > 8 && CityInputRequest && Cityname.text.Length > i)
        {
			if (Cityname.text.Length > 15)
				Cityname.fontSize -= 1;
		    Cityname.fontSize -= 3;
			i++;
        }
    }

}
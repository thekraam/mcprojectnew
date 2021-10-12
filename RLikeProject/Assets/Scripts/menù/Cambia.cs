using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace TryEz
{
    public class Cambia : MonoBehaviour
    {
        public string menutest;

        public void CaricaScena()
        {
            SceneManager.LoadScene(menutest);
        }
    }
}

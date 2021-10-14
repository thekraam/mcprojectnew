using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace TryEz
{
    public class ChangeScene : MonoBehaviour
    {
        public string ChangeToScene;

        public void LoadScene()
        {
            SceneManager.LoadScene(ChangeToScene);
        }
    }
}

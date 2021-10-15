using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    public GameObject loadingPanel;
    public CanvasGroup canvasGroup;

    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {

        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(loadingPanel.transform.parent);

    }
    
    // Update is called once per frame
    void Update()
    {
        if (onPressButton())
        {

        }
    }

    public bool onPressButton()
    {
        StartCoroutine(LoadScene(sceneName));
        return true;
   
    }
    

    IEnumerator LoadScene(string sceneName)
    {
        loadingPanel.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        while (!operation.isDone)
        {
            yield return new WaitForSeconds(2);
        }
        StartCoroutine(LoadingScreenFadeOut(2f));
    }

    IEnumerator LoadingScreenFadeOut(float duration)
    {
        float timePassed = 0f;
        float startAlpha = canvasGroup.alpha;

        while (timePassed < duration)
        {
            timePassed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 0f, timePassed / duration);
            yield return new WaitForSeconds(2);
        }
        loadingPanel.SetActive(false);
        canvasGroup.alpha = 1f;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TryEz;

public class SceneLoader : MonoBehaviour
{

    public GameObject loadingPanel;
    public CanvasGroup canvasGroup;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(loadingPanel.transform.parent);
    }

    public void onPressButton(string sceneName)
    {
        StartCoroutine(LoadScene(sceneName));
    }
    

    IEnumerator LoadScene(string sceneName)
    {
        loadingPanel.SetActive(true);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while (!operation.isDone)
        {
            yield return null;
        }
        StartCoroutine(LoadingScreenFadeOut(0.8f));
    }

    IEnumerator LoadingScreenFadeOut(float duration)
    {
        float test = Random.Range(1.5f, 3.5f);
  
        yield return new WaitForSeconds(test);

        float timePassed = 0f;
        float startAlpha = canvasGroup.alpha;

        while (timePassed < duration)
        {
            timePassed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 0f, timePassed / duration);
            yield return null;
        }
        loadingPanel.SetActive(false);
        canvasGroup.alpha = 1f;
    }
}
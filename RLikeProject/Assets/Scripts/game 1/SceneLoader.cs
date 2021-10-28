using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TryEz;

public class SceneLoader : MonoBehaviour
{
    public SpriteRenderer horserender;
    public GameObject horse;
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

    /*
    public void onPressButtonSpecial()
    {
        StartCoroutine(LoadingScreenFadeOut());
    }*/

    IEnumerator LoadScene(string sceneName)
    {

        loadingPanel.SetActive(true);
        if (sceneName == "0")
            StartCoroutine(LoadingScreenFadeOut(0.8f, true));
        else
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

            while (!operation.isDone)
            {
                yield return null;
            }
            StartCoroutine(LoadingScreenFadeOut(0.8f, false));
        }

    }

    IEnumerator LoadingScreenFadeOut(float duration, bool isSkippingTurn)
    {
        float test;
        if (isSkippingTurn)
            test = 1f;
        else
            test = Random.Range(1.5f, 3.5f);

        yield return new WaitForSeconds(test);

        float timePassed = 0f;
        float startAlpha = canvasGroup.alpha;
        float spritealpha;

        while (timePassed < duration)
        {
            timePassed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 0f, timePassed / duration);
            spritealpha = Mathf.Lerp(startAlpha, 0f, timePassed / duration);
            horserender = horse.GetComponent<SpriteRenderer>();
            Color horsecolor = new Color(1f, 1f, 1f, spritealpha);
            horserender.color = horsecolor;
            yield return null;
        }
        loadingPanel.SetActive(false);
        canvasGroup.alpha = 1f;
        Color resetcolor = new Color(1f, 1f, 1f, 1f);
        horserender.color = resetcolor;
    }
}
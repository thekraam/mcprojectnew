using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public SpriteRenderer horserender;
    public GameObject horse;
    public GameObject loadingPanel;
    public CanvasGroup canvasGroup;

    public GameObject IntroExecutionPanel;

    public AudioClip MainMenuMusic;

    public float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().PlayMusic(MainMenuMusic);
    }

    public void onQuitPressed()
    {
        SceneManager.UnloadSceneAsync(0);
        SceneManager.UnloadSceneAsync(1);
    }


    public void onPressButton(bool NewGame)
    {
        if (NewGame)
        {
            FindObjectOfType<AudioManager>().StopMusic(MainMenuMusic);
            IntroExecutionPanel.SetActive(true);
            FindObjectOfType<IntroExecution>().StartExecution();
        }
        else
        {
            loadingPanel.SetActive(true);
            StartCoroutine(LoadingScreenFadeOut(0.8f));
        }
    }
    public void onPressRestart()
    {
        
        FindObjectOfType<Game>().onQuitGame();
        onPressButton(true);
        FindObjectOfType<Game>().mainMenuPanel.SetActive(false);

        
    }

    /*
    public void onPressButtonSpecial()
    {
        StartCoroutine(LoadingScreenFadeOut());
    }*/

    IEnumerator LoadingScreenFadeOut(float duration)
    {
        waitTime = Random.Range(1.25f, 2.5f);

        yield return new WaitForSeconds(waitTime);

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
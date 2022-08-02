using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OutroExecution : MonoBehaviour
{
    public GameObject menu;
    public CanvasGroup self;

    //VITTORIA
    public CanvasGroup preLineVictory;
    public CanvasGroup firstLineVictory;
    public CanvasGroup secondLineVictory;
    public CanvasGroup thirdLineVictory;
    public CanvasGroup starsVictory;
    public CanvasGroup textVictory;

    //SCONFITTA
    public CanvasGroup preLineDefeat;
    public CanvasGroup firstLineDefeat;
    public CanvasGroup secondLineDefeat;
    public CanvasGroup thirdLineDefeat;
    public CanvasGroup starsDefeat;
    public CanvasGroup textDefeat;

    public bool outroSequenceOff = false;

    public static OutroExecution Instance = null;

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

        //DontDestroyOnLoad(gameObject);
    }

    //AVVIA ME PER INIZIARE TUTTO
    public void StartExecution(bool isVictory)
    {
        SaveSystem.DeleteSave();

        self.gameObject.SetActive(true);

        StartCoroutine(isVictory ? FadeSequenceVictory() : FadeSequenceDefeat());
    }

    IEnumerator FadeSequenceVictory()
    {
        ////ACCENDI SELF/////
        float timePassed = 0f;
        while (timePassed < 0.8f)
        {
            timePassed += Time.deltaTime;
            self.alpha = Mathf.Lerp(0f, 1f, timePassed / 0.8f); // da 0f a 1f si accende, da 1f a 0f si spegne
            yield return new WaitForSeconds(0.007f);
        }

        yield return new WaitForSeconds(0.7f);

        ////STARS E VICTORY TEXT/////
        timePassed = 0f;
        while (timePassed < 0.8f)
        {
            timePassed += Time.deltaTime;
            starsVictory.alpha = Mathf.Lerp(0f, 1f, timePassed / 0.8f); // da 0f a 1f si accende, da 1f a 0f si spegne
            textVictory.alpha = Mathf.Lerp(0f, 1f, timePassed / 0.8f); // da 0f a 1f si accende, da 1f a 0f si spegne
            yield return new WaitForSeconds(0.007f);
        }

        yield return new WaitForSeconds(0.7f);

        ///////////PRELINE ON///////////
        timePassed = 0f;
        while (timePassed < 0.8f)
        {
            timePassed += Time.deltaTime;
            preLineVictory.alpha = Mathf.Lerp(0f, 1f, timePassed / 0.8f); // da 0f a 1f si accende, da 1f a 0f si spegne
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(5.5f);

        ///////////PRELINE E TUTTO IL RESTO OFF///////////
        timePassed = 0f;
        while (timePassed < 0.8f)
        {
            timePassed += Time.deltaTime;
            preLineVictory.alpha = Mathf.Lerp(1f, 0f, timePassed / 0.8f); // da 0f a 1f si accende, da 1f a 0f si spegne
            textVictory.alpha = Mathf.Lerp(1f, 0f, timePassed / 0.8f); // da 0f a 1f si accende, da 1f a 0f si spegne
            yield return new WaitForSeconds(0.007f);
        }

        yield return new WaitForSeconds(1.5f);


        ///////////FIRSTLINE///////////
        timePassed = 0f;
        while (timePassed < 0.8f)
        {
            timePassed += Time.deltaTime;
            firstLineVictory.alpha = Mathf.Lerp(0f, 1f, timePassed / 0.8f); // da 0f a 1f si accende, da 1f a 0f si spegne
            yield return new WaitForSeconds(0.007f);
        }

        yield return new WaitForSeconds(1.5f);

        /////SECONDLINE//////////
        timePassed = 0f;
        while (timePassed < 0.8f)
        {
            timePassed += Time.deltaTime;
            secondLineVictory.alpha = Mathf.Lerp(0f, 1f, timePassed / 0.8f);
            yield return new WaitForSeconds(0.007f);

        }

        yield return new WaitForSeconds(1.5f);

        /////THIRDLINE////////
        timePassed = 0f;

        while (timePassed < 0.8f)
        {
            timePassed += Time.deltaTime;
            thirdLineVictory.alpha = Mathf.Lerp(0f, 1f, timePassed / 0.8f);
            yield return new WaitForSeconds(0.007f);
        }

        yield return new WaitForSeconds(1.5f);

        timePassed = 0f;

        /* fadeOut */
        /*while (timePassed3 < 0.8f)
        {
            timePassed3 += Time.deltaTime;
            thirdLine.alpha = Mathf.Lerp(1f, 0f, timePassed3 / 0.8f);
            yield return new WaitForSeconds(0.001f);
        }*/
        menu.SetActive(true);

        while (timePassed < 0.8f)
        {
            timePassed += Time.deltaTime;
            self.alpha = Mathf.Lerp(1f, 0f, timePassed / 0.8f);
            yield return new WaitForSeconds(0.01f);
        }

        //yield return new WaitForSeconds(0.2f);

        FindObjectOfType<AudioManager>().StopMusic(FindObjectOfType<AudioManager>().MusicSource.clip);
        
        

        //timePassed = 0f;
        //while (timePassed < 0.8f)
        //{
        //    timePassed += Time.deltaTime;
        //    self.alpha = Mathf.Lerp(1f, 0f, timePassed / 0.8f);
        //    yield return new WaitForSeconds(0.001f);
        //}

        FindObjectOfType<AudioManager>().ForcePlayMusic(FindObjectOfType<AudioManager>().MusicSource.clip);
        self.gameObject.SetActive(false);
    }
    IEnumerator FadeSequenceDefeat()
    {

        ////ACCENDI SELF/////
        float timePassed = 0f;
        while (timePassed < 0.8f)
        {
            timePassed += Time.deltaTime;
            self.alpha = Mathf.Lerp(0f, 1f, timePassed / 0.8f); // da 0f a 1f si accende, da 1f a 0f si spegne
            yield return new WaitForSeconds(0.007f);
        }

        yield return new WaitForSeconds(0.7f);

        ////STARS E Defeat TEXT/////
        timePassed = 0f;
        while (timePassed < 0.8f)
        {
            timePassed += Time.deltaTime;
            starsDefeat.alpha = Mathf.Lerp(0f, 1f, timePassed / 0.8f); // da 0f a 1f si accende, da 1f a 0f si spegne
            textDefeat.alpha = Mathf.Lerp(0f, 1f, timePassed / 0.8f); // da 0f a 1f si accende, da 1f a 0f si spegne
            yield return new WaitForSeconds(0.007f);
        }

        yield return new WaitForSeconds(0.7f);

        ///////////PRELINE ON///////////
        timePassed = 0f;
        while (timePassed < 0.8f)
        {
            timePassed += Time.deltaTime;
            preLineDefeat.alpha = Mathf.Lerp(0f, 1f, timePassed / 0.8f); // da 0f a 1f si accende, da 1f a 0f si spegne
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(5.5f);

        ///////////PRELINE E TUTTO IL RESTO OFF///////////
        timePassed = 0f;
        while (timePassed < 0.8f)
        {
            timePassed += Time.deltaTime;
            preLineDefeat.alpha = Mathf.Lerp(1f, 0f, timePassed / 0.8f); // da 0f a 1f si accende, da 1f a 0f si spegne
            textDefeat.alpha = Mathf.Lerp(1f, 0f, timePassed / 0.8f); // da 0f a 1f si accende, da 1f a 0f si spegne
            yield return new WaitForSeconds(0.007f);
        }

        yield return new WaitForSeconds(1.5f);


        ///////////FIRSTLINE///////////
        timePassed = 0f;
        while (timePassed < 0.8f)
        {
            timePassed += Time.deltaTime;
            firstLineDefeat.alpha = Mathf.Lerp(0f, 1f, timePassed / 0.8f); // da 0f a 1f si accende, da 1f a 0f si spegne
            yield return new WaitForSeconds(0.007f);
        }

        yield return new WaitForSeconds(1.5f);

        /////SECONDLINE//////////
        timePassed = 0f;
        while (timePassed < 0.8f)
        {
            timePassed += Time.deltaTime;
            secondLineDefeat.alpha = Mathf.Lerp(0f, 1f, timePassed / 0.8f);
            yield return new WaitForSeconds(0.007f);

        }

        yield return new WaitForSeconds(1.5f);

        /////THIRDLINE////////
        timePassed = 0f;

        while (timePassed < 0.8f)
        {
            timePassed += Time.deltaTime;
            thirdLineDefeat.alpha = Mathf.Lerp(0f, 1f, timePassed / 0.8f);
            yield return new WaitForSeconds(0.007f);
        }

        yield return new WaitForSeconds(1.5f);

        timePassed = 0f;

        /* fadeOut */
        /*while (timePassed3 < 0.8f)
        {
            timePassed3 += Time.deltaTime;
            thirdLine.alpha = Mathf.Lerp(1f, 0f, timePassed3 / 0.8f);
            yield return new WaitForSeconds(0.001f);
        }*/
        menu.SetActive(true);

        while (timePassed < 0.8f)
        {
            timePassed += Time.deltaTime;
            self.alpha = Mathf.Lerp(1f, 0f, timePassed / 0.8f);
            //secondLineDefeat.alpha = Mathf.Lerp(1f, 0f, timePassed / 0.8f); // da commentare qualora metodo 2
            //thirdLineDefeat.alpha = Mathf.Lerp(1f, 0f, timePassed / 0.8f); // da commentare qualora metodo 2
            yield return new WaitForSeconds(0.01f);
        }

        //yield return new WaitForSeconds(0.2f);

        FindObjectOfType<AudioManager>().StopMusic(FindObjectOfType<AudioManager>().MusicSource.clip);
        


        //timePassed = 0f;
        //while (timePassed < 0.8f)
        //{
        //    timePassed += Time.deltaTime;
        //    self.alpha = Mathf.Lerp(1f, 0f, timePassed / 0.8f);
        //    yield return new WaitForSeconds(0.001f);
        //}

        FindObjectOfType<AudioManager>().ForcePlayMusic(FindObjectOfType<AudioManager>().MusicSource.clip);
        self.gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroExecution : MonoBehaviour
{
    public GameObject MainMenu;
    public CanvasGroup skipButton;
    public GameObject skipButtonObject;
    public GameObject confirmSelection;
    public Text InputTextToRead;

    public Button logo1;
    public Button logo2;
    public Button logo3;
    public Button logo4;

    public CanvasGroup firstLine;
    public CanvasGroup secondLine;
    public CanvasGroup thirdLine;
    public CanvasGroup fourthLine;
    public CanvasGroup fifthLine;
    public CanvasGroup sixthLine;
    public CanvasGroup stars;
    public CanvasGroup IntroSequence;
    public CanvasGroup Choice;

    public AudioClip ConfirmSoundEffect;
    public AudioClip NewGameIntroEffect;
    public AudioClip flipToGameEffect;

    bool skipIsPressed = false;
    public bool introSequenceOff = false;

    public static IntroExecution Instance = null;

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

    public void ButtonHandler(int currentButton)
    {
        if(currentButton == 1)
        {
            logo1.interactable = false;
            logo2.interactable = true;
            logo3.interactable = true;
            logo4.interactable = true;
        }
        if (currentButton == 2)
        {
            logo1.interactable = true;
            logo2.interactable = false;
            logo3.interactable = true;
            logo4.interactable = true;
        }
        if (currentButton == 3)
        {
            logo1.interactable = true;
            logo2.interactable = true;
            logo3.interactable = false;
            logo4.interactable = true;
        }
        if (currentButton == 4)
        {
            logo1.interactable = true;
            logo2.interactable = true;
            logo3.interactable = true;
            logo4.interactable = false;
        }
    }

    public void SetLogo(int logoSelector)
    {
        ButtonHandler(logoSelector);
        if (logoSelector == 1)
        {
            FindObjectOfType<Game>().logoUI_1.SetActive(true);
            FindObjectOfType<Game>().logoUI_2.SetActive(false);
            FindObjectOfType<Game>().logoUI_3.SetActive(false);
            FindObjectOfType<Game>().logoUI_4.SetActive(false);
        }
        if (logoSelector == 2)
        {
            FindObjectOfType<Game>().logoUI_1.SetActive(false);
            FindObjectOfType<Game>().logoUI_2.SetActive(true);
            FindObjectOfType<Game>().logoUI_3.SetActive(false);
            FindObjectOfType<Game>().logoUI_4.SetActive(false);
        }
        if (logoSelector == 3)
        {
            FindObjectOfType<Game>().logoUI_1.SetActive(false);
            FindObjectOfType<Game>().logoUI_2.SetActive(false);
            FindObjectOfType<Game>().logoUI_3.SetActive(true);
            FindObjectOfType<Game>().logoUI_4.SetActive(false);
        }
        if (logoSelector == 4)
        {
            FindObjectOfType<Game>().logoUI_1.SetActive(false);
            FindObjectOfType<Game>().logoUI_2.SetActive(false);
            FindObjectOfType<Game>().logoUI_3.SetActive(false);
            FindObjectOfType<Game>().logoUI_4.SetActive(true);
        }
    }
    public void EndOfSequenceCityText(Text City)
    {
        MainMenu.SetActive(false);

        if (City.text != "")
        {
            confirmSelection.gameObject.GetComponentInChildren<Button>().interactable = false;
            FindObjectOfType<FontDecreaser>().Cityname.text = City.text;
            FindObjectOfType<FontDecreaser>().CityInputRequest = true;
            StartCoroutine(EndOfExecution());
        }
    }

    IEnumerator EndOfExecution()
    {
        // riproduzione suono sul confirm
        yield return new WaitForSeconds(0.8f);
        float choiceTime = 0f;
        FindObjectOfType<AudioManager>().PlayEffect(flipToGameEffect);
        while (choiceTime < 0.8f)
        {
            choiceTime += Time.deltaTime;
            Choice.alpha = Mathf.Lerp(1f, 0f, choiceTime / 0.8f); // da 0f a 1f si accende, da 1f a 0f si spegne
            IntroSequence.alpha = Mathf.Lerp(1f, 0f, choiceTime / 0.8f);
            yield return new WaitForSeconds(0.001f);
        }
        confirmSelection.SetActive(false);
        
        FindObjectOfType<FontDecreaser>().introClosed = true;

        if (FindObjectOfType<FirebaseManager>().isSignedIn())
        {
            StartCoroutine(FindObjectOfType<FirebaseManager>().LoadUserTutorial());

            yield return new WaitUntil(() => FindObjectOfType<FirebaseManager>().dataLoaded == true);
            FindObjectOfType<FirebaseManager>().dataLoaded = false;

            FindObjectOfType<FirebaseManager>().SaveDataButton();
        }

        IntroSequence.gameObject.SetActive(false);
    }

    public void StartExecution()
    {
        StartCoroutine(FadeSequence());
    }

    public void Skipping()
    {
        skipIsPressed = true;
    }

    IEnumerator FadeSequence()
    {
        /* azzeramento nome vecchio */
        InputTextToRead.text = "";

        /* fadeIn ad IntroSequence gameobject */
        skipButton.gameObject.SetActive(true);
        skipButton.alpha = 1;
        skipButtonObject.SetActive(true);
        skipButtonObject.GetComponentInChildren<Button>().interactable = true;

        float timePassed0 = 0f;
        while (timePassed0 < 0.8f)
        {
            timePassed0 += Time.deltaTime;
            IntroSequence.alpha = Mathf.Lerp(0f, 1f, timePassed0 / 0.8f); // da 0f a 1f si accende, da 1f a 0f si spegne
            yield return new WaitForSeconds(0.002f);
        }

        yield return new WaitForSeconds(0.5f);

        //////////////////////////////////////////
        float timePassed = 0f;
        while (timePassed < 0.8f)
        {
            if (skipIsPressed)
            {
                firstLine.alpha = 1f;
                timePassed = 1f;
            }
            else
            {
                timePassed += Time.deltaTime;
                firstLine.alpha = Mathf.Lerp(0f, 1f, timePassed / 0.8f); // da 0f a 1f si accende, da 1f a 0f si spegne
                yield return new WaitForSeconds(0.007f);
            }
        }
        if (skipIsPressed)
        {
            yield return null;
            skipIsPressed = false;
        }
        else
        {
            yield return new WaitForSeconds(1.5f);
        }
        timePassed = 0f;

        /* fadeOut */
        /*while (timePassed < 0.8f)
        {
            timePassed += Time.deltaTime;
            firstLine.alpha = Mathf.Lerp(1f, 0f, timePassed / 0.8f); 
            yield return new WaitForSeconds(0.001f);
        }*/
        
        float timePassed2 = 0f;
        while (timePassed2 < 0.8f)
        {
            if (skipIsPressed)
            {
                secondLine.alpha = 1f;
                timePassed2 = 1f;
            }
            else
            {
                timePassed2 += Time.deltaTime;
                secondLine.alpha = Mathf.Lerp(0f, 1f, timePassed2 / 0.8f);
                yield return new WaitForSeconds(0.007f);
            }
        }


        if (skipIsPressed)
        {
            yield return null;
            skipIsPressed = false;
        }
        else
        {
            yield return new WaitForSeconds(1.5f);
        }

        timePassed2 = 0f;

        /* fadeOut */
        /*while (timePassed2 < 0.8f)
        {
            timePassed2 += Time.deltaTime;
            secondLine.alpha = Mathf.Lerp(1f, 0f, timePassed2 / 0.8f);
            yield return new WaitForSeconds(0.001f);
        }*/

        float timePassed3 = 0f;
        while (timePassed3 < 0.8f)
        {
            if (skipIsPressed)
            {
                secondLine.alpha = 1f;
                timePassed3 = 1f;
            }
            else
            {
                timePassed3 += Time.deltaTime;
                thirdLine.alpha = Mathf.Lerp(0f, 1f, timePassed3 / 0.8f);
                yield return new WaitForSeconds(0.007f);
            }
        }

        if (skipIsPressed)
        {
            yield return null;
            skipIsPressed = false;
        }
        else
        {
            yield return new WaitForSeconds(1.5f);
        }
        timePassed3 = 0f;

        /* fadeOut */
        /*while (timePassed3 < 0.8f)
        {
            timePassed3 += Time.deltaTime;
            thirdLine.alpha = Mathf.Lerp(1f, 0f, timePassed3 / 0.8f);
            yield return new WaitForSeconds(0.001f);
        }*/

        while (timePassed3 < 0.8f)
        {
            if (skipIsPressed)
            {
                firstLine.alpha = 0f;
                secondLine.alpha = 0f;
                thirdLine.alpha = 0f;
                timePassed3 = 1f;
            }
            else
            {
                timePassed3 += Time.deltaTime;
                firstLine.alpha = Mathf.Lerp(1f, 0f, timePassed3 / 0.8f);
                secondLine.alpha = Mathf.Lerp(1f, 0f, timePassed3 / 0.8f); // da commentare qualora metodo 2
                thirdLine.alpha = Mathf.Lerp(1f, 0f, timePassed3 / 0.8f); // da commentare qualora metodo 2
                yield return new WaitForSeconds(0.01f);
            }
        }

        if (skipIsPressed)
        {
            yield return null;
            skipIsPressed = false;
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
        }

        /////////////////////////////////////* walltext *//////////////////////////////////////

        float timePassed4 = 0f;
        while (timePassed4 < 0.6f)
        {
            if (skipIsPressed)
            {
                timePassed4 = 1f;
                fourthLine.alpha = 1f;
                stars.alpha = 1f;
            }
            else
            {
                timePassed4 += Time.deltaTime;
                fourthLine.alpha = Mathf.Lerp(0f, 1f, timePassed4 / 0.6f); // da 0f a 1f si accende, da 1f a 0f si spegne
                stars.alpha = Mathf.Lerp(0f, 1f, timePassed4 / 0.6f);
                yield return new WaitForSeconds(0.025f);
            }
        }

        timePassed4 = 0f;

        if (skipIsPressed)
        {
            yield return null;
            skipIsPressed = false;
        }
        else
        {
            yield return new WaitForSeconds(3.25f);
        }

        while (timePassed4 < 0.8f) // fadeout fourthline
        {
            if (skipIsPressed)
            {
                timePassed4 = 1;
                fourthLine.alpha = 0f;
            }
            else
            {
                timePassed4 += Time.deltaTime;
                fourthLine.alpha = Mathf.Lerp(1f, 0f, timePassed4 / 0.8f);
                yield return new WaitForSeconds(0.01f);
            }
        }

        if (skipIsPressed)
        {
            yield return null;
            skipIsPressed = false;
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
        }

        float timePassed5 = 0f;

        while (timePassed5 < 0.6f)
        {
            if (skipIsPressed)
            {
                timePassed5 = 1f;
                fifthLine.alpha = 1f;
            }
            else
            {
                timePassed5 += Time.deltaTime;
                fifthLine.alpha = Mathf.Lerp(0f, 1f, timePassed5 / 0.6f);
                yield return new WaitForSeconds(0.01f);
            }
        }

        timePassed5 = 0f;
        if (skipIsPressed)
        {
            yield return null;
            skipIsPressed = false;
        }
        else
        {
            yield return new WaitForSeconds(3.2f);
        }

        while (timePassed5 < 0.6f) // fadeout fifthline
        {
            if (skipIsPressed)
            {
                timePassed5 = 1f;
                fifthLine.alpha = 0f;
            }
            else
            {
                timePassed5 += Time.deltaTime;
                fifthLine.alpha = Mathf.Lerp(1f, 0f, timePassed5 / 0.6f);
                yield return new WaitForSeconds(0.01f);
            }
        }

        if (skipIsPressed)
        {
            yield return null;
            skipIsPressed = false;
        }
        else
        {
            yield return new WaitForSeconds(0.5f);
        }

        float timePassed6 = 0f;
        while (timePassed6 < 0.6f)
        {
            if (skipIsPressed)
            {
                timePassed6 = 1f;
                sixthLine.alpha = 1f;
            }
            else
            {
                timePassed6 += Time.deltaTime;
                sixthLine.alpha = Mathf.Lerp(0f, 1f, timePassed6 / 0.6f);
                yield return new WaitForSeconds(0.01f);
            }
        }

        if (skipIsPressed)
        {
            yield return null;
            skipIsPressed = false;
        }
        else
        {
            yield return new WaitForSeconds(3.2f);
        }
        timePassed6 = 0f;

        while (timePassed6 < 0.6f) // fadeout sixthline
        {
            timePassed6 += Time.deltaTime;
            sixthLine.alpha = Mathf.Lerp(1f, 0f, timePassed6 / 0.6f);
            stars.alpha = Mathf.Lerp(1f, 0f, timePassed6 / 0.6f);
            skipButton.alpha = Mathf.Lerp(1f, 0f, timePassed6 / 0.6f);
            yield return new WaitForSeconds(0.025f);
        }

        skipButtonObject.SetActive(false);
        skipButtonObject.GetComponentInChildren<Button>().interactable = false;

        confirmSelection.gameObject.SetActive(true);
        confirmSelection.gameObject.GetComponentInChildren<Button>().interactable = true;

        yield return new WaitForSeconds(0.8f);

        float choiceTime = 0f;
        while (choiceTime < 0.8f)
        {
            choiceTime += Time.deltaTime;
            Choice.alpha = Mathf.Lerp(0f, 1f, choiceTime / 0.8f); // da 0f a 1f si accende, da 1f a 0f si spegne
            yield return new WaitForSeconds(0.001f);
        }
    }

}

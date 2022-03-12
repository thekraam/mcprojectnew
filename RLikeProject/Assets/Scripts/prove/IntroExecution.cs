using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroExecution : MonoBehaviour
{
    public CanvasGroup firstLine;
    public CanvasGroup secondLine;
    public CanvasGroup thirdLine;
    public void StartExecution()
    {
        StartCoroutine(FadeSequence());
    }

    IEnumerator FadeSequence()
    {
        float timePassed = 0f;
        while (timePassed < 0.8f)
        {
            timePassed += Time.deltaTime;
            firstLine.alpha = Mathf.Lerp(0f, 1f, timePassed / 0.8f); // da 0f a 1f si accende, da 1f a 0f si spegne
            Debug.LogError("alpha");
            Debug.LogError(firstLine.alpha);
            yield return new WaitForSeconds(0.025f);
        }

        yield return new WaitForSeconds(0.75f);
        timePassed = 0f;

        while (timePassed < 0.8f)
        {
            timePassed += Time.deltaTime;
            firstLine.alpha = Mathf.Lerp(1f, 0f, timePassed / 0.8f); 
            Debug.LogError("alpha2");
            Debug.LogError(firstLine.alpha);
            yield return new WaitForSeconds(0.025f);
        }

        yield return new WaitForSeconds(1.5f);
        
        float timePassed2 = 0f;
        while (timePassed2 < 0.8f)
        {
            timePassed2 += Time.deltaTime;
            secondLine.alpha = Mathf.Lerp(0f, 1f, timePassed2 / 0.8f);
            yield return new WaitForSeconds(0.025f);
        }

        yield return new WaitForSeconds(0.75f);
        timePassed2 = 0f;

        while (timePassed2 < 0.8f)
        {
            timePassed2 += Time.deltaTime;
            secondLine.alpha = Mathf.Lerp(1f, 0f, timePassed2 / 0.8f);
            yield return new WaitForSeconds(0.025f);
        }

        yield return new WaitForSeconds(1.5f);

        float timePassed3 = 0f;
        while (timePassed3 < 0.8f)
        {
            timePassed3 += Time.deltaTime;
            thirdLine.alpha = Mathf.Lerp(0f, 1f, timePassed3 / 0.8f);
            yield return new WaitForSeconds(0.025f);
        }

        yield return new WaitForSeconds(0.75f);
        timePassed3 = 0f;

        while (timePassed3 < 0.8f)
        {
            timePassed3 += Time.deltaTime;
            thirdLine.alpha = Mathf.Lerp(1f, 0f, timePassed3 / 0.8f);
            yield return new WaitForSeconds(0.025f);
        }
    }

}

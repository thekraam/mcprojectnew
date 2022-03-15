using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroExecution : MonoBehaviour
{
    public CanvasGroup firstLine;
    public CanvasGroup secondLine;
    public CanvasGroup thirdLine;
    public CanvasGroup fourthLine;
    public CanvasGroup fifthLine;
    public CanvasGroup sixthLine;
    public CanvasGroup stars;
    public CanvasGroup IntroSequence;

    bool skipIsPressed = false;

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
        /* fadeIn ad IntroSequence gameobject */

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

                skipIsPressed = false;
            }
            else
            {
                timePassed += Time.deltaTime;
                firstLine.alpha = Mathf.Lerp(0f, 1f, timePassed / 0.8f); // da 0f a 1f si accende, da 1f a 0f si spegne
                yield return new WaitForSeconds(0.007f);
            }
        }

        yield return new WaitForSeconds(1.5f);
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

                skipIsPressed = false;
            }
            else
            {
                timePassed3 += Time.deltaTime;
                thirdLine.alpha = Mathf.Lerp(0f, 1f, timePassed3 / 0.8f);
                yield return new WaitForSeconds(0.007f);
            }
        }

        yield return new WaitForSeconds(1.5f);
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

                skipIsPressed = false;
            }
            else
            {
                timePassed3 += Time.deltaTime;
                firstLine.alpha = Mathf.Lerp(1f, 0f, timePassed3 / 0.8f);
                secondLine.alpha = Mathf.Lerp(1f, 0f, timePassed3 / 0.8f); // da commentare qualora metodo 2
                thirdLine.alpha = Mathf.Lerp(1f, 0f, timePassed3 / 0.8f); // da commentare qualora metodo 2
                yield return new WaitForSeconds(0.025f);
            }
        }



        /////////////////////////////////////* walltext *//////////////////////////////////////

        float timePassed4 = 0f;
        while (timePassed4 < 0.6f)
        {
            timePassed4 += Time.deltaTime;
            fourthLine.alpha = Mathf.Lerp(0f, 1f, timePassed4 / 0.6f); // da 0f a 1f si accende, da 1f a 0f si spegne
            stars.alpha = Mathf.Lerp(0f, 1f, timePassed4 / 0.6f);
            yield return new WaitForSeconds(0.025f);
        }

        timePassed4 = 0f;

        yield return new WaitForSeconds(2.5f); // attesa per fadeout

        while (timePassed4 < 0.8f) // fadeout fourthline
        {
            timePassed4 += Time.deltaTime;
            fourthLine.alpha = Mathf.Lerp(1f, 0f, timePassed4 / 0.8f);
            yield return new WaitForSeconds(0.025f);
        }

        yield return new WaitForSeconds(1f);

        float timePassed5 = 0f;

        while (timePassed5 < 0.6f)
        {
            timePassed5 += Time.deltaTime;
            fifthLine.alpha = Mathf.Lerp(0f, 1f, timePassed5 / 0.6f);
            yield return new WaitForSeconds(0.025f);
        }
        timePassed5 = 0f;
        yield return new WaitForSeconds(2.5f);

        while (timePassed5 < 0.6f) // fadeout fifthline
        {
            timePassed5 += Time.deltaTime;
            fifthLine.alpha = Mathf.Lerp(1f, 0f, timePassed5 / 0.6f);
            yield return new WaitForSeconds(0.025f);
        }

        yield return new WaitForSeconds(1f);

        float timePassed6 = 0f;
        while (timePassed6 < 0.6f)
        {
            timePassed6 += Time.deltaTime;
            sixthLine.alpha = Mathf.Lerp(0f, 1f, timePassed6 / 0.6f);
            yield return new WaitForSeconds(0.025f);
        }

        yield return new WaitForSeconds(2.5f);
        timePassed6 = 0f;

        while (timePassed6 < 0.6f) // fadeout sixthline
        {
            timePassed6 += Time.deltaTime;
            sixthLine.alpha = Mathf.Lerp(1f, 0f, timePassed6 / 0.6f);
            stars.alpha = Mathf.Lerp(1f, 0f, timePassed6 / 0.6f);
            yield return new WaitForSeconds(0.025f);
        }

        yield return new WaitForSeconds(3.2f);

        /* sparizione primo walltext */
        /*while (timePassed4 < 0.8f)
        {
            timePassed4 += Time.deltaTime;
            fourthLine.alpha = Mathf.Lerp(1f, 0f, timePassed4 / 0.8f);
            //fifthLine.alpha = Mathf.Lerp(1f, 0f, timePassed4 / 0.8f); // da commentare qualora metodo 2
            //sixthLine.alpha = Mathf.Lerp(1f, 0f, timePassed4 / 0.8f); // da commentare qualora metodo 2
            yield return new WaitForSeconds(0.025f);
        }*/

        ///* metodo 2 *///

        /* sparizione secondo walltext */

        /*while (timePassed5 < 0.8f)
        {
            timePassed5 += Time.deltaTime;
            fifthLine.alpha = Mathf.Lerp(1f, 0f, timePassed5 / 0.8f);
            yield return new WaitForSeconds(0.025f);
        }*/
        /* sparizione terzo walltext */
        /*while (timePassed6 < 0.8f)
        {
            timePassed6 += Time.deltaTime;
            sixthLine.alpha = Mathf.Lerp(1f, 0f, timePassed6 / 0.8f);
            yield return new WaitForSeconds(0.025f);
        }*/
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillList : MonoBehaviour
{
    public Text[] Line;
    public CanvasGroup[] LineGroup;
    
    private int[] armyType = new int[30];
    int i = 0;

    public void insertNewLine(string line, int army)
    {
        Line[i].text = line;
        armyType[i] = army;
        i++;
    }

    public void test()
    {
        StartCoroutine(PushLines());
    }


    public void ResetKillList()
    {
        for(int j = 0; j<=i; j++)
        {
            Line[j].text = "";
            LineGroup[j].alpha = 0;
            armyType[j] = 0;
        }
        i = 0;
    }


    float oldPos;
    float newPos;

    private IEnumerator FadeIn(CanvasGroup currentLineGroup)
    {
        yield return new WaitForSeconds(0.2f);
        float timePassed0 = 0f;
        while (timePassed0 < 0.8f)
        {
            timePassed0 += Time.deltaTime;
            currentLineGroup.alpha = Mathf.Lerp(0f, 1f, timePassed0 / 0.8f); // da 0f a 1f si accende, da 1f a 0f si spegne
            yield return new WaitForSeconds(0.002f);
        }
    }

    private IEnumerator PushLines()
    {
        StartCoroutine(FadeIn(LineGroup[0]));
        if (armyType[0] == 2) Line[0].alignment = TextAnchor.MiddleRight;
        yield return new WaitForSeconds(Random.Range(1f, 3f));

        StartCoroutine(FadeIn(LineGroup[1]));
        if (armyType[1] == 2) Line[1].alignment = TextAnchor.MiddleRight;
            // oldPos = Line[0].rectTransform.localPosition.y; pare non serva
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 2, (float)0);
                yield return null;
            }
        
        yield return new WaitForSeconds(Random.Range(1f, 3f));


        if (Line[2].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[2]));

            // inserire sempre qui eventuali modifiche testuali contemporanee alla grafica del sistema

            if (armyType[2] == 2) Line[2].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 2, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 2, (float)0);
                yield return null;
            }
        }
        else StopCoroutine(PushLines());
        yield return new WaitForSeconds(Random.Range(1f, 3f));


        if (Line[3].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[3]));
            if (armyType[3] == 2) Line[3].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 2, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 2, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 2, (float)0);
                yield return null;
            }
        }
        else StopCoroutine(PushLines());
        yield return new WaitForSeconds(Random.Range(1f, 3f));


        if (Line[4].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[4]));
            if (armyType[4] == 2) Line[4].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 2, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 2, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 2, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 2, (float)0);
                yield return null;
            }
        }
        else StopCoroutine(PushLines());
        yield return new WaitForSeconds(Random.Range(1f, 3f));


        if (Line[5].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[5]));
            if (armyType[5] == 2) Line[5].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 2, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 2, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 2, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 2, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 2, (float)0);
                yield return null;
            }
        }
        else StopCoroutine(PushLines());
        yield return new WaitForSeconds(Random.Range(1f, 3f));

        if (Line[6].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[6]));
            if (armyType[6] == 2) Line[6].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 2, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 2, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 2, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 2, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 2, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 2, (float)0);
                yield return null;
            }
        }
        else StopCoroutine(PushLines());
        yield return new WaitForSeconds(Random.Range(1f, 3f));

        if (Line[7].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[7]));
            if (armyType[7] == 2) Line[7].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 2, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 2, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 2, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 2, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 2, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 2, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 2, (float)0);
                yield return null;
            }
        }
        else StopCoroutine(PushLines());
        yield return new WaitForSeconds(Random.Range(1f, 3f));

        if (Line[8].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[8]));
            if (armyType[8] == 2) Line[8].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 2, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 2, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 2, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 2, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 2, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 2, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 2, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 2, (float)0);
                yield return null;
            }
        }
        else StopCoroutine(PushLines());
        yield return new WaitForSeconds(Random.Range(1f, 3f));

        if (Line[9].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[9]));
            if (armyType[9] == 2) Line[9].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 2, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 2, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 2, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 2, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 2, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 2, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 2, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 2, (float)0);
                Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 2, (float)0);
                Line[9].rectTransform.localPosition = new Vector3(0, (float)Line[9].rectTransform.localPosition.y - 2, (float)0);
                yield return null;
            }
        }
        else StopCoroutine(PushLines());
        yield return new WaitForSeconds(Random.Range(1f, 3f));

        if (Line[10].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[10]));
            if (armyType[10] == 2) Line[10].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 2, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 2, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 2, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 2, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 2, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 2, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 2, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 2, (float)0);
                Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 2, (float)0);
                Line[9].rectTransform.localPosition = new Vector3(0, (float)Line[9].rectTransform.localPosition.y - 2, (float)0);
                Line[10].rectTransform.localPosition = new Vector3(0, (float)Line[10].rectTransform.localPosition.y - 2, (float)0);
                yield return null;
            }
        }
        else StopCoroutine(PushLines());
        yield return new WaitForSeconds(Random.Range(1f, 3f));

        if (Line[11].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[11]));
            if (armyType[11] == 2) Line[11].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 2, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 2, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 2, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 2, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 2, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 2, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 2, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 2, (float)0);
                Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 2, (float)0);
                Line[9].rectTransform.localPosition = new Vector3(0, (float)Line[9].rectTransform.localPosition.y - 2, (float)0);
                Line[10].rectTransform.localPosition = new Vector3(0, (float)Line[10].rectTransform.localPosition.y - 2, (float)0);
                Line[11].rectTransform.localPosition = new Vector3(0, (float)Line[11].rectTransform.localPosition.y - 2, (float)0);
                yield return null;
            }
        }
        else StopCoroutine(PushLines());
        yield return new WaitForSeconds(Random.Range(1f, 3f));

        if (Line[12].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[12]));
            if (armyType[12] == 2) Line[12].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 2, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 2, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 2, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 2, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 2, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 2, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 2, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 2, (float)0);
                Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 2, (float)0);
                Line[9].rectTransform.localPosition = new Vector3(0, (float)Line[9].rectTransform.localPosition.y - 2, (float)0);
                Line[10].rectTransform.localPosition = new Vector3(0, (float)Line[10].rectTransform.localPosition.y - 2, (float)0);
                Line[11].rectTransform.localPosition = new Vector3(0, (float)Line[11].rectTransform.localPosition.y - 2, (float)0);
                Line[12].rectTransform.localPosition = new Vector3(0, (float)Line[12].rectTransform.localPosition.y - 2, (float)0);
                yield return null;
            }
        }
        else StopCoroutine(PushLines());
        yield return new WaitForSeconds(Random.Range(1f, 3f));


        if (Line[13].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[13]));
            if (armyType[13] == 2) Line[13].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 2, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 2, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 2, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 2, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 2, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 2, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 2, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 2, (float)0);
                Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 2, (float)0);
                Line[9].rectTransform.localPosition = new Vector3(0, (float)Line[9].rectTransform.localPosition.y - 2, (float)0);
                Line[10].rectTransform.localPosition = new Vector3(0, (float)Line[10].rectTransform.localPosition.y - 2, (float)0);
                Line[11].rectTransform.localPosition = new Vector3(0, (float)Line[11].rectTransform.localPosition.y - 2, (float)0);
                Line[12].rectTransform.localPosition = new Vector3(0, (float)Line[12].rectTransform.localPosition.y - 2, (float)0);
                Line[13].rectTransform.localPosition = new Vector3(0, (float)Line[13].rectTransform.localPosition.y - 2, (float)0);
                yield return null;
            }
        }
        else StopCoroutine(PushLines());
        yield return new WaitForSeconds(Random.Range(1f, 3f));


        if (Line[14].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[14]));
            if (armyType[14] == 2) Line[14].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 2, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 2, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 2, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 2, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 2, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 2, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 2, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 2, (float)0);
                Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 2, (float)0);
                Line[9].rectTransform.localPosition = new Vector3(0, (float)Line[9].rectTransform.localPosition.y - 2, (float)0);
                Line[10].rectTransform.localPosition = new Vector3(0, (float)Line[10].rectTransform.localPosition.y - 2, (float)0);
                Line[11].rectTransform.localPosition = new Vector3(0, (float)Line[11].rectTransform.localPosition.y - 2, (float)0);
                Line[12].rectTransform.localPosition = new Vector3(0, (float)Line[12].rectTransform.localPosition.y - 2, (float)0);
                Line[13].rectTransform.localPosition = new Vector3(0, (float)Line[13].rectTransform.localPosition.y - 2, (float)0);
                Line[14].rectTransform.localPosition = new Vector3(0, (float)Line[14].rectTransform.localPosition.y - 2, (float)0);
                yield return null;
            }
        }
        else StopCoroutine(PushLines());
        yield return new WaitForSeconds(Random.Range(1f, 3f));



        if (Line[15].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[15]));
            if (armyType[15] == 2) Line[15].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 2, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 2, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 2, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 2, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 2, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 2, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 2, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 2, (float)0);
                Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 2, (float)0);
                Line[9].rectTransform.localPosition = new Vector3(0, (float)Line[9].rectTransform.localPosition.y - 2, (float)0);
                Line[10].rectTransform.localPosition = new Vector3(0, (float)Line[10].rectTransform.localPosition.y - 2, (float)0);
                Line[11].rectTransform.localPosition = new Vector3(0, (float)Line[11].rectTransform.localPosition.y - 2, (float)0);
                Line[12].rectTransform.localPosition = new Vector3(0, (float)Line[12].rectTransform.localPosition.y - 2, (float)0);
                Line[13].rectTransform.localPosition = new Vector3(0, (float)Line[13].rectTransform.localPosition.y - 2, (float)0);
                Line[14].rectTransform.localPosition = new Vector3(0, (float)Line[14].rectTransform.localPosition.y - 2, (float)0);
                Line[15].rectTransform.localPosition = new Vector3(0, (float)Line[15].rectTransform.localPosition.y - 2, (float)0);
                yield return null;
            }
        }
        else StopCoroutine(PushLines());
        yield return new WaitForSeconds(Random.Range(1f, 3f));



        if (Line[16].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[16]));
            if (armyType[16] == 2) Line[16].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 2, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 2, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 2, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 2, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 2, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 2, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 2, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 2, (float)0);
                Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 2, (float)0);
                Line[9].rectTransform.localPosition = new Vector3(0, (float)Line[9].rectTransform.localPosition.y - 2, (float)0);
                Line[10].rectTransform.localPosition = new Vector3(0, (float)Line[10].rectTransform.localPosition.y - 2, (float)0);
                Line[11].rectTransform.localPosition = new Vector3(0, (float)Line[11].rectTransform.localPosition.y - 2, (float)0);
                Line[12].rectTransform.localPosition = new Vector3(0, (float)Line[12].rectTransform.localPosition.y - 2, (float)0);
                Line[13].rectTransform.localPosition = new Vector3(0, (float)Line[13].rectTransform.localPosition.y - 2, (float)0);
                Line[14].rectTransform.localPosition = new Vector3(0, (float)Line[14].rectTransform.localPosition.y - 2, (float)0);
                Line[15].rectTransform.localPosition = new Vector3(0, (float)Line[15].rectTransform.localPosition.y - 2, (float)0);
                Line[16].rectTransform.localPosition = new Vector3(0, (float)Line[16].rectTransform.localPosition.y - 2, (float)0);
                yield return null;
            }
        }
        else StopCoroutine(PushLines());
        yield return new WaitForSeconds(Random.Range(1f, 3f));



        if (Line[17].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[17]));
            if (armyType[17] == 2) Line[17].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 2, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 2, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 2, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 2, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 2, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 2, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 2, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 2, (float)0);
                Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 2, (float)0);
                Line[9].rectTransform.localPosition = new Vector3(0, (float)Line[9].rectTransform.localPosition.y - 2, (float)0);
                Line[10].rectTransform.localPosition = new Vector3(0, (float)Line[10].rectTransform.localPosition.y - 2, (float)0);
                Line[11].rectTransform.localPosition = new Vector3(0, (float)Line[11].rectTransform.localPosition.y - 2, (float)0);
                Line[12].rectTransform.localPosition = new Vector3(0, (float)Line[12].rectTransform.localPosition.y - 2, (float)0);
                Line[13].rectTransform.localPosition = new Vector3(0, (float)Line[13].rectTransform.localPosition.y - 2, (float)0);
                Line[14].rectTransform.localPosition = new Vector3(0, (float)Line[14].rectTransform.localPosition.y - 2, (float)0);
                Line[15].rectTransform.localPosition = new Vector3(0, (float)Line[15].rectTransform.localPosition.y - 2, (float)0);
                Line[16].rectTransform.localPosition = new Vector3(0, (float)Line[16].rectTransform.localPosition.y - 2, (float)0);
                Line[17].rectTransform.localPosition = new Vector3(0, (float)Line[17].rectTransform.localPosition.y - 2, (float)0);
                yield return null;
            }
        }
        else StopCoroutine(PushLines());
        yield return new WaitForSeconds(Random.Range(1f, 3f));




        if (Line[18].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[18]));
            if (armyType[18] == 2) Line[18].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 2, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 2, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 2, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 2, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 2, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 2, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 2, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 2, (float)0);
                Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 2, (float)0);
                Line[9].rectTransform.localPosition = new Vector3(0, (float)Line[9].rectTransform.localPosition.y - 2, (float)0);
                Line[10].rectTransform.localPosition = new Vector3(0, (float)Line[10].rectTransform.localPosition.y - 2, (float)0);
                Line[11].rectTransform.localPosition = new Vector3(0, (float)Line[11].rectTransform.localPosition.y - 2, (float)0);
                Line[12].rectTransform.localPosition = new Vector3(0, (float)Line[12].rectTransform.localPosition.y - 2, (float)0);
                Line[13].rectTransform.localPosition = new Vector3(0, (float)Line[13].rectTransform.localPosition.y - 2, (float)0);
                Line[14].rectTransform.localPosition = new Vector3(0, (float)Line[14].rectTransform.localPosition.y - 2, (float)0);
                Line[15].rectTransform.localPosition = new Vector3(0, (float)Line[15].rectTransform.localPosition.y - 2, (float)0);
                Line[16].rectTransform.localPosition = new Vector3(0, (float)Line[16].rectTransform.localPosition.y - 2, (float)0);
                Line[17].rectTransform.localPosition = new Vector3(0, (float)Line[17].rectTransform.localPosition.y - 2, (float)0);
                Line[18].rectTransform.localPosition = new Vector3(0, (float)Line[18].rectTransform.localPosition.y - 2, (float)0);
                yield return null;
            }
        }
        else StopCoroutine(PushLines());
        yield return new WaitForSeconds(Random.Range(1f, 3f));



        if (Line[19].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[19]));
            if (armyType[19] == 2) Line[19].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 2, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 2, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 2, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 2, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 2, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 2, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 2, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 2, (float)0);
                Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 2, (float)0);
                Line[9].rectTransform.localPosition = new Vector3(0, (float)Line[9].rectTransform.localPosition.y - 2, (float)0);
                Line[10].rectTransform.localPosition = new Vector3(0, (float)Line[10].rectTransform.localPosition.y - 2, (float)0);
                Line[11].rectTransform.localPosition = new Vector3(0, (float)Line[11].rectTransform.localPosition.y - 2, (float)0);
                Line[12].rectTransform.localPosition = new Vector3(0, (float)Line[12].rectTransform.localPosition.y - 2, (float)0);
                Line[13].rectTransform.localPosition = new Vector3(0, (float)Line[13].rectTransform.localPosition.y - 2, (float)0);
                Line[14].rectTransform.localPosition = new Vector3(0, (float)Line[14].rectTransform.localPosition.y - 2, (float)0);
                Line[15].rectTransform.localPosition = new Vector3(0, (float)Line[15].rectTransform.localPosition.y - 2, (float)0);
                Line[16].rectTransform.localPosition = new Vector3(0, (float)Line[16].rectTransform.localPosition.y - 2, (float)0);
                Line[17].rectTransform.localPosition = new Vector3(0, (float)Line[17].rectTransform.localPosition.y - 2, (float)0);
                Line[18].rectTransform.localPosition = new Vector3(0, (float)Line[18].rectTransform.localPosition.y - 2, (float)0);
                Line[19].rectTransform.localPosition = new Vector3(0, (float)Line[19].rectTransform.localPosition.y - 2, (float)0);
                yield return null;
            }
        }
        else StopCoroutine(PushLines());
        yield return new WaitForSeconds(Random.Range(1f, 3f));



        if (Line[20].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[20]));
            if (armyType[20] == 2) Line[20].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 2, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 2, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 2, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 2, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 2, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 2, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 2, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 2, (float)0);
                Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 2, (float)0);
                Line[9].rectTransform.localPosition = new Vector3(0, (float)Line[9].rectTransform.localPosition.y - 2, (float)0);
                Line[10].rectTransform.localPosition = new Vector3(0, (float)Line[10].rectTransform.localPosition.y - 2, (float)0);
                Line[11].rectTransform.localPosition = new Vector3(0, (float)Line[11].rectTransform.localPosition.y - 2, (float)0);
                Line[12].rectTransform.localPosition = new Vector3(0, (float)Line[12].rectTransform.localPosition.y - 2, (float)0);
                Line[13].rectTransform.localPosition = new Vector3(0, (float)Line[13].rectTransform.localPosition.y - 2, (float)0);
                Line[14].rectTransform.localPosition = new Vector3(0, (float)Line[14].rectTransform.localPosition.y - 2, (float)0);
                Line[15].rectTransform.localPosition = new Vector3(0, (float)Line[15].rectTransform.localPosition.y - 2, (float)0);
                Line[16].rectTransform.localPosition = new Vector3(0, (float)Line[16].rectTransform.localPosition.y - 2, (float)0);
                Line[17].rectTransform.localPosition = new Vector3(0, (float)Line[17].rectTransform.localPosition.y - 2, (float)0);
                Line[18].rectTransform.localPosition = new Vector3(0, (float)Line[18].rectTransform.localPosition.y - 2, (float)0);
                Line[19].rectTransform.localPosition = new Vector3(0, (float)Line[19].rectTransform.localPosition.y - 2, (float)0);
                Line[20].rectTransform.localPosition = new Vector3(0, (float)Line[20].rectTransform.localPosition.y - 2, (float)0);
                yield return null;
            }
        }
        else StopCoroutine(PushLines());
        yield return new WaitForSeconds(Random.Range(1f, 3f));



        if (Line[21].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[21]));
            if (armyType[21] == 2) Line[21].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 2, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 2, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 2, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 2, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 2, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 2, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 2, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 2, (float)0);
                Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 2, (float)0);
                Line[9].rectTransform.localPosition = new Vector3(0, (float)Line[9].rectTransform.localPosition.y - 2, (float)0);
                Line[10].rectTransform.localPosition = new Vector3(0, (float)Line[10].rectTransform.localPosition.y - 2, (float)0);
                Line[11].rectTransform.localPosition = new Vector3(0, (float)Line[11].rectTransform.localPosition.y - 2, (float)0);
                Line[12].rectTransform.localPosition = new Vector3(0, (float)Line[12].rectTransform.localPosition.y - 2, (float)0);
                Line[13].rectTransform.localPosition = new Vector3(0, (float)Line[13].rectTransform.localPosition.y - 2, (float)0);
                Line[14].rectTransform.localPosition = new Vector3(0, (float)Line[14].rectTransform.localPosition.y - 2, (float)0);
                Line[15].rectTransform.localPosition = new Vector3(0, (float)Line[15].rectTransform.localPosition.y - 2, (float)0);
                Line[16].rectTransform.localPosition = new Vector3(0, (float)Line[16].rectTransform.localPosition.y - 2, (float)0);
                Line[17].rectTransform.localPosition = new Vector3(0, (float)Line[17].rectTransform.localPosition.y - 2, (float)0);
                Line[18].rectTransform.localPosition = new Vector3(0, (float)Line[18].rectTransform.localPosition.y - 2, (float)0);
                Line[19].rectTransform.localPosition = new Vector3(0, (float)Line[19].rectTransform.localPosition.y - 2, (float)0);
                Line[20].rectTransform.localPosition = new Vector3(0, (float)Line[20].rectTransform.localPosition.y - 2, (float)0);
                Line[21].rectTransform.localPosition = new Vector3(0, (float)Line[21].rectTransform.localPosition.y - 2, (float)0);
                yield return null;
            }
        }
        else StopCoroutine(PushLines());
        yield return new WaitForSeconds(Random.Range(1f, 3f));



        if (Line[22].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[22]));
            if (armyType[22] == 2) Line[22].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 2, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 2, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 2, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 2, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 2, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 2, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 2, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 2, (float)0);
                Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 2, (float)0);
                Line[9].rectTransform.localPosition = new Vector3(0, (float)Line[9].rectTransform.localPosition.y - 2, (float)0);
                Line[10].rectTransform.localPosition = new Vector3(0, (float)Line[10].rectTransform.localPosition.y - 2, (float)0);
                Line[11].rectTransform.localPosition = new Vector3(0, (float)Line[11].rectTransform.localPosition.y - 2, (float)0);
                Line[12].rectTransform.localPosition = new Vector3(0, (float)Line[12].rectTransform.localPosition.y - 2, (float)0);
                Line[13].rectTransform.localPosition = new Vector3(0, (float)Line[13].rectTransform.localPosition.y - 2, (float)0);
                Line[14].rectTransform.localPosition = new Vector3(0, (float)Line[14].rectTransform.localPosition.y - 2, (float)0);
                Line[15].rectTransform.localPosition = new Vector3(0, (float)Line[15].rectTransform.localPosition.y - 2, (float)0);
                Line[16].rectTransform.localPosition = new Vector3(0, (float)Line[16].rectTransform.localPosition.y - 2, (float)0);
                Line[17].rectTransform.localPosition = new Vector3(0, (float)Line[17].rectTransform.localPosition.y - 2, (float)0);
                Line[18].rectTransform.localPosition = new Vector3(0, (float)Line[18].rectTransform.localPosition.y - 2, (float)0);
                Line[19].rectTransform.localPosition = new Vector3(0, (float)Line[19].rectTransform.localPosition.y - 2, (float)0);
                Line[20].rectTransform.localPosition = new Vector3(0, (float)Line[20].rectTransform.localPosition.y - 2, (float)0);
                Line[21].rectTransform.localPosition = new Vector3(0, (float)Line[21].rectTransform.localPosition.y - 2, (float)0);
                Line[22].rectTransform.localPosition = new Vector3(0, (float)Line[22].rectTransform.localPosition.y - 2, (float)0);
                yield return null;
            }
        }
        else StopCoroutine(PushLines());
        yield return new WaitForSeconds(Random.Range(1f, 3f));




        if (Line[23].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[23]));
            if (armyType[23] == 2) Line[23].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 2, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 2, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 2, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 2, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 2, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 2, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 2, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 2, (float)0);
                Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 2, (float)0);
                Line[9].rectTransform.localPosition = new Vector3(0, (float)Line[9].rectTransform.localPosition.y - 2, (float)0);
                Line[10].rectTransform.localPosition = new Vector3(0, (float)Line[10].rectTransform.localPosition.y - 2, (float)0);
                Line[11].rectTransform.localPosition = new Vector3(0, (float)Line[11].rectTransform.localPosition.y - 2, (float)0);
                Line[12].rectTransform.localPosition = new Vector3(0, (float)Line[12].rectTransform.localPosition.y - 2, (float)0);
                Line[13].rectTransform.localPosition = new Vector3(0, (float)Line[13].rectTransform.localPosition.y - 2, (float)0);
                Line[14].rectTransform.localPosition = new Vector3(0, (float)Line[14].rectTransform.localPosition.y - 2, (float)0);
                Line[15].rectTransform.localPosition = new Vector3(0, (float)Line[15].rectTransform.localPosition.y - 2, (float)0);
                Line[16].rectTransform.localPosition = new Vector3(0, (float)Line[16].rectTransform.localPosition.y - 2, (float)0);
                Line[17].rectTransform.localPosition = new Vector3(0, (float)Line[17].rectTransform.localPosition.y - 2, (float)0);
                Line[18].rectTransform.localPosition = new Vector3(0, (float)Line[18].rectTransform.localPosition.y - 2, (float)0);
                Line[19].rectTransform.localPosition = new Vector3(0, (float)Line[19].rectTransform.localPosition.y - 2, (float)0);
                Line[20].rectTransform.localPosition = new Vector3(0, (float)Line[20].rectTransform.localPosition.y - 2, (float)0);
                Line[21].rectTransform.localPosition = new Vector3(0, (float)Line[21].rectTransform.localPosition.y - 2, (float)0);
                Line[22].rectTransform.localPosition = new Vector3(0, (float)Line[22].rectTransform.localPosition.y - 2, (float)0);
                Line[23].rectTransform.localPosition = new Vector3(0, (float)Line[23].rectTransform.localPosition.y - 2, (float)0);
                yield return null;
            }
        }
        else StopCoroutine(PushLines());
        yield return new WaitForSeconds(Random.Range(1f, 3f));



        if (Line[24].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[24]));
            if (armyType[24] == 2) Line[24].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 2, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 2, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 2, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 2, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 2, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 2, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 2, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 2, (float)0);
                Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 2, (float)0);
                Line[9].rectTransform.localPosition = new Vector3(0, (float)Line[9].rectTransform.localPosition.y - 2, (float)0);
                Line[10].rectTransform.localPosition = new Vector3(0, (float)Line[10].rectTransform.localPosition.y - 2, (float)0);
                Line[11].rectTransform.localPosition = new Vector3(0, (float)Line[11].rectTransform.localPosition.y - 2, (float)0);
                Line[12].rectTransform.localPosition = new Vector3(0, (float)Line[12].rectTransform.localPosition.y - 2, (float)0);
                Line[13].rectTransform.localPosition = new Vector3(0, (float)Line[13].rectTransform.localPosition.y - 2, (float)0);
                Line[14].rectTransform.localPosition = new Vector3(0, (float)Line[14].rectTransform.localPosition.y - 2, (float)0);
                Line[15].rectTransform.localPosition = new Vector3(0, (float)Line[15].rectTransform.localPosition.y - 2, (float)0);
                Line[16].rectTransform.localPosition = new Vector3(0, (float)Line[16].rectTransform.localPosition.y - 2, (float)0);
                Line[17].rectTransform.localPosition = new Vector3(0, (float)Line[17].rectTransform.localPosition.y - 2, (float)0);
                Line[18].rectTransform.localPosition = new Vector3(0, (float)Line[18].rectTransform.localPosition.y - 2, (float)0);
                Line[19].rectTransform.localPosition = new Vector3(0, (float)Line[19].rectTransform.localPosition.y - 2, (float)0);
                Line[20].rectTransform.localPosition = new Vector3(0, (float)Line[20].rectTransform.localPosition.y - 2, (float)0);
                Line[21].rectTransform.localPosition = new Vector3(0, (float)Line[21].rectTransform.localPosition.y - 2, (float)0);
                Line[22].rectTransform.localPosition = new Vector3(0, (float)Line[22].rectTransform.localPosition.y - 2, (float)0);
                Line[23].rectTransform.localPosition = new Vector3(0, (float)Line[23].rectTransform.localPosition.y - 2, (float)0);
                Line[24].rectTransform.localPosition = new Vector3(0, (float)Line[24].rectTransform.localPosition.y - 2, (float)0);
                yield return null;
            }
        }
        else StopCoroutine(PushLines());
        yield return new WaitForSeconds(Random.Range(1f, 3f));



        if (Line[25].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[25]));
            if (armyType[25] == 2) Line[25].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 2, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 2, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 2, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 2, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 2, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 2, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 2, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 2, (float)0);
                Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 2, (float)0);
                Line[9].rectTransform.localPosition = new Vector3(0, (float)Line[9].rectTransform.localPosition.y - 2, (float)0);
                Line[10].rectTransform.localPosition = new Vector3(0, (float)Line[10].rectTransform.localPosition.y - 2, (float)0);
                Line[11].rectTransform.localPosition = new Vector3(0, (float)Line[11].rectTransform.localPosition.y - 2, (float)0);
                Line[12].rectTransform.localPosition = new Vector3(0, (float)Line[12].rectTransform.localPosition.y - 2, (float)0);
                Line[13].rectTransform.localPosition = new Vector3(0, (float)Line[13].rectTransform.localPosition.y - 2, (float)0);
                Line[14].rectTransform.localPosition = new Vector3(0, (float)Line[14].rectTransform.localPosition.y - 2, (float)0);
                Line[15].rectTransform.localPosition = new Vector3(0, (float)Line[15].rectTransform.localPosition.y - 2, (float)0);
                Line[16].rectTransform.localPosition = new Vector3(0, (float)Line[16].rectTransform.localPosition.y - 2, (float)0);
                Line[17].rectTransform.localPosition = new Vector3(0, (float)Line[17].rectTransform.localPosition.y - 2, (float)0);
                Line[18].rectTransform.localPosition = new Vector3(0, (float)Line[18].rectTransform.localPosition.y - 2, (float)0);
                Line[19].rectTransform.localPosition = new Vector3(0, (float)Line[19].rectTransform.localPosition.y - 2, (float)0);
                Line[20].rectTransform.localPosition = new Vector3(0, (float)Line[20].rectTransform.localPosition.y - 2, (float)0);
                Line[21].rectTransform.localPosition = new Vector3(0, (float)Line[21].rectTransform.localPosition.y - 2, (float)0);
                Line[22].rectTransform.localPosition = new Vector3(0, (float)Line[22].rectTransform.localPosition.y - 2, (float)0);
                Line[23].rectTransform.localPosition = new Vector3(0, (float)Line[23].rectTransform.localPosition.y - 2, (float)0);
                Line[24].rectTransform.localPosition = new Vector3(0, (float)Line[24].rectTransform.localPosition.y - 2, (float)0);
                Line[25].rectTransform.localPosition = new Vector3(0, (float)Line[25].rectTransform.localPosition.y - 2, (float)0);
                yield return null;
            }
        }
        else StopCoroutine(PushLines());
        yield return new WaitForSeconds(Random.Range(1f, 3f));



        if (Line[26].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[26]));
            if (armyType[26] == 2) Line[26].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 2, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 2, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 2, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 2, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 2, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 2, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 2, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 2, (float)0);
                Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 2, (float)0);
                Line[9].rectTransform.localPosition = new Vector3(0, (float)Line[9].rectTransform.localPosition.y - 2, (float)0);
                Line[10].rectTransform.localPosition = new Vector3(0, (float)Line[10].rectTransform.localPosition.y - 2, (float)0);
                Line[11].rectTransform.localPosition = new Vector3(0, (float)Line[11].rectTransform.localPosition.y - 2, (float)0);
                Line[12].rectTransform.localPosition = new Vector3(0, (float)Line[12].rectTransform.localPosition.y - 2, (float)0);
                Line[13].rectTransform.localPosition = new Vector3(0, (float)Line[13].rectTransform.localPosition.y - 2, (float)0);
                Line[14].rectTransform.localPosition = new Vector3(0, (float)Line[14].rectTransform.localPosition.y - 2, (float)0);
                Line[15].rectTransform.localPosition = new Vector3(0, (float)Line[15].rectTransform.localPosition.y - 2, (float)0);
                Line[16].rectTransform.localPosition = new Vector3(0, (float)Line[16].rectTransform.localPosition.y - 2, (float)0);
                Line[17].rectTransform.localPosition = new Vector3(0, (float)Line[17].rectTransform.localPosition.y - 2, (float)0);
                Line[18].rectTransform.localPosition = new Vector3(0, (float)Line[18].rectTransform.localPosition.y - 2, (float)0);
                Line[19].rectTransform.localPosition = new Vector3(0, (float)Line[19].rectTransform.localPosition.y - 2, (float)0);
                Line[20].rectTransform.localPosition = new Vector3(0, (float)Line[20].rectTransform.localPosition.y - 2, (float)0);
                Line[21].rectTransform.localPosition = new Vector3(0, (float)Line[21].rectTransform.localPosition.y - 2, (float)0);
                Line[22].rectTransform.localPosition = new Vector3(0, (float)Line[22].rectTransform.localPosition.y - 2, (float)0);
                Line[23].rectTransform.localPosition = new Vector3(0, (float)Line[23].rectTransform.localPosition.y - 2, (float)0);
                Line[24].rectTransform.localPosition = new Vector3(0, (float)Line[24].rectTransform.localPosition.y - 2, (float)0);
                Line[25].rectTransform.localPosition = new Vector3(0, (float)Line[25].rectTransform.localPosition.y - 2, (float)0);
                Line[26].rectTransform.localPosition = new Vector3(0, (float)Line[26].rectTransform.localPosition.y - 2, (float)0);
                yield return null;
            }
        }
        else StopCoroutine(PushLines());
        yield return new WaitForSeconds(Random.Range(1f, 3f));



        if (Line[27].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[27]));
            if (armyType[27] == 2) Line[27].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 2, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 2, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 2, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 2, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 2, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 2, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 2, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 2, (float)0);
                Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 2, (float)0);
                Line[9].rectTransform.localPosition = new Vector3(0, (float)Line[9].rectTransform.localPosition.y - 2, (float)0);
                Line[10].rectTransform.localPosition = new Vector3(0, (float)Line[10].rectTransform.localPosition.y - 2, (float)0);
                Line[11].rectTransform.localPosition = new Vector3(0, (float)Line[11].rectTransform.localPosition.y - 2, (float)0);
                Line[12].rectTransform.localPosition = new Vector3(0, (float)Line[12].rectTransform.localPosition.y - 2, (float)0);
                Line[13].rectTransform.localPosition = new Vector3(0, (float)Line[13].rectTransform.localPosition.y - 2, (float)0);
                Line[14].rectTransform.localPosition = new Vector3(0, (float)Line[14].rectTransform.localPosition.y - 2, (float)0);
                Line[15].rectTransform.localPosition = new Vector3(0, (float)Line[15].rectTransform.localPosition.y - 2, (float)0);
                Line[16].rectTransform.localPosition = new Vector3(0, (float)Line[16].rectTransform.localPosition.y - 2, (float)0);
                Line[17].rectTransform.localPosition = new Vector3(0, (float)Line[17].rectTransform.localPosition.y - 2, (float)0);
                Line[18].rectTransform.localPosition = new Vector3(0, (float)Line[18].rectTransform.localPosition.y - 2, (float)0);
                Line[19].rectTransform.localPosition = new Vector3(0, (float)Line[19].rectTransform.localPosition.y - 2, (float)0);
                Line[20].rectTransform.localPosition = new Vector3(0, (float)Line[20].rectTransform.localPosition.y - 2, (float)0);
                Line[21].rectTransform.localPosition = new Vector3(0, (float)Line[21].rectTransform.localPosition.y - 2, (float)0);
                Line[22].rectTransform.localPosition = new Vector3(0, (float)Line[22].rectTransform.localPosition.y - 2, (float)0);
                Line[23].rectTransform.localPosition = new Vector3(0, (float)Line[23].rectTransform.localPosition.y - 2, (float)0);
                Line[24].rectTransform.localPosition = new Vector3(0, (float)Line[24].rectTransform.localPosition.y - 2, (float)0);
                Line[25].rectTransform.localPosition = new Vector3(0, (float)Line[25].rectTransform.localPosition.y - 2, (float)0);
                Line[26].rectTransform.localPosition = new Vector3(0, (float)Line[26].rectTransform.localPosition.y - 2, (float)0);
                Line[27].rectTransform.localPosition = new Vector3(0, (float)Line[27].rectTransform.localPosition.y - 2, (float)0);
                yield return null;
            }
        }
        else StopCoroutine(PushLines());
        yield return new WaitForSeconds(Random.Range(1f, 3f));



        if (Line[28].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[28]));
            if (armyType[28] == 2) Line[28].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 2, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 2, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 2, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 2, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 2, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 2, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 2, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 2, (float)0);
                Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 2, (float)0);
                Line[9].rectTransform.localPosition = new Vector3(0, (float)Line[9].rectTransform.localPosition.y - 2, (float)0);
                Line[10].rectTransform.localPosition = new Vector3(0, (float)Line[10].rectTransform.localPosition.y - 2, (float)0);
                Line[11].rectTransform.localPosition = new Vector3(0, (float)Line[11].rectTransform.localPosition.y - 2, (float)0);
                Line[12].rectTransform.localPosition = new Vector3(0, (float)Line[12].rectTransform.localPosition.y - 2, (float)0);
                Line[13].rectTransform.localPosition = new Vector3(0, (float)Line[13].rectTransform.localPosition.y - 2, (float)0);
                Line[14].rectTransform.localPosition = new Vector3(0, (float)Line[14].rectTransform.localPosition.y - 2, (float)0);
                Line[15].rectTransform.localPosition = new Vector3(0, (float)Line[15].rectTransform.localPosition.y - 2, (float)0);
                Line[16].rectTransform.localPosition = new Vector3(0, (float)Line[16].rectTransform.localPosition.y - 2, (float)0);
                Line[17].rectTransform.localPosition = new Vector3(0, (float)Line[17].rectTransform.localPosition.y - 2, (float)0);
                Line[18].rectTransform.localPosition = new Vector3(0, (float)Line[18].rectTransform.localPosition.y - 2, (float)0);
                Line[19].rectTransform.localPosition = new Vector3(0, (float)Line[19].rectTransform.localPosition.y - 2, (float)0);
                Line[20].rectTransform.localPosition = new Vector3(0, (float)Line[20].rectTransform.localPosition.y - 2, (float)0);
                Line[21].rectTransform.localPosition = new Vector3(0, (float)Line[21].rectTransform.localPosition.y - 2, (float)0);
                Line[22].rectTransform.localPosition = new Vector3(0, (float)Line[22].rectTransform.localPosition.y - 2, (float)0);
                Line[23].rectTransform.localPosition = new Vector3(0, (float)Line[23].rectTransform.localPosition.y - 2, (float)0);
                Line[24].rectTransform.localPosition = new Vector3(0, (float)Line[24].rectTransform.localPosition.y - 2, (float)0);
                Line[25].rectTransform.localPosition = new Vector3(0, (float)Line[25].rectTransform.localPosition.y - 2, (float)0);
                Line[26].rectTransform.localPosition = new Vector3(0, (float)Line[26].rectTransform.localPosition.y - 2, (float)0);
                Line[27].rectTransform.localPosition = new Vector3(0, (float)Line[27].rectTransform.localPosition.y - 2, (float)0);
                Line[28].rectTransform.localPosition = new Vector3(0, (float)Line[28].rectTransform.localPosition.y - 2, (float)0);
                yield return null;
            }
        }
        else StopCoroutine(PushLines());
        yield return new WaitForSeconds(Random.Range(1f, 3f));



        if (Line[29].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[29]));
            if (armyType[29] == 2) Line[29].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 2, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 2, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 2, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 2, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 2, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 2, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 2, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 2, (float)0);
                Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 2, (float)0);
                Line[9].rectTransform.localPosition = new Vector3(0, (float)Line[9].rectTransform.localPosition.y - 2, (float)0);
                Line[10].rectTransform.localPosition = new Vector3(0, (float)Line[10].rectTransform.localPosition.y - 2, (float)0);
                Line[11].rectTransform.localPosition = new Vector3(0, (float)Line[11].rectTransform.localPosition.y - 2, (float)0);
                Line[12].rectTransform.localPosition = new Vector3(0, (float)Line[12].rectTransform.localPosition.y - 2, (float)0);
                Line[13].rectTransform.localPosition = new Vector3(0, (float)Line[13].rectTransform.localPosition.y - 2, (float)0);
                Line[14].rectTransform.localPosition = new Vector3(0, (float)Line[14].rectTransform.localPosition.y - 2, (float)0);
                Line[15].rectTransform.localPosition = new Vector3(0, (float)Line[15].rectTransform.localPosition.y - 2, (float)0);
                Line[16].rectTransform.localPosition = new Vector3(0, (float)Line[16].rectTransform.localPosition.y - 2, (float)0);
                Line[17].rectTransform.localPosition = new Vector3(0, (float)Line[17].rectTransform.localPosition.y - 2, (float)0);
                Line[18].rectTransform.localPosition = new Vector3(0, (float)Line[18].rectTransform.localPosition.y - 2, (float)0);
                Line[19].rectTransform.localPosition = new Vector3(0, (float)Line[19].rectTransform.localPosition.y - 2, (float)0);
                Line[20].rectTransform.localPosition = new Vector3(0, (float)Line[20].rectTransform.localPosition.y - 2, (float)0);
                Line[21].rectTransform.localPosition = new Vector3(0, (float)Line[21].rectTransform.localPosition.y - 2, (float)0);
                Line[22].rectTransform.localPosition = new Vector3(0, (float)Line[22].rectTransform.localPosition.y - 2, (float)0);
                Line[23].rectTransform.localPosition = new Vector3(0, (float)Line[23].rectTransform.localPosition.y - 2, (float)0);
                Line[24].rectTransform.localPosition = new Vector3(0, (float)Line[24].rectTransform.localPosition.y - 2, (float)0);
                Line[25].rectTransform.localPosition = new Vector3(0, (float)Line[25].rectTransform.localPosition.y - 2, (float)0);
                Line[26].rectTransform.localPosition = new Vector3(0, (float)Line[26].rectTransform.localPosition.y - 2, (float)0);
                Line[27].rectTransform.localPosition = new Vector3(0, (float)Line[27].rectTransform.localPosition.y - 2, (float)0);
                Line[28].rectTransform.localPosition = new Vector3(0, (float)Line[28].rectTransform.localPosition.y - 2, (float)0);
                Line[29].rectTransform.localPosition = new Vector3(0, (float)Line[29].rectTransform.localPosition.y - 2, (float)0);
                yield return null;
            }
        }
        else StopCoroutine(PushLines());
        yield return new WaitForSeconds(Random.Range(1f, 3f));



        if (Line[30].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[30]));
            if (armyType[30] == 2) Line[30].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 2, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 2, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 2, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 2, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 2, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 2, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 2, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 2, (float)0);
                Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 2, (float)0);
                Line[9].rectTransform.localPosition = new Vector3(0, (float)Line[9].rectTransform.localPosition.y - 2, (float)0);
                Line[10].rectTransform.localPosition = new Vector3(0, (float)Line[10].rectTransform.localPosition.y - 2, (float)0);
                Line[11].rectTransform.localPosition = new Vector3(0, (float)Line[11].rectTransform.localPosition.y - 2, (float)0);
                Line[12].rectTransform.localPosition = new Vector3(0, (float)Line[12].rectTransform.localPosition.y - 2, (float)0);
                Line[13].rectTransform.localPosition = new Vector3(0, (float)Line[13].rectTransform.localPosition.y - 2, (float)0);
                Line[14].rectTransform.localPosition = new Vector3(0, (float)Line[14].rectTransform.localPosition.y - 2, (float)0);
                Line[15].rectTransform.localPosition = new Vector3(0, (float)Line[15].rectTransform.localPosition.y - 2, (float)0);
                Line[16].rectTransform.localPosition = new Vector3(0, (float)Line[16].rectTransform.localPosition.y - 2, (float)0);
                Line[17].rectTransform.localPosition = new Vector3(0, (float)Line[17].rectTransform.localPosition.y - 2, (float)0);
                Line[18].rectTransform.localPosition = new Vector3(0, (float)Line[18].rectTransform.localPosition.y - 2, (float)0);
                Line[19].rectTransform.localPosition = new Vector3(0, (float)Line[19].rectTransform.localPosition.y - 2, (float)0);
                Line[20].rectTransform.localPosition = new Vector3(0, (float)Line[20].rectTransform.localPosition.y - 2, (float)0);
                Line[21].rectTransform.localPosition = new Vector3(0, (float)Line[21].rectTransform.localPosition.y - 2, (float)0);
                Line[22].rectTransform.localPosition = new Vector3(0, (float)Line[22].rectTransform.localPosition.y - 2, (float)0);
                Line[23].rectTransform.localPosition = new Vector3(0, (float)Line[23].rectTransform.localPosition.y - 2, (float)0);
                Line[24].rectTransform.localPosition = new Vector3(0, (float)Line[24].rectTransform.localPosition.y - 2, (float)0);
                Line[25].rectTransform.localPosition = new Vector3(0, (float)Line[25].rectTransform.localPosition.y - 2, (float)0);
                Line[26].rectTransform.localPosition = new Vector3(0, (float)Line[26].rectTransform.localPosition.y - 2, (float)0);
                Line[27].rectTransform.localPosition = new Vector3(0, (float)Line[27].rectTransform.localPosition.y - 2, (float)0);
                Line[28].rectTransform.localPosition = new Vector3(0, (float)Line[28].rectTransform.localPosition.y - 2, (float)0);
                Line[29].rectTransform.localPosition = new Vector3(0, (float)Line[29].rectTransform.localPosition.y - 2, (float)0);
                Line[30].rectTransform.localPosition = new Vector3(0, (float)Line[30].rectTransform.localPosition.y - 2, (float)0);
                yield return null;
            }
        }
        else StopCoroutine(PushLines());
        yield return new WaitForSeconds(Random.Range(1f, 3f));
    }









    /*public void arrivanoVariabili()
    {
        string[] arrayString = { "aasda", "b23452", "cvnbm" };
    }

    public void MoveText(int armyType)
    {
        if (!lockPos)
        {
            lockPos = true;
            Line[0].text = message;
            Line[0].gameObject.SetActive(true);
            i++;
            armyType = 2;
        }
        else 
        {
            Line[i].text = "pupu";
            Line[i].alignment = TextAnchor.MiddleRight;
            StartCoroutine(StartPushPrevLines(), () => );
        }
    }

    IEnumerator StartPushPrevLines()
    {
        for (int k=i-1; k>=0; k--)
        {
            StartCoroutine(PushLine(Line[k]));
            yield return null;
        }
        Line[i].gameObject.SetActive(true);
        i++;
    }


    IEnumerator PushLine(Text Line)
    {
        float oldPos = Line.rectTransform.localPosition.y;
        float newPos = Line.rectTransform.localPosition.y - (float)119.7;
        while (Line.rectTransform.localPosition.y >= newPos)
        {
            Line.rectTransform.localPosition = new Vector3(0, (float)Line.rectTransform.localPosition.y - 2, (float)0);
            yield return null;
        }
    }*/
}


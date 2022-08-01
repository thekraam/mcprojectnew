using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillList : MonoBehaviour
{
    public Text soldiers;
    private int soldiersValue;
    public Text enemySoldiers;
    private int enemySoldiersValue;

    public Text ATKUI;
    private int ATKUIvalue;
    public Text DEFUI;
    private int DEFUIvalue;

    public Text eATKUI;
    private int eATKUIvalue;
    public Text eDEFUI;
    private int eDEFUIvalue;

    bool set = false;
    public bool battleConcluded = false;
    private bool canvasFadeDone = false;

    public Text[] Line;
    public CanvasGroup[] LineGroup;
    public CanvasGroup canvasContinue;
    //public GameObject buttonContinue;
    
    private int[] armyType = new int[30];
    private int[ , ] deadSoldiersInTurn = new int[30,2];
    private int[] atks = new int[30];
    private int[] defs = new int[30];
    int i = 0;

    private void Update()
    {
        if (set)
        {
            soldiers.text = " " + soldiersValue;
            enemySoldiers.text = "" + enemySoldiersValue;

            ATKUI.text = " " + ATKUIvalue;
            DEFUI.text = " " + DEFUIvalue;

            eATKUI.text = "" + eATKUIvalue;
            eDEFUI.text = "" + eDEFUIvalue;
        }
    }

    public void setKillList(int soldiers, int enemySoldiers, int ATKUI, int DEFUI, int eATKUI, int eDEFUI)
    {
        this.soldiersValue = soldiers;
        this.enemySoldiersValue = enemySoldiers;
        this.ATKUIvalue = ATKUI;
        this.DEFUIvalue = DEFUI;
        this.eATKUIvalue = eATKUI;
        this.eDEFUIvalue = eDEFUI;

        this.soldiers.text = "" + soldiers;
        this.enemySoldiers.text = "" + enemySoldiers;
        this.ATKUI.text = "" + ATKUI;
        this.DEFUI.text = "" + DEFUI;
        this.eATKUI.text = "" + eATKUI;
        this.eDEFUI.text = "" + eDEFUI;

        this.set = true;
    }


    public void setFightingSoldiers(int armytype, int deaths, int ATKtoSub, int DEFtoSub)
    {
        deadSoldiersInTurn[i , armytype] = deaths;
        atks[i] = ATKtoSub;
        defs[i] = DEFtoSub;
        i++;
    }

    public void insertNewLine(string line, int army)
    {
        Line[i].text = line;
        armyType[i] = army;
    }

    private void calcNewUI(int armytype, int line)
    {
        if(armytype == 1)
        {
            soldiersValue = (soldiersValue - deadSoldiersInTurn[line, armyType[line] - 1])<0 ? 0 : soldiersValue - deadSoldiersInTurn[line, armyType[line]-1];
            ATKUIvalue = (ATKUIvalue - atks[line])<0 ? 0 : ATKUIvalue - atks[line];
            DEFUIvalue = (DEFUIvalue - defs[line])<0 ? 0 : DEFUIvalue - defs[line];
        }
        else if (armytype == 2)
        {
            enemySoldiersValue = (enemySoldiersValue - deadSoldiersInTurn[line, armyType[line] - 1]) < 0 ? 0 : (enemySoldiersValue - deadSoldiersInTurn[line, armyType[line] - 1]);
            eATKUIvalue = (eATKUIvalue-atks[line])<0 ? 0 : (eATKUIvalue - atks[line]);
            eDEFUIvalue = (eDEFUIvalue-defs[line])<0 ? 0 : (eDEFUIvalue - defs[line]);
        }

    }

    public void test()
    {
        StartCoroutine(PushLines());
    }

    public IEnumerator delayedReset()
    {
        yield return new WaitUntil(() => battleConcluded == true);
        for (int j = 0; j <30; j++)
        {
            Line[j].text = "";
            Line[j].alignment = TextAnchor.MiddleLeft;
            LineGroup[j].alpha = 0;
            Line[j].rectTransform.localPosition = new Vector3(0, (float)476.8, (float)0);
            deadSoldiersInTurn[j, 0] = 0;
            deadSoldiersInTurn[j, 1] = 0;
            atks[j] = 0;
            defs[j] = 0;
            armyType[j] = 0;
        }
        i = 0;

        //buttonContinue.gameObject.SetActive(false);
        canvasContinue.alpha = 0;
        canvasContinue.gameObject.SetActive(false);

        battleConcluded = false;
        yield return null;
    }

    public void ResetKillList()
    {
        StartCoroutine(delayedReset());
    }


    float oldPos;
    float newPos;

    private IEnumerator FadeIn(CanvasGroup currentLineGroup)
    {
        currentLineGroup.gameObject.SetActive(true);
        
        float timePassed0 = 0f;

        if (currentLineGroup == canvasContinue)
        {

            yield return new WaitForSeconds(0.2f);

            if (currentLineGroup.alpha != 1)
                while (timePassed0 < 0.8f)
                {
                    timePassed0 += Time.deltaTime;
                    currentLineGroup.alpha = Mathf.Lerp(0f, 1f, timePassed0 / 0.8f); // da 0f a 1f si accende, da 1f a 0f si spegne
                    yield return new WaitForSeconds(0.002f);
                }
            canvasFadeDone = true;
        }
        else if(currentLineGroup == canvasContinue && canvasFadeDone) {
            yield return null;
        }
        else
        {
            yield return new WaitForSeconds(0.2f);

            if (currentLineGroup.alpha != 1)
                while (timePassed0 < 0.8f)
                {
                    timePassed0 += Time.deltaTime;
                    currentLineGroup.alpha = Mathf.Lerp(0f, 1f, timePassed0 / 0.8f); // da 0f a 1f si accende, da 1f a 0f si spegne
                    yield return new WaitForSeconds(0.002f);
                }
        }
        yield return null;
    }
    private IEnumerator FadeOut(CanvasGroup currentLineGroup)
    {
        yield return new WaitForSeconds(0.2f);
        float timePassed0 = 0f;

        if (currentLineGroup.alpha != 1)
            while (timePassed0 < 0.8f)
            {
                timePassed0 += Time.deltaTime;
                currentLineGroup.alpha = Mathf.Lerp(1f, 0f, timePassed0 / 0.8f); // da 0f a 1f si accende, da 1f a 0f si spegne
                yield return new WaitForSeconds(0.002f);
            }
        currentLineGroup.gameObject.SetActive(false);

    }

    public IEnumerator PushLines()
    {
        canvasFadeDone = false;
        yield return new WaitForSeconds(1f);

        if (Line[0].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[0]));
            if (armyType[0] == 2) Line[0].alignment = TextAnchor.MiddleRight;
        }
        else
        {
            if (!canvasFadeDone) StartCoroutine(FadeIn(canvasContinue));
            ResetKillList();
            StopCoroutine(PushLines());
            yield break;
        }
        calcNewUI(armyType[0], 0);



        yield return new WaitForSeconds(Random.Range(1f, 3f));

        if (Line[1].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[1]));
            if (armyType[1] == 2) Line[1].alignment = TextAnchor.MiddleRight;
            oldPos = Line[0].rectTransform.localPosition.y; 
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 4, (float)0);
                yield return null;
            }
            calcNewUI(armyType[1], 1);
        }
        else
        {
            if (!canvasFadeDone) StartCoroutine(FadeIn(canvasContinue));
            ResetKillList();
            StopCoroutine(PushLines());
            yield break;
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
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 4, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 4, (float)0);
                yield return null;
            }
            calcNewUI(armyType[2], 2);
        }
        else
        {
            if (!canvasFadeDone) StartCoroutine(FadeIn(canvasContinue));
            ResetKillList();
            StopCoroutine(PushLines());
            yield break;
        }

        yield return new WaitForSeconds(Random.Range(1f, 3f));


        if (Line[3].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[3]));
            if (armyType[3] == 2) Line[3].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 4, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 4, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 4, (float)0);
                yield return null;
            }
            calcNewUI(armyType[3], 3);
        }
        else
        {
            if (!canvasFadeDone) StartCoroutine(FadeIn(canvasContinue));
            ResetKillList();
            StopCoroutine(PushLines());
            yield break;
        }

        yield return new WaitForSeconds(Random.Range(1f, 3f));


        if (Line[4].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[4]));
            if (armyType[4] == 2) Line[4].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 4, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 4, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 4, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 4, (float)0);
                yield return null;
            }
            calcNewUI(armyType[4], 4);
        }
        else
        {
            if(!canvasFadeDone)  StartCoroutine(FadeIn(canvasContinue));
            ResetKillList();
            StopCoroutine(PushLines());
            yield break;
        }

        yield return new WaitForSeconds(Random.Range(1f, 3f));


        if (Line[5].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[5]));
            if (armyType[5] == 2) Line[5].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 4, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 4, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 4, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 4, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 4, (float)0);
                yield return null;
            }
            calcNewUI(armyType[5], 5);
        }
        else
        {
            if (!canvasFadeDone) StartCoroutine(FadeIn(canvasContinue));
            ResetKillList();
            StopCoroutine(PushLines());
            yield break;
        }

        yield return new WaitForSeconds(Random.Range(1f, 3f));

        if (Line[6].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[6]));
            if (armyType[6] == 2) Line[6].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 4, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 4, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 4, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 4, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 4, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 4, (float)0);
                yield return null;
            }
            calcNewUI(armyType[6], 6);
        }
        else
        {
            if (!canvasFadeDone) StartCoroutine(FadeIn(canvasContinue));
            ResetKillList();
            StopCoroutine(PushLines());
            yield break;
        }

        yield return new WaitForSeconds(Random.Range(1f, 3f));

        if (Line[7].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[7]));
            if (armyType[7] == 2) Line[7].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 4, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 4, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 4, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 4, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 4, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 4, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 4, (float)0);
                yield return null;
            }
            calcNewUI(armyType[7], 7);
        }
        else
        {
            if (!canvasFadeDone) StartCoroutine(FadeIn(canvasContinue));
            ResetKillList();
            StopCoroutine(PushLines());
            yield break;
        }

        yield return new WaitForSeconds(Random.Range(1f, 3f));

        if (Line[8].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[8]));
            if (armyType[8] == 2) Line[8].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 4, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 4, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 4, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 4, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 4, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 4, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 4, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 4, (float)0);
                yield return null;
            }
            calcNewUI(armyType[8], 8);
        }
        else
        {
            if (!canvasFadeDone) StartCoroutine(FadeIn(canvasContinue));
            ResetKillList();
            StopCoroutine(PushLines());
            yield break;
        }

        yield return new WaitForSeconds(Random.Range(1f, 3f));

        if (Line[9].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[9]));
            if (armyType[9] == 2) Line[9].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 4, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 4, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 4, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 4, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 4, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 4, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 4, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 4, (float)0);
                Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 4, (float)0);
                yield return null;
            }
            calcNewUI(armyType[9], 9);
        }
        else
        {
            if (!canvasFadeDone) StartCoroutine(FadeIn(canvasContinue));
            ResetKillList();
            StopCoroutine(PushLines());
            yield break;
        }

        yield return new WaitForSeconds(Random.Range(1f, 3f));

        if (Line[10].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[10]));
            if (armyType[10] == 2) Line[10].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 4, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 4, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 4, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 4, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 4, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 4, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 4, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 4, (float)0);
                Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 4, (float)0);
                Line[9].rectTransform.localPosition = new Vector3(0, (float)Line[9].rectTransform.localPosition.y - 4, (float)0);
                yield return null;
            }
            calcNewUI(armyType[10], 10);
        }
        else
        {
            if (!canvasFadeDone) StartCoroutine(FadeIn(canvasContinue));
            ResetKillList();
            StopCoroutine(PushLines());
            yield break;
        }

        yield return new WaitForSeconds(Random.Range(1f, 3f));

        if (Line[11].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[11]));
            if (armyType[11] == 2) Line[11].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 4, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 4, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 4, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 4, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 4, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 4, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 4, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 4, (float)0);
                Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 4, (float)0);
                Line[9].rectTransform.localPosition = new Vector3(0, (float)Line[9].rectTransform.localPosition.y - 4, (float)0);
                Line[10].rectTransform.localPosition = new Vector3(0, (float)Line[10].rectTransform.localPosition.y - 4, (float)0);
                yield return null;
            }
            calcNewUI(armyType[11], 11);
        }
        else
        {
            if (!canvasFadeDone) StartCoroutine(FadeIn(canvasContinue));
            ResetKillList();
            StopCoroutine(PushLines());
            yield break;
        }

        yield return new WaitForSeconds(Random.Range(1f, 3f));

        if (Line[12].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[12]));
            if (armyType[12] == 2) Line[12].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 4, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 4, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 4, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 4, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 4, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 4, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 4, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 4, (float)0);
                Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 4, (float)0);
                Line[9].rectTransform.localPosition = new Vector3(0, (float)Line[9].rectTransform.localPosition.y - 4, (float)0);
                Line[10].rectTransform.localPosition = new Vector3(0, (float)Line[10].rectTransform.localPosition.y - 4, (float)0);
                Line[11].rectTransform.localPosition = new Vector3(0, (float)Line[11].rectTransform.localPosition.y - 4, (float)0);
                yield return null;
            }
            calcNewUI(armyType[12], 12);
        }
        else
        {
            if (!canvasFadeDone) StartCoroutine(FadeIn(canvasContinue));
            ResetKillList();
            StopCoroutine(PushLines());
            yield break;
        }

        yield return new WaitForSeconds(Random.Range(1f, 3f));


        if (Line[13].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[13]));
            if (armyType[13] == 2) Line[13].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 4, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 4, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 4, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 4, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 4, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 4, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 4, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 4, (float)0);
                Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 4, (float)0);
                Line[9].rectTransform.localPosition = new Vector3(0, (float)Line[9].rectTransform.localPosition.y - 4, (float)0);
                Line[10].rectTransform.localPosition = new Vector3(0, (float)Line[10].rectTransform.localPosition.y - 4, (float)0);
                Line[11].rectTransform.localPosition = new Vector3(0, (float)Line[11].rectTransform.localPosition.y - 4, (float)0);
                Line[12].rectTransform.localPosition = new Vector3(0, (float)Line[12].rectTransform.localPosition.y - 4, (float)0);
                yield return null;
            }
            calcNewUI(armyType[13], 13);
        }
        else
        {
            if (!canvasFadeDone) StartCoroutine(FadeIn(canvasContinue));
            ResetKillList();
            StopCoroutine(PushLines());
            yield break;
        }

        yield return new WaitForSeconds(Random.Range(1f, 3f));


        if (Line[14].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[14]));
            if (armyType[14] == 2) Line[14].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 4, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 4, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 4, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 4, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 4, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 4, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 4, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 4, (float)0);
                Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 4, (float)0);
                Line[9].rectTransform.localPosition = new Vector3(0, (float)Line[9].rectTransform.localPosition.y - 4, (float)0);
                Line[10].rectTransform.localPosition = new Vector3(0, (float)Line[10].rectTransform.localPosition.y - 4, (float)0);
                Line[11].rectTransform.localPosition = new Vector3(0, (float)Line[11].rectTransform.localPosition.y - 4, (float)0);
                Line[12].rectTransform.localPosition = new Vector3(0, (float)Line[12].rectTransform.localPosition.y - 4, (float)0);
                Line[13].rectTransform.localPosition = new Vector3(0, (float)Line[13].rectTransform.localPosition.y - 4, (float)0);
                yield return null;
            }
            calcNewUI(armyType[14], 14);
        }
        else
        {
            if (!canvasFadeDone) StartCoroutine(FadeIn(canvasContinue));
            ResetKillList();
            StopCoroutine(PushLines());
            yield break;
        }

        yield return new WaitForSeconds(Random.Range(1f, 3f));



        if (Line[15].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[15]));
            if (armyType[15] == 2) Line[15].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 4, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 4, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 4, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 4, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 4, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 4, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 4, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 4, (float)0);
                Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 4, (float)0);
                Line[9].rectTransform.localPosition = new Vector3(0, (float)Line[9].rectTransform.localPosition.y - 4, (float)0);
                Line[10].rectTransform.localPosition = new Vector3(0, (float)Line[10].rectTransform.localPosition.y - 4, (float)0);
                Line[11].rectTransform.localPosition = new Vector3(0, (float)Line[11].rectTransform.localPosition.y - 4, (float)0);
                Line[12].rectTransform.localPosition = new Vector3(0, (float)Line[12].rectTransform.localPosition.y - 4, (float)0);
                Line[13].rectTransform.localPosition = new Vector3(0, (float)Line[13].rectTransform.localPosition.y - 4, (float)0);
                Line[14].rectTransform.localPosition = new Vector3(0, (float)Line[14].rectTransform.localPosition.y - 4, (float)0);
                yield return null;
            }
            calcNewUI(armyType[15], 15);
        }
        else
        {
            if (!canvasFadeDone) StartCoroutine(FadeIn(canvasContinue));
            ResetKillList();
            StopCoroutine(PushLines());
            yield break;
        }

        yield return new WaitForSeconds(Random.Range(1f, 3f));



        if (Line[16].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[16]));
            if (armyType[16] == 2) Line[16].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 4, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 4, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 4, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 4, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 4, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 4, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 4, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 4, (float)0);
                Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 4, (float)0);
                Line[9].rectTransform.localPosition = new Vector3(0, (float)Line[9].rectTransform.localPosition.y - 4, (float)0);
                Line[10].rectTransform.localPosition = new Vector3(0, (float)Line[10].rectTransform.localPosition.y - 4, (float)0);
                Line[11].rectTransform.localPosition = new Vector3(0, (float)Line[11].rectTransform.localPosition.y - 4, (float)0);
                Line[12].rectTransform.localPosition = new Vector3(0, (float)Line[12].rectTransform.localPosition.y - 4, (float)0);
                Line[13].rectTransform.localPosition = new Vector3(0, (float)Line[13].rectTransform.localPosition.y - 4, (float)0);
                Line[14].rectTransform.localPosition = new Vector3(0, (float)Line[14].rectTransform.localPosition.y - 4, (float)0);
                Line[15].rectTransform.localPosition = new Vector3(0, (float)Line[15].rectTransform.localPosition.y - 4, (float)0);
                yield return null;
            }
            calcNewUI(armyType[16], 16);
        }
        else
        {
            if (!canvasFadeDone) StartCoroutine(FadeIn(canvasContinue));
            ResetKillList();
            StopCoroutine(PushLines());
            yield break;
        }

        yield return new WaitForSeconds(Random.Range(1f, 3f));



        if (Line[17].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[17]));
            if (armyType[17] == 2) Line[17].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 4, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 4, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 4, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 4, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 4, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 4, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 4, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 4, (float)0);
                Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 4, (float)0);
                Line[9].rectTransform.localPosition = new Vector3(0, (float)Line[9].rectTransform.localPosition.y - 4, (float)0);
                Line[10].rectTransform.localPosition = new Vector3(0, (float)Line[10].rectTransform.localPosition.y - 4, (float)0);
                Line[11].rectTransform.localPosition = new Vector3(0, (float)Line[11].rectTransform.localPosition.y - 4, (float)0);
                Line[12].rectTransform.localPosition = new Vector3(0, (float)Line[12].rectTransform.localPosition.y - 4, (float)0);
                Line[13].rectTransform.localPosition = new Vector3(0, (float)Line[13].rectTransform.localPosition.y - 4, (float)0);
                Line[14].rectTransform.localPosition = new Vector3(0, (float)Line[14].rectTransform.localPosition.y - 4, (float)0);
                Line[15].rectTransform.localPosition = new Vector3(0, (float)Line[15].rectTransform.localPosition.y - 4, (float)0);
                Line[16].rectTransform.localPosition = new Vector3(0, (float)Line[16].rectTransform.localPosition.y - 4, (float)0);
                yield return null;
            }
            calcNewUI(armyType[17], 17);
        }
        else
        {
            if (!canvasFadeDone) StartCoroutine(FadeIn(canvasContinue));
            ResetKillList();
            StopCoroutine(PushLines());
            yield break;
        }

        yield return new WaitForSeconds(Random.Range(1f, 3f));




        if (Line[18].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[18]));
            if (armyType[18] == 2) Line[18].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 4, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 4, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 4, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 4, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 4, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 4, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 4, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 4, (float)0);
                Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 4, (float)0);
                Line[9].rectTransform.localPosition = new Vector3(0, (float)Line[9].rectTransform.localPosition.y - 4, (float)0);
                Line[10].rectTransform.localPosition = new Vector3(0, (float)Line[10].rectTransform.localPosition.y - 4, (float)0);
                Line[11].rectTransform.localPosition = new Vector3(0, (float)Line[11].rectTransform.localPosition.y - 4, (float)0);
                Line[12].rectTransform.localPosition = new Vector3(0, (float)Line[12].rectTransform.localPosition.y - 4, (float)0);
                Line[13].rectTransform.localPosition = new Vector3(0, (float)Line[13].rectTransform.localPosition.y - 4, (float)0);
                Line[14].rectTransform.localPosition = new Vector3(0, (float)Line[14].rectTransform.localPosition.y - 4, (float)0);
                Line[15].rectTransform.localPosition = new Vector3(0, (float)Line[15].rectTransform.localPosition.y - 4, (float)0);
                Line[16].rectTransform.localPosition = new Vector3(0, (float)Line[16].rectTransform.localPosition.y - 4, (float)0);
                Line[17].rectTransform.localPosition = new Vector3(0, (float)Line[17].rectTransform.localPosition.y - 4, (float)0);
                yield return null;
            }
            calcNewUI(armyType[18], 18);
        }
        else
        {
            if (!canvasFadeDone) StartCoroutine(FadeIn(canvasContinue));
            ResetKillList();
            StopCoroutine(PushLines());
            yield break;
        }

        yield return new WaitForSeconds(Random.Range(1f, 3f));



        if (Line[19].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[19]));
            if (armyType[19] == 2) Line[19].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 4, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 4, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 4, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 4, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 4, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 4, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 4, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 4, (float)0);
                Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 4, (float)0);
                Line[9].rectTransform.localPosition = new Vector3(0, (float)Line[9].rectTransform.localPosition.y - 4, (float)0);
                Line[10].rectTransform.localPosition = new Vector3(0, (float)Line[10].rectTransform.localPosition.y - 4, (float)0);
                Line[11].rectTransform.localPosition = new Vector3(0, (float)Line[11].rectTransform.localPosition.y - 4, (float)0);
                Line[12].rectTransform.localPosition = new Vector3(0, (float)Line[12].rectTransform.localPosition.y - 4, (float)0);
                Line[13].rectTransform.localPosition = new Vector3(0, (float)Line[13].rectTransform.localPosition.y - 4, (float)0);
                Line[14].rectTransform.localPosition = new Vector3(0, (float)Line[14].rectTransform.localPosition.y - 4, (float)0);
                Line[15].rectTransform.localPosition = new Vector3(0, (float)Line[15].rectTransform.localPosition.y - 4, (float)0);
                Line[16].rectTransform.localPosition = new Vector3(0, (float)Line[16].rectTransform.localPosition.y - 4, (float)0);
                Line[17].rectTransform.localPosition = new Vector3(0, (float)Line[17].rectTransform.localPosition.y - 4, (float)0);
                Line[18].rectTransform.localPosition = new Vector3(0, (float)Line[18].rectTransform.localPosition.y - 4, (float)0);
                yield return null;
            }
            calcNewUI(armyType[19], 19);
        }
        else
        {
            if (!canvasFadeDone) StartCoroutine(FadeIn(canvasContinue));
            ResetKillList();
            StopCoroutine(PushLines());
            yield break;
        }

        yield return new WaitForSeconds(Random.Range(1f, 3f));



        if (Line[20].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[20]));
            if (armyType[20] == 2) Line[20].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 4, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 4, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 4, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 4, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 4, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 4, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 4, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 4, (float)0);
                Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 4, (float)0);
                Line[9].rectTransform.localPosition = new Vector3(0, (float)Line[9].rectTransform.localPosition.y - 4, (float)0);
                Line[10].rectTransform.localPosition = new Vector3(0, (float)Line[10].rectTransform.localPosition.y - 4, (float)0);
                Line[11].rectTransform.localPosition = new Vector3(0, (float)Line[11].rectTransform.localPosition.y - 4, (float)0);
                Line[12].rectTransform.localPosition = new Vector3(0, (float)Line[12].rectTransform.localPosition.y - 4, (float)0);
                Line[13].rectTransform.localPosition = new Vector3(0, (float)Line[13].rectTransform.localPosition.y - 4, (float)0);
                Line[14].rectTransform.localPosition = new Vector3(0, (float)Line[14].rectTransform.localPosition.y - 4, (float)0);
                Line[15].rectTransform.localPosition = new Vector3(0, (float)Line[15].rectTransform.localPosition.y - 4, (float)0);
                Line[16].rectTransform.localPosition = new Vector3(0, (float)Line[16].rectTransform.localPosition.y - 4, (float)0);
                Line[17].rectTransform.localPosition = new Vector3(0, (float)Line[17].rectTransform.localPosition.y - 4, (float)0);
                Line[18].rectTransform.localPosition = new Vector3(0, (float)Line[18].rectTransform.localPosition.y - 4, (float)0);
                Line[19].rectTransform.localPosition = new Vector3(0, (float)Line[19].rectTransform.localPosition.y - 4, (float)0);
                yield return null;
            }
            calcNewUI(armyType[20], 20);
        }
        else
        {
            if (!canvasFadeDone) StartCoroutine(FadeIn(canvasContinue));
            ResetKillList();
            StopCoroutine(PushLines());
            yield break;
        }

        yield return new WaitForSeconds(Random.Range(1f, 3f));



        if (Line[21].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[21]));
            if (armyType[21] == 2) Line[21].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 4, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 4, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 4, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 4, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 4, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 4, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 4, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 4, (float)0);
                Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 4, (float)0);
                Line[9].rectTransform.localPosition = new Vector3(0, (float)Line[9].rectTransform.localPosition.y - 4, (float)0);
                Line[10].rectTransform.localPosition = new Vector3(0, (float)Line[10].rectTransform.localPosition.y - 4, (float)0);
                Line[11].rectTransform.localPosition = new Vector3(0, (float)Line[11].rectTransform.localPosition.y - 4, (float)0);
                Line[12].rectTransform.localPosition = new Vector3(0, (float)Line[12].rectTransform.localPosition.y - 4, (float)0);
                Line[13].rectTransform.localPosition = new Vector3(0, (float)Line[13].rectTransform.localPosition.y - 4, (float)0);
                Line[14].rectTransform.localPosition = new Vector3(0, (float)Line[14].rectTransform.localPosition.y - 4, (float)0);
                Line[15].rectTransform.localPosition = new Vector3(0, (float)Line[15].rectTransform.localPosition.y - 4, (float)0);
                Line[16].rectTransform.localPosition = new Vector3(0, (float)Line[16].rectTransform.localPosition.y - 4, (float)0);
                Line[17].rectTransform.localPosition = new Vector3(0, (float)Line[17].rectTransform.localPosition.y - 4, (float)0);
                Line[18].rectTransform.localPosition = new Vector3(0, (float)Line[18].rectTransform.localPosition.y - 4, (float)0);
                Line[19].rectTransform.localPosition = new Vector3(0, (float)Line[19].rectTransform.localPosition.y - 4, (float)0);
                Line[20].rectTransform.localPosition = new Vector3(0, (float)Line[20].rectTransform.localPosition.y - 4, (float)0);
                yield return null;
            }
            calcNewUI(armyType[21], 21);
        }
        else
        {
            if (!canvasFadeDone) StartCoroutine(FadeIn(canvasContinue));
            ResetKillList();
            StopCoroutine(PushLines());
            yield break;
        }

        yield return new WaitForSeconds(Random.Range(1f, 3f));



        if (Line[22].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[22]));
            if (armyType[22] == 2) Line[22].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 4, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 4, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 4, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 4, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 4, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 4, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 4, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 4, (float)0);
                Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 4, (float)0);
                Line[9].rectTransform.localPosition = new Vector3(0, (float)Line[9].rectTransform.localPosition.y - 4, (float)0);
                Line[10].rectTransform.localPosition = new Vector3(0, (float)Line[10].rectTransform.localPosition.y - 4, (float)0);
                Line[11].rectTransform.localPosition = new Vector3(0, (float)Line[11].rectTransform.localPosition.y - 4, (float)0);
                Line[12].rectTransform.localPosition = new Vector3(0, (float)Line[12].rectTransform.localPosition.y - 4, (float)0);
                Line[13].rectTransform.localPosition = new Vector3(0, (float)Line[13].rectTransform.localPosition.y - 4, (float)0);
                Line[14].rectTransform.localPosition = new Vector3(0, (float)Line[14].rectTransform.localPosition.y - 4, (float)0);
                Line[15].rectTransform.localPosition = new Vector3(0, (float)Line[15].rectTransform.localPosition.y - 4, (float)0);
                Line[16].rectTransform.localPosition = new Vector3(0, (float)Line[16].rectTransform.localPosition.y - 4, (float)0);
                Line[17].rectTransform.localPosition = new Vector3(0, (float)Line[17].rectTransform.localPosition.y - 4, (float)0);
                Line[18].rectTransform.localPosition = new Vector3(0, (float)Line[18].rectTransform.localPosition.y - 4, (float)0);
                Line[19].rectTransform.localPosition = new Vector3(0, (float)Line[19].rectTransform.localPosition.y - 4, (float)0);
                Line[20].rectTransform.localPosition = new Vector3(0, (float)Line[20].rectTransform.localPosition.y - 4, (float)0);
                Line[21].rectTransform.localPosition = new Vector3(0, (float)Line[21].rectTransform.localPosition.y - 4, (float)0);
                yield return null;
            }
            calcNewUI(armyType[22], 22);
        }
        else
        {
            if (!canvasFadeDone) StartCoroutine(FadeIn(canvasContinue));
            ResetKillList();
            StopCoroutine(PushLines());
            yield break;
        }

        yield return new WaitForSeconds(Random.Range(1f, 3f));




        if (Line[23].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[23]));
            if (armyType[23] == 2) Line[23].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 4, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 4, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 4, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 4, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 4, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 4, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 4, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 4, (float)0);
                Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 4, (float)0);
                Line[9].rectTransform.localPosition = new Vector3(0, (float)Line[9].rectTransform.localPosition.y - 4, (float)0);
                Line[10].rectTransform.localPosition = new Vector3(0, (float)Line[10].rectTransform.localPosition.y - 4, (float)0);
                Line[11].rectTransform.localPosition = new Vector3(0, (float)Line[11].rectTransform.localPosition.y - 4, (float)0);
                Line[12].rectTransform.localPosition = new Vector3(0, (float)Line[12].rectTransform.localPosition.y - 4, (float)0);
                Line[13].rectTransform.localPosition = new Vector3(0, (float)Line[13].rectTransform.localPosition.y - 4, (float)0);
                Line[14].rectTransform.localPosition = new Vector3(0, (float)Line[14].rectTransform.localPosition.y - 4, (float)0);
                Line[15].rectTransform.localPosition = new Vector3(0, (float)Line[15].rectTransform.localPosition.y - 4, (float)0);
                Line[16].rectTransform.localPosition = new Vector3(0, (float)Line[16].rectTransform.localPosition.y - 4, (float)0);
                Line[17].rectTransform.localPosition = new Vector3(0, (float)Line[17].rectTransform.localPosition.y - 4, (float)0);
                Line[18].rectTransform.localPosition = new Vector3(0, (float)Line[18].rectTransform.localPosition.y - 4, (float)0);
                Line[19].rectTransform.localPosition = new Vector3(0, (float)Line[19].rectTransform.localPosition.y - 4, (float)0);
                Line[20].rectTransform.localPosition = new Vector3(0, (float)Line[20].rectTransform.localPosition.y - 4, (float)0);
                Line[21].rectTransform.localPosition = new Vector3(0, (float)Line[21].rectTransform.localPosition.y - 4, (float)0);
                Line[22].rectTransform.localPosition = new Vector3(0, (float)Line[22].rectTransform.localPosition.y - 4, (float)0);
                yield return null;
            }
            calcNewUI(armyType[23], 23);
        }
        else
        {
            if (!canvasFadeDone) StartCoroutine(FadeIn(canvasContinue));
            ResetKillList();
            StopCoroutine(PushLines());
            yield break;
        }

        yield return new WaitForSeconds(Random.Range(1f, 3f));



        if (Line[24].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[24]));
            if (armyType[24] == 2) Line[24].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 4, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 4, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 4, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 4, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 4, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 4, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 4, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 4, (float)0);
                Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 4, (float)0);
                Line[9].rectTransform.localPosition = new Vector3(0, (float)Line[9].rectTransform.localPosition.y - 4, (float)0);
                Line[10].rectTransform.localPosition = new Vector3(0, (float)Line[10].rectTransform.localPosition.y - 4, (float)0);
                Line[11].rectTransform.localPosition = new Vector3(0, (float)Line[11].rectTransform.localPosition.y - 4, (float)0);
                Line[12].rectTransform.localPosition = new Vector3(0, (float)Line[12].rectTransform.localPosition.y - 4, (float)0);
                Line[13].rectTransform.localPosition = new Vector3(0, (float)Line[13].rectTransform.localPosition.y - 4, (float)0);
                Line[14].rectTransform.localPosition = new Vector3(0, (float)Line[14].rectTransform.localPosition.y - 4, (float)0);
                Line[15].rectTransform.localPosition = new Vector3(0, (float)Line[15].rectTransform.localPosition.y - 4, (float)0);
                Line[16].rectTransform.localPosition = new Vector3(0, (float)Line[16].rectTransform.localPosition.y - 4, (float)0);
                Line[17].rectTransform.localPosition = new Vector3(0, (float)Line[17].rectTransform.localPosition.y - 4, (float)0);
                Line[18].rectTransform.localPosition = new Vector3(0, (float)Line[18].rectTransform.localPosition.y - 4, (float)0);
                Line[19].rectTransform.localPosition = new Vector3(0, (float)Line[19].rectTransform.localPosition.y - 4, (float)0);
                Line[20].rectTransform.localPosition = new Vector3(0, (float)Line[20].rectTransform.localPosition.y - 4, (float)0);
                Line[21].rectTransform.localPosition = new Vector3(0, (float)Line[21].rectTransform.localPosition.y - 4, (float)0);
                Line[22].rectTransform.localPosition = new Vector3(0, (float)Line[22].rectTransform.localPosition.y - 4, (float)0);
                Line[23].rectTransform.localPosition = new Vector3(0, (float)Line[23].rectTransform.localPosition.y - 4, (float)0);
                yield return null;
            }
            calcNewUI(armyType[24], 24);
        }
        else
        {
            if (!canvasFadeDone) StartCoroutine(FadeIn(canvasContinue));
            ResetKillList();
            StopCoroutine(PushLines());
            yield break;
        }
        yield return new WaitForSeconds(Random.Range(1f, 3f));



        if (Line[25].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[25]));
            if (armyType[25] == 2) Line[25].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 4, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 4, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 4, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 4, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 4, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 4, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 4, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 4, (float)0);
                Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 4, (float)0);
                Line[9].rectTransform.localPosition = new Vector3(0, (float)Line[9].rectTransform.localPosition.y - 4, (float)0);
                Line[10].rectTransform.localPosition = new Vector3(0, (float)Line[10].rectTransform.localPosition.y - 4, (float)0);
                Line[11].rectTransform.localPosition = new Vector3(0, (float)Line[11].rectTransform.localPosition.y - 4, (float)0);
                Line[12].rectTransform.localPosition = new Vector3(0, (float)Line[12].rectTransform.localPosition.y - 4, (float)0);
                Line[13].rectTransform.localPosition = new Vector3(0, (float)Line[13].rectTransform.localPosition.y - 4, (float)0);
                Line[14].rectTransform.localPosition = new Vector3(0, (float)Line[14].rectTransform.localPosition.y - 4, (float)0);
                Line[15].rectTransform.localPosition = new Vector3(0, (float)Line[15].rectTransform.localPosition.y - 4, (float)0);
                Line[16].rectTransform.localPosition = new Vector3(0, (float)Line[16].rectTransform.localPosition.y - 4, (float)0);
                Line[17].rectTransform.localPosition = new Vector3(0, (float)Line[17].rectTransform.localPosition.y - 4, (float)0);
                Line[18].rectTransform.localPosition = new Vector3(0, (float)Line[18].rectTransform.localPosition.y - 4, (float)0);
                Line[19].rectTransform.localPosition = new Vector3(0, (float)Line[19].rectTransform.localPosition.y - 4, (float)0);
                Line[20].rectTransform.localPosition = new Vector3(0, (float)Line[20].rectTransform.localPosition.y - 4, (float)0);
                Line[21].rectTransform.localPosition = new Vector3(0, (float)Line[21].rectTransform.localPosition.y - 4, (float)0);
                Line[22].rectTransform.localPosition = new Vector3(0, (float)Line[22].rectTransform.localPosition.y - 4, (float)0);
                Line[23].rectTransform.localPosition = new Vector3(0, (float)Line[23].rectTransform.localPosition.y - 4, (float)0);
                Line[24].rectTransform.localPosition = new Vector3(0, (float)Line[24].rectTransform.localPosition.y - 4, (float)0);
                yield return null;
            }
            calcNewUI(armyType[25], 25);
        }
        else
        {
            if (!canvasFadeDone) StartCoroutine(FadeIn(canvasContinue));
            ResetKillList();
            StopCoroutine(PushLines());
            yield break;
        }

        yield return new WaitForSeconds(Random.Range(1f, 3f));



        if (Line[26].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[26]));
            if (armyType[26] == 2) Line[26].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 4, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 4, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 4, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 4, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 4, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 4, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 4, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 4, (float)0);
                Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 4, (float)0);
                Line[9].rectTransform.localPosition = new Vector3(0, (float)Line[9].rectTransform.localPosition.y - 4, (float)0);
                Line[10].rectTransform.localPosition = new Vector3(0, (float)Line[10].rectTransform.localPosition.y - 4, (float)0);
                Line[11].rectTransform.localPosition = new Vector3(0, (float)Line[11].rectTransform.localPosition.y - 4, (float)0);
                Line[12].rectTransform.localPosition = new Vector3(0, (float)Line[12].rectTransform.localPosition.y - 4, (float)0);
                Line[13].rectTransform.localPosition = new Vector3(0, (float)Line[13].rectTransform.localPosition.y - 4, (float)0);
                Line[14].rectTransform.localPosition = new Vector3(0, (float)Line[14].rectTransform.localPosition.y - 4, (float)0);
                Line[15].rectTransform.localPosition = new Vector3(0, (float)Line[15].rectTransform.localPosition.y - 4, (float)0);
                Line[16].rectTransform.localPosition = new Vector3(0, (float)Line[16].rectTransform.localPosition.y - 4, (float)0);
                Line[17].rectTransform.localPosition = new Vector3(0, (float)Line[17].rectTransform.localPosition.y - 4, (float)0);
                Line[18].rectTransform.localPosition = new Vector3(0, (float)Line[18].rectTransform.localPosition.y - 4, (float)0);
                Line[19].rectTransform.localPosition = new Vector3(0, (float)Line[19].rectTransform.localPosition.y - 4, (float)0);
                Line[20].rectTransform.localPosition = new Vector3(0, (float)Line[20].rectTransform.localPosition.y - 4, (float)0);
                Line[21].rectTransform.localPosition = new Vector3(0, (float)Line[21].rectTransform.localPosition.y - 4, (float)0);
                Line[22].rectTransform.localPosition = new Vector3(0, (float)Line[22].rectTransform.localPosition.y - 4, (float)0);
                Line[23].rectTransform.localPosition = new Vector3(0, (float)Line[23].rectTransform.localPosition.y - 4, (float)0);
                Line[24].rectTransform.localPosition = new Vector3(0, (float)Line[24].rectTransform.localPosition.y - 4, (float)0);
                Line[25].rectTransform.localPosition = new Vector3(0, (float)Line[25].rectTransform.localPosition.y - 4, (float)0);
                yield return null;
            }
            calcNewUI(armyType[26], 26);
        }
        else
        {
            if (!canvasFadeDone) StartCoroutine(FadeIn(canvasContinue));
            ResetKillList();
            StopCoroutine(PushLines());
            yield break;
        }

        yield return new WaitForSeconds(Random.Range(1f, 3f));



        if (Line[27].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[27]));
            if (armyType[27] == 2) Line[27].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 4, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 4, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 4, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 4, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 4, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 4, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 4, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 4, (float)0);
                Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 4, (float)0);
                Line[9].rectTransform.localPosition = new Vector3(0, (float)Line[9].rectTransform.localPosition.y - 4, (float)0);
                Line[10].rectTransform.localPosition = new Vector3(0, (float)Line[10].rectTransform.localPosition.y - 4, (float)0);
                Line[11].rectTransform.localPosition = new Vector3(0, (float)Line[11].rectTransform.localPosition.y - 4, (float)0);
                Line[12].rectTransform.localPosition = new Vector3(0, (float)Line[12].rectTransform.localPosition.y - 4, (float)0);
                Line[13].rectTransform.localPosition = new Vector3(0, (float)Line[13].rectTransform.localPosition.y - 4, (float)0);
                Line[14].rectTransform.localPosition = new Vector3(0, (float)Line[14].rectTransform.localPosition.y - 4, (float)0);
                Line[15].rectTransform.localPosition = new Vector3(0, (float)Line[15].rectTransform.localPosition.y - 4, (float)0);
                Line[16].rectTransform.localPosition = new Vector3(0, (float)Line[16].rectTransform.localPosition.y - 4, (float)0);
                Line[17].rectTransform.localPosition = new Vector3(0, (float)Line[17].rectTransform.localPosition.y - 4, (float)0);
                Line[18].rectTransform.localPosition = new Vector3(0, (float)Line[18].rectTransform.localPosition.y - 4, (float)0);
                Line[19].rectTransform.localPosition = new Vector3(0, (float)Line[19].rectTransform.localPosition.y - 4, (float)0);
                Line[20].rectTransform.localPosition = new Vector3(0, (float)Line[20].rectTransform.localPosition.y - 4, (float)0);
                Line[21].rectTransform.localPosition = new Vector3(0, (float)Line[21].rectTransform.localPosition.y - 4, (float)0);
                Line[22].rectTransform.localPosition = new Vector3(0, (float)Line[22].rectTransform.localPosition.y - 4, (float)0);
                Line[23].rectTransform.localPosition = new Vector3(0, (float)Line[23].rectTransform.localPosition.y - 4, (float)0);
                Line[24].rectTransform.localPosition = new Vector3(0, (float)Line[24].rectTransform.localPosition.y - 4, (float)0);
                Line[25].rectTransform.localPosition = new Vector3(0, (float)Line[25].rectTransform.localPosition.y - 4, (float)0);
                Line[26].rectTransform.localPosition = new Vector3(0, (float)Line[26].rectTransform.localPosition.y - 4, (float)0);
                yield return null;
            }
            calcNewUI(armyType[27], 27);
        }
        else
        {
            if (!canvasFadeDone) StartCoroutine(FadeIn(canvasContinue));
            ResetKillList();
            StopCoroutine(PushLines());
            yield break;
        }

        yield return new WaitForSeconds(Random.Range(1f, 3f));



        if (Line[28].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[28]));
            if (armyType[28] == 2) Line[28].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 4, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 4, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 4, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 4, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 4, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 4, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 4, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 4, (float)0);
                Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 4, (float)0);
                Line[9].rectTransform.localPosition = new Vector3(0, (float)Line[9].rectTransform.localPosition.y - 4, (float)0);
                Line[10].rectTransform.localPosition = new Vector3(0, (float)Line[10].rectTransform.localPosition.y - 4, (float)0);
                Line[11].rectTransform.localPosition = new Vector3(0, (float)Line[11].rectTransform.localPosition.y - 4, (float)0);
                Line[12].rectTransform.localPosition = new Vector3(0, (float)Line[12].rectTransform.localPosition.y - 4, (float)0);
                Line[13].rectTransform.localPosition = new Vector3(0, (float)Line[13].rectTransform.localPosition.y - 4, (float)0);
                Line[14].rectTransform.localPosition = new Vector3(0, (float)Line[14].rectTransform.localPosition.y - 4, (float)0);
                Line[15].rectTransform.localPosition = new Vector3(0, (float)Line[15].rectTransform.localPosition.y - 4, (float)0);
                Line[16].rectTransform.localPosition = new Vector3(0, (float)Line[16].rectTransform.localPosition.y - 4, (float)0);
                Line[17].rectTransform.localPosition = new Vector3(0, (float)Line[17].rectTransform.localPosition.y - 4, (float)0);
                Line[18].rectTransform.localPosition = new Vector3(0, (float)Line[18].rectTransform.localPosition.y - 4, (float)0);
                Line[19].rectTransform.localPosition = new Vector3(0, (float)Line[19].rectTransform.localPosition.y - 4, (float)0);
                Line[20].rectTransform.localPosition = new Vector3(0, (float)Line[20].rectTransform.localPosition.y - 4, (float)0);
                Line[21].rectTransform.localPosition = new Vector3(0, (float)Line[21].rectTransform.localPosition.y - 4, (float)0);
                Line[22].rectTransform.localPosition = new Vector3(0, (float)Line[22].rectTransform.localPosition.y - 4, (float)0);
                Line[23].rectTransform.localPosition = new Vector3(0, (float)Line[23].rectTransform.localPosition.y - 4, (float)0);
                Line[24].rectTransform.localPosition = new Vector3(0, (float)Line[24].rectTransform.localPosition.y - 4, (float)0);
                Line[25].rectTransform.localPosition = new Vector3(0, (float)Line[25].rectTransform.localPosition.y - 4, (float)0);
                Line[26].rectTransform.localPosition = new Vector3(0, (float)Line[26].rectTransform.localPosition.y - 4, (float)0);
                Line[27].rectTransform.localPosition = new Vector3(0, (float)Line[27].rectTransform.localPosition.y - 4, (float)0);
                yield return null;
            }
            calcNewUI(armyType[28], 28);
        }
        else
        {
            if (!canvasFadeDone) StartCoroutine(FadeIn(canvasContinue));
            ResetKillList();
            StopCoroutine(PushLines());
            yield break;
        }

            yield return new WaitForSeconds(Random.Range(1f, 3f));



        if (Line[29].text != "")
        {
            StartCoroutine(FadeIn(LineGroup[29]));
            if (armyType[29] == 2) Line[29].alignment = TextAnchor.MiddleRight;
            newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
            while (Line[0].rectTransform.localPosition.y >= newPos)
            {
                Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 4, (float)0);
                Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 4, (float)0);
                Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 4, (float)0);
                Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 4, (float)0);
                Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 4, (float)0);
                Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 4, (float)0);
                Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 4, (float)0);
                Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 4, (float)0);
                Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 4, (float)0);
                Line[9].rectTransform.localPosition = new Vector3(0, (float)Line[9].rectTransform.localPosition.y - 4, (float)0);
                Line[10].rectTransform.localPosition = new Vector3(0, (float)Line[10].rectTransform.localPosition.y - 4, (float)0);
                Line[11].rectTransform.localPosition = new Vector3(0, (float)Line[11].rectTransform.localPosition.y - 4, (float)0);
                Line[12].rectTransform.localPosition = new Vector3(0, (float)Line[12].rectTransform.localPosition.y - 4, (float)0);
                Line[13].rectTransform.localPosition = new Vector3(0, (float)Line[13].rectTransform.localPosition.y - 4, (float)0);
                Line[14].rectTransform.localPosition = new Vector3(0, (float)Line[14].rectTransform.localPosition.y - 4, (float)0);
                Line[15].rectTransform.localPosition = new Vector3(0, (float)Line[15].rectTransform.localPosition.y - 4, (float)0);
                Line[16].rectTransform.localPosition = new Vector3(0, (float)Line[16].rectTransform.localPosition.y - 4, (float)0);
                Line[17].rectTransform.localPosition = new Vector3(0, (float)Line[17].rectTransform.localPosition.y - 4, (float)0);
                Line[18].rectTransform.localPosition = new Vector3(0, (float)Line[18].rectTransform.localPosition.y - 4, (float)0);
                Line[19].rectTransform.localPosition = new Vector3(0, (float)Line[19].rectTransform.localPosition.y - 4, (float)0);
                Line[20].rectTransform.localPosition = new Vector3(0, (float)Line[20].rectTransform.localPosition.y - 4, (float)0);
                Line[21].rectTransform.localPosition = new Vector3(0, (float)Line[21].rectTransform.localPosition.y - 4, (float)0);
                Line[22].rectTransform.localPosition = new Vector3(0, (float)Line[22].rectTransform.localPosition.y - 4, (float)0);
                Line[23].rectTransform.localPosition = new Vector3(0, (float)Line[23].rectTransform.localPosition.y - 4, (float)0);
                Line[24].rectTransform.localPosition = new Vector3(0, (float)Line[24].rectTransform.localPosition.y - 4, (float)0);
                Line[25].rectTransform.localPosition = new Vector3(0, (float)Line[25].rectTransform.localPosition.y - 4, (float)0);
                Line[26].rectTransform.localPosition = new Vector3(0, (float)Line[26].rectTransform.localPosition.y - 4, (float)0);
                Line[27].rectTransform.localPosition = new Vector3(0, (float)Line[27].rectTransform.localPosition.y - 4, (float)0);
                Line[28].rectTransform.localPosition = new Vector3(0, (float)Line[28].rectTransform.localPosition.y - 4, (float)0);
                yield return null;
            }
            calcNewUI(armyType[29], 29);
        }
        else
        {
            if (!canvasFadeDone) StartCoroutine(FadeIn(canvasContinue));
            ResetKillList();
            StopCoroutine(PushLines());
            yield break;
        }


        if (!canvasFadeDone) StartCoroutine(FadeIn(canvasContinue));

        ResetKillList();

        StopCoroutine(PushLines());

        yield break;




        //if (Line[30].text != "")
        //{
        //    StartCoroutine(FadeIn(LineGroup[30]));
        //    if (armyType[30] == 2) Line[30].alignment = TextAnchor.MiddleRight;
        //    newPos = Line[0].rectTransform.localPosition.y - (float)119.7;
        //    while (Line[0].rectTransform.localPosition.y >= newPos)
        //    {
        //        Line[0].rectTransform.localPosition = new Vector3(0, (float)Line[0].rectTransform.localPosition.y - 4, (float)0);
        //        Line[1].rectTransform.localPosition = new Vector3(0, (float)Line[1].rectTransform.localPosition.y - 4, (float)0);
        //        Line[2].rectTransform.localPosition = new Vector3(0, (float)Line[2].rectTransform.localPosition.y - 4, (float)0);
        //        Line[3].rectTransform.localPosition = new Vector3(0, (float)Line[3].rectTransform.localPosition.y - 4, (float)0);
        //        Line[4].rectTransform.localPosition = new Vector3(0, (float)Line[4].rectTransform.localPosition.y - 4, (float)0);
        //        Line[5].rectTransform.localPosition = new Vector3(0, (float)Line[5].rectTransform.localPosition.y - 4, (float)0);
        //        Line[6].rectTransform.localPosition = new Vector3(0, (float)Line[6].rectTransform.localPosition.y - 4, (float)0);
        //        Line[7].rectTransform.localPosition = new Vector3(0, (float)Line[7].rectTransform.localPosition.y - 4, (float)0);
        //        Line[8].rectTransform.localPosition = new Vector3(0, (float)Line[8].rectTransform.localPosition.y - 4, (float)0);
        //        Line[9].rectTransform.localPosition = new Vector3(0, (float)Line[9].rectTransform.localPosition.y - 4, (float)0);
        //        Line[10].rectTransform.localPosition = new Vector3(0, (float)Line[10].rectTransform.localPosition.y - 4, (float)0);
        //        Line[11].rectTransform.localPosition = new Vector3(0, (float)Line[11].rectTransform.localPosition.y - 4, (float)0);
        //        Line[12].rectTransform.localPosition = new Vector3(0, (float)Line[12].rectTransform.localPosition.y - 4, (float)0);
        //        Line[13].rectTransform.localPosition = new Vector3(0, (float)Line[13].rectTransform.localPosition.y - 4, (float)0);
        //        Line[14].rectTransform.localPosition = new Vector3(0, (float)Line[14].rectTransform.localPosition.y - 4, (float)0);
        //        Line[15].rectTransform.localPosition = new Vector3(0, (float)Line[15].rectTransform.localPosition.y - 4, (float)0);
        //        Line[16].rectTransform.localPosition = new Vector3(0, (float)Line[16].rectTransform.localPosition.y - 4, (float)0);
        //        Line[17].rectTransform.localPosition = new Vector3(0, (float)Line[17].rectTransform.localPosition.y - 4, (float)0);
        //        Line[18].rectTransform.localPosition = new Vector3(0, (float)Line[18].rectTransform.localPosition.y - 4, (float)0);
        //        Line[19].rectTransform.localPosition = new Vector3(0, (float)Line[19].rectTransform.localPosition.y - 4, (float)0);
        //        Line[20].rectTransform.localPosition = new Vector3(0, (float)Line[20].rectTransform.localPosition.y - 4, (float)0);
        //        Line[21].rectTransform.localPosition = new Vector3(0, (float)Line[21].rectTransform.localPosition.y - 4, (float)0);
        //        Line[22].rectTransform.localPosition = new Vector3(0, (float)Line[22].rectTransform.localPosition.y - 4, (float)0);
        //        Line[23].rectTransform.localPosition = new Vector3(0, (float)Line[23].rectTransform.localPosition.y - 4, (float)0);
        //        Line[24].rectTransform.localPosition = new Vector3(0, (float)Line[24].rectTransform.localPosition.y - 4, (float)0);
        //        Line[25].rectTransform.localPosition = new Vector3(0, (float)Line[25].rectTransform.localPosition.y - 4, (float)0);
        //        Line[26].rectTransform.localPosition = new Vector3(0, (float)Line[26].rectTransform.localPosition.y - 4, (float)0);
        //        Line[27].rectTransform.localPosition = new Vector3(0, (float)Line[27].rectTransform.localPosition.y - 4, (float)0);
        //        Line[28].rectTransform.localPosition = new Vector3(0, (float)Line[28].rectTransform.localPosition.y - 4, (float)0);
        //        Line[29].rectTransform.localPosition = new Vector3(0, (float)Line[29].rectTransform.localPosition.y - 4, (float)0);
        //        yield return null;
        //    }
        //    calcNewUI(armyType[30], 30);
        //}
        //else
        //{
        //    StartCoroutine(FadeIn(canvasContinue));
        //    StopCoroutine(PushLines());
        //}
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
            Line.rectTransform.localPosition = new Vector3(0, (float)Line.rectTransform.localPosition.y - 4, (float)0);
            yield return null;
        }
    }*/
}


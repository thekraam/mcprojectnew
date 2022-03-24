using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillList : MonoBehaviour
{
    public void MoveText(Text message, int armyType)
    {
        StartCoroutine(Movement(message, new Vector3((float)-100, (float)-100, (float)0)));
    }

    IEnumerator Movement(Text message, Vector3 position)
    {
        float i = position.x;
        float k = position.y;
        while (k <= 40) {
            message.rectTransform.localPosition = new Vector3(0, (float)k, (float)0);
            i++;
            k += 5;
            yield return null;
        }
    }
}


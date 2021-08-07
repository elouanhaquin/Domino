using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryButton : MonoBehaviour
{
    public void Retry()
    {
        var dominoMaster = GameObject.FindGameObjectWithTag("DominoMaster");
        for (int i = 0; i < dominoMaster.transform.childCount; i++)
            dominoMaster.transform.GetChild(i).transform.eulerAngles = Vector3.zero;
    }
}

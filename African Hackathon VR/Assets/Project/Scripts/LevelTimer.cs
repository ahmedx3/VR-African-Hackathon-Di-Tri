using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    public float wholeLevelTimer = 20;
    private float counting;

    bool hasChangedMat = false;

    CoronaLogic coronaLogic;

    public Image circularProgress;

    void Start()
    {
        coronaLogic = GetComponent<CoronaLogic>();
        counting = wholeLevelTimer;
    }

    void Update()
    {
        if (counting > 0)
        {
            counting -= Time.deltaTime;
            circularProgress.fillAmount = (wholeLevelTimer - counting) / wholeLevelTimer ;
        }
        else
        {
            if (!hasChangedMat)
            {
                coronaLogic.StartCoronaXRay();
                hasChangedMat = true;
            }
        }
    }
}

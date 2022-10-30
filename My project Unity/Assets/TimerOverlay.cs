using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerOverlay : MonoBehaviour
{

    public Text mTxtTime;
    public Text targetCount;
    public Text hitPercent;

    // Update is called once per frame
    void Update()
    {
        mTxtTime.text = PauseMenu.fTime.ToString();
        //targetCount.text = TargetShooter.targetCounter.ToString();
       // hitPercent.text = TargetShooter.targetHitPercent.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePassedText : CommonUIText
{
    public override void UpdateText()
    {
        string TimeString = LifeTimer.instance.GetTime();
        int Year = LifeTimer.instance.GetFakeYear();
        text.text = "Observation time passed : " + Year + " Years(" + TimeString + ")";
    }
}

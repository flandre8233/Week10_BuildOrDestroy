using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YearText : CommonUIText
{
    protected override void Start()
    {
        InvokeRepeating("UpdateText", 0, 60.0f);
    }

    public override void UpdateText()
    {
        text.text = "AD " + LifeTimer.instance.GetFakeYear().ToString();
    }


}

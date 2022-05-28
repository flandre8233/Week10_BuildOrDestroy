using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimesText : CommonUIText
{
    [SerializeField] GodInterference GodInterference;
    public override void UpdateText()
    {
        text.text = "Interventions times : " + GodInterference.Interventions;

    }
}

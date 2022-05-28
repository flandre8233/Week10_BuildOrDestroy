using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterventionText : CommonUIText
{
    [SerializeField] GodInterference GodInterference;
    public override void UpdateText()
    {
        text.text = "Interventions : " + GodInterference.Interventions;
    }
}

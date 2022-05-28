using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteInvasion : Invasion<WhiteInvasion>
{

    public void Start()
    {
        Probability = 5 + (5 * WhiteResearch.instance.GetCastleCount() * 0.5f);
    }

    protected override IBelongBase GetTargetBase()
    {
        return BlackBase.instance;
    }
}

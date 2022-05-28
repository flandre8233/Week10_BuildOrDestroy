using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BlackInvasion : Invasion<BlackInvasion>
{
    public void Start()
    {
        frequency = 15 / (BalanceWatcher.instance.GetBlackRate() * 2);
        frequency = Mathf.Clamp(frequency, 1, 20);
    }

    protected override IBelongBase GetTargetBase()
    {
        return WhiteBase.instance;
    }
}

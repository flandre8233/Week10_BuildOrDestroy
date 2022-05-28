using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceHealthBar : SingletonMonoBehavior<BalanceHealthBar>
{
    [SerializeField] Healthbar Bar;

    public void UpdateVal()
    {
        float Balance = BalanceWatcher.instance.GetBalanceRate();
        Bar.SetHealth(Balance * 100);
    }
}

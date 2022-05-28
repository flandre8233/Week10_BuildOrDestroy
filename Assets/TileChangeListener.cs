using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileChangeListener : SingletonMonoBehavior<TileChangeListener>
{
    [SerializeField] BalanceHealthBar BalanceHealthBar;
    [SerializeField] BalanceWatcher BalanceWatcher;
    public CommonUIText InterventionsView;

    private void Start()
    {
        OnChanged(new Vector3Int());
    }
    public void OnChanged(Vector3Int ChangedV3)
    {
        BalanceWatcher.UpdateBalanceRate();
        BalanceHealthBar.UpdateVal();
        InterventionsView.UpdateText();
        BlackInvasion.instance.Start();
        WhiteInvasion.instance.Start();
    }
}

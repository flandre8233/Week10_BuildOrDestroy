using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class BalanceWatcher : SingletonMonoBehavior<BalanceWatcher>
{
    [SerializeField] Tilemap Tilemap;

    [SerializeField] float WhiteRate;
    [SerializeField] float BlackRate;

    void Start()
    {
        UpdateBalanceRate();
    }

    public void UpdateBalanceRate()
    {
        int WhiteCount = WhiteBase.instance.GetBase().Length;
        int BlackCount = BlackBase.instance.GetBase().Length;
        int Count = WhiteCount + BlackCount;
        WhiteRate = (float)WhiteCount / (float)Count;
        BlackRate = (float)BlackCount / (float)Count;
    }

    public float GetBalanceRate()
    {
        float LowestVal = (WhiteRate < BlackRate) ? WhiteRate : BlackRate;
        return LowestVal * 2;
    }

    public float GetWhiteRate()
    {
        return WhiteRate;
    }

    public float GetBlackRate()
    {
        return BlackRate;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TimeRepeater<T> : SingletonMonoBehavior<T>
{
    [SerializeField] protected float frequency;
    [SerializeField] float CurTime;

    protected virtual void Update()
    {
        CurTime += Time.deltaTime;
        if (CurTime >= frequency)
        {
            CurTime = 0;
            OnTimeEnd();
        }
    }

    protected abstract void OnTimeEnd();
}

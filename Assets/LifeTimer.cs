using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class LifeTimer : SingletonMonoBehavior<LifeTimer>
{
    [SerializeField] float TotalTime;
    [SerializeField] float StartTime;

    private void Start()
    {
        StartTime = Time.time;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            UpdateTime();
            print(GetTime());
        }
    }

    public void UpdateTime()
    {
        TotalTime += Time.time - StartTime;
        StartTime = Time.time;
    }

    public void SetTotalTime(float _TotalTime)
    {
        TotalTime = _TotalTime;
    }

    public float GetTotalTime()
    {
        UpdateTime();
        return TotalTime;
    }

    public int GetFakeYear()
    {
        float TotalTime = LifeTimer.instance.GetTotalTime();
        return (int)TotalTime / 60;
    }

    public string GetTime()
    {
        TimeSpan time = TimeSpan.FromSeconds(TotalTime);
        return time.ToString("hh':'mm':'ss");
    }
}

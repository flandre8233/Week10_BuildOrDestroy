using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScale : MonoBehaviour
{
    [SerializeField]
    public float Scale;
    void Update()
    {
        Time.timeScale = Scale;
    }
}

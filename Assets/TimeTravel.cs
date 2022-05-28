using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTravel : MonoBehaviour
{
    public float WaitedTime;
    // Start is called before the first frame update
    void Start()
    {
        WaitedTime = Time.time + LeaveTimer.instance.GetTimePassed();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    private void Update()
    {
        Time.timeScale = Mathf.Clamp(Time.timeScale + Time.deltaTime, 0, 100);

        if (StatusControll.instance.IsStatusEqual(new GameoverStatus()))
        {
            Time.timeScale = 1;
            Destroy(this);
            return;
        }

        if (Time.time >= WaitedTime)
        {
            Time.timeScale = 1;
            Destroy(this);
            if (!StatusControll.instance.IsStatusEqual(new GameoverStatus()))
            {
                StatusControll.ToNewStatus(new GameStatus());
            }
        }
    }
}

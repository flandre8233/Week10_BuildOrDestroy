using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleCheater : MonoBehaviour
{

    [SerializeField]
    public float Scale;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Scale = 1;
            Time.timeScale = 1;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Scale += 5;
            Time.timeScale = Scale;
        }

    }
}

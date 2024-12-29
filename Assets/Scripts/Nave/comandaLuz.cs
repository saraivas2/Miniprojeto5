using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comandaLuz : MonoBehaviour
{
    private const int V = 0;
    private Light light1;
    public float timerLight = 2f;
    private float rangeTimer = 2f;

    // Start is called before the first frame update
    void Start()
    {
     light1 = GetComponentInChildren<Light>();   
    }

    // Update is called once per frame
    void Update()
    {

        TimerOff();
        TimerOn();    }

    private void TimerOff()
    {
        timerLight -= Time.deltaTime;
        if (timerLight <= 0)
        {
            light1.intensity = V;
            timerLight = rangeTimer;
        }
    }

    private void TimerOn()
    {
        timerLight -= Time.deltaTime;
        if (timerLight <= 0)
        {
            light1.intensity = 2;
            timerLight = rangeTimer;
        }
    }

}

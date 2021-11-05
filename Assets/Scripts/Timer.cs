using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer 
{
    private float currentTime;
    private float maxTime;

    public Timer(float maxTime)
    {
        currentTime = 0;
        this.maxTime = maxTime;
    }
    public bool RepeatCountTimer()
    {
        currentTime += Time.deltaTime;
        if (currentTime> maxTime)
        {
            currentTime = 0;
            return true;
        }
      
        return false;
    }
}

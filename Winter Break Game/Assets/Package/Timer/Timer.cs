using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    float _timer;

    float seconds; 
    public Timer(float _seconds)
    {
        seconds = _seconds;
    }

    public void ResetTimer(float _seconds)
    {
        seconds = _seconds;
        ResetTimer();
    }

    public void ResetTimer() => _timer = Time.realtimeSinceStartup + seconds; 
    public bool IsTimerUp() => _timer < Time.realtimeSinceStartup; 
}

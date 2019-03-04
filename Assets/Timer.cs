using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Stopwatch stopwatch;

    public void StartTimer()
    {
        stopwatch = new Stopwatch();
        stopwatch.Start();
    }

    public string GetTimerValue()
    {
        var ts = stopwatch.Elapsed;
        string elapsedTime = System.String.Format("{0:00}:{1:00}.{2:00}",
            ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
        return elapsedTime;
    }

    public void StopTimer()
    {
        stopwatch.Stop();
    }
}

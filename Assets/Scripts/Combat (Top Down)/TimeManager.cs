using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    // Deprecated?
    public float slowdownFactor = 0.05f;
    public float slowdownLength = 2f;

    public float freezeDuration = 4.00f;

    void Update()
    {
        Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }

    public void DoSlowmotion ()
    {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

    public void FreezeTime(float duration)
    {
        // Uncomment this and add it as a param of Wait() to add the last timespeed
        // float curTimespeed = Time.timeScale;

        // 0 will stop time
        Time.timeScale = 0.0f;
        StartCoroutine(Wait(duration));
    }

    IEnumerator Wait(float duration)
    {
        yield return new WaitForSecondsRealtime(duration);
        // if you want to set it back to current time speed use below. Otherwise, set back to 1
        // Time.timeScale = curTimespeed;
        Time.timeScale = 1.0f;
    }
}

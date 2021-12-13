using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    // Deprecated?
    public float slowdownFactor = 0.05f;
    public float slowdownLength = 2f;


    // So, weird bug here, but this second script being attached allows slowdown to happen super quickly
    void Update()
    {
        Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }

    // public void DoSlowmotion ()
    // {
    //     Time.timeScale = slowdownFactor;
    //     Time.fixedDeltaTime = Time.timeScale * 0.02f;
    // }
}

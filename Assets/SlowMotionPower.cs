using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotionPower : MonoBehaviour
{
    // public TimeManager timeM;
    // void Update()
    // {
    //     if (Input.GetButtonDown("Fire1"))
    //     {
    //     SlowMo();
    //     }
    // }
    // public void SlowMo()
    // {
    //     timeM.DoSlowmotion();
    // }

    ///---------
    // public float slowdownFactor = 0.05f;
    // public float slowdownLength = 2f;
    public float slowdownFactor = 0.05f;
    public float slowdownLength = 10f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            DoSlowmotion();
        }
        Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }

    public void DoSlowmotion ()
    {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowMotionPower : MonoBehaviour
{
    public float slowdownFactor = 0.05f;
    public float slowdownLength = 10f;

    public float freezeDuration = 4.09f;

    public float refillSlowdownsSpeed = 0.5f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("We can't use slowdowns because it is at: " + GameManager.instance.slowdownsLeft);
            if(GameManager.instance.slowdownsLeft > 1){
                Debug.Log("slowdownsLeft " + GameManager.instance.slowdownsLeft);
                DoSlowmotion();
                GameManager.instance.slowdownsLeft -= 1;
                // FreezeTime(freezeDuration);
            }
        }
        Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);

        if(GameManager.instance.slowdownsLeft < GameManager.instance.maxSlowdowns)
        {
            GameManager.instance.slowdownsLeft += refillSlowdownsSpeed * Time.deltaTime;
        }
    }

    public void DoSlowmotion()
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

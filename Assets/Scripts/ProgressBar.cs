using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider slider;

    public float fillSpeed = 0.2f;
    //NOTE: set target progress to 0 for not using fill meter, and to 100 if it does use fill meter
    public float targetProgress = 0f;

    public Vector3 sliderSize = new Vector3(0.02f, 0.03f, 1f);

    void Start()
    {
        // IncrementProgress(0.75f);
    }
    private void Awake()
    {
    }
    void Update()
    {
        //If silder is filled 
        if(slider.value >= 1f && GameManager.instance.filledMeter != true) 
        {
            Debug.Log("Filled");
            //now create a thing. Maybe you've avoided your problems enough to be okay with them, and you can push through
            // maybe you get a bucket of water
            GameManager.instance.filledMeter = true;
            // Debug.Log("gm.inst.filledMeter:" + GameManager.instance.filledMeter);

            // Remember to set value back to zero so it only fills once
            slider.value = 0f;
            targetProgress = 0f;
        } 

        //This fills the slider
        if(slider.value < targetProgress)
        {
            slider.value += fillSpeed * Time.deltaTime;

            gameObject.transform.localScale = sliderSize;
        } 
        else 
        {
            //make the object disappear
            gameObject.transform.localScale = new Vector3(0f, 0f, 0f);
        }
    }
    public void IncrementProgress(float newProgress)
    {
        targetProgress = slider.value + newProgress;
    }

    public void UseFill()
    {
        Debug.Log("@_@ Used Fill, setting fillMeter to false");
        GameManager.instance.filledMeter = false;
        //do more things
        // Set slider value back so this happens only once (maybe set targetProgress as well?)
        slider.value = 1f;
    }
}

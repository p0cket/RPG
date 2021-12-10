using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider slider;
    // public ParticleSystem particleSys;

    public float fillSpeed = 0.2f;
    
    //NOTE: set target progress to 0 for not using fill meter, and to 100 if it does use fill meter
    public float targetProgress = 0;
    public bool isActive = false;
    public bool usesFilledMeter = false;

    void Start()
    {
        // IncrementProgress(0.75f);
    }
    private void Awake()
    {
        // slider = gameObject.GetComponent<Slider>();
    }
    void Update()
    {
        if(slider.value >= 1f && GameManager.instance.filledMeter != true && usesFilledMeter == false) 
        {
            Debug.Log("Filled");
            //now create a thing. Maybe you've avoided your problems enough to be okay with them, and you can push through
            // maybe you get a bucket of water
            GameManager.instance.filledMeter = true;
            // Debug.Log("gm.inst.filledMeter:" + GameManager.instance.filledMeter);

            // Remember to set value back to zero so it only fills once
            slider.value =  0f;
        } else if (slider.value <= 0f && GameManager.instance.filledMeter == true && usesFilledMeter == true)
        {
            UseFill();
        }
        if(isActive)
        {
            if(slider.value < targetProgress && usesFilledMeter == false)
            {
                slider.value += fillSpeed * Time.deltaTime;
            } 
            else if (slider.value > targetProgress && usesFilledMeter == true)
            {
                slider.value -= fillSpeed * Time.deltaTime;
                //stall a moment and then turn off the visual indicator
            }
        }
    }
    public void IncrementProgress(float newProgress)
    {
        targetProgress = slider.value + newProgress;
    }

    public void UseFill()
    {
        // Debug.Log("UseFill Ran. 1:" + GameManager.instance.filledMeter +" and 2 usesFilledMeter:" +usesFilledMeter);
        // if(GameManager.instance.filledMeter == true && usesFilledMeter == true)
        // {
            // Debug.Log("UseFill(): Sets GameManager.instance.filledMeter false & does a thing");
            // if(slider.value <= 0f)
            // {
                Debug.Log("@_@ Used Fill, setting fillMeter to false");
                GameManager.instance.filledMeter = false;

                //do more things

                // Set slider value back so this happens only once (maybe set targetProgress as well?)
                slider.value = 1f;
            // } else {
                
            // }
            // Do a thing
            // Add a visual affect to the thing
        // } 
    }
}

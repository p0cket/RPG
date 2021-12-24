using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DepletionBar : MonoBehaviour
{
    public Slider slider;
    //IDEA: particle system while the slider changes
    // public ParticleSystem particleSys;

    public float fillSpeed = 0.2f;
    
    //NOTE: set target progress to 0 for not using fill meter, and to 100 if it does use fill meter
    public float targetProgress = 1f;

    public Vector3 sliderSize = new Vector3(0.02f, 0.03f, 1f);

    [Header("Object To Destroy")]
    public GameObject objectToDestroy;

    void Start()
    {
    }
    private void Awake()
    {
    }
    void Update()
    {
        if (slider.value <= 0f && GameManager.instance.filledMeter == true)
        {
            UseFill();
        }
        //This unfills the slider
        else if (slider.value > targetProgress)
        {
            slider.value -= fillSpeed * Time.deltaTime;
            //stall a moment and then turn off the visual indicator
            
            //make the object appear
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
        //Destroy the meter and the fire
        if(objectToDestroy)
        {
            Debug.Log("Destroying the object");
            Destroy(objectToDestroy);
        }
        else
        {
            Debug.Log("No object to destroy");
        }
        
        

        // if you want to reset the progress, use this below
        // slider.value = 1f;
        // targetProgress = 1f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressActivation : MonoBehaviour
{
    public ProgressBar progressBar;
    // Start is called before the first frame update
    public bool canFill;

    void Update()
    {
        if(canFill)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                FillMeter();
            }
        }
    }
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.name == "Player")
        {
            if(GameManager.instance.filledMeter != true)
            {
                canFill = true;
                // if(Input.GetKeyDown(KeyCode.E))
                // {
                //     FillMeter();
                // }
            }
        }
    }
    void OnTriggerExit2D (Collider2D other)
    {
        if (other.name == "Player")
        {
            if(GameManager.instance.filledMeter != true)
            {
                canFill = false;
            }
        }
    }
    public void FillMeter()
    {
        // Debug.Log("Entered += 0.2f");
        progressBar.IncrementProgress(0.2f);
        // if filled, Create a variable that is "Filled"
    }
}


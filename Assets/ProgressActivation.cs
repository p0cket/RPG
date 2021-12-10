using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressActivation : MonoBehaviour
{
    public ProgressBar progressBar;
    // Start is called before the first frame update
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.name == "Player")
        {
            if(progressBar.usesFilledMeter)
            {
                UnfillMeter();
            } else
            {
                FillMeter();
            }
        }
    }
    public void UnfillMeter()
    {
        progressBar.IncrementProgress(-0.2f);
        //if fully unused, set "filled" to false, and do a thing

        //commented out for now
        // progressBar.UseFill();
    }
    public void FillMeter()
    {
        // if not, fill the bucket
        // Debug.Log("Entered += 0.2f");
        progressBar.IncrementProgress(0.2f);
        // if filled, Create a variable that is "Filled"
    }
}

            // progressBar.SetActive(true);

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DepletionActivation : MonoBehaviour
{
    public DepletionBar depletionBar;
    // Start is called before the first frame update
    public bool requiresFill = true;
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.name == "Player")
        {  
            if(requiresFill)
            {
                if(GameManager.instance.filledMeter == true)
                {
                    UnfillMeter();
                }
            } else 
            {
                UnfillMeter();   
            }
        }
    }
    /// <summary>
    /// Unfills the bar gradually. Currently just one line.
    /// <br/>
    /// "depletionBar.IncrementProgress(-0.2f);"
    /// </summary>
    public void UnfillMeter()
    {
        depletionBar.IncrementProgress(-0.2f);
        //if fully unused, set "filled" to false, and do a thing

        //commented out for now
        // progressBar.UseFill();
    }
}
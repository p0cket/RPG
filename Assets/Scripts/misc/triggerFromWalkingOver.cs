using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerFromWalkingOver : MonoBehaviour
{
    public Animator myAnimator;
    public string animationName;
    void OnTriggerEnter2D (Collider2D other)
    {
        // Debug.Log("Entered: " + other.tag);
        if(other.tag == "Player")
        {
        Debug.Log( other.tag + "Walked Over Thing");
        myAnimator.Play(animationName);
        }
    }
}



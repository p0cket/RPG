using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAnimation : MonoBehaviour
{
    public string animationName;
    public Animator anim;
    void Start()
    {
    }
    public void PlayAnimation()
    {
        anim.Play(animationName);
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        Debug.Log("Enter: " + other.tag);
        if(other.tag == "Player")
        {
            PlayAnimation();
        }
        // Debug.Log(other.name);
    }
}

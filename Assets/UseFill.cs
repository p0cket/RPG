using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseFill : MonoBehaviour
{
    public GameObject deathEffect;

    void Update () 
    {
        if(GameManager.instance.filledMeter){
            Debug.Log("filledMeter is True");
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Die();  
            //set filledMeter to false
            GameManager.instance.filledMeter = false;
        }
    }

    //     void OnTriggerEnter2D (Collider2D other)
    // {
    //     // Debug.Log("Entered: " + other.tag);
    //     if(other.tag == "Player")
    //     {
    //         Debug.Log( other.tag + "Walked into Thing");
    //         Instantiate(deathEffect, transform.position, Quaternion.identity);
    //         Die();  
    //     }
    // }
    public void Die ()
    {
        Destroy(gameObject);
    }
}

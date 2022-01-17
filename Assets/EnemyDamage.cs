using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    //Instead i've been using all of the functionality in Enemy.cs
    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.name != "Player")
        {
            Debug.Log(other.name + " is the name and " + other.tag + " is the tag");
        }
        // Debug.Log("Ex Entered: " + other.tag);
        // if(other.tag == "IceBlock")
        // {
        //     Debug.Log(other.name + "Did Damage to iceBlock");
        // } else if(other.tag == "Cloudsly")
        // {
        //     Debug.Log(other.name + "Did Damage to enemy");
        //     // DamageEnemy();
        // } else {
        //     Debug.Log(other.name + "is the name and " + other.tag + " is the tag");
        // }
    }
    
}

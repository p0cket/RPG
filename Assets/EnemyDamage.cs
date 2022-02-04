using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public int damageToDeal = -10;
    //Instead i've been using all of the functionality in Enemy.cs
    void OnTriggerEnter2D (Collider2D other)
    {
        if(other.name != "Player")
        {
            Debug.Log(other.name + " is the name and " + other.tag + " is the tag");
        } else if (other.name == "Player")
        {
            Debug.Log("Damage Player");
            GameManager.instance.playerStats[0].AddHealth(damageToDeal);
            CameraController.instance.StartShake(.2f, .1f);
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

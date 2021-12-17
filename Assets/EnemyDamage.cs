using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D other)
    {
        // Debug.Log("Ex Entered: " + other.tag);
        if(other.tag == "IceBlock")
        {
            Debug.Log(other.name + "Did Damage");
        }
        // Debug.Log(other.name);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject objectToEmit;
    public Transform placeToEmit;

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.name == "Player")
        {
            EmitObject();
        }
    }
    public void EmitObject()
    {
        Instantiate (objectToEmit, placeToEmit.transform.position, Quaternion.identity);
    }
}


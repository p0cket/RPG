using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObjects : MonoBehaviour
{
    // For our timeline, when enabled, activate our scene elements

    // make an array of objects
    public GameObject[] gameObjects;

    void OnEnable()
    {
        for(int i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i].SetActive(true);
        }
    }
}

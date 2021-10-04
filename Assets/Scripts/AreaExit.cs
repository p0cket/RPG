using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// this
// using Cinemachine;


public class AreaExit : MonoBehaviour
{
    public string areaToLoad;
    public string areaTransitionName;

    public AreaEntrance theEntrance;

    // Start is called before the first frame update
    void Start()
    {
        theEntrance.transitionName = areaTransitionName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(areaToLoad);
            PlayerController.instance.areaTransitionName = areaTransitionName;
            // PlayerController.instance.gameObject.SetActive(false);
        }
    }
}


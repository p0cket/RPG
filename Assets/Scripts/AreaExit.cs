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

    public float waitToLoad = 1f;
    private bool shouldLoadAfterFade;

    // Start is called before the first frame update
    void Start()
    {
        theEntrance.transitionName = areaTransitionName;
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldLoadAfterFade){
            waitToLoad -= Time.deltaTime;
            if(waitToLoad <= 0) {
                shouldLoadAfterFade = true;
                SceneManager.LoadScene(areaToLoad);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            shouldLoadAfterFade = true;
            GameManager.instance.fadeBetweenAreas = true;
            UIFade.instance.FadeToBlack();
            PlayerController.instance.areaTransitionName = areaTransitionName;
            Debug.Log("Loading: "+areaToLoad+ " at areaTransition: "+areaTransitionName);
        }
    }
}


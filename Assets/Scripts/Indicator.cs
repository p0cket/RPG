using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Indicator : MonoBehaviour
{
    public GameObject objectToAppear;

    // public SpriteRenderer rendererOfObjectToAppear;
    public float fadeSpeed = 3f;
    void Start()
    {
        
    }

    void Update()
    {
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        // Debug.Log("Enter: " + other.tag);
        if(other.tag == "Player")
        {
            objectToAppear.SetActive(true);
        }
        // Debug.Log(other.name);
    }

    void OnTriggerExit2D (Collider2D other)
    {
        // Debug.Log("Exit: " + other.tag);
        if(other.tag == "Player")
        {
            objectToAppear.SetActive(false);
            
            // rendererOfObjectToAppear.color = new Color(rendererOfObjectToAppear.color.r, rendererOfObjectToAppear.color.g, rendererOfObjectToAppear.color.b, Mathf.MoveTowards(rendererOfObjectToAppear.color.a, 1f, fadeSpeed * Time.deltaTime));

            // if(rendererOfObjectToAppear.color.a == 1f){
            //     objectToAppear.SetActive(false);
            //     // shouldFadeToBlack = false;
            // }
        }
        // Debug.Log(other.name);
    }
}
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class UIFade : MonoBehaviour
// {

//     public static UIFade instance;
//     public Image fadeScreen;
//     public float fadeSpeed;
//     public bool shouldFadeToBlack;
//     public bool shouldFadeFromBlack;
//     // Start is called before the first frame update
//     void Start()
//     {
//         instance = this;
//         DontDestroyOnLoad(gameObject);
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if(shouldFadeToBlack){
//             fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));

//             if(fadeScreen.color.a == 1f){
//                 shouldFadeToBlack = false;
//             }
//         }

//         if(shouldFadeFromBlack){
//             fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));

//             if(fadeScreen.color.a == 0f){
//                 shouldFadeFromBlack = false;
//             }
//         }
//     }

//     public void FadeToBlack(){
//         shouldFadeToBlack = true;
//         shouldFadeFromBlack = false;
//     }

//     public void FadeFromBlack(){
//         shouldFadeToBlack = false;
//         shouldFadeFromBlack = true;
//     }
// }

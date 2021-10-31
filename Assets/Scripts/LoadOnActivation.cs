using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class LoadOnActivation : MonoBehaviour
{

    public string sceneName;
    void OnEnable()
    {
        // Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
        // SceneManager.LoadScene("OtherSceneName", LoadSceneMode.Additive);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);

    }
}
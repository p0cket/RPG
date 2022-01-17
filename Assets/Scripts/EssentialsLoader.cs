using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialsLoader : MonoBehaviour
{
    public GameObject UIScreen;
    public GameObject player;
    public GameObject gameMan;
    public GameObject soundMan;
    public GameObject sanityMeter;
    // public GameObject focusMeter;
    void Awake()
    {
        if(UIFade.instance == null){
            Instantiate(UIScreen);
        }
        if(PlayerController.instance == null){
            Instantiate(player);
        }
        if(GameManager.instance == null){
            Instantiate(gameMan);
        }
        if(AudioManager.instance == null){
            Instantiate(soundMan);
        }
        // if(SanitySlider.instance == null){
        //     Instantiate(sanityMeter);
        // }
    }
}

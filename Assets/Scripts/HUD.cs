using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public static HUD instance;
    public Text currentHealth;


    // Slider Code
    public Slider slider;
    void Start()
    {
       //create instance by defining a static instance up top, and assigning to this
       instance = this;
       DontDestroyOnLoad(gameObject);


        currentHealth.text = "" + GameManager.instance.playerStats[0].currentHP;
        //Slider
        slider.maxValue = GameManager.instance.playerStats[0].maxHP;
        slider.value = GameManager.instance.playerStats[0].currentHP;
    }



    public void UpdateHUD()
    {
        currentHealth.text = "" + GameManager.instance.playerStats[0].currentHP;
        Debug.Log("Updated HUD");
        slider.value = GameManager.instance.playerStats[0].currentHP;
    }
}

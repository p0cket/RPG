using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public static HUD instance;
    public Text currentHealth;


    // Slider Code
    public Slider healthSlider;
    public Text currentSlowdowns;
    public Slider slowdownSlider;
    void Start()
    {
       //create instance by defining a static instance up top, and assigning to this
       instance = this;
       DontDestroyOnLoad(gameObject);

        //Manage Health Here
        currentHealth.text = "" + GameManager.instance.playerStats[0].currentHP;
        //healthSlider
        healthSlider.maxValue = GameManager.instance.playerStats[0].maxHP;
        healthSlider.value = GameManager.instance.playerStats[0].currentHP;

        //Manage Slowdowns here
        currentSlowdowns.text = "" + Mathf.Floor(GameManager.instance.slowdownsLeft);
        //healthSlider
        slowdownSlider.maxValue = GameManager.instance.maxSlowdowns;
        slowdownSlider.value = GameManager.instance.slowdownsLeft;
    }

    void Update()
    {
        UpdateHUD();
    }

    public void UpdateHUD()
    {
        //Health
        currentHealth.text = "" + GameManager.instance.playerStats[0].currentHP;
        healthSlider.value = GameManager.instance.playerStats[0].currentHP;

        //Slowdowns
        currentSlowdowns.text = "" + Mathf.Floor(GameManager.instance.slowdownsLeft);
        slowdownSlider.value = GameManager.instance.slowdownsLeft;

        // Debug.Log("Updated HUD");
    }
}

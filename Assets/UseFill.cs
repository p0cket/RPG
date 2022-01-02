using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseFill : MonoBehaviour
{
    public GameObject deathEffect;

    //for triggering fungusblocks
    public Fungus.Flowchart flowChart;
    //[SerializeField]


    //[SerializeField]
    public string blockName;

    //@TODO Below is for setting player movement to stop. 
    [Header("Add ourDialog when you're ready to add pause game on Dialog")]
    public GameObject ourDialog;

    void Update () 
    {
        if(GameManager.instance.filledMeter){
            Debug.Log("filledMeter is True");
            Instantiate(deathEffect, transform.position, Quaternion.identity);
 
            //set filledMeter to false
            GameManager.instance.filledMeter = false;
            TriggerBlock();

            Die();  
        }
        //@TODO Fix buggyness
        //if there is a `sayDialog` active, set the playerController's canMove to false. 
        // if(ourDialog.activeInHierarchy){
        //     //old code said stop moving the player, new code says tell Game Manager the dialog is active.
        //     // PlayerController.instance.canMove = false;
        //     GameManager.instance.dialogActive = true;
        // } else {
        //     // PlayerController.instance.canMove = true;
        //     GameManager.instance.dialogActive = false;
        // }
    
    }

    public void TriggerBlock()
    {
        if(blockName != null) 
        {
                Debug.Log("Flowchart Block Triggered. It will execute the selected block now");
                flowChart.ExecuteBlock(blockName);
        }
        else 
        {
                Debug.Log("Please enter the block name");
        }
    }
    public void Die ()
    {
        Destroy(gameObject);
    }

    
}

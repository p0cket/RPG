using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class triggerFungusBlock : MonoBehaviour
{
    [Header("Important: Player needs the 'Player' tag to trigger this block")]
    //[SerializeField]
    public Fungus.Flowchart flowChart;
    //[SerializeField]

    //Below is for setting player movement to stop.
    public GameObject ourDialog;
    // public Fungus.SayDialog ourDialog;

    //[SerializeField]
    public string blockName;
    

    // Start is called before the first frame update
    void Start()
    {
        //flowChart.ExecuteBlock("test");
    }

    // Update is called once per frame
    void Update()
    {
        // if there is a `sayDialog` active, set the playerController's canMove to false.
        if(ourDialog.activeInHierarchy){
            PlayerController.instance.canMove = false;
        } else {
            PlayerController.instance.canMove = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player"){
            if(blockName != null) {
                Debug.Log("Flowchart Block Triggered. It will execute the selected block now");
                flowChart.ExecuteBlock(blockName);
            }
            else {
                Debug.Log("Please enter the block name");
            }
        }
    }

}

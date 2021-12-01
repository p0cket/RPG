using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fungusBlockActivator : MonoBehaviour
{
    public Fungus.Flowchart flowChart;
    public string blockName;
    private bool canActivate;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canActivate && Input.GetButtonDown("Fire1")){
            Debug.Log("execute the dialog blockName");
            flowChart.ExecuteBlock(blockName);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player"){
            canActivate = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Player"){
            canActivate = false;
        }
    }
}

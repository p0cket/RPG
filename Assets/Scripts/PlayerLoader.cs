using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerLoader : MonoBehaviour
{
    public GameObject player;

    [Tooltip("Cinemachine")]
    public CinemachineVirtualCamera vcam;

    // Start is called before the first frame update
    void Start()
    {
        if(PlayerController.instance == null)
        {
            Instantiate(player);

            // 
            vcam.Follow = player.transform;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!vcam.Follow) {
            vcam.Follow = player.transform;
            vcam.enabled = false;
            vcam.enabled = true;
        }
    }
}

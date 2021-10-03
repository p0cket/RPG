using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntrance : MonoBehaviour
{

    public string transitionName;

   void Start() {
        if(transitionName == PlayerController.instance.areaTransitionName)
        {
            Vector3 playerPos = transform.position;
            playerPos.z = 0;
            PlayerController.instance.transform.position = playerPos;
            StartCoroutine(FollowCamIssueWorkaround());
        }
    }

    private IEnumerator FollowCamIssueWorkaround()
    {
        yield return new WaitForSeconds(0.01f);
        Debug.Log("object enabled");
        PlayerController.instance.gameObject.SetActive(true);
        // cinemachineConfiner.m_BoundingShape2D
    }
}


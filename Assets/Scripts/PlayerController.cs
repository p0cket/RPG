using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// this
using Cinemachine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D theRB;
    public float moveSpeed;
    
    public Animator myAnim;

    public static PlayerController instance;

    public string areaTransitionName;

    // this
    [Header("Cinemachine Cam")]
    public CinemachineVirtualCamera vcam;
    
    // public Collider2D boundary;

    // Start is called before the first frame update
    void Start() {
        if(instance == null)
        {
            instance = this;
        } else {
            Destroy(gameObject);
        }

        // this
        vcam.Follow = gameObject.transform;

        // try to set the confiner boundingShape2D attripute on load
        // vcam.cinemachineConfiner.m_BoundingShape2D = boundary;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;

        myAnim.SetFloat("moveX", theRB.velocity.x);
        myAnim.SetFloat("moveY", theRB.velocity.y);
    }
}

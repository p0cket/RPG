using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D theRB;
    public float moveSpeed;
    
    public Animator myAnim;

    public static PlayerController instance;

    public string areaTransitionName;
    
    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;

    void Start() {
        if(instance == null)
        {
            instance = this;
        } else {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;

        myAnim.SetFloat("moveX", theRB.velocity.x);
        myAnim.SetFloat("moveY", theRB.velocity.y);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);

    }

    public void SetBounds (Vector3 botLeft, Vector3 topRight) {
        bottomLeftLimit = botLeft + new Vector3(0.5f, 0.5f, 0f);
        topRightLimit = topRight + new Vector3(-0.5f, -0.5f, 0f);
    }
    
}

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

    public bool canMove = true;

    //grabbing bullets
    public Bullet[] allBullets;

    void Awake() {
        if(instance == null)
        {
            instance = this;
        } else {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if(canMove){
            theRB.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * moveSpeed;
            // if you want to be able to not move in place when a player is frozen and can't move while talking, move the animation
            // logic over here
            // myAnim.SetFloat("moveX", theRB.velocity.x);
            // myAnim.SetFloat("moveY", theRB.velocity.y);

            // ~SlowTime functionality below
            if(Input.GetKeyDown(KeyCode.M))
            {
                SlowOthers();
            }
        } else {
            theRB.velocity = Vector2.zero;
        }

        myAnim.SetFloat("moveX", theRB.velocity.x);
        myAnim.SetFloat("moveY", theRB.velocity.y);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
    }

    public void SetBounds (Vector3 botLeft, Vector3 topRight) {
        bottomLeftLimit = botLeft + new Vector3(0.5f, 0.5f, 0f);
        topRightLimit = topRight + new Vector3(-0.5f, -0.5f, 0f);
    }

    public void SlowOthers ()
    {
        Debug.Log("Slowing Others");
        allBullets = FindObjectsOfType<Bullet>();
        Debug.Log(allBullets);
        // Either
        // allBullets.speed = allBullets.speed * 0.8f;
        //or
        for(int i = 0; i < allBullets.Length; i++)
        {
            Debug.Log("Slowing Speed" + i);
            // allBullets[i].moveDirection = (target.transform.position - transform.position).normalized * speed;
            // allBullets[i].moveDirection = (allBullets[i].target.transform.position - allBullets[i].transform.position).normalized * allBullets[i].speed;
            allBullets[i].moveDirection = (allBullets[i].target.transform.position - allBullets[i].transform.position).normalized * allBullets[i].speed;



            // allBullets[i].speed = allBullets[i].speed * 0.1f;

        }
    }
    
}

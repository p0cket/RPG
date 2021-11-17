using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //@TODO make a controllable speed slowdown by button press

    public float speed = 80f;
    public Rigidbody2D rb;
    public int soundEffect;
    public int bulletDamage;

    public float timeUntilDestroyed = 2f;

    //if has target
    public GameObject target;
    // public Player target;
    public Vector2 moveDirection;


    // void Awake(){
    //   Destroy(gameObject, timeUntilDestroyed);
    // }
    void Start()
    {
        //just uncomment this if it doesn't work
        // rb.velocity = transform.right * speed;

        

        //disabled the one line below temporarily while firing was happing in RPG battle
        // AudioManager.instance.PlaySFX(soundEffect);
        
        // target = GameObject.FindObjectOfType<Player>();
        target = GameObject.Find("Player");

        // Debug.Log("Target Position" + target.transform.position);
        // Debug.Log("Bullet Position" + transform.position);

        moveDirection = (target.transform.position - transform.position).normalized * speed;
        rb.velocity = new Vector2 (moveDirection.x, moveDirection.y);

        // wait and then destroy 
        // yield WaitForSeconds(timeUntilDestroyed);
        // Destroy(gameObject, 3f);

    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        // Debug.Log(hitInfo.name);
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
        
        if (hitInfo.name == "Player")
        {
            // Debug.Log("HIT!");
            // now deal damage to the character
            // BattleManager.instance.DealDamage(selectedTarget, bulletDamage);
            // BattleManager.instance.activeBattlers[target].currentHP -= bulletDamage;
            Debug.Log(GameManager.instance.playerStats[0].charName + "hit with" + bulletDamage + "Damage to his currentHP:" + GameManager.instance.playerStats[0].currentHP);
            GameManager.instance.playerStats[0].AddHealth(-22);
            Debug.Log( "Now health is:" + GameManager.instance.playerStats[0].currentHP);
            HUD.instance.UpdateHUD();




            Destroy(gameObject);

        }

        StartCoroutine(SelfDestruct());

        // Destroy(gameObject);
        //Not the most elegant, but a destroy nonetheless below
    }
     IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(timeUntilDestroyed);
        Destroy(gameObject);
    }
}

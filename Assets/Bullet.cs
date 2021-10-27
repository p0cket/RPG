using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 5f;
    public Rigidbody2D rb;
    public int soundEffect;
    public int bulletDamage;

    public float timeUntilDestroyed = 2f;

    // void Awake(){
    //   Destroy(gameObject, timeUntilDestroyed);
    // }
    void Start()
    {
        rb.velocity = transform.right * speed;
        //disabled the one line below temporarily while firing was happing in RPG battle
        // AudioManager.instance.PlaySFX(soundEffect);
        
        // wait and then destroy 
        // yield WaitForSeconds(timeUntilDestroyed);
        // Destroy(gameObject);

    }

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(bulletDamage);
        }
        // Debug.Log(hitInfo.name);
        Destroy(gameObject);
    }
}

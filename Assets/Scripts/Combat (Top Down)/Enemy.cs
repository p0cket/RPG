using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 100;
    public GameObject deathEffect;
    public GameObject damageEffect;

    public void TakeDamage (int damage)
    {
        health -= damage;
        Instantiate(damageEffect, transform.position, Quaternion.identity);

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die ()
    {
        Destroy(gameObject);
        Instantiate(deathEffect, transform.position, Quaternion.identity);

    }
}

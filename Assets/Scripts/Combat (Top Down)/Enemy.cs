using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int health = 100;
    public int damageToDeal = -5;
    public GameObject deathEffect;
    public GameObject enemyDamagedEffect;
    //Add Impact Effect
    public GameObject playerDamagedEffect;
    public bool damagesWhenTouched;



    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        if (hitInfo.name == "Player")
        {

            Debug.Log(GameManager.instance.playerStats[0].charName + "hit with" + damageToDeal + "Damage to his currentHP:" + GameManager.instance.playerStats[0].currentHP);
            DealDamage();
            // GameManager.instance.playerStats[0].AddHealth(-22);
            // GameObject explosionEffect = Instantiate(playerDamagedEffect, transform.position, transform.rotation);
            // Destroy(explosionEffect, 3f);
            // CameraController.instance.StartShake(.2f, .1f);
            // // Debug.Log( "Now health is:" + GameManager.instance.playerStats[0].currentHP);
            // HUD.instance.UpdateHUD();
        } 
        Debug.Log("name is: "+ hitInfo.tag);
        // else if (hitInfo.tag == "PlayerAttack")
        // {
        //     TakeDamage(5);
        // }
    }

    public void TakeDamage (int damage)
    {
        Debug.Log("Enemy is taking "+ damage +" damage from its' health of " + health);
        health -= damage;
        Instantiate(enemyDamagedEffect, transform.position, Quaternion.identity);

        if (health <= 0)
        {
            Die();
        }
    }

    public void DealDamage()
    {
            GameManager.instance.playerStats[0].AddHealth(damageToDeal);
            // GameObject explosionEffect = Instantiate(playerDamagedEffect, transform.position, transform.rotation);
            CameraController.instance.StartShake(.2f, .1f);
    }

    public void Die()
    {
        Destroy(gameObject);
        Instantiate(deathEffect, transform.position, Quaternion.identity);

    }
}

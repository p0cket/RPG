using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeDrain : MonoBehaviour
{
    public float amtToDrain = 3f;
    public float curDrain = 0f;
    public float curCooldown = 0f;
    public float refreshedCooldownNum = 3f;
    public GameObject particleDrain;
    public GameObject blastWave;
    public float timeToDestroyBlastWave;

    public bool canBlast = true;

    //Attack Vars
    public Animator focusBlastAnimator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 100;
    void Update()
    {
        FocusEnergy();
    }
    public void FocusEnergy()
    {
        // Note: If you want a cooldown, uncomment cooldown code
        // [Cooldown Part 1]
        // if(Input.GetKey(KeyCode.Q) && curCooldown <= 0)
        if(Input.GetKey(KeyCode.Q))
        {
            if(curDrain >= amtToDrain && canBlast){
                // make wave and deal damage
                LifeDrainAttack();
                // [][] Deprecated Approach, working on Collission Array Approach [][]
                // Instantiate(blastWave, particleDrain.transform.position, Quaternion.identity);
                // Destroy(blastWave, timeToDestroyBlastWave);

                canBlast = false;

                Debug.Log("Drained Fully, Do next thing");
                particleDrain.SetActive(false);

                // reset drain amount
                curDrain = 0f;
                // [Cooldown Part 2]
                // curCooldown = refreshedCooldownNum;
            } else {
                canBlast = true;
                curDrain += 1.0f * Time.deltaTime;
                Debug.Log("SetParticles & Drainging: "+curDrain+" out of "+amtToDrain);
                particleDrain.SetActive(true);
                // particlesActive = true;
            }
        } else {
            // if(particlesActive)
            // {
                // Debug.Log("SetParticles Off");
                particleDrain.SetActive(false);
                curDrain = 0f;
            // }
        }
        // [Cooldown Part 3]
        // if(curCooldown >= 0)
        // {
        //     curCooldown -= 1.0f * Time.deltaTime;
        // }
    }
    public void LifeDrainAttack()
    {
        // if(Input.GetKey(KeyCode.E))
        // {
            // Debug.Log("Play Anim");
            focusBlastAnimator.SetTrigger("FocusAttack");
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            foreach (Collider2D enemy in hitEnemies)
            {
                Debug.Log("We hit: "+ enemy.name);
                // TakeDamage(5);
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);

            }
        // }
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            Debug.Log("attackPoint is null. Check inspector and LifeDrain.cs");
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}

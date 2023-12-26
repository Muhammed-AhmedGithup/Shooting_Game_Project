using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacking : MonoBehaviour
{
    private Animator animator;
    private playerHealth playerHealth;
    private bool Attacking;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerHealth=FindAnyObjectByType<playerHealth>();
        
    }
    public void Attack()
    {
        if (Attacking) return;
        Attacking = true;
        StartCoroutine(Attack_d());
       
    }

    public void StopAttack()
    {
        Attacking = false;
    }

    private IEnumerator Attack_d()
    {
        animator.SetBool("attack", true);
        while (Attacking)
        {
            if (playerHealth)
            {
                playerHealth.DecreaseHealth(5);
               
            }
            yield return new WaitForSeconds(2);
        }
    }
}

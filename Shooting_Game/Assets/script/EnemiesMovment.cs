using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemiesMovment : MonoBehaviour
{
   
    public float maxspeed = 5f;
    public float currentspeed;
    public float stopDistance = 10f;

    private PlayerMovment player;
    private Animator animator;
    private NavMeshAgent Agent;
    private bool startmove = false;
    private EnemyAttacking enemyAttacking;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        Agent = GetComponent<NavMeshAgent>();
        player = FindAnyObjectByType<PlayerMovment>();
        enemyAttacking = GetComponent<EnemyAttacking>();
        
    }

    private IEnumerator Start()
    {
        yield return (new WaitForSeconds(3));
        startmove = true;
    }

    private void Update()
    {
        if(!startmove) { return; }
        if (player)
        {
            Move();
        }
        
    }

    private void Move()
    {
        if (Vector3.Distance(transform.position, player.transform.position) >= stopDistance)
        {
            enemyAttacking.StopAttack();
            Agent.SetDestination(player.transform.position);
            animator.SetFloat("move", currentspeed/maxspeed);
            currentspeed += Time.deltaTime;
            currentspeed=Mathf.Clamp(currentspeed, 0, 5);
            animator.SetBool("attack", false);

        }
        else
        {
            Agent.SetDestination(transform.position);
            
            animator.SetFloat("move", 0);
            currentspeed = 0;
            enemyAttacking.Attack();
        }
    }

    

}

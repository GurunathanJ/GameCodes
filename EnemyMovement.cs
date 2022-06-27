using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyMovement : MonoBehaviour
{
private AggroDetection aggroDetection;
private Animator animator;
private NavMeshAgent navMeshAgent; 
private Transform target;
public GameObject player;
public GameObject enemy;
private int damage=1;
private int lastAttackTime = 0;
private int attackCoolDown = 1;

private void Awake()
{
    animator=GetComponentInChildren<Animator>();
    navMeshAgent=GetComponent<NavMeshAgent>();
    aggroDetection=GetComponent<AggroDetection>();
    aggroDetection.OnAggro+=AggroDetection_OnAggro;
}

private void Start()
{
    player=GameObject.FindGameObjectWithTag("Player");
    enemy=GameObject.FindGameObjectWithTag("Enemy");
}

private void AggroDetection_OnAggro(Transform target)
{
    this.target = target;
}

private void Update()
{
    // bool bDistance = navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance;
     bool CollisionChk=aggroDetection.detectionChk;
    //Debug.Log(bDistance);
    //Debug.Log(CollisionChk);
    if(target != null && enemy.gameObject.activeSelf==true)
    {
        navMeshAgent.SetDestination(target.position);
        float CurrSpeed=navMeshAgent.velocity.magnitude;
        animator.SetFloat("Speed",CurrSpeed);
    }
    
    if(CollisionChk)
    {
        if(navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
        animator.SetBool("Attack",true);
        if(Time.time-lastAttackTime>=attackCoolDown)
        {
        lastAttackTime=(int) Time.time;
        player.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
        if(player.gameObject.activeSelf!=true)
        {
        animator.SetBool("Attack",false);
        }
        }
    }
    else
    {
    animator.SetBool("Attack",false);
    }

}
}

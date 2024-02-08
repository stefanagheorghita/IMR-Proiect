
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DinoScript : MonoBehaviour
{
    private enum Dinostate
    {
        Idle,
        Running,
        Attacking,
        Dead
    }

    private NavMeshAgent navigation;
    private Animator anim;
    private Transform player;

    public GameObject dino;

    public bool alreadyDead = false;

    public float attackDistance = 2f;

    private Dinostate currentState = Dinostate.Idle;

    void Start()
    {
        anim = dino.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        navigation = GetComponent<NavMeshAgent>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
             anim.SetBool("dead", true);
        }
    }

    void Update()
    {
        if (alreadyDead == true)
        {
            // anim.enabled = false;
            Destroy(dino,5f);
            return;
        }
        navigation.SetDestination(player.position);
        if (anim.GetBool("dead") == true)
        {
            DeadState();
        }
        else{
        switch (currentState)
        {
            case Dinostate.Idle:
                IdleState();
                break;
            case Dinostate.Running:
                RunningState();
                break;
            case Dinostate.Attacking:
                AttackingState();
                break;
           
        }
        }
    }

    void IdleState()
    {   

        navigation.isStopped = true;
        anim.SetBool("idle", true);
        if (Vector3.Distance(transform.position, player.position) < 10)
        {
            anim.SetBool("idle", false);
            currentState = Dinostate.Running;
        }
    }

    void RunningState()
    {

        navigation.isStopped = false;
        anim.SetBool("run", true);
        if (Vector3.Distance(transform.position, player.position) < attackDistance)
        {
            anim.SetBool("run", false);
            currentState = Dinostate.Attacking;
        }
    }

    void AttackingState()
    {

        navigation.isStopped = true;
        anim.SetBool("attack", true);
        if (Vector3.Distance(transform.position, player.position) > attackDistance)
        {
            anim.SetBool("attack", false);
            currentState = Dinostate.Running;
        }
    }

    void DeadState()
    {
        navigation.isStopped = true;
        anim.SetBool("dead", true);
        alreadyDead = true;
    }
}


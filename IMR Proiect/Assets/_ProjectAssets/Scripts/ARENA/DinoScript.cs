using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class DinoScript : MonoBehaviour
{
    private enum Dinostate{
        Idle,
        Running,
        Attacking,
        Dead
    }

    private NavMeshAgent navigation;
    private Animator anim;
    private Transform player;

    public float attackDistance = 2f;


    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        navigation = GetComponent<NavMeshAgent>();
    
    }

    // Update is called once per frame
    void Update()
    {
        navigation.isStopped = false;
        navigation.SetDestination(player.position);
    }
}

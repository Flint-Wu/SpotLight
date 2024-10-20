using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public float playerDis;

    public bool Attacking;

    public Transform playerPos;
    protected GameObject player;
    public Transform target; 
    public NavMeshAgent nav;

    
    protected float Tik;

     void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

     void Update()
    {
        if (player != null)
        {
            MoveTowardsPlayer();
        }

    }

    protected void MoveTowardsPlayer()
    {
        if (Attacking)
        {
            return;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        playerDis = distanceToPlayer;

    }


}

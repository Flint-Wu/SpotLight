using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    
    public float moveSpeed = 3.0f; 
    public float detectionRange = 10.0f; 

    private Transform playerPos;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Update()
    {
       if (player!=null)
        {
            MoveTowardsPlayer();
        }
    }

    private void MoveTowardsPlayer()
    {
        playerPos = player.transform;
        float distanceToPlayer = Vector3.Distance(transform.position, playerPos.position);

        if (distanceToPlayer <= detectionRange)
        {
            Vector3 direction = (playerPos.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }
}

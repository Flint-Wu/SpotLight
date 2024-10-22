using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public float playerDis;
    public float tempSpeed;

    public bool Attacking;

    public Transform playerPos;
    protected GameObject player;
    public Transform target; 
    public NavMeshAgent nav;
    protected EnemyState EnemyState;

    [SerializeField]
    protected Vector3 tempScale;

    protected float Tik;

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

    protected void TurnAround()
    {
        

        if (target.position.z > transform.position.z)
        {
            transform.localScale = new Vector3(tempScale.x, tempScale.y, -tempScale.z);
        }
        else if (target.position.z < transform.position.z)
        {
            transform.localScale = new Vector3(tempScale.x, tempScale.y, tempScale.z);
        }
    }

    protected void GotHurt()
    {

        if (EnemyState.WasAttack && EnemyState.WasDect)
        {
            nav.speed = 0;
        }
        else
        {
            nav.speed = tempSpeed;
        }
    }
}

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
        if (player != null)
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

    // 绘制检测范围的Gizmos
    private void OnDrawGizmos()
    {
        // 设置Gizmos颜色为红色
        Gizmos.color = Color.red;

        // 在敌人的位置绘制一个检测范围的球体
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        // 如果player存在，绘制一条指向玩家的射线
        if (player != null)
        {
            Gizmos.DrawLine(transform.position, player.transform.position);
        }
    }
}

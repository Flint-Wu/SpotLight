using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public float detectionRange = 10.0f;
    public float StopDis;
    public float playerDis;

    public Transform playerPos;
    protected GameObject player;

    protected void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    protected void Update()
    {
        if (player != null)
        {
            MoveTowardsPlayer();
        }
    }

    protected void MoveTowardsPlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        playerDis = distanceToPlayer;

        if (distanceToPlayer >= StopDis)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }

    // ���Ƽ�ⷶΧ��Gizmos
    protected void OnDrawGizmos()
    {
        // ����Gizmos��ɫΪ��ɫ
        Gizmos.color = Color.red;

        // �ڵ��˵�λ�û���һ����ⷶΧ������
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        // ���player���ڣ�����һ��ָ����ҵ�����
        if (player != null)
        {
            Gizmos.DrawLine(transform.position, player.transform.position);
        }
    }
}

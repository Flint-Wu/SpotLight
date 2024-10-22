using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEnemy : EnemyMove
{
    public float AttackReadyTime;

    public Collider AttackArea;


    void Start()
    {

        playerPos = GameObject.FindWithTag("Player").transform;
        target = GameObject.FindWithTag("Player").transform;

        tempScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        TurnAround();

        nav.SetDestination(target.position);
    }

    private void Attack()
    {
        Vector3 center = AttackArea.bounds.center;
        Vector3 size = AttackArea.bounds.size;

        Collider[] collidersInside = Physics.OverlapBox(center, size / 2);

        float tempSpeed = nav.speed;

        if (playerDis <= nav.stoppingDistance)//和玩家距离到达设定数值
        {
            nav.speed = 0;

            Tik += Time.deltaTime;

            if (Tik >= AttackReadyTime)//吟唱结束
            {
                for (int i = 0; i < collidersInside.Length; i++)//开始检测攻击范围内是否有玩家，有就扣血
                {
                    if (collidersInside[i].transform.CompareTag("Player"))
                    {
                        collidersInside[i].transform.GetComponent<PlayerState>().Health -= 1;
                    }
                }

                Tik = 0;
            }

            nav.speed = tempSpeed;
        }
    }
}

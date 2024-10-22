using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RedEnemy : EnemyMove
{
    public float AttackReadyTime;

    public Collider AttackArea;

    

    // ʹ�� Physics.OverlapBox ���������������Ƿ������� colliders
    

    void Start()
    {
        playerPos = GameObject.FindWithTag("Player").transform;
        target= GameObject.FindWithTag("Player").transform;


        tempScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        TurnAround();


        nav.SetDestination(target.position);
    }

    private void Attack() 
    {
        Vector3 center = AttackArea.bounds.center;
        Vector3 size = AttackArea.bounds.size;

        Collider[] collidersInside = Physics.OverlapBox(center, size / 2);

        float tempSpeed = nav.speed;

        if (playerDis <= nav.stoppingDistance)
        {
            nav.speed = 0;

            Tik += Time.deltaTime;

            if (Tik >= AttackReadyTime)
            {
                for (int i = 0; i < collidersInside.Length; i++)//��ʼ��⹥����Χ���Ƿ�����ң��оͿ�Ѫ
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

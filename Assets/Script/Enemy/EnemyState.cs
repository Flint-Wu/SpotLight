using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public string EnemyName;
    public int health;

    public float damageCooldown = 2.0f;  // ÿ����ײ�˺�֮��ļ��ʱ��
    private float lastDamageTime = -Mathf.Infinity;

    private Transform player;
    


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // ����Ƿ񳬹����˺���ȴʱ��
            if (Time.time >= lastDamageTime + damageCooldown)
            {
                // �������˺�
            }
        }
        else if (collision.gameObject.CompareTag("Weapon")) //tag������
        {
            // �������˺�
            //TakeDamage(.damage);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}

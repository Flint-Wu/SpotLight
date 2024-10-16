using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public string EnemyName;
    public int health;

    public float damageCooldown = 2.0f;  // 每次碰撞伤害之间的间隔时间
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
            // 检查是否超过了伤害冷却时间
            if (Time.time >= lastDamageTime + damageCooldown)
            {
                // 主角受伤害
            }
        }
        else if (collision.gameObject.CompareTag("Weapon")) //tag名待定
        {
            // 敌人受伤害
            //TakeDamage(.damage);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}

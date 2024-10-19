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

    public bool WasDect,WasAttack;
    


    void Start()
    {
        
    }

    private void OnEnable()
    {
        EventHandler.EnemyDectedEvent += Dected;
    }

    private void OnDisable()
    {
        EventHandler.EnemyDectedEvent -= Dected;
    }

    private void Dected(GameObject @object)
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (WasDect && WasAttack)
        {
            Hurt();
        }
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
        //if (collision.gameObject.CompareTag("Player"))
        //{
        //    // ����Ƿ񳬹����˺���ȴʱ��
        //    if (Time.time >= lastDamageTime + damageCooldown)
        //    {
        //        // �������˺�
        //    }
        //}
        //else if (collision.gameObject.CompareTag("Weapon")) //tag������
        //{
        //    // �������˺�
        //    //TakeDamage(.damage);
        //}

        if (collision.transform.CompareTag("Light"))
            WasDect = true;
        if (collision.transform.CompareTag("playerAttack"))
            WasAttack = true;

    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Light"))
            WasDect = false;
        if (collision.transform.CompareTag("playerAttack"))
            WasAttack = false;
    }

    private void Hurt()
    {

    }

    private void Die()
    {
        Destroy(gameObject);
    }
}

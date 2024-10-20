using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public float healthTime,MaxTime;

    public float damageCooldown = 2.0f;  // 每次碰撞伤害之间的间隔时间
    private float lastDamageTime = -Mathf.Infinity;

    private Transform player;
    public GameObject playerLight;

    public bool WasDect,WasAttack;

    public string tag;
    


    void Start()
    {
        playerLight = GameObject.FindWithTag("playerAttack");
    }

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
    }

    // Update is called once per frame
    void Update()
    {
        TakeDamage();
        if (healthTime >= MaxTime)
        {
            Die();
        }

        if (!playerLight.activeInHierarchy)
        {
            WasAttack = false;
        }
    }

    public void TakeDamage()
    {
        if (WasAttack && WasDect)
        {
            healthTime += Time.deltaTime;
        }
        if (healthTime <= MaxTime && (!WasAttack||!WasDect) && healthTime >= 0) 
        {
            healthTime -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(tag))
            WasDect = true;
        else if (other.transform.CompareTag("playerAttack"))
            WasAttack = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag(tag))
        {
            WasDect = true;
        }
        else if (other.transform.CompareTag("playerAttack"))
        {
            WasAttack = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag(tag))
            WasDect = false;
        else if (other.transform.CompareTag("playerAttack"))
            WasAttack = false;
    }

    private void Hurt()
    {

    }

    private void Die()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
}

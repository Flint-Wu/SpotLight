using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public float Health;
    public float maxHealth;

    public float ReLifeSpeed;

    void Start()
    {
        Health = maxHealth;
    }


    void Update()
    {
        if (Health < maxHealth)
        {
            Health += Time.deltaTime * ReLifeSpeed;
        }
    }
}

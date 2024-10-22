using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BirthDext : MonoBehaviour
{

    public bool BrithAllow;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            BrithAllow = true;
        }
        else if(other == null || !other.CompareTag("Respawn"))
        {
            BrithAllow = false;
        }
    }
}

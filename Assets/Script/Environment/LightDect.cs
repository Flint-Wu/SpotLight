using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDect : MonoBehaviour
{
    public Collider DectArea;

    private void Start()
    {
        DectArea = GetComponent<Collider>();
    }

    private void OnCollisionStay(Collision collision)
    {
        
    }
}

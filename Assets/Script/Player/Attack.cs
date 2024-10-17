using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject Light;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Light.SetActive(true);
            Debug.Log("1");
        }
        else
        {
            Light.SetActive(false);
        }
    }


}

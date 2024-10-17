using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;



public class Light : MonoBehaviour
{
    float inputX, inputZ;

    void Start()
    {
        
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.W))
        {
            this.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.eulerAngles = new Vector3(0, 90, 0);
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.eulerAngles = new Vector3(0, 270, 0);
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            this.transform.eulerAngles = new Vector3(0, 315, 0);
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            this.transform.eulerAngles = new Vector3(0, 135, 0);
        }
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            this.transform.eulerAngles = new Vector3(0, 45, 0);
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            this.transform.eulerAngles = new Vector3(0, 225, 0);
        }
    }
}

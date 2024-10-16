using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;



public class Light : MonoBehaviour
{ float inputX, inputZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //inputX = Input.GetAxis("Horizontal");
        //inputZ = Input.GetAxis("Vertical");
        //if (inputX>=0.01f&&(inputZ<=0.01f&&inputZ>=-0.01f)) 
        //{ this.transform.eulerAngles = new Vector3(0,90,0); }//O-270度,已45度为变换当达到360度时初始化
        //else if(inputX<=-0.01f && (inputZ <= 0.01f && inputZ >= -0.01f))
        //{
        //    this.transform.eulerAngles = new Vector3(0, 270, 0);

        //}
        //else if (inputZ >= 0.01f && (inputX <= 0.01f && inputX >= -0.01f)) 
        //{
        //    this.transform.eulerAngles = new Vector3(0,0,0);

        //}
        //else if(inputZ<=-0.01f && (inputX <= 0.01f && inputX >= -0.01f))
        //{
        //    this.transform.eulerAngles = new Vector3(0, 180, 0);
        //}
        //else if(inputZ>=0.01f&&inputX<=-0.01f)
        //{
        //  
        //} 
        //else if(inputZ >= 0.1f && inputX >= 1f)
        //{
        //    this.transform.eulerAngles = new Vector3(0, 45, 0);
        //} 
        if(Input.GetKey(KeyCode.W))
        {
            this.transform.eulerAngles = new Vector3(0,0, 0);
        }
    if (Input.GetKey(KeyCode.S))
        {
            this.transform.eulerAngles = new Vector3(0,180,0);
        }
      if (Input.GetKey(KeyCode.D))
        {
            this.transform.eulerAngles = new Vector3(0, 90, 0);
        }
       if (Input.GetKey(KeyCode.A))
        {
            this.transform.eulerAngles = new Vector3(0, 270, 0);
        }
     if(Input.GetKey(KeyCode.A)&&Input.GetKey(KeyCode.W))
        {
            this.transform.eulerAngles = new Vector3(0, 315, 0);
        }
    if(Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            this.transform.eulerAngles = new Vector3(0, 135, 0);
        }
    if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            this.transform.eulerAngles = new Vector3(0, 45, 0);
        }
  if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.S))
        {
            this.transform.eulerAngles = new Vector3(0, 225, 0);
        }
    }
}

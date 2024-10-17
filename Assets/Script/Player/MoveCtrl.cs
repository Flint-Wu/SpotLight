using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveCtrl : MonoBehaviour
{

    [Header("���գ�References��")]
    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Rigidbody rb;

    public float rotationSpeed;

    private void Awake() 
    {
        
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        

    }

    private void FixedUpdate()
    {
        CharRot();
    }

    private void CharRot()
    {
        //�����ת��λ
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;
    }
}

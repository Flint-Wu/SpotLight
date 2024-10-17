using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerMovementTutorial : MonoBehaviour
{

    [Header("Movement")]
    public float moveSpeed;

    bool readyToJump;

    [HideInInspector] public float walkSpeed;
    [HideInInspector] public float sprintSpeed;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded = true;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    public Material front, back;
    public MeshRenderer playerImg;

    public Vector3 moveDirection;

    Rigidbody rb;

    private void Awake()
    {

    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;
    }

    private void Update()
    {
        // ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);

        MyInput();
        SpeedControl();

    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()//玩家输入
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
    }

    private void MovePlayer()//角色移动
    {
        // calculate movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        

        // on ground
        rb.velocity = moveDirection.normalized * moveSpeed * 10f;
        Pic();
        //rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

        // no input
        if (horizontalInput != 0 && verticalInput != 0 && rb.velocity != Vector3.zero)
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }

    }


    private void SpeedControl()//角色速度
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        // limit velocity if needed
        if(flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Pic()//角色方向
    {
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(horizontalInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (verticalInput > 0)
        {
            playerImg.materials[0] = front;
        }
        else if(verticalInput < 0)
        {
            playerImg.materials[0] = back;
        }
    }
}
using UnityEngine;

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

    public Material topLeftMaterial, topRightMaterial, bottomLeftMaterial, bottomRightMaterial;
    public Material topCenterMaterial, bottomCenterMaterial;  // 新增两个材质球：中上和中下
    public MeshRenderer playerImg;

    public Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        readyToJump = true;
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);

        MyInput();
        SpeedControl();
        Pic();  // 检测鼠标位置并更改材质球
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.velocity = moveDirection.normalized * moveSpeed * 10f;

        if (horizontalInput != 0 && verticalInput != 0 && rb.velocity != Vector3.zero)
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    private void Pic()
    {
        Vector3 mousePos = Input.mousePosition;
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        // 屏幕宽度分成三列，分别是左、中、右
        // 屏幕高度分成两行，分别是上、下
        bool isLeft = mousePos.x < screenWidth / 3;
        bool isRight = mousePos.x > 2 * screenWidth / 3;
        bool isCenter = !isLeft && !isRight;

        bool isTop = mousePos.y > screenHeight / 2;
        bool isBottom = mousePos.y < screenHeight / 2;

        // 根据鼠标位置来改变材质
        if (isLeft && isTop)
        {
            playerImg.material = topLeftMaterial;    // 左上
        }
        else if (isRight && isTop)
        {
            playerImg.material = topRightMaterial;   // 右上
        }
        else if (isLeft && isBottom)
        {
            playerImg.material = bottomLeftMaterial; // 左下
        }
        else if (isRight && isBottom)
        {
            playerImg.material = bottomRightMaterial;// 右下
        }
        else if (isCenter && isTop)
        {
            playerImg.material = topCenterMaterial;  // 中上
        }
        else if (isCenter && isBottom)
        {
            playerImg.material = bottomCenterMaterial;// 中下
        }
    }
}

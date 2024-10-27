using UnityEngine;
using UnityEngine.InputSystem; // 引入 New Input System 命名空间

public class PlayerMovementTutorial : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    public Animator animator;

    [HideInInspector] public float walkSpeed;
    [HideInInspector] public float sprintSpeed;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded = true;

    public Transform orientation;

    private Vector2 moveInput;  // 用于存储 WASD 输入值

    public Material topLeftMaterial, topRightMaterial, bottomLeftMaterial, bottomRightMaterial;
    public Material topCenterMaterial, bottomCenterMaterial;  // 新增两个材质球：中上和中下
    public SpriteRenderer playerImg;

    public Vector3 moveDirection;
    private Rigidbody rb;

    // 引用你创建的 Input Action Asset
    public PlayerInput playerInput;

    // 音效组件
    public AudioClip moveSound;
    private AudioSource audioSource;

    private void Awake()
    {
        playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        playerImg = GetComponentInChildren<SpriteRenderer>();

        // 初始化音效组件
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = moveSound;
        audioSource.loop = true;  // 设置音效循环
    }

    private void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, whatIsGround);

        SpeedControl();
        Pic();  // 检测鼠标位置并更改材质球

        MovePlayer();

        animator.SetFloat("Speed", rb.velocity.magnitude);
    }

    private void MovePlayer()
    {
        moveInput = playerInput.Gaming.Move.ReadValue<Vector2>();

        // 使用 moveInput.x 和 moveInput.y 来获取横向和纵向输入
        moveDirection = orientation.forward * moveInput.y + orientation.right * moveInput.x;
        rb.velocity = moveDirection.normalized * moveSpeed * 10f;

        // 播放移动音效
        if (moveDirection.magnitude > 0 && grounded)
        {
            if (!audioSource.isPlaying)  // 如果音效未播放，则开始播放
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();  // 停止播放音效
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
        Vector3 mousePos = Mouse.current.position.ReadValue();  // 从 New Input System 获取鼠标位置
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        bool isLeft = mousePos.x < screenWidth / 3;
        bool isRight = mousePos.x > 2 * screenWidth / 3;
        bool isCenter = !isLeft && !isRight;

        bool isTop = mousePos.y > screenHeight / 2;
        bool isBottom = mousePos.y < screenHeight / 2;

        if (isLeft && isTop)
        {
            animator.SetFloat("Blend", 0);
            playerImg.flipX = true;
        }
        else if (isRight && isTop)
        {
            animator.SetFloat("Blend", 0.4f);
            playerImg.flipX = false;
        }
        else if (isLeft && isBottom)
        {
            animator.SetFloat("Blend", 0.6f);
            playerImg.flipX = true;
        }
        else if (isRight && isBottom)
        {
            animator.SetFloat("Blend", 1);
            playerImg.flipX = false;
        }
        else if (isCenter && isTop)
        {
            animator.SetFloat("Blend", 0.2f);
            playerImg.flipX = false;
        }
        else if (isCenter && isBottom)
        {
            animator.SetFloat("Blend", 0.8f);
            playerImg.flipX = false;
        }
    }
}

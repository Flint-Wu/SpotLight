using UnityEngine;
public enum Player_Now_state
{
    normal,
    Interaction,//交互 
    Move,//移动
    Fight,//战斗
    Death,//死亡
    
}

public class Player : MonoBehaviour
{
  
    public Player_Now_state nowState = Player_Now_state.Move;
    private Animator animator;
    public float playerMoveSpeed;
    new private Rigidbody rigidbody;
    private float inputX;
    private float inputZ;
    private float stopX, stopZ;
    private Vector3 offset;
    
    void Update()
    { 
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");
        switch (nowState)
        {
            
             case Player_Now_state.normal:
                normalUpdate();
                break;
            case Player_Now_state.Interaction:
                InteractionUpdate();
                break;
            case Player_Now_state.Move:
                MoveUpdate();
                break;
            case Player_Now_state.Fight:
                FightUpdate();
                break;
            case Player_Now_state.Death:
                break;
            default:
                break;
        }
        CameraConsole();
    }
    private Player_Now_state InputState()
    {
        if (inputX != 0 || inputZ != 0)
        {
            return Player_Now_state.Move;
            
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            return Player_Now_state.Interaction;
        }
       
        return Player_Now_state.normal;
   
    }


    void Start()
    {
        offset = Camera.main.transform.position - transform.position;
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
       
        
    }
    void MoveUpdate()
    { 
            Vector3 moveDirection = new Vector3(inputX, 0, inputZ).normalized;

        this.transform.eulerAngles = new Vector3(0,0,0);
        if (inputX < 0.01f && inputX > -0.01f && inputZ > -0.01f && inputZ < 0.01f)
        
        { animator.SetBool("IsMoving", false);
            nowState = Player_Now_state.normal;


        }
        else
        {
            this.transform.Translate(moveDirection*playerMoveSpeed*Time.deltaTime);
            animator.SetBool("IsMoving", true);
            animator.SetFloat("InputX", inputX);
            animator.SetFloat("InputZ", inputZ);
        }
    }
 
  void PlayerRotate()
    {
        this.transform.eulerAngles = new Vector3(0,0,0); 
    }
    private void FightUpdate()
    {

    }
    private void InteractionUpdate()
    {
        print("已交互");
    nowState = InputState();

    }
    void normalUpdate()
    {

        nowState = InputState();

    }
  void CameraConsole()
    {
        Camera.main.transform.position = transform.position + offset;
    }
}
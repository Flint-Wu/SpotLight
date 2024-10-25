using UnityEngine;
using UnityEngine.AI;

public class EnemyAnim : MonoBehaviour
{
    private Animator animator;
    public NavMeshAgent agent;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 velocity = agent.velocity;
        float speed = velocity.magnitude;

        // 获取角色的移动方向
        Vector3 direction = transform.InverseTransformDirection(velocity.normalized);

        // 设置动画参数
        animator.SetFloat("Speed", speed);
        animator.SetFloat("Horizontal", direction.x); // 左右方向
        animator.SetFloat("Vertical", direction.z);   // 前后方向
    }
}

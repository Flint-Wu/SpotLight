using System.Collections.Generic;
using UnityEngine;

public class BossDectLight : MonoBehaviour
{
    public float detectionRadius = 10f; // 检测范围半径
    public LayerMask detectionLayer; // 检测的层级
    public Collider closestCollider; // 最近的碰撞体

    void Start()
    {
        // 每帧更新时找到最近的碰撞体
        FindClosestCollider();

        // 输出最近的碰撞体
        if (closestCollider != null)
        {
            Debug.Log("Closest object: " + closestCollider.name);
        }
    }

    private void FindClosestCollider()
    {
        float closestDistance = Mathf.Infinity;
        closestCollider = null;

        // 获取范围内的所有碰撞体
        Collider[] collidersInRange = Physics.OverlapSphere(transform.position, detectionRadius);

        foreach (var collider in collidersInRange)
        {
            // 仅检测指定层级的碰撞体
            if ((detectionLayer.value & (1 << collider.gameObject.layer)) == 0)
                continue;

            float distance = Vector3.Distance(transform.position, collider.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestCollider = collider;
            }
        }
    }

    // 可视化检测范围和最近碰撞体
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        Gizmos.color = Color.green;
        if (closestCollider != null)
        {
            Gizmos.DrawLine(transform.position, closestCollider.transform.position);
        }
    }
}

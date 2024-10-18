using UnityEngine;

public class ObjectLookAtMouseClick : MonoBehaviour
{
    public Transform objectToRotate; // 需要旋转的对象
    public GameObject target;
    public LayerMask targetLayer;    // 需要检测的层
    public string targetTag = "Ground"; // 需要检测的Tag
    public Vector3 targetPoint;     // 目标点坐标
    private bool hasTarget = false;  // 是否有目标点

    private void Start()
    {
        // 解锁鼠标，使其可以自由移动
        Cursor.lockState = CursorLockMode.None;

        // 显示鼠标光标
        Cursor.visible = true;
    }

    void Update()
    {
        // 检测鼠标左键点击
        if (Input.GetMouseButton(0))
        {
            // 从摄像机生成射线，基于鼠标当前屏幕位置
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // 使用RaycastAll检测所有碰撞体
            RaycastHit[] hits = Physics.RaycastAll(ray, Mathf.Infinity, targetLayer);

            foreach (RaycastHit hit in hits)
            {
                // 检查碰撞体是否具有指定的Tag
                if (hit.collider.CompareTag(targetTag))
                {
                    // 保存最后一个符合条件的碰撞点作为目标点
                    targetPoint = hit.point;
                    target.transform.position = targetPoint;
                    hasTarget = true; // 确认已经有目标点

                    // 你可以在这里进行其他逻辑处理，比如响应多个目标的碰撞
                    Debug.Log("Detected: " + hit.collider.name);
                }
            }
        }

        // 如果有目标点，持续让对象朝向目标点
        if (hasTarget)
        {
            RotateObjectTowardsTarget();
        }
    }

    // 让对象朝向目标点
    void RotateObjectTowardsTarget()
    {
        // 计算目标点与对象之间的方向向量
        Vector3 directionToTarget = - targetPoint + objectToRotate.position;

        // 如果方向向量有长度，才进行旋转
        if (directionToTarget.sqrMagnitude > 0.01f)
        {
            // 让对象的前方向朝向目标点
            objectToRotate.rotation = Quaternion.LookRotation(directionToTarget);
        }
    }
}

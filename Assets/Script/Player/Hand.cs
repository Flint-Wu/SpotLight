using UnityEngine;

public class Hand : MonoBehaviour
{
    public LayerMask targetLayer;      // 需要检测的层
    public string targetTag = "HandRot"; // 需要检测的Tag
    public Vector3 targetPoint;        // 目标点坐标
    public Transform TargetTrans;      // 需要移动的目标
    public float maxDistance = 5f;     // 最大允许距离

    private bool hasTarget = false;    // 是否有目标点

    public Material topLeftMaterial;
    public Material topCenterMaterial;
    public Material topRightMaterial;
    public Material bottomLeftMaterial;
    public Material bottomCenterMaterial;
    public Material bottomRightMaterial;

    public MeshRenderer meshRenderer;

    private void Start()
    {
        // 解锁鼠标，使其可以自由移动
        Cursor.lockState = CursorLockMode.None;

        // 显示鼠标光标
        Cursor.visible = true;
    }

    void Update()
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

                // 计算当前对象与目标点之间的距离
                float distanceToTarget = Vector3.Distance(transform.position, targetPoint);

                // 如果目标点超出最大距离，则将目标点调整到最大距离范围内
                if (distanceToTarget > maxDistance)
                {
                    // 将目标点限制在最大距离范围内
                    Vector3 direction = (targetPoint - transform.position).normalized;
                    targetPoint = transform.position + direction * maxDistance;
                }

                // 将目标物体移动到目标点
                TargetTrans.position = targetPoint;
                hasTarget = true; // 确认已经有目标点

                Debug.Log("Detected: " + hit.collider.name);
            }
        }

        // 如果有目标点，处理移动
        if (hasTarget)
        {
            DetectMousePositionAndChangeMaterial();
        }
    }

    void DetectMousePositionAndChangeMaterial()
    {
        // 获取屏幕尺寸
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        // 获取鼠标当前的位置
        Vector3 mousePos = Input.mousePosition;

        // 定义区域边界
        float leftBoundary = screenWidth / 3;
        float rightBoundary = 2 * screenWidth / 3;
        float topBoundary = 2 * screenHeight / 3;
        float bottomBoundary = screenHeight / 3;

        // 设置一个目标点的默认值
        Vector3 targetPoint = transform.position;

        // 判断鼠标在哪个区域并切换材质
        if (mousePos.x < leftBoundary && mousePos.y > topBoundary)
        {
            // 左上角
            Debug.Log("Mouse in Top-Left");
            meshRenderer.material = topLeftMaterial;
            targetPoint = new Vector3(-1, 0, 1); // 设置目标方向
        }
        else if (mousePos.x > rightBoundary && mousePos.y > topBoundary)
        {
            // 右上角
            Debug.Log("Mouse in Top-Right");
            meshRenderer.material = topRightMaterial;
            targetPoint = new Vector3(1, 0, 1); // 设置目标方向
        }
        else if (mousePos.x > leftBoundary && mousePos.x < rightBoundary && mousePos.y > topBoundary)
        {
            // 中上
            Debug.Log("Mouse in Top-Center");
            meshRenderer.material = topCenterMaterial;
            targetPoint = new Vector3(0, 0, 1); // 设置目标方向
        }
        else if (mousePos.x < leftBoundary && mousePos.y < bottomBoundary)
        {
            // 左下角
            Debug.Log("Mouse in Bottom-Left");
            meshRenderer.material = bottomLeftMaterial;
            targetPoint = new Vector3(-1, 0, -1); // 设置目标方向
        }
        else if (mousePos.x > rightBoundary && mousePos.y < bottomBoundary)
        {
            // 右下角
            Debug.Log("Mouse in Bottom-Right");
            meshRenderer.material = bottomRightMaterial;
            targetPoint = new Vector3(1, 0, -1); // 设置目标方向
        }
        else if (mousePos.x > leftBoundary && mousePos.x < rightBoundary && mousePos.y < bottomBoundary)
        {
            // 中下
            Debug.Log("Mouse in Bottom-Center");
            meshRenderer.material = bottomCenterMaterial;
            targetPoint = new Vector3(0, 0, -1); // 设置目标方向
        }


    }
}


using UnityEngine;

public class Hand : MonoBehaviour
{
    public LayerMask targetLayer;      // ��Ҫ���Ĳ�
    public string targetTag = "HandRot"; // ��Ҫ����Tag
    public Vector3 targetPoint;        // Ŀ�������
    public Transform TargetTrans;      // ��Ҫ�ƶ���Ŀ��
    public float maxDistance = 5f;     // ����������

    private bool hasTarget = false;    // �Ƿ���Ŀ���

    public Material topLeftMaterial;
    public Material topCenterMaterial;
    public Material topRightMaterial;
    public Material bottomLeftMaterial;
    public Material bottomCenterMaterial;
    public Material bottomRightMaterial;

    public MeshRenderer meshRenderer;

    private void Start()
    {
        // ������꣬ʹ����������ƶ�
        Cursor.lockState = CursorLockMode.None;

        // ��ʾ�����
        Cursor.visible = true;
    }

    void Update()
    {
        // ��������������ߣ�������굱ǰ��Ļλ��
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // ʹ��RaycastAll���������ײ��
        RaycastHit[] hits = Physics.RaycastAll(ray, Mathf.Infinity, targetLayer);

        foreach (RaycastHit hit in hits)
        {
            // �����ײ���Ƿ����ָ����Tag
            if (hit.collider.CompareTag(targetTag))
            {
                // �������һ��������������ײ����ΪĿ���
                targetPoint = hit.point;

                // ���㵱ǰ������Ŀ���֮��ľ���
                float distanceToTarget = Vector3.Distance(transform.position, targetPoint);

                // ���Ŀ��㳬�������룬��Ŀ�������������뷶Χ��
                if (distanceToTarget > maxDistance)
                {
                    // ��Ŀ��������������뷶Χ��
                    Vector3 direction = (targetPoint - transform.position).normalized;
                    targetPoint = transform.position + direction * maxDistance;
                }

                // ��Ŀ�������ƶ���Ŀ���
                TargetTrans.position = targetPoint;
                hasTarget = true; // ȷ���Ѿ���Ŀ���

                Debug.Log("Detected: " + hit.collider.name);
            }
        }

        // �����Ŀ��㣬�����ƶ�
        if (hasTarget)
        {
            DetectMousePositionAndChangeMaterial();
        }
    }

    void DetectMousePositionAndChangeMaterial()
    {
        // ��ȡ��Ļ�ߴ�
        float screenWidth = Screen.width;
        float screenHeight = Screen.height;

        // ��ȡ��굱ǰ��λ��
        Vector3 mousePos = Input.mousePosition;

        // ��������߽�
        float leftBoundary = screenWidth / 3;
        float rightBoundary = 2 * screenWidth / 3;
        float topBoundary = 2 * screenHeight / 3;
        float bottomBoundary = screenHeight / 3;

        // ����һ��Ŀ����Ĭ��ֵ
        Vector3 targetPoint = transform.position;

        // �ж�������ĸ������л�����
        if (mousePos.x < leftBoundary && mousePos.y > topBoundary)
        {
            // ���Ͻ�
            Debug.Log("Mouse in Top-Left");
            meshRenderer.material = topLeftMaterial;
            targetPoint = new Vector3(-1, 0, 1); // ����Ŀ�귽��
        }
        else if (mousePos.x > rightBoundary && mousePos.y > topBoundary)
        {
            // ���Ͻ�
            Debug.Log("Mouse in Top-Right");
            meshRenderer.material = topRightMaterial;
            targetPoint = new Vector3(1, 0, 1); // ����Ŀ�귽��
        }
        else if (mousePos.x > leftBoundary && mousePos.x < rightBoundary && mousePos.y > topBoundary)
        {
            // ����
            Debug.Log("Mouse in Top-Center");
            meshRenderer.material = topCenterMaterial;
            targetPoint = new Vector3(0, 0, 1); // ����Ŀ�귽��
        }
        else if (mousePos.x < leftBoundary && mousePos.y < bottomBoundary)
        {
            // ���½�
            Debug.Log("Mouse in Bottom-Left");
            meshRenderer.material = bottomLeftMaterial;
            targetPoint = new Vector3(-1, 0, -1); // ����Ŀ�귽��
        }
        else if (mousePos.x > rightBoundary && mousePos.y < bottomBoundary)
        {
            // ���½�
            Debug.Log("Mouse in Bottom-Right");
            meshRenderer.material = bottomRightMaterial;
            targetPoint = new Vector3(1, 0, -1); // ����Ŀ�귽��
        }
        else if (mousePos.x > leftBoundary && mousePos.x < rightBoundary && mousePos.y < bottomBoundary)
        {
            // ����
            Debug.Log("Mouse in Bottom-Center");
            meshRenderer.material = bottomCenterMaterial;
            targetPoint = new Vector3(0, 0, -1); // ����Ŀ�귽��
        }


    }
}


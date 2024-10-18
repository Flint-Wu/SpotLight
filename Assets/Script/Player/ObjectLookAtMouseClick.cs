using UnityEngine;

public class ObjectLookAtMouseClick : MonoBehaviour
{
    public Transform objectToRotate; // ��Ҫ��ת�Ķ���
    public GameObject target;
    public LayerMask targetLayer;    // ��Ҫ���Ĳ�
    public string targetTag = "Ground"; // ��Ҫ����Tag
    public Vector3 targetPoint;     // Ŀ�������
    private bool hasTarget = false;  // �Ƿ���Ŀ���

    private void Start()
    {
        // ������꣬ʹ����������ƶ�
        Cursor.lockState = CursorLockMode.None;

        // ��ʾ�����
        Cursor.visible = true;
    }

    void Update()
    {
        // ������������
        if (Input.GetMouseButton(0))
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
                    target.transform.position = targetPoint;
                    hasTarget = true; // ȷ���Ѿ���Ŀ���

                    // �������������������߼�����������Ӧ���Ŀ�����ײ
                    Debug.Log("Detected: " + hit.collider.name);
                }
            }
        }

        // �����Ŀ��㣬�����ö�����Ŀ���
        if (hasTarget)
        {
            RotateObjectTowardsTarget();
        }
    }

    // �ö�����Ŀ���
    void RotateObjectTowardsTarget()
    {
        // ����Ŀ��������֮��ķ�������
        Vector3 directionToTarget = - targetPoint + objectToRotate.position;

        // ������������г��ȣ��Ž�����ת
        if (directionToTarget.sqrMagnitude > 0.01f)
        {
            // �ö����ǰ������Ŀ���
            objectToRotate.rotation = Quaternion.LookRotation(directionToTarget);
        }
    }
}

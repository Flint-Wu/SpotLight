using UnityEngine;

public class Enemy_Birth : MonoBehaviour
{
    [SerializeField]
    private Enemy_BirthDext[] enemy_BirthDexts;  // ���ɵ��˵ĵ�
    private Enemy_BirthDext[] enemy_BirthDexts_Temp;  // ��ʱ�洢�������ɵĵ�

    public GameObject RED, BLUE, YELLOW;  // ���˵�Ԥ����

    // ���Ƶ��˵���������
    [SerializeField]
    private int redMaxCount = 1;
    [SerializeField]
    private int blueMaxCount = 1;
    [SerializeField]
    private int yellowMaxCount = 1;

    // �������ɵ�ʱ����
    public float spawnInterval = 5f;
    private float spawnTimer;

    public int redCount;
    public int blueCount;
    public int yellowCount;

    void Start()
    {
        enemy_BirthDexts = GetComponentsInChildren<Enemy_BirthDext>();
        enemy_BirthDexts_Temp = new Enemy_BirthDext[enemy_BirthDexts.Length];
        spawnTimer = spawnInterval;  // ��ʼ����ʱ��
    }

    void Update()
    {
        // ÿ��һ��ʱ�����ɵ���
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            CreateMonster();
            spawnTimer = spawnInterval;  // ���ü�ʱ��
        }

        // ͨ�����ҳ����ж�Ӧ��ǩ�ĵ�������
        redCount = GameObject.FindGameObjectsWithTag("Red").Length;
        blueCount = GameObject.FindGameObjectsWithTag("Blue").Length;
        yellowCount = GameObject.FindGameObjectsWithTag("Yellow").Length;
    }

    void CreateMonster()
    {
        // ɸѡ�������ɵĵ�
        int tempCount = 0;
        for (int i = 0; i < enemy_BirthDexts.Length; i++)
        {
            if (enemy_BirthDexts[i].BrithAllow)
            {
                enemy_BirthDexts_Temp[tempCount] = enemy_BirthDexts[i];
                tempCount++;
            }
        }

        // ���û�п������ɵ㣬�򷵻�
        if (tempCount == 0) return;



        // ����Ƿ��Ѿ��ﵽ������ɫ���˵���������
        if (redCount >= redMaxCount && blueCount >= blueMaxCount && yellowCount >= yellowMaxCount)
        {
            Debug.Log("������ɫ�ĵ��˶��ﵽ����������");
            return;
        }

        // ���ѡ��һ�����ɵ�
        int numPoint = Random.Range(0, tempCount);
        Vector3 spawnPosition = enemy_BirthDexts_Temp[numPoint].transform.position;

        // ������ɵ��˵���ɫ����Ҫ����ÿ����ɫ������
        GameObject selectedEnemy = null;

        int attempts = 0;
        while (selectedEnemy == null && attempts < 100) // ��ֹ����ѭ������������Դ���
        {
            int randomColor = Random.Range(0, 3);  // 0=RED, 1=BLUE, 2=YELLOW

            switch (randomColor)
            {
                case 0:
                    if (redCount < redMaxCount)
                    {
                        selectedEnemy = RED;
                    }
                    break;
                case 1:
                    if (blueCount < blueMaxCount)
                    {
                        selectedEnemy = BLUE;
                    }
                    break;
                case 2:
                    if (yellowCount < yellowMaxCount)
                    {
                        selectedEnemy = YELLOW;
                    }
                    break;
            }

            attempts++;
        }

        if (attempts >= 100)
        {
            Debug.LogWarning("δ�����ɵ��ˣ��Ѵﵽ����Դ���");
            return;
        }

        // ���ɵ���
        if (selectedEnemy != null)
        {
            Instantiate(selectedEnemy, spawnPosition, Quaternion.identity);
        }
    }
}

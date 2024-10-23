using UnityEngine;

public class Enemy_Birth : MonoBehaviour
{
    [SerializeField]
    private Enemy_BirthDext[] enemy_BirthDexts;  // 生成敌人的点
    private Enemy_BirthDext[] enemy_BirthDexts_Temp;  // 临时存储允许生成的点
    private GameObject BornEnemies;

    public GameObject RED, BLUE, YELLOW;  // 敌人的预制体

    // 控制敌人的生成上限
    [SerializeField]
    private int redMaxCount = 5;
    [SerializeField]
    private int blueMaxCount = 5;
    [SerializeField]
    private int yellowMaxCount = 5;

    // 追踪每种颜色敌人的生成数量
    [SerializeField]
    private int redCount = 0; [SerializeField]
    private int blueCount = 0; [SerializeField]
    private int yellowCount = 0;

    // 敌人生成的时间间隔
    public float spawnInterval = 5f;
    private float spawnTimer;

    void Start()
    {
        enemy_BirthDexts = GetComponentsInChildren<Enemy_BirthDext>();
        enemy_BirthDexts_Temp = new Enemy_BirthDext[enemy_BirthDexts.Length];
        spawnTimer = spawnInterval;  // 初始化计时器
    }

    void Update()
    {
        // 每过一定时间生成敌人
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            creatMonster();
            spawnTimer = spawnInterval;  // 重置计时器
        }
    }

    void creatMonster()
    {
        // 筛选允许生成的点
        int tempCount = 0;
        for (int i = 0; i < enemy_BirthDexts.Length; i++)
        {
            if (enemy_BirthDexts[i].BrithAllow)
            {
                enemy_BirthDexts_Temp[tempCount] = enemy_BirthDexts[i];
                tempCount++;
            }
        }

        // 如果没有可用生成点，则返回
        if (tempCount == 0) return;

        // 检查是否已经达到所有颜色敌人的生成上限
        if (redCount >= redMaxCount && blueCount >= blueMaxCount && yellowCount >= yellowMaxCount)
        {
            Debug.Log("所有颜色的敌人都达到了生成上限");
            return;
        }

        // 随机选择一个生成点
        int numPoint = Random.Range(0, tempCount);
        Vector3 spawnPosition = enemy_BirthDexts_Temp[numPoint].transform.position;

        // 随机生成敌人的颜色，但要考虑每种颜色的上限
        GameObject selectedEnemy = null;

        int attempts = 0;
        while (selectedEnemy == null && attempts < 100) // 防止无限循环，增加最大尝试次数
        {
            int randomColor = Random.Range(0, 3);  // 0=RED, 1=BLUE, 2=YELLOW

            switch (randomColor)
            {
                case 0:
                    if (redCount < redMaxCount)
                    {
                        selectedEnemy = RED;
                        redCount++;
                    }
                    break;
                case 1:
                    if (blueCount < blueMaxCount)
                    {
                        selectedEnemy = BLUE;
                        blueCount++;
                    }
                    break;
                case 2:
                    if (yellowCount < yellowMaxCount)
                    {
                        selectedEnemy = YELLOW;
                        yellowCount++;
                    }
                    break;
            }

            attempts++;
        }

        if (attempts >= 100)
        {
            Debug.LogWarning("未能生成敌人，已达到最大尝试次数");
            return;
        }

        // 生成敌人
        if (selectedEnemy != null)
        {
            Instantiate(selectedEnemy, spawnPosition, Quaternion.identity);
        }
    }

}

using UnityEngine;

public class BossEnemy : EnemyMove
{
    public float AttackReadyTime;

    public Collider AttackArea;

    public BossDectLight BossDectLight;

    void Start()
    {

        EnemyState = GetComponentInChildren<EnemyState>();
        playerPos = GameObject.FindWithTag("Player").transform;

        BossDectLight = GetComponentInChildren<BossDectLight>();

        tempScale = transform.localScale;

        
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = BossDectLight.closestCollider.transform;
        target = playerPos;

        Attack();

        TurnAround();

        nav.SetDestination(target.position);

        if (target != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, target.transform.position);
            playerDis = distanceToPlayer;
        }
    }

    private void Attack()
    {
        float tempSpeed = nav.speed;

        if (playerDis <= nav.stoppingDistance)//和玩家距离到达设定数值
        {
            nav.speed = 0;

            Tik += Time.deltaTime;

            target.parent.gameObject.SetActive(false);
            Debug.Log("cut!" + target.transform.name);

            nav.speed = tempSpeed;
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavi : MonoBehaviour
{
    public NavMeshAgent nav;

    public Transform target;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.nav.SetDestination(this.target.position);
    }
}

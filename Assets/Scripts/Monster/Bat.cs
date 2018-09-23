using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonsterLogic {
    public Transform target;
    public Vector2 direction;
    public int distance;

    private void Start()
    {
        distance = gameObject.GetComponent<MonsterLogic>().ICOUNT_LEGNTH;
        distance = 3;
    }

    private void Update()
    {
        MoveToTarget();
    }

    void MoveToTarget()
    {
        target = GameObject.Find("Player").transform;
        direction = (target.position - transform.position);
        if(distance < 5)
        {
            this.transform.Translate(new Vector2(transform.position.x + target.position.x,
                transform.position.y - target.position.y));
        }
    }
}
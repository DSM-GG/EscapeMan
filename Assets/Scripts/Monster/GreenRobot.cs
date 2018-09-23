using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenRobot : MonsterLogic
{
    GameObject player;
    public int distance;
    public int GrRobotHp;
    Animator animator;
    // Update is called once per frame
        
    protected void Start()
    {
        player = GameObject.Find("Player");
        animator = GetComponent<Animator>();
        distance = GetComponent<MonsterLogic>().ICOUNT_LEGNTH;
        GrRobotHp = GetComponent<MonsterLogic>().MonsterHp;
        GrRobotHp = 3;
        distance = 4;
    }
    protected void FixedUpdate()
    {
        Dead();
        if (Vector2.Distance(player.transform.position, transform.position) < distance)
        {
            incount = true;
        }
        else
        {
            incount = false;
            Move();
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            if (left.Equals(true))
            {
                left = false;
            }
            else
            {
                left = true;
            }
        }
        if (other.gameObject.tag == "Bullet")
        {
            GrRobotHp -= 1;
        }
    }

    

    public bool CallLeft()
    {
        return getLeft();
    }
}

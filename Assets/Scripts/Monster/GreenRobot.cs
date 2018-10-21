using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenRobot : MonsterLogic
{
    public static int greenRobotDmg = 10;
    public int distance;
    public float grRobotHp;
    // Update is called once per frame
        
    protected void Start()
    {
        player = GameObject.Find("Player");
        distance = GetComponent<MonsterLogic>().ICOUNT_LEGNTH;
        grRobotHp = GetComponent<MonsterLogic>().monsterHp;
        grRobotHp = 3;
    }

    protected void FixedUpdate()
    {
        if(grRobotHp == 0)
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
            grRobotHp -= 1;
        }
    }

    public bool CallLeft()
    {
        return getLeft();
    }
}

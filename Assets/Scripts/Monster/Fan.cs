using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonsterLogic {
    public static int fanDmg = 10;
    GameObject rightAir;
    GameObject leftAir;
    Animator animator;
    int fanIncount;
    float fanHP;
	// Use this for initialization
	void Start () {
        rightAir = this.gameObject.transform.GetChild(0).gameObject;
        leftAir = this.gameObject.transform.GetChild(1).gameObject;
        animator = gameObject.GetComponent<Animator>();
        fanIncount = GetComponent<MonsterLogic>().ICOUNT_LEGNTH;
        fanIncount = 2;
        fanHP = GetComponent<MonsterLogic>().monsterHp;
        fanHP = 5;
    }
	
	// Update is called once per frame
	void Update () {
        Move();
        if (fanHP == 0)
            Dead();
        if (Vector2.Distance(player.transform.position, gameObject.transform.position) < fanIncount)
        {
            Attack();
            turnAirOn(left, true);
        }
        else
        {
            animator.SetBool("Incount", false);
        }
    }

    void turnAirOn(bool left, bool onOff)
    {
        if(onOff == true)
        {
            if(left == true)
            {
                leftAir.SetActive(true);
                rightAir.SetActive(false);
            }
            else
            {
                rightAir.SetActive(true);
                leftAir.SetActive(false);
            }
        }
        else
        {
            leftAir.SetActive(false);
            rightAir.SetActive(false);
        }
    }

    void Attack()
    {
        animator.SetBool("Incount", true);
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
            fanHP -= 1;
        }
    }

    public bool CallLeft()
    {
        return getLeft();
    }
}

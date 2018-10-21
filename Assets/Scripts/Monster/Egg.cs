using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonsterLogic {
    public static int eggDmg = 10;
    public GameObject eg;
    public float eggHp;
    Animator animator;
    int distance;
    bool canAttack;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        eggHp = GetComponent<MonsterLogic>().monsterHp;
        distance = GetComponent<MonsterLogic>().ICOUNT_LEGNTH;
        player = GameObject.Find("Player");
        eg = transform.GetChild(0).gameObject;
        canAttack = true;
        eggHp = 2;
        distance = 2;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Vector2.Distance(player.transform.position, transform.position) < distance)
        {
            incount = true;
            Attack();
        }
        else
        {
            incount = false;
            Move();
        }
        if (eggHp <= 0)
        {
            Dead();
        }
	}

    void Attack()
    {
        if (incount == false) // 적 플레이어 incount 여부
            return;
        if (canAttack == false) // 공격 재사용 대기시간
            return;
        if (transform.GetChild(0).GetComponent<Eg>().isBroken == false) // 달걀이 부서지지않으면 return;
            return;

        canAttack = false;
        animator.SetBool("isAttacked", true);
        eg.SetActive(true);
        StartCoroutine("AttackCool");
    }

    IEnumerator AttackCool()
    {
        yield return new WaitForSeconds(3);
        animator.SetBool("isAttacked", false);
        canAttack = true;
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
    }
}

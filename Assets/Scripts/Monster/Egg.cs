using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonsterLogic {
    public GameObject Eg;
    public int EggHp;
    Animator animator;
    GameObject player;
    int distance;
    bool incount;
    bool canAttack;
	// Use this for initialization
	void Start () {
        EggHp = GetComponent<MonsterLogic>().MonsterHp;
        EggHp = 2;
        player = GameObject.Find("Player");
        distance = GetComponent<MonsterLogic>().ICOUNT_LEGNTH;
        distance = 2;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Vector2.Distance(player.transform.position, transform.position) < distance)
            incount = true;
        else
            incount = false;
        if(EggHp <= 0)
        {
            Dead();
        }
	}

    private void FixedUpdate()
    {
        Attack();
    }

    void Attack()
    {
        if (incount == false)
            return;
        if (canAttack == false)
            return;

        canAttack = false;
        animator.SetBool("isAttacked", true);
        Instantiate(Eg, this.transform);
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
        if(other.gameObject.tag == "Bullet")
        {
            EggHp -= 1;
        }
    }
}

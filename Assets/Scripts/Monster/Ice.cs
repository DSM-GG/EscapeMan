using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : MonsterLogic {
    public float IceMove = 0.05f;
    public float IceHp;
    public GameObject Player;
    bool canAttack;
    Animator animator;
    GameObject IceBullet;

    // Use this for initialization
    void Start () {
        IceBullet = this.gameObject.transform.GetChild(0).gameObject;
        animator = GetComponent<Animator>();
        canAttack = true;
        IceHp = GetComponent<MonsterLogic>().monsterHp;
        IceHp = 3;
	}
	
	// Update is called once per frame
	void Update () {
        if (IceHp <= 0)
            Dead();
        if (Vector2.Distance(this.transform.position, Player.transform.position) < 5)
        {
            incount = true;
        }
        else
        {
            incount = false;
            Move();
        }
    }

    private void FixedUpdate()
    {
        Attack();
    }

    void Attack()
    {
        if (incount == false) // 적 플레이어 incount 여부
            return;
        if (canAttack == false) // 공격 재사용 대기시간
            return;

        canAttack = false;
        animator.SetBool("isAttacked", true);
        IceBullet.SetActive(true);
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

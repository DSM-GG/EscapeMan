using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAtk : MonoBehaviour
{
    public GameObject[] Bullets;
    bool CanAttack;
    Animator animator;
    public GameObject Player;
    public GameObject BulletPrefab;
    const int BULLET_MAXSIZE = 5;
    GreenRobot greenRobot;
    void MakeBullet()
    {
        Bullets = new GameObject[BULLET_MAXSIZE];
        for (int i = 0; i < BULLET_MAXSIZE; i++)
        {
            Bullets[i] = Instantiate(BulletPrefab);
            Bullets[i].SetActive(false);
        }
    }
    // Use this for initialization
    void Start () {
        CanAttack = true;
        greenRobot = gameObject.GetComponent<GreenRobot>();
        animator = this.gameObject.GetComponent<Animator>();
        MakeBullet();
    }

    private void Update()
    {
        if(greenRobot.incount.Equals(true))
        {
            Attack();
        }
    }

    void Attack()
    {
        animator.SetBool("Incount", true);
        if(CanAttack.Equals(true))
        {
            if (Player.transform.position.x > this.transform.position.x)
            {
                // 우측으로 공격
                for (int i = 0; i < BULLET_MAXSIZE; i++)
                {
                    if (Bullets[i].activeSelf == false)
                    {
                        StartCoroutine("CoolTime");
                        Bullets[i].GetComponent<MonsterBullet>().Shoot(this.transform, greenRobot.CallLeft());
                        break;
                    }
                }
            }
            else
            {
                // 좌측으로 공격
                for (int i = 0; i <= BULLET_MAXSIZE; i++)
                {
                    if (Bullets[i].activeSelf == false)
                    {
                        StartCoroutine("CoolTime");
                        Bullets[i].GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 0), ForceMode2D.Impulse);
                        break;
                    }
                }
            }
        }
    }
    IEnumerator CoolTime()
    {
        CanAttack = false;
        yield return new WaitForSeconds(0.5f);
        CanAttack = true;
    }
}

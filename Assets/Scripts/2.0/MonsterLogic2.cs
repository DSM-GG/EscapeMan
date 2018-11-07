using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLogic2 : MonoBehaviour {
    public float monsterHp;
    public float monsterSpd;
    protected bool left; // 왼쪽을 향할 때 true
    protected bool playerIsLeft; // 몬스터기준 플레이어 위치

    public Vector3 vecLeft = new Vector3 (-1, 0, 0);
    public Vector3 vecRight = new Vector3(1, 0, 0);
    public GameObject player;
    protected SpriteRenderer spriteRenderer;

    protected bool Rincount;
    protected bool Lincount;
    protected bool isIncount;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected void FixedUpdate()
    {
        Check();
        Move();
    }

    protected void Check() // 플레이어가 incount상태인가 + 플레이어가 몬스터의 어느쪽에 있는가를 확인해 줌.
    {
        Rincount = transform.GetChild(0).GetChild(0).gameObject.GetComponent<Observer>().Incount;
        Lincount = transform.GetChild(0).GetChild(1).gameObject.GetComponent<Observer>().Incount;
        if (Rincount == true || Lincount == true)
            isIncount = true;

        if (player.transform.position.x > transform.position.x)
            playerIsLeft = false;
        else
            playerIsLeft = true;
    }

    protected void Move() // 몬스터 단순 이동
    {
        if (Rincount == true || Lincount == true) // 플레이어가 공격범위 or 추적범위 진입시 기본 이동은 금지.
            return;

        if(left == true)
        {
            spriteRenderer.flipX = true;
            transform.position += vecLeft;
        }
        else
        {
            spriteRenderer.flipX = false;
            transform.position += vecRight;
        }
    }

    public void Damaged(float dmg) // 몬스터를 총알로 맞추면 플레이어가 이 함수를 호출한다.
    {
        monsterHp -= dmg;
    }

    private void OnCollisionEnter2D(Collision2D other) // 벽에 부딪히면 방향전환.
    {
        switch(other.gameObject.tag)
        {
            case "wall":
                if (left.Equals(true))
                    left = false;
                else
                    left = true;
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLogic2 : MonoBehaviour {
    public float monsterHp;
    public float monsterSpd;
    public int incountLength;
    public Vector3 vecLeft = new Vector3 (-1, 0, 0);
    public Vector3 vecRight = new Vector3(1, 0, 0);
    public bool left; // 왼쪽을 향할 때 true
    protected bool isIncount;
    protected bool playerIsLeft;

    public GameObject player;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected void FixedUpdate()
    {
        Check();
        Move();
    }

    protected void Check()
    {
        if (player.transform.position.x > transform.position.x)
            playerIsLeft = false;
        else
            playerIsLeft = true;
    }

    protected void Move()
    {
        if(left.Equals(true))
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

    private void OnCollisionEnter2D(Collision2D other)
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

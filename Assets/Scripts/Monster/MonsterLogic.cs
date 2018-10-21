using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLogic : MonoBehaviour {
    public float monsterHp;
    public float monsterSpd = 0.1f;
    public GameObject player;
    public bool incount;
    SpriteRenderer monsterrenderer;
    public int ICOUNT_LEGNTH = 5; // 임의로 정해준 incount거리.
    protected bool left { get; set; } // 벽에 부딫혔을 때 이동방향을 정해줌.
    private void Awake()
    {
        monsterrenderer = GetComponent<SpriteRenderer>();
        left = false;
    }
    
    protected void Move() // 순찰
    {
        if (left == true)
        {
            monsterrenderer.flipX = true;
            transform.Translate(Vector2.left * monsterSpd);
        }
        else
        {
            monsterrenderer.flipX = false;
            transform.Translate(Vector2.right * monsterSpd);
        }
    }

    protected void Dead() // 각 몬스터별로 정해준 체력이 0이 되었을 경우 monster를 파괴.
    {
        Destroy(this.gameObject);
    }

    protected bool getLeft()
    {
        return left;
    }

    public void Damaged(float dmg)
    {
        this.monsterHp -= dmg;
    }
}

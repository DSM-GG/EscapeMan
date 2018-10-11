using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing : MonsterLogic {
    public SpriteRenderer monsterRenderer;
    bool stop = false;

    private void Start()
    {
        monsterRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (player.transform.position.x - transform.position.x < ICOUNT_LEGNTH) // 플레이어 위치에서 몬스터 위치를 빼서 이동방향을 정해줌.
        {
            if(stop == false)
            {
                Follow();
            }

        }
        else
        {
            Move();
        }
    }

    private void Follow()
    {
        if(player.transform.position.x > this.transform.position.x)
        {
            transform.Translate(Vector2.right * 0.1f);
            monsterRenderer.flipX = false;
        }
        else
        {
            transform.Translate(Vector2.left * 0.1f);
            monsterRenderer.flipX = true;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall") // 벽을 만날경우 방향을 반대로 틀어준다.
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
        if(other.gameObject.tag == "Player") // 플레이어와 접촉했을경우 몬스터 이동을 잠시 멈춰준다.
        {
            stop = true;
            StartCoroutine("ReChase");
        }
    }

    public bool CallLeft()
    {
        return getLeft();
    }

    IEnumerator ReChase()
    {
        yield return new WaitForSeconds(3); 
        stop = false;
    }
}

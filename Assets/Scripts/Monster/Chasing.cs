using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasing : MonsterLogic {
    public SpriteRenderer MonsterRenderer;
    bool Stop = false;

    private void Start()
    {
        MonsterRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (Player.transform.position.x - transform.position.x < ICOUNT_LEGNTH)
        {
            if(Stop == false)
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
        if(Player.transform.position.x > this.transform.position.x)
        {
            transform.Translate(Vector2.right * 0.1f);
            MonsterRenderer.flipX = false;
        }
        else
        {
            transform.Translate(Vector2.left * 0.1f);
            MonsterRenderer.flipX = true;
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
        if(other.gameObject.tag == "Player")
        {
            Stop = true;
            StartCoroutine("ReCase");
        }
    }

    public bool CallLeft()
    {
        return getLeft();
    }

    IEnumerator ReChase()
    {
        yield return new WaitForSeconds(3);
        Stop = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corn : MonsterLogic {
    public SpriteRenderer CornRenderer;

    private void Start()
    {
        CornRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (Player.transform.position.x - transform.position.x < ICOUNT_LEGNTH)
        {
            Follow();
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
            CornRenderer.flipX = false;
        }
        else
        {
            transform.Translate(Vector2.left * 0.1f);
            CornRenderer.flipX = true;
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
    }

    public bool CallLeft()
    {
        return getLeft();
    }
}

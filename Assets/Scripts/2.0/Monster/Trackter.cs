using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trackter : MonsterLogic2 {
    public bool crashed;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall")
            StartCoroutine("Crash");
    }

    IEnumerator Crash()
    {
        crashed = true;
        if (left == true)
            left = false;
        else
            left = true;
        yield return new WaitForSeconds(1.5f);
        crashed = false;
    }

    override protected void Move()
    {
        if (crashed == true)
            return;

        if (left == true)
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
}

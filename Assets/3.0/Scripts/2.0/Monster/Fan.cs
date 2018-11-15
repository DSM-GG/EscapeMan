using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : Shoot
{

    protected override void Update()
    {
        base.Update();
        PlayAnimation(isIncount);
    }

    void PlayAnimation(bool incount)
    {
        animator.SetBool("isIncount", incount);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Character character = other.gameObject.GetComponent<Character>();
            character.Damaged(20);
        }

        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Platform")
        {
            if (left == true)
                left = false;
            else
                left = true;
        }
    }
}
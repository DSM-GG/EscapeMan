using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenRobot : MonsterLogic
{
<<<<<<< HEAD
    // Update is called once per frame
=======
    Animator animator;
    // Update is called once per frame
    protected void Start()
    {
        animator = GetComponent<Animator>();
    }
>>>>>>> 29212966ad344bd181d831b991539183138bc341
    protected void FixedUpdate()
    {
        if (Player.transform.position.x - transform.position.x < ICOUNT_LEGNTH)
        {
            incount = true;
        }
        else
        {
            incount = false;
            Move();
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

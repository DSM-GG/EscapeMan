using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonsterLogic2
{
    public bool attackedPlayer = false;
    public GameObject LeftObser;
    public GameObject RightObser;

    private void Update()
    {
        PlayerCheck();
        Chasing();
    }

    void PlayerCheck()
    {
        if (LeftObser.GetComponent<Observer>().Incount == true)
        {
            left = true;
        }
        else if (RightObser.GetComponent<Observer>().Incount == false)
        {
            left = false;
        }
    }

    void Chasing()
    {
        if (attackedPlayer == true)
            return;
        if (Lincount == true)
        {
            spriteRenderer.flipX = true;
            transform.position += vecLeft;
        }
        else if (Rincount == true)
        {
            spriteRenderer.flipX = false;
            transform.position += vecRight;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
            attackedPlayer = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
            attackedPlayer = false;
    }
}

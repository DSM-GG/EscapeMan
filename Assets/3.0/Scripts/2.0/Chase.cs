using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonsterLogic2
{
    public bool attackedPlayer = false;
    public GameObject LeftObser;
    public GameObject RightObser;
    public float Damage = 20;

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
        else if (RightObser.GetComponent<Observer>().Incount == true)
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            attackedPlayer = true;
            other.gameObject.GetComponent<Character>().Damaged(Damage);
        }
            
        else if(other.gameObject.tag == "Platform")
        {
            if (left == true)
            {
                left = false;
            }
            else if (left == false)
            {
                left = true;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
            attackedPlayer = false;
    }
}

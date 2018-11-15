using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tire : MonsterLogic2
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Character character = other.gameObject.GetComponent<Character>();
            character.Damaged(10);
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
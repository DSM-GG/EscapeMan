﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour {
    public float groundDist = 0.07f;
    Vector3 v;
    Movement movement;
    float height;
    float minus = 0.1f;
    float minus2 = 0.05f;

    private void Start()
    {
        v = new Vector3();
        movement = GetComponent<Movement>();
        height = GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    private void Update()
    {
        GroundCheck();
        LadderCheck();
        
    }

    // 캐릭터의 양 쪽 끝에 달린 레이캐스트로 땅에 있는지 감지
    void GroundCheck()
    {
        // 캐릭터가 현재 사다리를 오르고 있다면 레이캐스트 X
        if (movement.IsClimbing())
        {
            // movement.SetGrounded(false);
            return;
        }

        float te = transform.localScale.x / 10;
        RaycastHit2D[] hit;

        v.Set(transform.position.x - te, transform.position.y, transform.position.z);
        hit = Physics2D.RaycastAll(v, Vector2.down, groundDist);

        bool bSum = false;

        foreach (RaycastHit2D elem in hit)
        {
            // y축에 대한 캐릭터의 속도가 0이고 플랫폼에 닿아있는 상태면 
            if (elem.transform.tag == "Platform" && transform.GetComponentInParent<Rigidbody2D>().velocity.y == 0)
            { 
                bSum = true;
                break;
            }
        }

        v.Set(transform.position.x + te, transform.position.y, transform.position.z);
        hit = Physics2D.RaycastAll(v, Vector2.down, groundDist);

        foreach (RaycastHit2D elem in hit)
        {
            // y축에 대한 캐릭터의 속도가 0이고 플랫폼에 닿아있는 상태면 
            if (elem.transform.tag == "Platform" && transform.GetComponentInParent<Rigidbody2D>().velocity.y == 0)
            {
                bSum = true;
                break;
            }
        }
        movement.SetGrounded(bSum);
    }

    void LadderCheck()
    {
        // if (!movement.IsGrounded()) return;
        RaycastHit2D[] hit;
        bool temp = false;
        float tempX = 0.0f;

        // down
        v.Set(transform.position.x, transform.position.y /*+ height*/, transform.position.z);
        hit = Physics2D.RaycastAll(v, Vector2.down, (groundDist * 2));
        foreach (RaycastHit2D elem in hit)
        {
            if (elem.transform.tag == "Ladder")
            {
                tempX = elem.transform.position.x;
                temp = true;
            }
        }
        movement.SetDownLadder(temp, tempX);

        temp = false;

        // up
        v.Set(transform.position.x, transform.position.y - height, transform.position.z);
        hit = Physics2D.RaycastAll(v, Vector2.up, (groundDist * 2));
        foreach (RaycastHit2D elem in hit)
        {
            if (elem.transform.tag == "Ladder")
            {
                tempX = elem.transform.position.x;
                temp = true;
            }
        }
        movement.SetUpLadder(temp, tempX);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Vector3 temp = transform.position;
        // UP
        temp.Set(temp.x, temp.y - height, temp.z);
        Gizmos.DrawRay(temp, Vector2.up * ( groundDist * 2) );

        // Down
        temp.Set(temp.x, transform.position.y , temp.z);
       // Gizmos.DrawRay(temp, Vector2.down * ( groundDist * 2) );
    }

}

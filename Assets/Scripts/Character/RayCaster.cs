using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour {

    
    public float groundDist = 0.07f;

    private void Update()
    {
        RaycastHit2D[] hit;
        hit = Physics2D.RaycastAll(transform.position, Vector2.down, groundDist);

        foreach (RaycastHit2D elem in hit)
        {
            // y축에 대한 캐릭터의 속도가 0이고 플랫폼에 닿아있는 상태면 
            if (elem.transform.tag == "Platform" && transform.GetComponentInParent<Rigidbody2D>().velocity.y == 0)
            {
                // 땅에 닿아있는 판정 수행
                GetComponent<Movement>().SetGrounded(true);
                break;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, Vector2.down * groundDist);
    }

}

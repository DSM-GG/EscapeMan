using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour {
    public float groundDist = 0.07f;
    Vector3 v;

    private void Start()
    {
        v = new Vector3();
    }

    private void Update()
    {
        GroundCheck();
        
    }

    // 캐릭터의 양 쪽 끝에 달린 레이캐스트로 땅에 있는지 감지
    void GroundCheck()
    {
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
                bSum = bSum | true;
                break;
            }
            else
                bSum = bSum | false;
        }

        v.Set(transform.position.x + te, transform.position.y, transform.position.z);
        hit = Physics2D.RaycastAll(v, Vector2.down, groundDist);

        foreach (RaycastHit2D elem in hit)
        {
            // y축에 대한 캐릭터의 속도가 0이고 플랫폼에 닿아있는 상태면 
            if (elem.transform.tag == "Platform" && transform.GetComponentInParent<Rigidbody2D>().velocity.y == 0)
            {
                bSum = bSum | true;
                break;
            }
            else
                bSum = bSum | false;
        }
        GetComponent<Movement>().SetGrounded(bSum);
    }

    private void OnDrawGizmos()
    {
        float te = transform.localScale.x / 10;
        Vector3 asd = new Vector3(transform.position.x - te, transform.position.y, transform.position.z);
        Gizmos.DrawRay(asd, Vector2.down * groundDist);  
        asd = new Vector3(transform.position.x + te, transform.position.y, transform.position.z);
        Gizmos.DrawRay(asd, Vector2.down * groundDist);
    }

}

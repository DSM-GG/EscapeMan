using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCaster : MonoBehaviour {

    
    public float groundDist = 0.2f;

    private void Update()
    {
        RaycastHit2D[] hit;
        hit = Physics2D.RaycastAll(transform.position, Vector2.down, groundDist);

        foreach (RaycastHit2D elem in hit)
        {
            if (elem.transform.tag == "Platform")
            {
                GetComponent<Movement>().SetGrounded(true);
                break;
            }
        }
    }

}

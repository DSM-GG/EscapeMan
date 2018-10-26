using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour {

    bool bSum = true;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponentInParent<Movement>().SetGrounded(bSum);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bSum = false;

        Debug.Log("asd");
        if (collision.tag == "Platform" && transform.GetComponentInParent<Rigidbody2D>().velocity.y == 0)
        {
            Debug.Log("Grounded");
            bSum = bSum | true;
        }
        else
        {
            bSum = bSum | false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        bSum = false;

        Debug.Log("asd");
        if (collision.tag == "Platform" && transform.GetComponentInParent<Rigidbody2D>().velocity.y == 0)
        {
            Debug.Log("Grounded");
            bSum = bSum | true;
        }
        else
        {
            bSum = bSum | false;
        }
    }
}

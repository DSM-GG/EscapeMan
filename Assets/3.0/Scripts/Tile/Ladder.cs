using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour {
    // Use this for initialization

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Check");
            // 여기 수정할 것
            collision.GetComponent<Movement>().SetLadder(true, collision.transform.position.x);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Exit");
            collision.GetComponent<Movement>().SetLadder(false, 0);
        }
    }
}

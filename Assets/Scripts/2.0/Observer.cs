using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour {
    public bool isLeft;
    public bool isRight;
    public bool Incount;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Incount = true;
            
            if (isLeft == true)
            {
                isLeft = true;
                isRight = false;
            }
                
            else if (isRight == true)
            {
                isLeft = false;
                isRight = true;
            }
        }

        Debug.Log(Oleft);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        Incount = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour {
    public bool Incount;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Incount = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Incount = false;
    }
}

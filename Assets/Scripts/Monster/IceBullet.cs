using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBullet : MonoBehaviour {
    bool isBroken;

    private void Start()
    {
        isBroken = false;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        isBroken = true;
        Destroy(this.gameObject);
    }
}

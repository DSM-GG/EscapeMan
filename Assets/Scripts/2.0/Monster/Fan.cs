using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : Shoot {

    protected override void Update () {
        base.Update();
        PlayAnimation(isIncount);
	}

    void PlayAnimation(bool incount)
    {
        animator.SetBool("isIncount", incount);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonsterLogic2
{
    private void Update()
    {
        IsClose(Vector2.Distance(transform.position, player.gameObject.transform.position));
        Chasing(isIncount);
    }

    void IsClose(float dis)
    {
        if (dis <= incountLength)
            isIncount = true;
    }

    void Chasing(bool isIncount)
    {
        if(isIncount == false)
            return;

        if(playerIsLeft == false)
            left = false;
        else
            left = true;
    }
}

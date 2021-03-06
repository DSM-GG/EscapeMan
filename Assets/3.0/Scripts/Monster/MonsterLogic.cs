﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLogic : MonoBehaviour {
    public GameObject Player;
    public bool incount;
    SpriteRenderer renderer;
    protected const int ICOUNT_LEGNTH = 2;
    protected bool left { get; set; } // 벽에 부딫혔을 때 이동방향을 정해줌.
               // Use this for initialization

    private void Awake()
    {
        Player = GameObject.Find("RockMan");
        renderer = GetComponent<SpriteRenderer>();
        left = false;
    }
    
    protected void Move() // 순찰
    {
        if (left == true)
        {
            renderer.flipX = true;
            transform.Translate(Vector2.left * 0.1f);
        }
        else
        {
            renderer.flipX = false;
            transform.Translate(Vector2.right * 0.1f);
        }
    }

    protected bool getLeft()
    {
        return left;
    }
    
}

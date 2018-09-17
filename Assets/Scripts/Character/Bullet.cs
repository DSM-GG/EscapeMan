﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int type;
    public float bullet_speed;

    Rigidbody2D rb;

	// Use this for initialization
	void Awake () {
        rb = GetComponent<Rigidbody2D>();
	}

    public void Move(Vector2 dir, Vector3 pos)
    {
        transform.position = new Vector3(pos.x + dir.x * 0.3f, pos.y, pos.x);
        gameObject.SetActive(true);
        rb.AddForce(dir * bullet_speed, ForceMode2D.Impulse);
    }

}
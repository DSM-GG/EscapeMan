using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEg : MonoBehaviour {
    public GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(player.transform.position.x > transform.position.x)
        {
            transform.position = new Vector2(0.1f, 0);
        }
        else
        {
            transform.position = new Vector2(-0.1f, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}

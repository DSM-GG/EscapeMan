using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject player;
    public float minHeight;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        IsFalling();
	}

    void IsFalling()
    {
        if (player.transform.position.y < minHeight)
            Destroy(player); // 추후 씬을 다시 로드할 것.
    }

}

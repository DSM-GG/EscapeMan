using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearDetector : MonoBehaviour {

    string stgName;

	// Use this for initialization
	void Start () {
        stgName = SceneManager.GetActiveScene().name;
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //GameObject.Find("Manager").GetComponent<GameManager>().Game
        }
    }

}

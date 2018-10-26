using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCode : MonoBehaviour {

    Character character;

 
	// Use this for initialization
	void Start () {
        character = GetComponent<Character>();
	}
	
	// Update is called once per frame
	void Update () {
        Test_Damaged();	
	}

    void Test_Damaged()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            character.Damaged(1);
        }
    }

}

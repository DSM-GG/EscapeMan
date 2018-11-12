using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCode : MonoBehaviour {

    Character character;
    Character_UI characterUI;
 
	// Use this for initialization
	void Start () {
        character = GetComponent<Character>();
        characterUI = GetComponent<Character_UI>();

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
            characterUI.ApplyChanges();
        }
    }

}

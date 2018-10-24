using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    // Character 클래스에서 모든 부속 클래스의 값들을 조정한다. 
    
    Movement movement; 
    Attack attack;

    public float hp;
    public float life;
    public float damage;
    public float speed;
    public int status;
    public int score;
    public float jumpPower;     // 점프 크기 
    public float slidingPower;
    public float slidingCoolTime;

    // Use this for initialization
    void Start () {
        movement = GetComponent<Movement>();
        attack = GetComponent<Attack>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Damaged(float damage)
    {
        hp -= damage;

        if (hp <= 0)
        {

        }
    }
}

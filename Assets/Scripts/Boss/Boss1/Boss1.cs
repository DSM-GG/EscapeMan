using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonsterLogic2 {

    public float floatSpeed;
    public float moveSpeed;

    Vector3 scale;
    Vector3 AdditionPos;
    Vector3 MovingPos;
    float time = 0.0f;
    float dir;

	// Use this for initialization
	void Start () {
        AdditionPos = new Vector3(0, 0, 0);
        scale = new Vector3();
        MovingPos = new Vector3();
        player = GameObject.Find("RockMan");

        Flip();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    protected override void Move()
    {
        Floating();
        Moving();
    }

    protected override void Check()
    {
        Rincount = transform.GetChild(0).GetChild(0).gameObject.GetComponent<Observer>().Incount;
        Lincount = transform.GetChild(0).GetChild(1).gameObject.GetComponent<Observer>().Incount;

        if (Rincount == true || Lincount == true)
            isIncount = true;
        else
            isIncount = false;

        if (player.transform.position.x > transform.position.x)
            playerIsLeft = false;
        else
            playerIsLeft = true;

        //if (monsterHp <= 0)
        //    StartCoroutine("MonsterDying");
    }

    // 둥둥 떠다니는 이동을 위함
    void Floating()
    {
        time += Time.deltaTime * floatSpeed;
        float y = Mathf.Sin(time) * 0.02f;
        Debug.Log(y);
        AdditionPos.Set(0, y, 0);
        transform.position += AdditionPos;
    }

    void Moving()
    {

    }

    void Flip()
    {
        scale.Set(transform.localScale.x * -1, 1, 1);
        dir = transform.localScale.x;
        transform.localScale = scale;
    }
}

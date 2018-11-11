using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonsterLogic2 {

    public float floatSpeed;
    public float moveSpeed;

    public float moveCoolTime;
    public float bombCoolTime;
    public float missileCoolTime;

    WaitForSeconds wfs_missile, wfs_moving, wfs_bomb;

    Vector3 scale;
    Vector3 additionPos;
    Vector3 movingPos;
    float time = 0.0f;
    int dir = 1;

    float prevX = 0, nowX = 0;
    bool isMovingCool, isMissileCool, isBombCool;

	// Use this for initialization
	void Start () {
        additionPos = new Vector3(0, 0, 0);
        scale = new Vector3();
        movingPos = new Vector3();
        player = GameObject.Find("RockMan");

        wfs_missile = new WaitForSeconds(missileCoolTime);
        wfs_moving = new WaitForSeconds(moveCoolTime);
        wfs_bomb = new WaitForSeconds(bombCoolTime);

        nowX = transform.position.x;
        isMovingCool = isMissileCool = isBombCool = false;

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
    }

    // 둥둥 떠다니는 이동을 위함
    void Floating()
    {
        time += Time.deltaTime * floatSpeed;
        float y = Mathf.Sin(time) * 0.02f;
        Debug.Log(y);
        additionPos.Set(0, y, 0);
        transform.position += additionPos;
    }

    void Moving()
    {
        if (isMovingCool) return;
        nowX = transform.position.x;

        if(prevX == nowX)
        {
            StartCoroutine("MovingCool");
        }

        movingPos.Set(moveSpeed * dir, 0, 0);
        transform.position += movingPos;
        prevX = nowX;
    }
        
    void Flip()
    {
        scale.Set(transform.localScale.x * -1, 1, 1);
        transform.localScale = scale;
        dir = (int)transform.localScale.x;
    }

    IEnumerator MovingCool()
    {
        Flip();
        isMovingCool = true;
        yield return wfs_moving;
        isMovingCool = false;
    }

    IEnumerator BombCool()
    {
        yield return wfs_bomb;
    }

    IEnumerator MissileCool()
    {
        yield return wfs_missile;
    }
}

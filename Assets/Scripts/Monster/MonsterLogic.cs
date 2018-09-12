using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLogic : MonoBehaviour {
    public GameObject Player;
    bool left; // 벽에 부딫혔을 때 이동방향을 정해줌.
	// Use this for initialization
	void Start () {
        left = false;
	}

    // Update is called once per frame
    void Update () {
        if(Player.transform.position.x - transform.position.x < 10)
        {
            Incount();
        }
        else
        {
            Move();
        }
	}

    void Move() // 순찰
    {
        if(left == true)
        {
            this.transform.localScale = new Vector3(-1.5f, 0, 0);
            transform.Translate(Vector2.left * 0.1f);
        }
        else
        {
            this.transform.localScale = new Vector3(1.5f, 0, 0);
            transform.Translate(Vector2.right * 0.1f);
        }
    }
    void Incount() // 플레이어가 인접했을 때
    {
        if(Player.transform.position.x > this.transform.position.x)
        {
            this.transform.localScale = new Vector3(1.5f, 0, 0);
            transform.Translate(Vector2.right * 0.1f);
        }
        else
        {
            this.transform.localScale = new Vector3(-1.5f, 0, 0);
            transform.Translate(Vector2.left * 0.1f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Wall") // 벽의 콜리전을 닿았을 때를 기준으로 방향을 바꿔준다. 초나 거리를 기준으로 바꾸고싶으면 수정.
        {
            if(left == true)
            {
                left = false;
            }
            else
            {
                left = true;
            }
        }
    }
}

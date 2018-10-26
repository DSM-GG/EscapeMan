using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    // Character 클래스에서 모든 부속 클래스의 값들을 조정한다. 

    const int FADE_CNT = 10;

    Movement movement; 
    Attack attack;
    SpriteRenderer sr;

    public float fade_sec;
    public float hp;
    public float life;
    public float damage;
    public float speed;
    public float ladderSpeed;
    public int status;
    public int score;
    public float jumpPower;     // 점프 크기 
    public float slidingPower;
    public float slidingCoolTime;

    WaitForSeconds wfs;
    Color fadeIn, fadeOut;

    // Use this for initialization
    void Start () {
        movement = GetComponent<Movement>();
        attack = GetComponent<Attack>();
        sr = GetComponent<SpriteRenderer>();
        wfs = new WaitForSeconds(fade_sec);
        fadeIn = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        fadeOut = new Color(1.0f, 1.0f, 1.0f, 0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Damaged(float damage)
    {
        hp -= damage;

        if (hp <= 0)
        {

        }

        StartCoroutine("Fade");
    }

    IEnumerator Fade()
    {
        int cnt = 0;
        while (cnt <= FADE_CNT)
        {
            // 흐려짐
            sr.color = fadeOut;
            Debug.Log(fadeOut);

            yield return wfs;

            // 진해짐
            sr.color = fadeIn;
            Debug.Log(fadeIn);
        
            yield return wfs;

            ++cnt;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {
    // Character 클래스에서 모든 부속 클래스의 값들을 조정한다. 
    const int FADE_CNT = 10;

    Movement movement; 
    Attack attack;
    SpriteRenderer sr;
    Character_UI character_UI;
    bool Isinvincibility = false;

    public float fade_sec;
    public float damage;
    public float speed;
    public float ladderSpeed;
    public int status;
    public int score;
    public float jumpPower;     // 점프 크기 
    public float slidingPower;
    public float slidingCoolTime;

    public float hpMax;
    public float hp;

    WaitForSeconds wfs;
    Color fadeIn, fadeOut;

    // Use this for initialization
    void Start () {
        movement = GetComponent<Movement>();
        attack = GetComponent<Attack>();
        sr = GetComponent<SpriteRenderer>();
        character_UI = GetComponent<Character_UI>();

        hp = hpMax;

        fadeIn = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        fadeOut = new Color(1.0f, 1.0f, 1.0f, 0.5f);
        wfs = new WaitForSeconds(fade_sec);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Damaged(float damage)
    {
        if (Isinvincibility)
            return;

        hp -= damage;
        if (hp <= 0)
            Die();

        character_UI.ApplyChanges();
        StartCoroutine("Fade");
    }

    void Die()
    {

    }

    IEnumerator Fade()
    {
        Isinvincibility = true;
        int cnt = 0;
        while (cnt <= FADE_CNT)
        {
            // 흐려짐
            sr.color = fadeOut;
            yield return wfs;

            // 진해짐
            sr.color = fadeIn;
            yield return wfs;

            ++cnt;
        }
        Isinvincibility = false;
    }
}

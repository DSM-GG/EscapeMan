using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int type;
    public float bullet_speed;
    public float bullet_damage;
    public float bullet_Distance;
    public WaitForSeconds bullet_Wait_second;

    private const float BULLET_MAX_TIME = 1.5f;
    private Animator animator;

    float originX;

    Character character;

    Rigidbody2D rb;

	// Use this for initialization
	void Awake () {
        animator = GetComponent<Animator>();
        bullet_Wait_second = new WaitForSeconds(BULLET_MAX_TIME);
        rb = GetComponent<Rigidbody2D>();
        character = GetComponent<Character>();
        originX = gameObject.transform.position.x;
    }

    //private void Update()
    //{

    //}

    public void Move(Vector2 dir, Vector3 pos)
    {
        gameObject.SetActive(true);
        rb.simulated = true;
        //originX = gameObject.transform.position.x;
        transform.position = new Vector3(pos.x + dir.x * 0.3f, pos.y, pos.x);
        rb.AddForce(dir * bullet_speed, ForceMode2D.Impulse);
        StartCoroutine("BulletTimer");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            collision.GetComponent<MonsterLogic2>().Damaged(bullet_damage);
            StopCoroutine("BulletTimer");
            HitAnim();
        }
        else if(collision.tag == "Platform")
        {
            HitAnim();
        }
    }

    void HitAnim()
    {
        rb.simulated = false;
        animator.SetTrigger("hitted");
    }

    void Deactive()
    {
        gameObject.SetActive(false);
    }

    // 시간을 재서 총알을 끄는 코루틴
    IEnumerator BulletTimer()
    {
        yield return bullet_Wait_second;
        gameObject.SetActive(false);
    }

}

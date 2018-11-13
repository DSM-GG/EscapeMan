using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Missile : MonoBehaviour {

    public float speed;
    public float damage;
    public float range;
    public Sprite missileSprite;

    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator animator;
    private float prevX, prevY, nowX, nowY;
    private Vector3 rotV;
    private Vector3 deltaV;
    private int direction;
    private float angle;

    // Use this for initialization
    void Awake () {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rotV = new Vector3();
        deltaV = new Vector3();
        angle = 0;

    }
	
	// Update is called once per frame
	void Update () {
        ChangeRot();
	}

    void ChangeRot()
    {
        nowX = transform.position.x;
        nowY = transform.position.y;

        float dx = nowX - prevX;
        float dy = nowY - prevY;

        deltaV.Set(dx, dy, 0);
        deltaV.Normalize();
        Vector2 temp = new Vector2(direction, 0);
        angle += Vector2.Dot(deltaV, temp);
        rotV.Set(0, 0, angle);
        transform.rotation = Quaternion.Euler(rotV);
    }

    public void Fly(Vector3 launcherPos, Vector2 angle, int dir)
    {
        direction = dir;
        gameObject.SetActive(true);
        transform.position = launcherPos;
        rb.AddForce(angle * speed, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Platform" || collision.tag == "Player")
        {
            Boom();
        }
    }

    void Boom()
    {
        rb.simulated = false;

        animator.SetTrigger("Boom");
        Collider2D[] nearObj = Physics2D.OverlapCircleAll(transform.position, range);
        for (int i = 0; i < nearObj.Length; ++i)
        {
            if (nearObj[i].tag == "Player")
            {
                nearObj[i].GetComponent<Character>().Damaged(damage);
            }
        }
    }

    void Deactive()
    {
        sr.sprite = missileSprite;
        rb.simulated = true;
        gameObject.SetActive(false);
    }

    void Active()
    {
        gameObject.SetActive(true);
    }

    //void ChangeRot(Vector2 fireVec)
    //{
    //    float angle;
    //    angle = Vector2.Dot(fireVec, Vector2.right * transform.parent.localScale.x);
    //    rotV.Set(0, angle, 0);
    //    transform.rotation = Quaternion.Euler(rotV);
    //}
}

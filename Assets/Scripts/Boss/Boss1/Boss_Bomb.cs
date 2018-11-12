using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Bomb : MonoBehaviour {

    private SpriteRenderer sr;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 velocity;

    public Sprite bombSprite;
    public float damage;
    public float bombSpeed;
    public float range;

	// Use this for initialization
	void Awake () {
        velocity = new Vector2();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Shoot(float power, Vector3 cannonPos)
    {
        Active();
        velocity.Set(power * bombSpeed, 0);
        transform.position = cannonPos;
        rb.AddForce(velocity, ForceMode2D.Impulse);
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
        for(int i = 0; i < nearObj.Length; ++i)
        {
            if(nearObj[i].tag == "Player")
            {
                nearObj[i].GetComponent<Character>().Damaged(damage);
            }
        }
    }

    void Deactive()
    {
        sr.sprite = bombSprite;
        rb.simulated = true;
        gameObject.SetActive(false);
    }

    void Active()
    {
        gameObject.SetActive(true);
    }
}
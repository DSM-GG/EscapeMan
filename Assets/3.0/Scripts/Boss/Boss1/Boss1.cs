using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : MonsterLogic2
{ 
    public float floatSpeed;
    public float moveSpeed;

    public float moveCoolTime;
    public float crashDamage;

    private WaitForSeconds wfs_missile, wfs_moving, wfs_bomb;
    private WaitForSeconds wfs_fade;
    private SpriteRenderer sr;

    private Vector3 scale;
    private Vector3 additionPos;
    private Vector3 movingPos;
    private Color fadeIn, fadeOut;
    private float time = 0.0f;
    private int dir = 1;

    private float prevX = 0, nowX = 0;
    private bool isMovingCool;
    private bool isClose = false;
    private bool isDie = false;

    private const float FADE_TIME = 0.1f;
    private const int FADE_CNT = 10;

    // Use this for initialization
    void Awake()
    {
        additionPos = new Vector3(0, 0, 0);
        scale = new Vector3();
        movingPos = new Vector3();
        player = GameObject.Find("RockMan");
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        wfs_moving = new WaitForSeconds(moveCoolTime);
        wfs_fade = new WaitForSeconds(FADE_TIME);

        fadeIn = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        fadeOut = new Color(1.0f, 1.0f, 1.0f, 0.5f);
        

        nowX = transform.position.x;
        isMovingCool = false;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void Start()
    {
        Flip();
    }

    protected override void Move()
    {
        Floating();                                  
        Moving();
    }

    protected override void Check()
    {
    }
    
    public override void Damaged(float dmg)
    {
        monsterHp -= dmg;
        StartCoroutine("Fade");
        if (monsterHp <= 0)
        {
            isDie = true;
            for (int i = 0; i < 5; ++i)
            {
                if(i < transform.childCount && transform.GetChild(i) != null)
                    Destroy(transform.GetChild(i).gameObject);
            }
            animator.SetTrigger("die");
        }
    }

    // 둥둥 떠다니는 이동을 위함
    void Floating()
    {
        if (isDie) return;

        time += Time.deltaTime * floatSpeed;
        float y = Mathf.Sin(time) * 0.02f;
        additionPos.Set(0, y, 0);
        transform.position += additionPos;
    }

    void Moving()
    {
        if (isMovingCool || isDie) return;

        movingPos.Set(moveSpeed * dir, 0, 0);
        transform.position += movingPos;
    }

    void Flip()
    {
        scale.Set(transform.localScale.x * -1, 1, 1);
        transform.localScale = scale;
        dir = (int)transform.localScale.x;
    }

    void Die()
    {
        Destroy(gameObject);
    }

    IEnumerator MovingCool()
    {
        isMovingCool = true;
        yield return wfs_moving;
        isMovingCool = false;
    }

    IEnumerator Fade()
    {
        int cnt = 0;
        while (cnt <= FADE_CNT)
        {
            // 흐려짐
            sr.color = fadeOut;
            yield return wfs_fade;

            // 진해짐
            sr.color = fadeIn;
            yield return wfs_fade;

            ++cnt;
        }
    }

    public int GetDir()
    {
        return dir;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Character>().Damaged(crashDamage);
        }
        else if (collision.gameObject.tag == "Platform")
        {
            if (!isClose)
            {
                StartCoroutine("MovingCool");
                isClose = true;
                Flip();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            if (isClose)
            {
                isClose = false;
            }
        }
    }
}
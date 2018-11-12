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

    private Vector3 scale;
    private Vector3 additionPos;
    private Vector3 movingPos;
    private float time = 0.0f;
    private int dir = 1;

    private float prevX = 0, nowX = 0;
    private bool isMovingCool;
    private bool isClose = false;

    // Use this for initialization
    void Awake()
    {
        additionPos = new Vector3(0, 0, 0);
        scale = new Vector3();
        movingPos = new Vector3();
        player = GameObject.Find("RockMan");

        wfs_moving = new WaitForSeconds(moveCoolTime);

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

    // 둥둥 떠다니는 이동을 위함
    void Floating()
    {
        time += Time.deltaTime * floatSpeed;
        float y = Mathf.Sin(time) * 0.02f;
        additionPos.Set(0, y, 0);
        transform.position += additionPos;
    }

    void Moving()
    {
        if (isMovingCool) return;

        movingPos.Set(moveSpeed * dir, 0, 0);
        transform.position += movingPos;
    }

    void Flip()
    {
        scale.Set(transform.localScale.x * -1, 1, 1);
        transform.localScale = scale;
        dir = (int)transform.localScale.x;
    }

    IEnumerator MovingCool()
    {
        isMovingCool = true;
        yield return wfs_moving;
        isMovingCool = false;
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
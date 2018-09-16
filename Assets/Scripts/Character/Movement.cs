using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public float moveSpeed;     // 이동 속도
    public float jumpPower;     // 점프 크기 
    public Vector3 direction;

    Animator animator;          
    SpriteRenderer sr;          
    Rigidbody2D rb;            

    bool isJumped = false;      // 캐릭터의 점프 상태 

	// Use this for initialization
	void Awake () {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        direction = new Vector3();

    }
	
	// Update is called once per frame
	void Update () {
        Jump();
        InputMovement();
	}

    void InputMovement()
    {
        // <- 이동
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = Vector3.left;
            sr.flipX = true;                        // 스프라이트 방향을 왼쪽으로 돌린다
            animator.SetBool("isWalking", true);    // 애니메이션 실행

            // 위에서 정해진 방향으로 속도를 곱하여 위치 값을 변화시킨다.
            Vector3 v = new Vector3(direction.x * moveSpeed * Time.deltaTime, 0, 0);
            transform.position += v;
        }
        // -> 이동
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            direction = Vector3.right;
            sr.flipX = false;                       // 스프라이트 방향을 오른쪽으로 돌린다.
            animator.SetBool("isWalking", true);    // 애니메이션 실행

            // 위에서 정해진 방향으로 속도를 곱하여 위치 값을 변화시킨다.
            Vector3 v = new Vector3(direction.x * moveSpeed * Time.deltaTime, 0, 0);
            transform.position += v;
        }
        // 이동 X
        else
        {
            animator.SetBool("isWalking", false);   // 애니메이션 종료
        }


    }

    void Jump()
    {
        // 점프해서 착지했다면 
        if (rb.velocity.y == 0)
        {
            isJumped = false;   // 점프 확인 변수 = false
        }

        // 스페이스바 입력시
        if (Input.GetKeyDown(KeyCode.Space) && !isJumped)
        {
            animator.SetTrigger("jumpTrigger");                     // 애니메이션 실행
            isJumped = true;                                        // 점프 확인 변수 = true
            Vector2 jumpVector = new Vector2(0, 1 * jumpPower);     // 점프 크기 지정 
            rb.AddForce(jumpVector, ForceMode2D.Impulse);           // 점프 수행
        }
    }
}
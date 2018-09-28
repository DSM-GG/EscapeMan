using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    float moveSpeed;            // 이동 속도
    float jumpPower;            // 점프 크기 
    float slidingPower;         // 슬라이딩 크기
    public Vector3 direction;

    bool isGrounded = true;     // 착지 상태
    bool isJumped = false;      // 캐릭터의 점프 상태 
    bool isSliding = false;     // 캐릭터의 슬라이딩 상태

    bool isSlideCool = false;

    Animator animator;          
    SpriteRenderer sr;          
    Rigidbody2D rb;
    Character character;

	// Use this for initialization
	void Awake () {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        direction = new Vector3();
        character = GetComponent<Character>();

        moveSpeed = character.speed;
        jumpPower = character.jumpPower;
        slidingPower = character.slidingPower;
    }
	
	// Update is called once per frame
	void Update () {
        Jump();
        Sliding();
        InputMovement();
	}

    void InputMovement()
    {
        if (isSliding)
            return;

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
        if (isSliding)
            return;

        // 점프해서 착지했다면 
        if (isGrounded)
        {
            isJumped = false;   // 점프 확인 변수 = false
            animator.SetTrigger("isGrounded");
        }

        // 스페이스바 입력시
        if (Input.GetKeyDown(KeyCode.Space) && !isJumped && isGrounded)
        {
            isGrounded = false;
            animator.SetTrigger("jumpTrigger");                     // 애니메이션 실행
            isJumped = true;                                        // 점프 확인 변수 = true
            Vector2 jumpVector = new Vector2(0, 1 * jumpPower);     // 점프 크기 지정 
            rb.AddForce(jumpVector, ForceMode2D.Impulse);           // 점프 수행
        }
    }

    void Sliding()
    {
        // 현재 바라보고 있는 방향을 향해서
        // 슬라이딩을 한다.
        if(!isSliding && Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetTrigger("slidingTrigger");
            isSliding = true;
            Vector2 slideDir = new Vector2(direction.x * slidingPower, direction.y);
            rb.AddForce(slideDir, ForceMode2D.Impulse);
        }
        // 만약 슬라이딩 중 & 쿨타임을 안돌리고 있는 상황이면
        else if(isSliding & !isSlideCool)
        {
            // 쿨타임을 돌린다. 
            isSlideCool = true;
            StartCoroutine("SlideTimer");
        }
    }

    IEnumerator SlideTimer()
    {
        yield return new WaitForSeconds(0.5f);
        isSliding = false;
        isSlideCool = false;
        animator.ResetTrigger("SlidingTrigger");
    }

    public bool GetGrounded()
    {
        return isGrounded;
    }

    public void SetGrounded(bool val)
    {
        isGrounded = val;
    }
}
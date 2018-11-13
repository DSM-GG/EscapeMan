using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    float moveSpeed;            // 이동 속도
    float jumpPower;            // 점프 크기 
    float slidingPower;         // 슬라이딩 크기
    float ladderSpeed;          // 사다리 오르는 속도
    public Vector3 direction;

    bool isClimbing = false;
    bool isGrounded = false;     // 착지 상태
    bool isJumped = false;      // 캐릭터의 점프 상태 
    bool isSliding = false;     // 캐릭터의 슬라이딩 상태
    bool isUpLadder = false;
    bool isDownLadder = false;
    bool isSlideCool = false;

    Animator animator;
    SpriteRenderer sr;
    Rigidbody2D rb;
    Character character;
    Attack attack;

    Vector3 ladder_velocity;
    float ladderPosX;

    // Use this for initialization
    void Awake() {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        character = GetComponent<Character>();
        attack = GetComponent<Attack>();

        direction = new Vector3();
        ladder_velocity = new Vector3();

        ladderSpeed = character.ladderSpeed;
        moveSpeed = character.speed;
        jumpPower = character.jumpPower;
        slidingPower = character.slidingPower;

        animator.ResetTrigger("isGrounded");

        direction = Vector3.right;
    }

    // Update is called once per frame
    void Update() {
        Jump();
        Sliding();
        InputMovement();
    }

    void InputMovement()
    {
        // 슬라이딩 중에는 이동 입력 X
        if (isSliding)
            return;

        // <- 이동
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            direction = Vector3.left;
            sr.flipX = true;                        // 스프라이트 방향을 왼쪽으로 돌린다
            animator.SetBool("isWalking", true);    // 애니메이션 실행


            // 사다리를 오르고 있는 상태라면 좌우 이동을 무시한다.
            if (isClimbing) return;

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

            // 사다리를 오르고 있는 상태라면 좌우 이동을 무시한다.
            if (isClimbing) return;

            // 위에서 정해진 방향으로 속도를 곱하여 위치 값을 변화시킨다.
            Vector3 v = new Vector3(direction.x * moveSpeed * Time.deltaTime, 0, 0);
            transform.position += v;
        }
        // 사다리 위로 이동
        else if (isUpLadder && Input.GetKey(KeyCode.UpArrow))
        {
            isClimbing = true;
            // rigidbody2D의 중력을 잠시 꺼둔다.
            rb.isKinematic = true;
            ladder_velocity.y = ladderSpeed * 1;
            transform.position.Set(ladderPosX, transform.position.y, transform.position.z);

            animator.SetBool("isClimbing", true);
            transform.position += ladder_velocity;
        }
        // 사다리 아래로 이동
        else if (isDownLadder && Input.GetKey(KeyCode.DownArrow))
        {
            isClimbing = true;
            // rigidbody2D의 중력을 잠시 꺼둔다.
            rb.isKinematic = true;
            ladder_velocity.y = ladderSpeed * -1;
            transform.position.Set(ladderPosX, transform.position.y, transform.position.z);

            animator.SetBool("isClimbing", true);
            transform.position += ladder_velocity;
        }
        else
        {
            animator.SetBool("isClimbing", false);
            animator.SetBool("isWalking", false);   // 애니메이션 종료
        }
    }

    void Jump()
    {
        if (isSliding)
            return;
;
        // 점프해서 착지했다면 
        if (isGrounded && isJumped)
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
        if (isClimbing) return;
        // 현재 바라보고 있는 방향을 향해서
        // 슬라이딩을 한다.
        if (!isSliding && Input.GetKeyDown(KeyCode.LeftShift))
        {
            animator.SetTrigger("slidingTrigger");
            isSliding = true;
            Vector2 slideDir = new Vector2(direction.x * slidingPower, direction.y);
            rb.AddForce(slideDir, ForceMode2D.Impulse);
        }
        // 만약 슬라이딩 중 & 쿨타임을 안돌리고 있는 상황이면
        else if (isSliding & !isSlideCool)
        {
            // 쿨타임을 돌린다. 
            isSlideCool = true;
            StartCoroutine("SlideTimer");
        }
    }

    IEnumerator SlideTimer()
    {
        yield return new WaitForSeconds(0.5f);
        // 슬라이딩 시간이 지난 후, 쿨타임을 초기화 한다.
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

    public bool IsSliding()
    {
        return isSliding;
    }

    public bool IsClimbing()
    {
        return isClimbing;
    }

    public bool IsGrounded()
    {
        return isGrounded;
    }

    public void SetUpLadder(bool val, float posX)
    {
        ladderPosX = posX;
        isUpLadder = val;
        if (!val && isGrounded)
        {
            animator.SetTrigger("isGrounded");
            isClimbing = false;
            rb.isKinematic = false;
        }
    }

    public void SetDownLadder(bool val, float posX)
    {
        ladderPosX = posX;
        isDownLadder = val;
        
        if(!isDownLadder)
        {
            if (!isUpLadder)
            {
                isClimbing = false;
                rb.isKinematic = false;
            }
        }
    }

    public void SetLadder(bool val, float posX)
    {
        if(!val)
        {
            animator.SetTrigger("isGrounded");
            isClimbing = false;
            isGrounded = true;
            rb.isKinematic = false;
        }
    }
}
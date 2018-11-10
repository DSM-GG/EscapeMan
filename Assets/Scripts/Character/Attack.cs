using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public int maxBullet = 10;  // 총알 최대 수 

    public GameObject bullet_prefab;

    GameObject[] bullets;       // 총알 배열
    Animator animator;
    Movement movement;
    bool currentShoot = false;
    bool isChecking = false;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        bullets = new GameObject[maxBullet];
        movement = GetComponent<Movement>();

        CreateBullet();
    }

    // Update is called once per frame
    private void Update()
    {
        Fire();
    }

    void Fire()
    {
        // Z키 입력 시 
<<<<<<< HEAD
        if (Input.GetKeyDown(KeyCode.Z))
        {
            MBullet bullet = GetFreeBullet();
            bullet.Fire(movement.direction, transform.position);
=======
        if(Input.GetKeyDown("z"))
        {
            // 슬라이딩중이면 공격을 하지 않는다.
            if (movement.IsSliding())
                return;

            Bullet bullet = GetFreeBullet();

            // 여유총알이 남아있지 않다면 아무것도 하지 않는다.
            if (bullet == null)
                return;

            bullet.Move(movement.direction, transform.position);
>>>>>>> d5a5f71dab1160ff6a01fe05bc5800358fe2ebee
            currentShoot = true;
            //Debug.Log("Fire");

            animator.SetBool("isAttacking", true);
        }
        else
        {
            currentShoot = false;
            if (animator.GetBool("isAttacking") && !isChecking)
            {
                StartCoroutine("AttackTimer");
            }
        }
    }

    // 현재 비활성화인 총알을 반환.
    MBullet GetFreeBullet()
    {
<<<<<<< HEAD
        for (int i = 0; i < MAX_BULLET; ++i)
        {
            if (bullets[i].activeSelf == false)
=======
        for(int i = 0; i < maxBullet; ++i)
        {         
            if(bullets[i].activeSelf == false)
>>>>>>> d5a5f71dab1160ff6a01fe05bc5800358fe2ebee
            {
                return bullets[i].GetComponent<MBullet>();
            }
        }
        return null;
    }

    // 초기 총알들을 생성한다. 
    void CreateBullet()
    {
<<<<<<< HEAD
        for (int i = 0; i < MAX_BULLET; ++i)
=======
        for(int i = 0; i < maxBullet; ++i)
>>>>>>> d5a5f71dab1160ff6a01fe05bc5800358fe2ebee
        {
            bullets[i] = Instantiate(bullet_prefab);
            bullets[i].SetActive(false);
        }
    }

    IEnumerator AttackTimer()
    {
        isChecking = true;
        yield return new WaitForSeconds(1.0f);

        if (!currentShoot)
        {
            animator.SetBool("isAttacking", false);
            isChecking = false;
            //yield return null;
        }

        isChecking = false;
    }
}

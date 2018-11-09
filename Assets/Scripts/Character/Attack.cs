using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    const int MAX_BULLET = 50;  // 총알 최대 수 

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
        bullets = new GameObject[MAX_BULLET];
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
        if (Input.GetKeyDown(KeyCode.Z))
        {
            MBullet bullet = GetFreeBullet();
            bullet.Fire(movement.direction, transform.position);
            currentShoot = true;
            Debug.Log("Fire");

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
        for (int i = 0; i < MAX_BULLET; ++i)
        {
            if (bullets[i].activeSelf == false)
            {
                return bullets[i].GetComponent<MBullet>();
            }
        }
        return null;
    }

    // 초기 총알들을 생성한다. 
    void CreateBullet()
    {
        for (int i = 0; i < MAX_BULLET; ++i)
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
            Debug.Log("CLOSE");
            isChecking = false;
            yield return null;
        }

        Debug.Log("CLOSE2");
        isChecking = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Cannon : MonoBehaviour {

    public GameObject bombPrefab;
    public int bombAmount;

    private float fireDelay;
    private GameObject[] bomb;
    private WaitForSeconds wfs_fireDelay;
    private Animator animator;

    // Use this for initialization
    void Awake()
    {
        wfs_fireDelay = new WaitForSeconds(fireDelay);
        animator = GetComponent<Animator>();
        CreateBullet();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CreateBullet()
    {
        bomb = new GameObject[bombAmount];
        for (int i = 0; i < bombAmount; ++i)
        {
            bomb[i] = Instantiate(bombPrefab);
            bomb[i].SetActive(false);
        }
    }

    Boss_Bomb FindBullet()
    {
        for (int i = 0; i < bombAmount; ++i)
        {
            if (bomb[i].activeSelf == false)
                return bomb[i].GetComponent<Boss_Bomb>();
        }
        return null;
    }

    public void Fire(int fireNumber, int dir)
    {
        StartCoroutine(FireStep(fireNumber, dir));
    }

    IEnumerator FireStep(int fireNumber, int dir)
    {
        for (int i = 0; i < fireNumber; ++i)
        {
            animator.SetTrigger("Fire");
            Boss_Bomb load = FindBullet();
            load.Shoot(dir, transform.position);
            yield return wfs_fireDelay;
        }
    }

    public void SetDelay(float delay)
    {
        this.fireDelay = delay;
        wfs_fireDelay = new WaitForSeconds(delay);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonsterLogic2 {
    public GameObject[] bullets;
    public GameObject bulletPrefab;
    const int bullets_number = 5;
    bool canFire;
    
    private void Awake()
    {
        MakeBullet();
    }

    void MakeBullet()
    {
        bullets = new GameObject[bullets_number]; 
        for(int i = 0; i < bullets_number; i++)
        {
            bullets[i] = Instantiate(bulletPrefab);
            bullets[i].SetActive(false);
        }
    }

    private void Update()
    {
        ShootBullet(isIncount);
    }

    private void ShootBullet(bool incount)
    {
        if (incount == false)
            return;

        Bullet bullet = GetFreeBullet();

        if(playerIsLeft == true)
        {
            bullet.Move(new Vector2(-1, 0), this.gameObject.transform.position);
        }
        else
        {
            bullet.Move(new Vector2(1, 0), this.gameObject.transform.position);
        }
    }

    Bullet GetFreeBullet()
    {
        for(int i = 0; i < bullets_number; i++)
        {
            if(bullets[i].activeSelf == false)
            {
                return bullets[i].GetComponent<Bullet>();
            }
        }
        return null;
    }
}

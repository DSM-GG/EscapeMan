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
        Fire(isIncount);
    }

    private void Fire(bool incount)
    {
        if (incount == false)
            return;

        if(playerIsLeft == true)
        {

        }
        else
        {

        }
    }
}

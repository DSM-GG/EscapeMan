using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonsterLogic2 {
    public GameObject[] bullets;
    public GameObject bulletPrefab;
    const int bullets_number = 5;
    bool canFire = true;
    
    virtual protected void Awake()
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

    virtual protected void Update()
    {
        ShootBullet(isIncount);
    }

    private void ShootBullet(bool incount)
    {

        if (incount == false)
            return;
        if (canFire == false)
            return;

        MBullet bullet = GetFreeBullet();

        if(Lincount == true)
        {
            spriteRenderer.flipX = true;
            bullet.Fire(new Vector2(-5, 0), this.gameObject.transform.position);
        }
        else if(Rincount == true)
        {
            spriteRenderer.flipX = false;
            bullet.Fire(new Vector2(5, 0), this.gameObject.transform.position);
        }
        StartCoroutine("CoolTime");
    }

    MBullet GetFreeBullet()
    {
        for(int i = 0; i < bullets_number; i++)
        {
            if(bullets[i].activeSelf == false)
            {
                return bullets[i].GetComponent<MBullet>();
            }
        }
        return null;
    }

    IEnumerator CoolTime()
    {
        canFire = false;
        yield return new WaitForSeconds(3);
        canFire = true;
    }
}

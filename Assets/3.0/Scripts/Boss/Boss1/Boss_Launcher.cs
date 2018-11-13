using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Launcher : MonoBehaviour {
   
    public GameObject missilePrefab;

    private int missileAmount;
    private GameObject[] missile;
    private float missileDelay;
    private WaitForSeconds wfs_fireDelay;

    // Use this for initialization
    void Start () {
        CreateBullet();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CreateBullet()
    {
        missile = new GameObject[missileAmount];
        for(int i = 0; i < missileAmount; ++i)
        {
            missile[i] = Instantiate(missilePrefab);
            missile[i].SetActive(false);
        }
    }

    public void SetMissileDelay(float delay)
    {
        missileDelay = delay;
        wfs_fireDelay = new WaitForSeconds(missileDelay);
    }

    public void SetMissileAmount(int amount)
    {
        missileAmount = amount;
    }

    Boss_Missile FindBullet()
    {
        for(int i = 0; i < missileAmount; ++i)
        {
            if (missile[i].activeSelf == false)
                return missile[i].GetComponent<Boss_Missile>();
        }
        return null;
    }

    public void Fire(int fireNumber, int dir)
    {
        StartCoroutine(FireDelay(fireNumber, dir));
    }

    void Shoot(Vector2 angle)
    {
        Boss_Missile load = FindBullet();
        load.Fly(transform.position, angle, (int)transform.parent.localScale.x);
    }

    IEnumerator FireDelay(int fireNumber, int dir)
    {
        for (int i = fireNumber; i > 0; --i)
        {
            Vector2 temp = new Vector2();
            float rad = ((90.0f * Mathf.Deg2Rad / fireNumber) * i);
            temp.x = Mathf.Cos(rad) * dir;
            temp.y = Mathf.Sin(rad);
            temp.Normalize();
            Shoot(temp);
            yield return wfs_fireDelay;
         }    
    }
}

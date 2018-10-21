using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBullet : MonoBehaviour {
    public static int bulletDmg = 10;
    public Rigidbody2D rig;
    public GreenRobot green;
	// Use this for initialization
	void Awake ()
    {
        rig = this.gameObject.GetComponent<Rigidbody2D>();
        green = GetComponent<GreenRobot>();
	}
    IEnumerator BulletTime()
    {
        yield return new WaitForSeconds(3);
        this.gameObject.SetActive(false);
    }

    public void Shoot(Transform Ctransform, bool Left)
    {
        this.gameObject.SetActive(true);
        this.transform.position = Ctransform.position;

        if (Left.Equals(true))
        {
            rig.AddForce(new Vector2(-3, 0), ForceMode2D.Impulse);
        }
        else
        {
            rig.AddForce(new Vector2(3, 0), ForceMode2D.Impulse);
        }
    }
    IEnumerator getBack()
    {
        yield return new WaitForSeconds(3);
        this.gameObject.SetActive(false);
    }
}

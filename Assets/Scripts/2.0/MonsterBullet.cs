using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBullet : MonoBehaviour {
    public float speed;

    Rigidbody2D rig;


    private void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    public void Fire(Vector2 dir, Vector3 pos)
    {
        transform.position = new Vector3(pos.x + dir.x * speed, pos.y + dir.y * speed);
        gameObject.SetActive(true);
        rig.AddForce(dir * speed, ForceMode2D.Impulse);
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        gameObject.SetActive(false);
    }
}

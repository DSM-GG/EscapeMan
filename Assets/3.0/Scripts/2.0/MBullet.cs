using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MBullet : MonoBehaviour
{
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Character character = other.gameObject.GetComponent<Character>();
            character.Damaged(10);
        }
            gameObject.SetActive(false);
    }
}
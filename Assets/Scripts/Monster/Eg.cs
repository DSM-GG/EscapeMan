using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eg : MonoBehaviour {
    public static int egDmg = 10;
    public GameObject smallEg;
    public bool isBroken;
	// Update is called once per frame
	void Awake () {
	}

    private void OnTriggerEnter2D(Collider2D other) // 다른 object와 접촉시 SmallEg를 스폰하고 Egg로 돌아감.
    {
        Instantiate(smallEg, transform);
        isBroken = true;
        this.transform.position = transform.parent.position;
        gameObject.SetActive(false);
    }
}

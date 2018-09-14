using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {

    public Transform target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // target의 위치에 따라 카메라의 위치를 선형 보간. 
        transform.position = Vector3.Lerp(transform.position, target.position, 2f * Time.deltaTime);
        // 보간 과정에서 z값이 변동하므로 z값을 되돌려 놓는다.
        transform.Translate(0, 0, -10);
	}
}

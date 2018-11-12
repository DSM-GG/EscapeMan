using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour {
    public GameObject smallRobot;

    private void OnDestroy()
    {
        Instantiate(this.gameObject, this.transform);
    }
}

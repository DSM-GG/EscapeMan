using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public GameObject smallRobot;

    public void Spawn()
    {
        Instantiate(smallRobot, transform.position - new Vector3(0, 0.1f, 0), Quaternion.identity);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public GameObject smallRobot;

    public void Spawn()
    {
        Debug.Log("아니;;");
        Instantiate(smallRobot, transform.position, Quaternion.identity);
    }
}
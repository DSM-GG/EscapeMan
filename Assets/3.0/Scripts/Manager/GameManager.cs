using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject player;
    public float minHeight;
    public string currentStage;

    int nowChapter = 1;
    int nowStage = 1;
    bool pannelOn = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        string currentStage = SceneManager.GetActiveScene().name;
        IsFalling();
        CheckDied();
	}

    void IsFalling()
    {
        if (player.transform.position.y < minHeight)
            GameOver(false);
    }

    void CheckDied()
    {
        if (player.GetComponent<Character>().hp <= 0)
            GameOver(false);
    }

    public void GameOver(bool isClear)
    {
        if (pannelOn) return;
        pannelOn = true;
        string clear = (isClear == true) ? "CLEAR" : "FAILED";
        string time = "TIME : " + GetComponent<Timer>().GetTime();
        string stg = currentStage;
        transform.GetComponent<OverScript>().OpenOverPannel(clear, time, stg); 
    }
}
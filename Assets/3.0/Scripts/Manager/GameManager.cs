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
        currentStage = SceneManager.GetActiveScene().name;
        Debug.Log(currentStage);
        IsFalling();
        CheckDied();
	}

    void IsFalling()
    {
        if (player != null && player.transform.position.y < minHeight)
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
        string stg = "STAGE : " + currentStage;
        transform.GetComponent<OverScript>().OpenOverPannel(clear, time, stg); 
    }

    void Set_Chapter_Stg(int chapter, int stage)
    {
        nowChapter = chapter;
        nowStage = stage;
    }

    public string Get_Chapter_Stg()
    {
        player = GameObject.Find("RockMan");
        string info = "Stage " + currentStage;
        return info;
    }
}
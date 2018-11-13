using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject player;
    public float minHeight;

    int nowChapter = 1;
    int nowStage = 1;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        IsFalling();
	}

    void IsFalling()
    {
        if (player.transform.position.y < minHeight)
            Destroy(player); // 추후 씬을 다시 로드할 것.
    }

    void CheckDied()
    {
        if (player.GetComponent<Character>().hp <= 0)
            GameOver();
    }

    void GameOver()
    {
        transform.GetComponent<OverScript>();
    }

    void Set_Chapter_Stg(int chapter, int stage)
    {
        nowChapter = chapter;
        nowStage = stage;
    }

    public string Get_Chapter_Stg()
    {
        string info = "Stage " + nowChapter.ToString() + " - " + nowStage.ToString();
        return info;
    }
}
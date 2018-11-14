using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverScript : MonoBehaviour {

    // GameOver
    // 시간
    // 현재 스테이지
    public GameObject overPannel;

    private Text time, stage, clearStatus;

	// Use this for initialization
	void Start () {
        time = overPannel.transform.Find("Time").GetComponent<Text>();
        stage = overPannel.transform.Find("NowStage").GetComponent<Text>();
        clearStatus = overPannel.transform.Find("ClearStatus").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OpenOverPannel(string clear, string overTime, string overStage)
    {
        overPannel.SetActive(true);
        clearStatus.text = clear;
        time.text = overTime;
        stage.text = overStage;
    }
}

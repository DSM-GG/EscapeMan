using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage : MonoBehaviour {
    public GameObject CurrentStage;
    public Text StageText;
    private string StageInfo;
	// Use this for initialization
	void Start () {
        StageInfo = CurrentStage.GetComponent<ExampleStage>().currentStage; // ExamplStage에 있는 현재 스테이지 string값을 가져온다.
        StageText.text = "Stage : " + StageInfo;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

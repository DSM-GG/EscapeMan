﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using UnityEngine.UI;

public class LineManager : MonoBehaviour {

    // 대사 형식
    // 숫자 이름 대사
    // 숫자 : 초상화 코드
    // 이름 : 말하는 캐릭터의 이름
    // 대사 : 대사
    public Image charImage;
    public Text Name;
    public Text Line;

    string[] lines;

	// Use this for initialization
	void Start () {
        ReadLine();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ReadLine()
    {
        lines = File.ReadAllLines(@"Assets\Lines\Line_1.txt", Encoding.Default);
        
        Line.text = lines[0];
    }
}
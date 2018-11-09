using System.Collections;
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
    int lineIndex = 0;

	// Use this for initialization
	void Start () {
        ReadLine("Line_1");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ReadLine(string stage)
    {
        lines = File.ReadAllLines(@"Assets\Lines\" + stage + ".txt", Encoding.Default);
        
        Line.text = lines[0];
    }

    void NextLine()
    {
        ++lineIndex;
        if (lineIndex >= lines.Length)
            lineIndex = 0;
    }
}

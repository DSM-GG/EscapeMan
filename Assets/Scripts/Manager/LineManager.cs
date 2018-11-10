using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using UnityEngine.UI;

public class LineManager : MonoBehaviour {

    // 대사 타이핑 속도
    const float TYPE_SPEED = 0.01f;
    WaitForSeconds wfs;

    // 숫자 : 말하는 캐릭터의 코드
    // 대사 : 대사
    public GameObject lineBox; 
    Image portrait;
    Text speakerName;
    Text line;

    string[] lines;
    int lineIndex = 0;

    // Use this for initialization
    void Start() {

        portrait = lineBox.transform.GetChild(0).GetComponent<Image>();
        speakerName = lineBox.transform.GetChild(1).GetComponent<Text>();
        line = lineBox.transform.GetChild(2).GetComponent<Text>();

        wfs = new WaitForSeconds(TYPE_SPEED);
        ReadLine(1);
        InsertLine();
    }

    // Update is called once per frame
    void Update() {
        SkipLine();
    }

    void ReadLine(int stage)
    {
        string fileName = @"Assets\Lines\Line_" + stage + ".txt";
        lines = File.ReadAllLines(fileName, Encoding.Default);
    }

    void NextLine()
    {
        // 대사를 모두 지움
        line.text = " ";
        // 다음 대사로 넘김
        ++lineIndex;
        if (lineIndex >= lines.Length)
            lineIndex = 0;
    }

    void InsertLine()
    {
        int who = (int)lines[0][0];
        speakerName.text = SpeakerList.lineInforms[who].name;
        portrait.sprite = SpeakerList.lineInforms[who].portrait;
        StartCoroutine("TypeLine");
    }

    void SkipLine()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            NextLine();
            InsertLine();
        }
    }

    // 대사를 타이핑 하는 코루틴
    IEnumerator TypeLine()
    {
        for(int i = 2; i < lines[lineIndex].Length; ++i)
        {
            line.text += lines[lineIndex][i];
            yield return wfs;
        }
    }

    public void TurnOnLineBox(int scriptNo)
    {
        lineBox.SetActive(true);
        ReadLine(scriptNo);
    }
}

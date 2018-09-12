using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Point : MonoBehaviour {
    public Text PointText;
    public int KillCount = 1;

    private void Update()
    {
        Getpoint();
    }

    void Getpoint()
    {
        PointText.text = "Score : " + KillCount * 100;  // 적에 따라 점수가 나늬는지는 모르니까 킬수 * 100점으로 일단 설정.
    }
}

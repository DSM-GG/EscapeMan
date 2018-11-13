using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character_UI : MonoBehaviour
{ 
    public Slider hp_bar;       // HP 바
    public Text stageText;
    Character character;

    // Use this for initialization
    void Awake()
    {
        character = GameObject.Find("RockMan").GetComponent<Character>();
        hp_bar.maxValue = character.hpMax;
        hp_bar.value = character.hpMax;
        stageText.text = GetComponent<GameManager>().Get_Chapter_Stg();
    }

    private void FixedUpdate()
    {
        ApplyChanges();
    }

    // UI 수치의 변화를 업데이트, 적용
    public void ApplyChanges()
    {
        hp_bar.value = character.hp;
    }

    // 현재 스테이지를 표시하는 텍스트를 그릴 것
}

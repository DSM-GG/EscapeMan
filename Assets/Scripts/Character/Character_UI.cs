using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character_UI : MonoBehaviour
{ 
    public Slider hp_bar;       // HP 바
    Character character;

    // Use this for initialization
    void Start()
    {
        character = GetComponent<Character>();
        character.hp = character.hpMax;
        hp_bar.maxValue = character.hp;
        hp_bar.value = character.hp;
        DrawLife(character.hp);
    }

    // UI 수치의 변화를 업데이트, 적용
    public void ApplyChanges()
    {
        hp_bar.value = character.hp;
        DrawLife(character.hp);
    }

    // 생명 개수를 그리는 함수
    void DrawLife(float hp)
    {

    }

    // 현재 스테이지를 표시하는 텍스트를 그릴 것
}

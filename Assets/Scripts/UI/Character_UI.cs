using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character_UI : MonoBehaviour {

    public Slider hp_bar;       // HP 바
    public Slider shield_bar;   // 쉴드 바
    public Image[] lifeArr;     // 목숨 UI
    public Sprite[] lifeSprite; // 목숨 UI 스프라이트 
                                // 0 -> 꽉찬 하트, 1 -> 빈 하트
    Character character;

	// Use this for initialization
	void Start () {
        character = GetComponent<Character>();
        hp_bar.maxValue = character.hp;
        hp_bar.value = character.hp;
        shield_bar.maxValue = character.shieldMax;
        shield_bar.value = character.shield;
        DrawLife(character.life);
    }
	
    // UI 수치의 변화를 업데이트, 적용
    public void ApplyChanges()
    {
        hp_bar.value = character.hp;
        DrawLife(character.life);
    }

    // 생명 개수를 그리는 함수
    void DrawLife(int life)
    {
        Debug.Log("Life : " + life);
        for(int i = 0; i < 3; ++i)
        {
            if (i < life)
                lifeArr[i].sprite = lifeSprite[1];
            else
                lifeArr[i].sprite = lifeSprite[0];
        }
    }

    // 현재 스테이지를 표시하는 텍스트를 그릴 것
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hp : MonoBehaviour {
    public int item; // 나중에 아이템 구현하면 그 스크립트에서 정보를 가져와서 넣어준다.
    public Slider HpBar;
    public Slider ShBar;
    private int rebirth = 3; // 부활 가능횟수 필요없으면 삭제.
    private bool Gameover = false;

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Itme")
        {
            switch(item)
            {
                case 1: // 각 아이템마다 번호를 정해주면 편할듯? ex ) 1 : 체력포션
                    HpBar.value += 0.3f;
                    break;
                case 2: // 쉴드 회복
                    ShBar.value += 0.3f;
                    break;
            }
        }

        else if(other.tag == "Enemy")
        {
            if (ShBar.value != 0)
            {
                ShBar.value -= 0.1f; // 쉴드가 있으면 쉴드가 체력보다 우선적으로 깍이도록 해놈.
            }
            else
            {
                HpBar.value -= 0.1f; // 적이 닿아있을 동안 10%씩 채력이 깍이는데 추후 캐릭터가 적에 닿고 일시 무적이 생기면 즉사하는 상황은 없어질것이라 예상.
                if (HpBar.value == 0) // 체력이 0이되면 부활 가능횟수를 -1 만큼 해주고 체력을 다시 풀로 채운다.
                {
                    HpBar.value = 1;
                    rebirth -= 1;
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if(rebirth == 0 && HpBar.value == 0) // 부활가능 횟수가 0이고 체력이 0이면 사망
        {
            isDead();
        }
    }

    private void isDead()
    {
        // gameover
    }
}

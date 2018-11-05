using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonsterLogic2
{
    bool atkCool = true;
    public GameObject LeftObser;
    public GameObject RightObser;
    
    private void Update()
    {
        PlayerCheck();
    }

    void PlayerCheck()
    {
        if (LeftObser.GetComponent<Observer>().Incount == true || RightObser.GetComponent<Observer>().Incount == true)
        {

        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
            AtkCool();
    }

    IEnumerator AtkCool()
    {
        atkCool = false; 
        yield return new WaitForSeconds(3);
        atkCool = true;
    }
}

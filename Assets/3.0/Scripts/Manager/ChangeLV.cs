using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLV : MonoBehaviour {
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            switch(SceneManager.GetActiveScene().name)
            {
                case "1-1":
                    SceneManager.LoadScene("1-2");
                    break;
                case "1-2":
                    SceneManager.LoadScene("1-3");
                    break;
                case "1-3":
                    SceneManager.LoadScene("Boss");
                    break;
            }
        }
    }
}

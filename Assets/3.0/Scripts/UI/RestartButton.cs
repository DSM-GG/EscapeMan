using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public GameObject UI;
    public void onClick()
    {
        SceneManager.LoadScene("1-1");
        UI.SetActive(false);
        Destroy(this.gameObject);
    }

}

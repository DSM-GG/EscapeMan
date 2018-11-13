using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExampleStage : MonoBehaviour {

    public string currentStage = "1 - 1"; // 스테이지 값을 나타냄

    private void Update()
    {
        currentStage = SceneManager.GetActiveScene().name;
    }
}

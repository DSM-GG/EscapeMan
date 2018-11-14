using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManage : MonoBehaviour {

    AudioSource audioSource;

	// Use this for initialization
	void Awake () {
        audioSource = GetComponent<AudioSource>();
        PlayBGM();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void PlayBGM()
    {
        string stage = "BGM/" + SceneManager.GetActiveScene().name;
        AudioClip audioClip = Resources.Load<AudioClip>(stage);
        audioSource.clip = audioClip;
        audioSource.Play();
    }

}

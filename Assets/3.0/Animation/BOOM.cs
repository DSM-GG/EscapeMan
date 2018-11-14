using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOOM : MonoBehaviour {

    AudioSource audioSource;

    // Use this for initialization
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Boom()
    {
        audioSource.Play();
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    float m = 0, s = 0, ms = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ms += Time.deltaTime;
        if (ms >= 1)
        {
            ms = 0;
            ++s;
            if (s >= 60)
            {
                s = 0;
                ++m;
            }
        }
    }

    public string GetTime()
    {
        string time = m.ToString() + " : " + s.ToString() + " : " + ms.ToString(".00");
        return time; 
    }

}

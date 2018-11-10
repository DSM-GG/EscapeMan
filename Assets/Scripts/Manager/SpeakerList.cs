using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakerList : MonoBehaviour {

    public struct LineInform
    {
        public string name;     // 이름
        public Sprite portrait; // 초상화

        public LineInform(string name, string portraitPath)
        {
            this.name = name;
            portrait = Resources.Load<Sprite>(portraitPath);
            if (portrait == null)
                Debug.Log("Resource Load Failed");
        }
    }

    const int SPEAKER = 3;  // 전체 발화자(말하는 이)

    public static LineInform[] lineInforms =
    {
        new LineInform("RockMan", "Portrait/UMP45"),
    };
}

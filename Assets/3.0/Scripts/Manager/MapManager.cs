using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour {

    Tilemap tmap;
    BoundsInt bounds;
    TileBase[] allTiles;
    Dictionary<Vector3, Tilemap> worldTile;

	// Use this for initialization
	void Start () {
        
        // 타일맵에 있는 모든 타일들을 불러온다.
        tmap = GetComponent<Tilemap>();
        bounds = tmap.cellBounds;
        allTiles = tmap.GetTilesBlock(bounds);

        //foreach (Vector3Int pos in tmap.cellBounds.allPositionsWithin)
        //{
        //    Debug.Log(pos);
        //}

        // 사다리 타일을 자동으로 배치하기 위해 탐색을 한다.
        //int cnt = 0;
        //for (int i = 0; i < allTiles.Length; ++i)
        //{
        //    if (allTiles[i] != null)
        //        if (allTiles[i].name == "1_5")
        //            ++cnt;
        //}
        //Debug.Log(cnt);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}